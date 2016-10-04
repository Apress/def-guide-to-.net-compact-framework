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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnOpen As System.Windows.Forms.Button
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
  Friend WithEvents txtFilter As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
Me.btnOpen = New System.Windows.Forms.Button
Me.txtFilter = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
'
'btnOpen
'
Me.btnOpen.Location = New System.Drawing.Point(8, 244)
Me.btnOpen.Text = "Open"
'
'txtFilter
'
Me.txtFilter.Location = New System.Drawing.Point(68, 8)
Me.txtFilter.Size = New System.Drawing.Size(164, 22)
Me.txtFilter.Text = """Text files (*.txt)|*.txt|All files (*.*)|*.*"""
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(4, 12)
Me.Label1.Size = New System.Drawing.Size(64, 20)
Me.Label1.Text = "Filter:"
'
'Form1
'
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.txtFilter)
Me.Controls.Add(Me.btnOpen)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "OpenFileDialog Demo"

    End Sub

#End Region

  Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
    Dim diaResult As DialogResult
    Dim mb As MessageBox

' Configure the dialog.
    OpenFileDialog1.Filter = txtFilter.Text

' Display the dialog.
    diaResult = OpenFileDialog1.ShowDialog()

' Respond to the dialog.
    If (diaResult = DialogResult.OK) Then
      mb.Show(OpenFileDialog1.FileName)
    End If

  End Sub
End Class
