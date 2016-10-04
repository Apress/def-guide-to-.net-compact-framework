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
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
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
  Friend WithEvents btnLoad As System.Windows.Forms.Button
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.TreeView1 = New System.Windows.Forms.TreeView
Me.btnLoad = New System.Windows.Forms.Button
'
'TreeView1
'
Me.TreeView1.ImageIndex = -1
Me.TreeView1.Location = New System.Drawing.Point(8, 8)
Me.TreeView1.SelectedImageIndex = -1
Me.TreeView1.Size = New System.Drawing.Size(224, 232)
'
'btnLoad
'
Me.btnLoad.Location = New System.Drawing.Point(8, 244)
Me.btnLoad.Text = "Load"
'
'Form1
'
Me.Controls.Add(Me.btnLoad)
Me.Controls.Add(Me.TreeView1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "TreeView Demo"

    End Sub

#End Region

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

  ' Suppress repainting the TreeView.
    TreeView1.BeginUpdate()

  ' Clear the TreeView.
    TreeView1.Nodes.Clear()

  ' Add the Assembly department.
    TreeView1.Nodes.Add(New TreeNode("Assembly"))

  ' Add a few maintenance calls to Assembly.
    TreeView1.Nodes(0).Nodes.Add(New TreeNode("North, part feeder 5"))
    TreeView1.Nodes(0).Nodes.Add(New TreeNode("North, test stand 2"))
    TreeView1.Nodes(0).Nodes.Add(New TreeNode("South, torq gun 4"))

  ' Add the Manufacturing department.
    TreeView1.Nodes.Add(New TreeNode("Manufacturing"))

  ' Add a few maintenance calls to Assembly.
    TreeView1.Nodes(1).Nodes.Add(New TreeNode("Dept 205, milling 2"))
    TreeView1.Nodes(1).Nodes.Add(New TreeNode("Dept 224, grinder 1"))
    TreeView1.Nodes(1).Nodes.Add(New TreeNode("Dept 306, stamping 6"))

  ' Add the Sub-Assembly department.
    TreeView1.Nodes.Add(New TreeNode("Sub-Assembly"))

    TreeView1.Nodes(2).Nodes.Add(New TreeNode("South conveyor"))
    TreeView1.Nodes(2).Nodes.Add(New TreeNode("welder 4"))

  ' Begin repainting the TreeView.
    TreeView1.EndUpdate()

  End Sub

End Class
