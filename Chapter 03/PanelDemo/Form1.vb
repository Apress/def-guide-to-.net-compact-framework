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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents pnlContact As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents pnlOrders As System.Windows.Forms.Panel
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPanelGeneral As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPanelContact As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPanelOrders As System.Windows.Forms.MenuItem
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
  Friend WithEvents pnlGeneral As System.Windows.Forms.Panel
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.MenuItem1 = New System.Windows.Forms.MenuItem
Me.mnuPanelGeneral = New System.Windows.Forms.MenuItem
Me.mnuPanelContact = New System.Windows.Forms.MenuItem
Me.mnuPanelOrders = New System.Windows.Forms.MenuItem
Me.pnlGeneral = New System.Windows.Forms.Panel
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.pnlContact = New System.Windows.Forms.Panel
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.pnlOrders = New System.Windows.Forms.Panel
Me.DataGrid1 = New System.Windows.Forms.DataGrid
'
'MainMenu1
'
Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
'
'MenuItem1
'
Me.MenuItem1.MenuItems.Add(Me.mnuPanelGeneral)
Me.MenuItem1.MenuItems.Add(Me.mnuPanelContact)
Me.MenuItem1.MenuItems.Add(Me.mnuPanelOrders)
Me.MenuItem1.Text = "Panel"
'
'mnuPanelGeneral
'
Me.mnuPanelGeneral.Text = "General"
'
'mnuPanelContact
'
Me.mnuPanelContact.Text = "Contact"
'
'mnuPanelOrders
'
Me.mnuPanelOrders.Text = "Orders"
'
'pnlGeneral
'
Me.pnlGeneral.Controls.Add(Me.TextBox1)
Me.pnlGeneral.Controls.Add(Me.Label1)
Me.pnlGeneral.Location = New System.Drawing.Point(300, 0)
Me.pnlGeneral.Size = New System.Drawing.Size(236, 268)
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(73, 13)
Me.TextBox1.Size = New System.Drawing.Size(156, 22)
Me.TextBox1.Text = ""
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 16)
Me.Label1.Size = New System.Drawing.Size(64, 20)
Me.Label1.Text = "Company:"
'
'pnlContact
'
Me.pnlContact.Controls.Add(Me.TextBox2)
Me.pnlContact.Controls.Add(Me.Label2)
Me.pnlContact.Location = New System.Drawing.Point(300, 0)
Me.pnlContact.Size = New System.Drawing.Size(236, 268)
'
'TextBox2
'
Me.TextBox2.Location = New System.Drawing.Point(73, 13)
Me.TextBox2.Size = New System.Drawing.Size(158, 22)
Me.TextBox2.Text = ""
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 16)
Me.Label2.Size = New System.Drawing.Size(56, 24)
Me.Label2.Text = "Contact:"
'
'pnlOrders
'
Me.pnlOrders.Controls.Add(Me.DataGrid1)
Me.pnlOrders.Location = New System.Drawing.Point(300, 0)
Me.pnlOrders.Size = New System.Drawing.Size(240, 268)
'
'DataGrid1
'
Me.DataGrid1.Location = New System.Drawing.Point(8, 4)
Me.DataGrid1.Size = New System.Drawing.Size(224, 260)
Me.DataGrid1.Text = "DataGrid1"
'
'Form1
'
Me.Controls.Add(Me.pnlOrders)
Me.Controls.Add(Me.pnlContact)
Me.Controls.Add(Me.pnlGeneral)
Me.Menu = Me.MainMenu1
Me.Text = "PanelDemo"

    End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  ' When we start show the general panel.
    ShowPanel(pnlGeneral)

  End Sub

  Sub ShowPanel(ByVal PanelToShow As Panel)

' Hide all of the panels.
    pnlGeneral.Left = 300
    pnlContact.Left = 300
    pnlOrders.Left = 300

' Display the selected panel.
    PanelToShow.Left = 0

  End Sub

  Private Sub mnuPanelGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPanelGeneral.Click

  ' Show the General panel.
    ShowPanel(pnlGeneral)

  End Sub

  Private Sub mnuPanelContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPanelContact.Click

  ' Show the Contact panel.
    ShowPanel(pnlContact)

  End Sub

  Private Sub mnuPanelOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPanelOrders.Click

  ' Show the Orders panel.
    ShowPanel(pnlOrders)

  End Sub
End Class
