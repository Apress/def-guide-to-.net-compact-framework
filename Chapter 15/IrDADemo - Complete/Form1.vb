'
' The Definitive Guide to the .NET Compact Framework
'   Apress : ISBN 1-59059-095-3 : 2003
'
' Authors:
'   Larry Roof
'     email: larry.roof@larryroof.com
'     web site: www.larryroof.com
'   Dan Fergus 
'     email: danf@forestsoftwaregroup.com
'     web site: www.forestsoftwaregroup.com
'
' You can obtain updates to the samples included with
' this title at the following sites:
'   www.larryroof.com
'   www.forestsoftwaregroup.com
'   www.apress.com
'
'
' Copyright (c) 2003 by Larry Roof and Dan Fergus
'   
' The information and code provided hereunder (collectively referred to
' as "Software") is provided as is without warranty of any kind, either
' express or implied, including but not limited to the implied 
' warranties of merchantability and fitness for a particular purpose.
' In no event shall either Larry Roof and/or Dan Fergus be liable for any
' damages whatsoever including direct, indirect, incidental, consequential,
' loss of business profits or special damages, even if Larry Roof and/or Dan
' Fergus have been advised of the possibility of such damages. Some states
' do not allow the exclusion or limitation of liability for consequential
' or incidental damages so the foregoing limitation may not apply.
'
' This software, and the examples and techniques demonstrated within this
' software, may be incorporated into your software products subject to the
' following conditions:
'
' 1. This software cannot be distributed in its original form to any other
'    individuals for any purpose.
'
' 2. License to use this software is only provided to those individuals that
'    purchase a copy of the book "The Definitive Guide to the .NET Compact
'    Framework", published by Apress Publishing.
'
' 3. You agree to indemnify, hold harmless, and defend Larry Roof and Dan
'    Fergus from and against any claims or lawsuits, including attorneys 
'    fees, that arise or result from the use or distribution of your software 
'    product and any modifications to the Software.

Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnListen As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Private BufferLength As Integer = 2
    Private NumberOfRetries As Integer = 5
    Private ServiceName As String = "IRDA_DEMO"

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents lstColor As System.Windows.Forms.ListBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnListen = New System.Windows.Forms.Button
Me.btnSend = New System.Windows.Forms.Button
Me.Label1 = New System.Windows.Forms.Label
Me.lstColor = New System.Windows.Forms.ListBox
'
'btnListen
'
Me.btnListen.Location = New System.Drawing.Point(4, 132)
Me.btnListen.Text = "Listen"
'
'btnSend
'
Me.btnSend.Location = New System.Drawing.Point(164, 132)
Me.btnSend.Text = "Send"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(4, 7)
Me.Label1.Size = New System.Drawing.Size(100, 16)
Me.Label1.Text = "Select Color:"
'
'lstColor
'
Me.lstColor.Items.Add("Red")
Me.lstColor.Items.Add("Blue")
Me.lstColor.Items.Add("Green")
Me.lstColor.Items.Add("Yellow")
Me.lstColor.Items.Add("Black")
Me.lstColor.Items.Add("White")
Me.lstColor.Location = New System.Drawing.Point(4, 22)
Me.lstColor.Size = New System.Drawing.Size(232, 100)
'
'Form1
'
Me.Controls.Add(Me.lstColor)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.btnSend)
Me.Controls.Add(Me.btnListen)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "IrDA Demo"

    End Sub

#End Region

  Private Sub btnListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListen.Click
    Dim BytesRead As Integer = 0
    Dim Buffer(BufferLength) As Byte
    Dim listener As IrDAListener = New IrDAListener(ServiceName)
    Dim client As IrDAClient = Nothing
    Dim stream As System.IO.Stream = Nothing

    Try

  ' Wait for client connection.
      listener.Start()

  ' Accept client connection.
      client = listener.AcceptIrDAClient()  ' blocking call
      stream = client.GetStream()

  ' Read and process the data that the client sent.
      BytesRead = stream.Read(Buffer, 0, BufferLength)
      Select Case Buffer(1)
        Case 0
          Me.BackColor = System.Drawing.Color.Red
        Case 1
          Me.BackColor = System.Drawing.Color.Blue
        Case 2
          Me.BackColor = System.Drawing.Color.Green
        Case 3
          Me.BackColor = System.Drawing.Color.Yellow
        Case 4
          Me.BackColor = System.Drawing.Color.Black
        Case 5
          Me.BackColor = System.Drawing.Color.White
      End Select

  ' Handle any exceptions that might occur.
    Catch ex As Exception
      MsgBox(ex.Message)

    Finally

  ' Clean-up before exiting.
      If (Not stream Is Nothing) Then
        stream.Close()
      End If

      If (Not client Is Nothing) Then
        client.Close()
      End If

      listener.Stop()
    End Try

  End Sub

  Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
    Dim Buffer(BufferLength) As Byte
    Dim client As IrDAClient = Nothing
    Dim CurrentTries As Integer = 0
    Dim stream As System.IO.Stream = Nothing

  ' Send the selected color.
    Buffer(1) = lstColor.SelectedIndex

  ' Loop while trying to send the data.
    Do
      Try
        client = New IrDAClient(ServiceName)
      Catch se As SocketException
        MsgBox(se.Message)
        Exit Sub
      Catch ex As Exception
        MsgBox(ex.Message)
        Exit Sub
      End Try
      CurrentTries = CurrentTries + 1

    Loop While client Is Nothing And CurrentTries < NumberOfRetries

  ' A timeout occurred while attempting to connect to server.
    If (client Is Nothing) Then
      MsgBox("Timeout trying to send.")
      Exit Sub
    End If

  ' We have a connection, so send the data.
    Try
      stream = client.GetStream()
      stream.Write(Buffer, 0, BufferLength)
      MsgBox("Data sent.")
    Catch ex As Exception
      MsgBox(ex.Message)
    Finally
      If (Not stream Is Nothing) Then
        stream.Close()
      End If
      client.Close()
    End Try

  End Sub
End Class
