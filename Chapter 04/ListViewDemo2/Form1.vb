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
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnToggle As System.Windows.Forms.Button
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
  Friend WithEvents imgLarge As System.Windows.Forms.ImageList
  Friend WithEvents imgSmall As System.Windows.Forms.ImageList
  Friend WithEvents lblView As System.Windows.Forms.Label
    Private Sub InitializeComponent()
Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.ListView1 = New System.Windows.Forms.ListView
Me.btnLoad = New System.Windows.Forms.Button
Me.btnToggle = New System.Windows.Forms.Button
Me.imgLarge = New System.Windows.Forms.ImageList
Me.imgSmall = New System.Windows.Forms.ImageList
Me.lblView = New System.Windows.Forms.Label
'
'ListView1
'
Me.ListView1.LargeImageList = Me.imgLarge
Me.ListView1.Location = New System.Drawing.Point(8, 32)
Me.ListView1.Size = New System.Drawing.Size(224, 164)
Me.ListView1.SmallImageList = Me.imgSmall
'
'btnLoad
'
Me.btnLoad.Location = New System.Drawing.Point(8, 244)
Me.btnLoad.Text = "Load"
'
'btnToggle
'
Me.btnToggle.Location = New System.Drawing.Point(92, 244)
Me.btnToggle.Text = "Toggle"
'
'imgLarge
'
Me.imgLarge.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
Me.imgLarge.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
Me.imgLarge.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Image))
Me.imgLarge.ImageSize = New System.Drawing.Size(32, 32)
'
'imgSmall
'
Me.imgSmall.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Image))
Me.imgSmall.Images.Add(CType(resources.GetObject("resource4"), System.Drawing.Image))
Me.imgSmall.Images.Add(CType(resources.GetObject("resource5"), System.Drawing.Image))
Me.imgSmall.ImageSize = New System.Drawing.Size(16, 16)
'
'lblView
'
Me.lblView.Location = New System.Drawing.Point(8, 8)
'
'Form1
'
Me.Controls.Add(Me.lblView)
Me.Controls.Add(Me.btnToggle)
Me.Controls.Add(Me.btnLoad)
Me.Controls.Add(Me.ListView1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "ListView Demo 2"

    End Sub

#End Region

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    Dim intCounter As Integer
    Dim LVItem As ListViewItem

  ' Load the file info into the ListView.
    ListView1.Items.Clear()

  ' Build the contents.
    LVItem = New ListViewItem
    LVItem.Text = "Expenses.pxl"
    LVItem.SubItems.Add("3.11KB")
    LVItem.SubItems.Add("Pocket Excel Workbook")
    LVItem.SubItems.Add("9/18/2002 10:10:10 AM")
    LVItem.ImageIndex = 0
    ListView1.Items.Add(LVItem)

    LVItem = New ListViewItem
    LVItem.Text = "My Lists.clf"
    LVItem.SubItems.Add("9.50KB")
    LVItem.SubItems.Add("ListPro Document")
    LVItem.SubItems.Add("10/19/2002 11:11:11 AM")
    LVItem.ImageIndex = 1
    ListView1.Items.Add(LVItem)

    LVItem = New ListViewItem
    LVItem.Text = "My Wallet.wlt"
    LVItem.SubItems.Add("62.5KB")
    LVItem.SubItems.Add("eWallet Document")
    LVItem.SubItems.Add("11/20/2002 12:12:12 PM")
    LVItem.ImageIndex = 2
    ListView1.Items.Add(LVItem)

    lblView.Text = "Large Icon View"
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  ' Define the view.
    ListView1.View = View.LargeIcon

  ' Configure the columns.
    ListView1.Columns.Add("Name", 120, HorizontalAlignment.Left)
    ListView1.Columns.Add("Size", 70, HorizontalAlignment.Center)
    ListView1.Columns.Add("Type", 130, HorizontalAlignment.Center)
    ListView1.Columns.Add("Modified", 150, HorizontalAlignment.Center)

  End Sub

  Private Sub btnToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggle.Click
    Select Case ListView1.View
      Case View.LargeIcon
        ListView1.View = View.SmallIcon
        lblView.Text = "Small Icon View"
      Case View.List
        ListView1.View = View.Details
        lblView.Text = "Details View"
      Case View.SmallIcon
        ListView1.View = View.List
        lblView.Text = "List View"
      Case View.Details
        ListView1.View = View.LargeIcon
        lblView.Text = "Large Icon View"
    End Select
  End Sub
End Class
