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

Imports System.Net.Sockets

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

' Example scan record structure.
    Structure ScanRecord
      Dim Barcode As String
      Dim TimeStamp As DateTime
      Dim Qty As Integer
    End Structure

' Queue of scans on the device.
    Dim Scans As New Collection

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtIP As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.txtDisplay = New System.Windows.Forms.TextBox
Me.btnSend = New System.Windows.Forms.Button
Me.btnCreate = New System.Windows.Forms.Button
Me.Label1 = New System.Windows.Forms.Label
Me.txtIP = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.txtPort = New System.Windows.Forms.TextBox
'
'txtDisplay
'
Me.txtDisplay.Location = New System.Drawing.Point(4, 56)
Me.txtDisplay.Multiline = True
Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDisplay.Size = New System.Drawing.Size(231, 180)
Me.txtDisplay.Text = "[status display]"
'
'btnSend
'
Me.btnSend.Enabled = False
Me.btnSend.Location = New System.Drawing.Point(125, 242)
Me.btnSend.Size = New System.Drawing.Size(111, 20)
Me.btnSend.Text = "Send Data"
'
'btnCreate
'
Me.btnCreate.Location = New System.Drawing.Point(4, 242)
Me.btnCreate.Size = New System.Drawing.Size(111, 20)
Me.btnCreate.Text = "Create Data"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 7)
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.Text = "IP:"
'
'txtIP
'
Me.txtIP.Location = New System.Drawing.Point(38, 4)
Me.txtIP.Size = New System.Drawing.Size(126, 22)
Me.txtIP.Text = "192.168.1.180"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 31)
Me.Label2.Size = New System.Drawing.Size(36, 16)
Me.Label2.Text = "Port:"
'
'txtPort
'
Me.txtPort.Location = New System.Drawing.Point(38, 28)
Me.txtPort.Size = New System.Drawing.Size(62, 22)
Me.txtPort.Text = "1234"
'
'Form1
'
Me.Controls.Add(Me.txtPort)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtIP)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.txtDisplay)
Me.Controls.Add(Me.btnSend)
Me.Controls.Add(Me.btnCreate)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "TCP Demo"

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
    Dim Scan As ScanRecord

    Cursor.Current = Cursors.WaitCursor

  ' Create the data.
  ' First record.
    Scan.Barcode = "11111"
    Scan.TimeStamp = Now
    Scan.Qty = 11
    Scans.Add(Scan)
    txtDisplay.Text += vbCrLf & "scanned item 11111"

  ' Pause for effect.
    System.Threading.Thread.CurrentThread().Sleep(500)

  ' Second record.
    Scan.Barcode = "22222"
    Scan.TimeStamp = Now
    Scan.Qty = 22
    Scans.Add(Scan)
    txtDisplay.Text += vbCrLf & "scanned item 22222"

  ' Pause for effect.
    System.Threading.Thread.CurrentThread().Sleep(500)

  ' Third record.
    Scan.Barcode = "33333"
    Scan.TimeStamp = Now
    Scan.Qty = 33
    Scans.Add(Scan)
    txtDisplay.Text += vbCrLf & "scanned item 33333"

  ' Toggle the buttons.
    btnCreate.Enabled = False
    btnSend.Enabled = True

    Cursor.Current = Cursors.Default

  End Sub

  Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
    Dim Counter As Integer
    Dim InboundPacket As String
    Dim OutboundPacket As String
    Dim Scan As ScanRecord

  ' Loop through the data sending it to the server.
    For Each Scan In Scans
      OutboundPacket = "DAT|"
      OutboundPacket += Scan.Barcode & "|"
      OutboundPacket += Scan.TimeStamp & "|"
      OutboundPacket += Scan.Qty & "|"

  ' Send the message.
      InboundPacket = SendMessage(OutboundPacket)

  ' Display the return message.
      txtDisplay.Text += vbCrLf & InboundPacket

    Next

  ' Clear out the collection after the data has been sent.
    For Counter = Scans.Count - 1 To 0 Step -1
      Scans.Remove(1)
    Next

  ' Toggle the buttons.
    btnSend.Enabled = False
    btnCreate.Enabled = True

  End Sub

#End Region

#Region " General Procedures "

  Function SendMessage(ByVal myMessage As String) As String
    Dim Client As TcpClient
    Dim InBuffer(1000) As Byte
    Dim OutBuffer() As Byte
    Dim ReturnMessage As String

  ' Connect to the server.
    Client = New TcpClient
    Try
      Client.Connect(txtIP.Text, txtPort.Text)
    Catch ex As Exception
      MsgBox("Connection failed: " & ex.Message)
      Return "[no signal]"
    End Try

  ' Build the message.
    OutBuffer = System.Text.Encoding.Default.GetBytes(myMessage.ToCharArray)

  ' Send the message.
    Client.GetStream().Write(OutBuffer, 0, OutBuffer.Length)

  ' Wait for a response.
    While Not Client.GetStream.DataAvailable()
      Application.DoEvents()
    End While

  ' Read the server's response.
    ReturnMessage = ""
    While Client.GetStream.DataAvailable()
      Client.GetStream().Read(InBuffer, 0, InBuffer.Length)
      ReturnMessage &= System.Text.Encoding.Default.GetString(InBuffer, 0, InBuffer.Length)
    End While

  ' Close the connection.
    Client.Close()

  ' Send back the response.
    Return ReturnMessage

  End Function

#End Region

End Class

