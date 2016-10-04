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
Imports Apress.CompactFramework.UnmanagedCode

Public Class frmBatteryInfo
    Inherits System.Windows.Forms.Form
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 8)
        Me.Button1.Size = New System.Drawing.Size(224, 20)
        Me.Button1.Text = "Get Battery Status"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(112, 40)
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(112, 88)
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(112, 112)
        Me.Label4.Size = New System.Drawing.Size(120, 20)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(112, 136)
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(0, 40)
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.Text = "Line Status"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(112, 64)
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(0, 64)
        Me.Label7.Size = New System.Drawing.Size(104, 20)
        Me.Label7.Text = "Battery Flag"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(0, 88)
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.Text = "Battery Life %"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(0, 112)
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.Text = "Battery Life Time"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(0, 136)
        Me.Label10.Size = New System.Drawing.Size(104, 20)
        Me.Label10.Text = "Backup Flag"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(0, 168)
        Me.Label11.Size = New System.Drawing.Size(104, 20)
        Me.Label11.Text = "Battery Chemistry"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(112, 168)
        Me.Label12.Size = New System.Drawing.Size(120, 20)
        '
        'frmBatteryInfo
        '
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Text = "frmBatteryInfo"

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		Dim pwr As BatteryInformation = New BatteryInformation
        Label1.Text = pwr.LineStatus
        Label2.Text = pwr.BatteryFlag
        Label3.Text = pwr.BatteryLifePercent
        Label4.Text = pwr.BatteryLifeTime
        Label5.Text = pwr.BackupBatteryFlag
        Label12.Text = pwr.BatteryChemistry
    End Sub

    Private Sub frmBatteryInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label6_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.ParentChanged

    End Sub
End Class
