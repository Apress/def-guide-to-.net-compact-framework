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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TabPage1 = New System.Windows.Forms.TabPage
Me.TabPage2 = New System.Windows.Forms.TabPage
Me.TabPage3 = New System.Windows.Forms.TabPage
Me.TabPage4 = New System.Windows.Forms.TabPage
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
'
'TabControl1
'
Me.TabControl1.Controls.Add(Me.TabPage1)
Me.TabControl1.Controls.Add(Me.TabPage2)
Me.TabControl1.Controls.Add(Me.TabPage3)
Me.TabControl1.Controls.Add(Me.TabPage4)
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(240, 272)
'
'TabPage1
'
Me.TabPage1.Controls.Add(Me.Label1)
Me.TabPage1.Location = New System.Drawing.Point(4, 4)
Me.TabPage1.Size = New System.Drawing.Size(232, 246)
Me.TabPage1.Text = "General"
'
'TabPage2
'
Me.TabPage2.Controls.Add(Me.Label2)
Me.TabPage2.Location = New System.Drawing.Point(4, 4)
Me.TabPage2.Size = New System.Drawing.Size(232, 246)
Me.TabPage2.Text = "Phone"
'
'TabPage3
'
Me.TabPage3.Controls.Add(Me.Label3)
Me.TabPage3.Location = New System.Drawing.Point(4, 4)
Me.TabPage3.Size = New System.Drawing.Size(232, 246)
Me.TabPage3.Text = "History"
'
'TabPage4
'
Me.TabPage4.Controls.Add(Me.Label4)
Me.TabPage4.Location = New System.Drawing.Point(4, 4)
Me.TabPage4.Size = New System.Drawing.Size(232, 246)
Me.TabPage4.Text = "Comments"
'
'Label1
'
Me.Label1.Size = New System.Drawing.Size(128, 20)
Me.Label1.Text = "The General Tab"
'
'Label2
'
Me.Label2.Size = New System.Drawing.Size(120, 20)
Me.Label2.Text = "The Phone Tab"
'
'Label3
'
Me.Label3.Size = New System.Drawing.Size(116, 20)
Me.Label3.Text = "The History Tab"
'
'Label4
'
Me.Label4.Size = New System.Drawing.Size(132, 20)
Me.Label4.Text = "The Comments Tab"
'
'Form1
'
Me.Controls.Add(Me.TabControl1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "TabControl Demo"

    End Sub

#End Region

End Class
