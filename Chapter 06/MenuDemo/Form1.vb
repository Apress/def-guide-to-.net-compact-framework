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
    Friend WithEvents mnuFileFile1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileFile2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileFile3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileFile4 As System.Windows.Forms.MenuItem

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
  Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
  Friend WithEvents txtContent As System.Windows.Forms.TextBox
  Friend WithEvents mnuContext As System.Windows.Forms.ContextMenu
  Friend WithEvents imgToolbar As System.Windows.Forms.ImageList
  Friend WithEvents tlbMain As System.Windows.Forms.ToolBar
  Friend WithEvents tbbPrint As System.Windows.Forms.ToolBarButton
  Friend WithEvents tbbTask As System.Windows.Forms.ToolBarButton
  Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
  Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEditCut As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEditCopy As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEditPaste As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEditClear As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEditSelectAll As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEditBar1 As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEditFind As System.Windows.Forms.MenuItem
  Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
  Friend WithEvents mnuToolsBeam As System.Windows.Forms.MenuItem
  Friend WithEvents mnuToolsSaveAs As System.Windows.Forms.MenuItem
  Friend WithEvents mnuToolsDelete As System.Windows.Forms.MenuItem
    Private Sub InitializeComponent()
Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
Me.mnuMain = New System.Windows.Forms.MainMenu
Me.mnuNew = New System.Windows.Forms.MenuItem
Me.mnuEdit = New System.Windows.Forms.MenuItem
Me.mnuEditCut = New System.Windows.Forms.MenuItem
Me.mnuEditCopy = New System.Windows.Forms.MenuItem
Me.mnuEditPaste = New System.Windows.Forms.MenuItem
Me.mnuEditClear = New System.Windows.Forms.MenuItem
Me.mnuEditSelectAll = New System.Windows.Forms.MenuItem
Me.mnuEditBar1 = New System.Windows.Forms.MenuItem
Me.mnuEditFind = New System.Windows.Forms.MenuItem
Me.mnuTools = New System.Windows.Forms.MenuItem
Me.mnuToolsBeam = New System.Windows.Forms.MenuItem
Me.MenuItem5 = New System.Windows.Forms.MenuItem
Me.mnuToolsSaveAs = New System.Windows.Forms.MenuItem
Me.mnuToolsDelete = New System.Windows.Forms.MenuItem
Me.txtContent = New System.Windows.Forms.TextBox
Me.mnuContext = New System.Windows.Forms.ContextMenu
Me.imgToolbar = New System.Windows.Forms.ImageList
Me.tlbMain = New System.Windows.Forms.ToolBar
Me.tbbPrint = New System.Windows.Forms.ToolBarButton
Me.tbbTask = New System.Windows.Forms.ToolBarButton
'
'mnuMain
'
Me.mnuMain.MenuItems.Add(Me.mnuNew)
Me.mnuMain.MenuItems.Add(Me.mnuEdit)
Me.mnuMain.MenuItems.Add(Me.mnuTools)
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
Me.mnuEdit.MenuItems.Add(Me.mnuEditClear)
Me.mnuEdit.MenuItems.Add(Me.mnuEditSelectAll)
Me.mnuEdit.MenuItems.Add(Me.mnuEditBar1)
Me.mnuEdit.MenuItems.Add(Me.mnuEditFind)
Me.mnuEdit.Text = "Edit"
'
'mnuEditCut
'
Me.mnuEditCut.Enabled = False
Me.mnuEditCut.Text = "Cut"
'
'mnuEditCopy
'
Me.mnuEditCopy.Enabled = False
Me.mnuEditCopy.Text = "Copy"
'
'mnuEditPaste
'
Me.mnuEditPaste.Enabled = False
Me.mnuEditPaste.Text = "Paste"
'
'mnuEditClear
'
Me.mnuEditClear.Text = "Clear"
'
'mnuEditSelectAll
'
Me.mnuEditSelectAll.Text = "Select All"
'
'mnuEditBar1
'
Me.mnuEditBar1.Text = "-"
'
'mnuEditFind
'
Me.mnuEditFind.Text = "Find/Replace..."
'
'mnuTools
'
Me.mnuTools.MenuItems.Add(Me.mnuToolsBeam)
Me.mnuTools.MenuItems.Add(Me.MenuItem5)
Me.mnuTools.MenuItems.Add(Me.mnuToolsSaveAs)
Me.mnuTools.MenuItems.Add(Me.mnuToolsDelete)
Me.mnuTools.Text = "Tools"
'
'mnuToolsBeam
'
Me.mnuToolsBeam.Text = "Beam Document..."
'
'MenuItem5
'
Me.MenuItem5.Text = "-"
'
'mnuToolsSaveAs
'
Me.mnuToolsSaveAs.Text = "Save Document As..."
'
'mnuToolsDelete
'
Me.mnuToolsDelete.Text = "Delete Document"
'
'txtContent
'
Me.txtContent.ContextMenu = Me.mnuContext
Me.txtContent.Multiline = True
Me.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtContent.Size = New System.Drawing.Size(240, 269)
Me.txtContent.Text = ""
'
'mnuContext
'
'
'imgToolbar
'
Me.imgToolbar.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
Me.imgToolbar.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
Me.imgToolbar.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Image))
Me.imgToolbar.ImageSize = New System.Drawing.Size(16, 16)
'
'tlbMain
'
Me.tlbMain.Buttons.Add(Me.tbbPrint)
Me.tlbMain.Buttons.Add(Me.tbbTask)
Me.tlbMain.ImageList = Me.imgToolbar
'
'tbbPrint
'
Me.tbbPrint.ImageIndex = 0
'
'tbbTask
'
Me.tbbTask.ImageIndex = 2
'
'Form1
'
Me.ClientSize = New System.Drawing.Size(240, 295)
Me.ControlBox = False
Me.Controls.Add(Me.txtContent)
Me.Controls.Add(Me.tlbMain)
Me.Menu = Me.mnuMain
Me.Text = "MenuDemo"

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

#End Region

  Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    If (mnuOptionsAutoSave.Checked = True) Then
      MsgBox("auto saving file...")
    End If
  End Sub

  Private Sub mnuContext_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContext.Popup
    Dim mnuContextCut As New MenuItem
    Dim mnuContextCopy As New MenuItem
    Dim mnuContextPaste As New MenuItem

' Define the menu items.
    mnuContextCut.Text = "Cut"
    mnuContextCopy.Text = "Copy"
    mnuContextPaste.Text = "Paste"

' Clear the contents of the context menu.
    mnuContext.MenuItems.Clear()

' Add the menu items to the context menu.
    mnuContext.MenuItems.Add(mnuContextCut)
    mnuContext.MenuItems.Add(mnuContextCopy)
    mnuContext.MenuItems.Add(mnuContextPaste)

' Add the event handlers for the individual menu items.
    AddHandler mnuContextCut.Click, AddressOf Me.mnuContextCut_OnClick
    AddHandler mnuContextCopy.Click, AddressOf Me.mnuContextCopy_OnClick
    AddHandler mnuContextPaste.Click, AddressOf Me.mnuContextPaste_OnClick

  End Sub

Private Sub mnuContextCut_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
  MsgBox("cut...")
End Sub

Private Sub mnuContextCopy_OnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
  MsgBox("copy...")
End Sub

Private Sub mnuContextPaste_OnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
  MsgBox("paste...")
End Sub

  Private Sub tlbMain_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbMain.ButtonClick
    Select Case e.Button.ImageIndex
      Case 0
        MsgBox("print...")
      Case 1
        MsgBox("save...")
      Case 2
        MsgBox("task...")
    End Select
  End Sub

  Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
    MsgBox("new...")
  End Sub

  ' *** the Cut menu item ***
  Private Sub mnuEditCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditCut.Click
    MsgBox("cut...")
  End Sub

  ' *** the Copy menu item ***
  Private Sub mnuEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditCopy.Click
    MsgBox("copy...")
  End Sub

  ' *** the Paste menu item ***
  Private Sub mnuEditPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditPaste.Click
    MsgBox("paste...")
  End Sub

  ' *** the Clear menu item ***
  Private Sub mnuEditClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditClear.Click
    MsgBox("clear...")
  End Sub

  ' *** the Select All menu item ***
  Private Sub mnuEditSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditSelectAll.Click
    MsgBox("select all...")
  End Sub

  ' *** the Find/Replace menu item ***
  Private Sub mnuEditFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditFind.Click
    MsgBox("find/replace...")
  End Sub

  ' *** the Beam menu item ***
  Private Sub mnuToolsBeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsBeam.Click
    MsgBox("beam...")
  End Sub

  ' *** the Save As menu item ***
  Private Sub mnuToolsSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsSaveAs.Click
    MsgBox("save as...")
  End Sub

  ' *** the Delete menu item ***
  Private Sub mnuToolsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsDelete.Click
    MsgBox("delete...")
  End Sub
End Class
