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
' You can obtain updates to the samples included with this title 
' at the following sites:
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
'

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents Button1 As System.Windows.Forms.Button
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
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCreate As System.Windows.Forms.MenuItem
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuCreate = New System.Windows.Forms.MenuItem
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.mnuCreate)
        Me.MenuItem1.Text = "Data"
        '
        'mnuCreate
        '
        Me.mnuCreate.Text = "Create Database"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 240)
        Me.Button1.Size = New System.Drawing.Size(224, 20)
        Me.Button1.Text = "Button1"
        '
        'DataGrid1
        '
        Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
        Me.DataGrid1.Size = New System.Drawing.Size(224, 160)
        Me.DataGrid1.Text = "DataGrid1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(8, 216)
        Me.Button2.Size = New System.Drawing.Size(224, 20)
        Me.Button2.Text = "Pull Data"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Button3.Location = New System.Drawing.Point(8, 192)
        Me.Button3.Size = New System.Drawing.Size(224, 20)
        Me.Button3.Text = "Replication"
        '
        'Form1
        '
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button1)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim di As DataInterface = New DataInterface
        'di.ReplSynchronize()

        Dim di As DataInterfaceDisconnected = New DataInterfaceDisconnected
        '        Dim dr As SqlServerCe.SqlCeDataReader = di.GetData()
        '        dr.Read()

        DataGrid1.DataSource = di.GetDataSet().Tables(0)

    End Sub


    Private Sub mnuCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreate.Click
        Dim di As DataInterfaceDisconnected
        di = New DataInterfaceDisconnected
        di.CreateDatabase()
        '        di.CreateDatabase("passw0rd")
        di.CreateTable()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim di As DataInterface = New DataInterface
        di.DownloadBooks()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim di As DataInterface = New DataInterface
        di.Replication()
    End Sub
End Class
