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

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

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
  Friend WithEvents txtBoolean As System.Windows.Forms.TextBox
  Friend WithEvents txtInteger As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.txtBoolean = New System.Windows.Forms.TextBox
Me.txtInteger = New System.Windows.Forms.TextBox
Me.btnLoad = New System.Windows.Forms.Button
Me.btnSave = New System.Windows.Forms.Button
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 16)
Me.Label1.Size = New System.Drawing.Size(88, 16)
Me.Label1.Text = "Boolean value:"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 48)
Me.Label2.Size = New System.Drawing.Size(88, 16)
Me.Label2.Text = "Integer value:"
'
'txtBoolean
'
Me.txtBoolean.Location = New System.Drawing.Point(96, 16)
Me.txtBoolean.Size = New System.Drawing.Size(80, 22)
Me.txtBoolean.Text = "True"
'
'txtInteger
'
Me.txtInteger.Location = New System.Drawing.Point(96, 48)
Me.txtInteger.Size = New System.Drawing.Size(80, 22)
Me.txtInteger.Text = "0"
'
'btnLoad
'
Me.btnLoad.Location = New System.Drawing.Point(88, 240)
Me.btnLoad.Size = New System.Drawing.Size(64, 24)
Me.btnLoad.Text = "Load"
'
'btnSave
'
Me.btnSave.Location = New System.Drawing.Point(168, 240)
Me.btnSave.Size = New System.Drawing.Size(64, 24)
Me.btnSave.Text = "Save"
'
'Form1
'
Me.Controls.Add(Me.btnSave)
Me.Controls.Add(Me.btnLoad)
Me.Controls.Add(Me.txtInteger)
Me.Controls.Add(Me.txtBoolean)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Menu = Me.MainMenu1
Me.Text = "Binary File Demo"

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

#End Region

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    Dim br As System.IO.BinaryReader
    Dim fs As System.IO.FileStream

' Open the file.
    fs = New _
      System.IO.FileStream(AppPath() & "\demo.dat", _
      IO.FileMode.Open)
    br = New System.IO.BinaryReader(fs)

' Read two values from the file.
    txtBoolean.Text = br.ReadBoolean.ToString
    txtInteger.Text = br.ReadInt16.ToString

' Close the file.
    br.Close()

  End Sub

  Private Function AppPath() As String

' Return the path to this application.
    AppPath = _
      System.IO.Path.GetDirectoryName(Reflection.Assembly. _
      GetExecutingAssembly().GetName().CodeBase.ToString())

  End Function

  Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim bw As System.IO.BinaryWriter
    Dim fs As System.IO.FileStream

' Open the file.
    fs = New _
      System.IO.FileStream(AppPath() & "\demo.dat", _
      IO.FileMode.OpenOrCreate)
    bw = New System.IO.BinaryWriter(fs)

' Write the two values to the file.
    bw.Write(CBool(txtBoolean.Text))
    bw.Write(CInt(txtInteger.Text))

' Reset the TextBox controls.
    txtInteger.Text = "True"
    txtString.Text = "0"

' Close the file.
    bw.Close()

  End Sub
End Class
