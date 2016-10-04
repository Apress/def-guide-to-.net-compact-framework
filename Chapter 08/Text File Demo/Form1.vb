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
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
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
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnLoad = New System.Windows.Forms.Button
Me.btnSave = New System.Windows.Forms.Button
Me.txtContent = New System.Windows.Forms.TextBox
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
'txtContent
'
Me.txtContent.Location = New System.Drawing.Point(8, 8)
Me.txtContent.Multiline = True
Me.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtContent.Size = New System.Drawing.Size(224, 224)
Me.txtContent.Text = ""
'
'Form1
'
Me.Controls.Add(Me.txtContent)
Me.Controls.Add(Me.btnSave)
Me.Controls.Add(Me.btnLoad)
Me.Menu = Me.MainMenu1
Me.Text = "Text File Demo"

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

#End Region

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    Dim sr As System.IO.StreamReader

' Check to see if the file exists. If it does open and read the file.
    If (System.IO.File.Exists(AppPath() & "\demo.txt")) Then
      sr = System.IO.File.OpenText(AppPath() & "\demo.txt")
      txtContent.Text = sr.ReadToEnd
      sr.Close()

' The file doesn't exist so tell the user what to do.
    Else
      MsgBox("Demo file does not exist." & _
        " Tap the Save button to create the file", _
        MsgBoxStyle.Information, _
        "File not found")
    End If

  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim sw As System.IO.StreamWriter

' Whack the file if it already exists.
    If (System.IO.File.Exists(AppPath() & "\demo.txt")) Then
      MsgBox("Deleting existing version of the demo file.")
      System.IO.File.Delete(AppPath() & "\demo.txt")
    End If

' Open, and create, the file.
    sw = New System.IO.StreamWriter(AppPath() & "\demo.txt")

' Write some text to the file.
    sw.Write("This demo file was created at ")
    sw.WriteLine(DateTime.Now)

' Close the file.
    sw.Close()

  End Sub

  Private Function AppPath() As String

' Return the path to this application.
    AppPath = _
      System.IO.Path.GetDirectoryName(Reflection.Assembly. _
      GetExecutingAssembly().GetName().CodeBase.ToString())

  End Function
End Class
