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
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents btnBind As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
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
  Friend WithEvents btnLast As System.Windows.Forms.Button
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents btnDelete As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.txtFirstName = New System.Windows.Forms.TextBox
Me.txtLastName = New System.Windows.Forms.TextBox
Me.btnBind = New System.Windows.Forms.Button
Me.btnFirst = New System.Windows.Forms.Button
Me.btnPrevious = New System.Windows.Forms.Button
Me.btnNext = New System.Windows.Forms.Button
Me.btnLast = New System.Windows.Forms.Button
Me.btnAdd = New System.Windows.Forms.Button
Me.btnDelete = New System.Windows.Forms.Button
Me.btnCancel = New System.Windows.Forms.Button
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(4, 8)
Me.Label1.Size = New System.Drawing.Size(72, 20)
Me.Label1.Text = "First Name:"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(4, 39)
Me.Label2.Size = New System.Drawing.Size(68, 20)
Me.Label2.Text = "Last Name:"
'
'txtFirstName
'
Me.txtFirstName.Location = New System.Drawing.Point(75, 6)
Me.txtFirstName.Size = New System.Drawing.Size(157, 22)
Me.txtFirstName.Text = ""
'
'txtLastName
'
Me.txtLastName.Location = New System.Drawing.Point(76, 36)
Me.txtLastName.Size = New System.Drawing.Size(156, 22)
Me.txtLastName.Text = ""
'
'btnBind
'
Me.btnBind.Location = New System.Drawing.Point(6, 68)
Me.btnBind.Size = New System.Drawing.Size(60, 24)
Me.btnBind.Text = "Bind"
'
'btnFirst
'
Me.btnFirst.Enabled = False
Me.btnFirst.Location = New System.Drawing.Point(76, 68)
Me.btnFirst.Size = New System.Drawing.Size(36, 24)
Me.btnFirst.Text = "<<"
'
'btnPrevious
'
Me.btnPrevious.Enabled = False
Me.btnPrevious.Location = New System.Drawing.Point(116, 68)
Me.btnPrevious.Size = New System.Drawing.Size(36, 24)
Me.btnPrevious.Text = "<"
'
'btnNext
'
Me.btnNext.Enabled = False
Me.btnNext.Location = New System.Drawing.Point(156, 68)
Me.btnNext.Size = New System.Drawing.Size(36, 24)
Me.btnNext.Text = ">"
'
'btnLast
'
Me.btnLast.Enabled = False
Me.btnLast.Location = New System.Drawing.Point(196, 68)
Me.btnLast.Size = New System.Drawing.Size(36, 24)
Me.btnLast.Text = ">>"
'
'btnAdd
'
Me.btnAdd.Enabled = False
Me.btnAdd.Location = New System.Drawing.Point(6, 103)
Me.btnAdd.Size = New System.Drawing.Size(60, 21)
Me.btnAdd.Text = "Add"
'
'btnDelete
'
Me.btnDelete.Enabled = False
Me.btnDelete.Location = New System.Drawing.Point(6, 128)
Me.btnDelete.Size = New System.Drawing.Size(60, 21)
Me.btnDelete.Text = "Delete"
'
'btnCancel
'
Me.btnCancel.Enabled = False
Me.btnCancel.Location = New System.Drawing.Point(6, 154)
Me.btnCancel.Size = New System.Drawing.Size(60, 21)
Me.btnCancel.Text = "Cancel"
'
'Form1
'
Me.Controls.Add(Me.btnCancel)
Me.Controls.Add(Me.btnDelete)
Me.Controls.Add(Me.btnAdd)
Me.Controls.Add(Me.btnLast)
Me.Controls.Add(Me.btnNext)
Me.Controls.Add(Me.btnPrevious)
Me.Controls.Add(Me.btnFirst)
Me.Controls.Add(Me.btnBind)
Me.Controls.Add(Me.txtLastName)
Me.Controls.Add(Me.txtFirstName)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Binding Tutorial"

    End Sub

#End Region

End Class
