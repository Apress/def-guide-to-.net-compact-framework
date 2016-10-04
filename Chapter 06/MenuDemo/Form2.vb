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

Public Class Form2
    Inherits System.Windows.Forms.Form
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEditCut As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEditCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEditPaste As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.mnuNew = New System.Windows.Forms.MenuItem
Me.mnuEdit = New System.Windows.Forms.MenuItem
Me.mnuEditCut = New System.Windows.Forms.MenuItem
Me.mnuEditCopy = New System.Windows.Forms.MenuItem
Me.mnuEditPaste = New System.Windows.Forms.MenuItem
'
'MainMenu1
'
Me.MainMenu1.MenuItems.Add(Me.mnuNew)
Me.MainMenu1.MenuItems.Add(Me.mnuEdit)
'
'mnuNew
'
Me.mnuNew.Text = "New"
'
'mnuEdit
'
Me.mnuEdit.MenuItems.Add(Me.mnuEditCut)
Me.mnuEdit.MenuItems.Add(Me.mnuEditCopy)
Me.mnuEdit.MenuItems.Add(Me.mnuEditPaste)
Me.mnuEdit.Text = "Edit"
'
'mnuEditCut
'
Me.mnuEditCut.Text = "Cut"
'
'mnuEditCopy
'
Me.mnuEditCopy.Text = "Copy"
'
'mnuEditPaste
'
Me.mnuEditPaste.Text = "Paste"
'
'Form2
'
Me.Menu = Me.MainMenu1
Me.Text = "Form1"

    End Sub

#End Region

  Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class
