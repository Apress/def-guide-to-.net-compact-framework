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
    Friend WithEvents btnCreate As System.Windows.Forms.Button
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
  Friend WithEvents btnLocked As System.Windows.Forms.Button
  Friend WithEvents lblStatus As System.Windows.Forms.Label
  Friend WithEvents lblKeyDown As System.Windows.Forms.Label
  Friend WithEvents lblKeyPress As System.Windows.Forms.Label
  Friend WithEvents lblKeyUp As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
  Friend WithEvents btnAutoSip As System.Windows.Forms.Button
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnCreate = New System.Windows.Forms.Button
Me.btnLocked = New System.Windows.Forms.Button
Me.lblStatus = New System.Windows.Forms.Label
Me.lblKeyDown = New System.Windows.Forms.Label
Me.lblKeyPress = New System.Windows.Forms.Label
Me.lblKeyUp = New System.Windows.Forms.Label
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
Me.btnAutoSip = New System.Windows.Forms.Button
'
'btnCreate
'
Me.btnCreate.Location = New System.Drawing.Point(128, 8)
Me.btnCreate.Size = New System.Drawing.Size(108, 24)
Me.btnCreate.Text = "Create"
'
'btnLocked
'
Me.btnLocked.Location = New System.Drawing.Point(128, 36)
Me.btnLocked.Size = New System.Drawing.Size(108, 24)
Me.btnLocked.Text = "Toggle Locked"
'
'lblStatus
'
Me.lblStatus.Location = New System.Drawing.Point(9, 40)
Me.lblStatus.Size = New System.Drawing.Size(115, 20)
Me.lblStatus.Text = "locked - false"
'
'lblKeyDown
'
Me.lblKeyDown.Location = New System.Drawing.Point(9, 64)
Me.lblKeyDown.Size = New System.Drawing.Size(115, 20)
Me.lblKeyDown.Text = "KeyDown - 0"
'
'lblKeyPress
'
Me.lblKeyPress.Location = New System.Drawing.Point(9, 88)
Me.lblKeyPress.Size = New System.Drawing.Size(115, 20)
Me.lblKeyPress.Text = "KeyPress - 0"
'
'lblKeyUp
'
Me.lblKeyUp.Location = New System.Drawing.Point(9, 112)
Me.lblKeyUp.Size = New System.Drawing.Size(115, 20)
Me.lblKeyUp.Text = "KeyUp - 0"
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(11, 145)
Me.TextBox1.Text = "regular TextBox"
'
'btnAutoSip
'
Me.btnAutoSip.Location = New System.Drawing.Point(128, 64)
Me.btnAutoSip.Size = New System.Drawing.Size(108, 24)
Me.btnAutoSip.Text = "Add Auto-SIP"
'
'Form1
'
Me.Controls.Add(Me.btnAutoSip)
Me.Controls.Add(Me.TextBox1)
Me.Controls.Add(Me.lblKeyUp)
Me.Controls.Add(Me.lblKeyPress)
Me.Controls.Add(Me.lblKeyDown)
Me.Controls.Add(Me.lblStatus)
Me.Controls.Add(Me.btnLocked)
Me.Controls.Add(Me.btnCreate)
Me.Menu = Me.MainMenu1
Me.Text = "TextBoxPlus Demo"

    End Sub

#End Region

End Class

