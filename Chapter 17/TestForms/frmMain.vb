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

Public Class frmMain
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCryptographyTest As System.Windows.Forms.MenuItem
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
	Friend WithEvents mnuMessageWindow As System.Windows.Forms.MenuItem
	Private Sub InitializeComponent()
		Me.MainMenu1 = New System.Windows.Forms.MainMenu
		Me.MenuItem6 = New System.Windows.Forms.MenuItem
		Me.MenuItem7 = New System.Windows.Forms.MenuItem
		Me.MenuItem8 = New System.Windows.Forms.MenuItem
		Me.MenuItem9 = New System.Windows.Forms.MenuItem
		Me.MenuItem10 = New System.Windows.Forms.MenuItem
		Me.MenuItem11 = New System.Windows.Forms.MenuItem
		Me.mnuCryptographyTest = New System.Windows.Forms.MenuItem
		Me.Button1 = New System.Windows.Forms.Button
		Me.Button2 = New System.Windows.Forms.Button
		Me.Button3 = New System.Windows.Forms.Button
		Me.Button4 = New System.Windows.Forms.Button
		Me.Button5 = New System.Windows.Forms.Button
		Me.Button6 = New System.Windows.Forms.Button
		Me.Button7 = New System.Windows.Forms.Button
		Me.mnuMessageWindow = New System.Windows.Forms.MenuItem
		'
		'MainMenu1
		'
		Me.MainMenu1.MenuItems.Add(Me.MenuItem6)
		'
		'MenuItem6
		'
		Me.MenuItem6.MenuItems.Add(Me.MenuItem7)
		Me.MenuItem6.MenuItems.Add(Me.MenuItem8)
		Me.MenuItem6.MenuItems.Add(Me.MenuItem9)
		Me.MenuItem6.MenuItems.Add(Me.MenuItem10)
		Me.MenuItem6.MenuItems.Add(Me.MenuItem11)
		Me.MenuItem6.MenuItems.Add(Me.mnuCryptographyTest)
		Me.MenuItem6.MenuItems.Add(Me.mnuMessageWindow)
		Me.MenuItem6.Text = "Test Forms"
		'
		'MenuItem7
		'
		Me.MenuItem7.Text = "Registry"
		'
		'MenuItem8
		'
		Me.MenuItem8.Text = "Battery"
		'
		'MenuItem9
		'
		Me.MenuItem9.Text = "System Metrics"
		'
		'MenuItem10
		'
		Me.MenuItem10.Text = "Special Folder"
		'
		'MenuItem11
		'
		Me.MenuItem11.Text = "Notification"
		'
		'mnuCryptographyTest
		'
		Me.mnuCryptographyTest.Text = "Cryptography"
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(24, 16)
		Me.Button1.Size = New System.Drawing.Size(192, 20)
		Me.Button1.Text = "Show SIP"
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(24, 48)
		Me.Button2.Size = New System.Drawing.Size(192, 20)
		Me.Button2.Text = "Hide ISP"
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(24, 96)
		Me.Button3.Size = New System.Drawing.Size(192, 20)
		Me.Button3.Text = "Status = Hidden"
		'
		'Button4
		'
		Me.Button4.Location = New System.Drawing.Point(24, 136)
		Me.Button4.Size = New System.Drawing.Size(192, 20)
		Me.Button4.Text = "Hide Start Menu"
		'
		'Button5
		'
		Me.Button5.Location = New System.Drawing.Point(24, 160)
		Me.Button5.Size = New System.Drawing.Size(192, 20)
		Me.Button5.Text = "Hide Sip Button"
		'
		'Button6
		'
		Me.Button6.Location = New System.Drawing.Point(24, 184)
		Me.Button6.Size = New System.Drawing.Size(192, 20)
		Me.Button6.Text = "Hide Task Bar"
		'
		'Button7
		'
		Me.Button7.Location = New System.Drawing.Point(24, 208)
		Me.Button7.Size = New System.Drawing.Size(192, 20)
		Me.Button7.Text = "Full Screen"
		'
		'mnuMessageWindow
		'
		Me.mnuMessageWindow.Text = "Message Handling"
		'
		'frmMain
		'
		Me.Controls.Add(Me.Button7)
		Me.Controls.Add(Me.Button6)
		Me.Controls.Add(Me.Button5)
		Me.Controls.Add(Me.Button4)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Menu = Me.MainMenu1
		Me.MinimizeBox = False
		Me.Text = "Form1"

	End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SipOperation.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SipOperation.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If SipOperation.IsVisible Then
            Button3.Text = "Status = " & "Visible"
        Else
            Button3.Text = "Status = " & "Hidden"
        End If
    End Sub

#Region "Methods to Call Test Forms"
    Private Sub RegistryTestForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Dim frm As frmRegistryInfo = New frmRegistryInfo
        frm.ShowDialog()
    End Sub

    Private Sub BatteryTestForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Dim frm As frmBatteryInfo = New frmBatteryInfo
        frm.ShowDialog()
    End Sub

    Private Sub SystemMetricsTestForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        Dim frm As frmSystemMetrics = New frmSystemMetrics
        frm.ShowDialog()
    End Sub

    Private Sub SpecialFoldersTestForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Dim frm As SpecialFolders = New SpecialFolders
        frm.ShowDialog()
    End Sub

    Private Sub NotificationTestForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Dim frm As frmNotification = New frmNotification
        frm.ShowDialog()
    End Sub

    Private Sub mnuCryptographyTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCryptographyTest.Click
        Dim frm As frmCryptography = New frmCryptography
        frm.ShowDialog()
    End Sub
#End Region

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Hide Start Menu" Then
            SipOperation.HideStartMenu(Me.Text)
            Button4.Text = "Show Start Menu"
        Else
            SipOperation.ShowStartMenu(Me.Text)
            Button4.Text = "Hide Start Menu"
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Button5.Text = "Hide Sip Button" Then
            SipOperation.HideSipButton(Me.Text)
            Button5.Text = "Show Sip Button"
        Else
            SipOperation.ShowSipButton(Me.Text)
            Button5.Text = "Hide Sip Button"
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Button6.Text = "Hide Task Bar" Then
            SipOperation.HideTaskBar(Me.Text)
            Button6.Text = "Show Task Bar"
        Else
            SipOperation.ShowTaskBar(Me.Text)
            Button6.Text = "Hide Task Bar"
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Button7.Text = "Full Screen" Then
            SipOperation.ShowFullScreen(Me.Text)
            Button7.Text = "Normal Screen"
        Else
            SipOperation.ShowScreenNormal(Me.Text)
            Button7.Text = "Full Screen"
        End If
    End Sub

	Private Sub mnuMessageWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMessageWindow.Click
		Dim frm As frmMessages = New frmMessages
		frm.Show()
	End Sub
End Class
