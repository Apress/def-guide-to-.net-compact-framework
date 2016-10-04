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
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
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
  Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(8, 8)
Me.TextBox1.Size = New System.Drawing.Size(44, 22)
Me.TextBox1.Text = ""
'
'TextBox2
'
Me.TextBox2.Location = New System.Drawing.Point(8, 38)
Me.TextBox2.Multiline = True
Me.TextBox2.Size = New System.Drawing.Size(224, 138)
Me.TextBox2.Text = ""
'
'HScrollBar1
'
Me.HScrollBar1.Location = New System.Drawing.Point(60, 8)
Me.HScrollBar1.Maximum = 91
Me.HScrollBar1.Size = New System.Drawing.Size(172, 22)
'
'Form1
'
Me.Controls.Add(Me.HScrollBar1)
Me.Controls.Add(Me.TextBox2)
Me.Controls.Add(Me.TextBox1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "InputPanel Demo"

    End Sub

#End Region

  Private Sub HScrollBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
    TextBox1.Text = HScrollBar1.Value.ToString
  End Sub


  Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
    InputPanel1.Enabled = True
  End Sub

  Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
    InputPanel1.Enabled = False
  End Sub
End Class
