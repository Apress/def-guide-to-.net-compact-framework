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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 8)
        Me.Button1.Size = New System.Drawing.Size(216, 104)
        Me.Button1.Text = "GetSettings"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Button2.Location = New System.Drawing.Point(8, 120)
        Me.Button2.Size = New System.Drawing.Size(152, 104)
        Me.Button2.Text = "Close App"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Button3.Location = New System.Drawing.Point(168, 120)
        Me.Button3.Size = New System.Drawing.Size(56, 104)
        Me.Button3.Text = "Setup"
        '
        'Form1
        '
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim t As UserSettings.ForestSoftware.NetCF.UserSettings.XmlSettings
        t = New UserSettings.ForestSoftware.NetCF.UserSettings.XmlSettings("TestFrame1")

        'Dim strRet As String = t.ReadSettingString("Startup", "Product", "<Unknown>")
        'Dim strRet2 As String = t.ReadSettingString("Startup", "Version", "<Unknown>")

        t.WriteSettingString("Info", "test", "oh boy")
        Dim iRet As Int32 = t.ReadSettingInt("Info", "DiskSpace", 5000)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim t As UserSettings.ForestSoftware.NetCF.UserSettings.XmlSettings
        t = New UserSettings.ForestSoftware.NetCF.UserSettings.XmlSettings("TestFrame")

        t.WriteSettingString("Info", "again", "oh please work")
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim t As UserSettings.ForestSoftware.NetCF.UserSettings.XmlSettings
        t = New UserSettings.ForestSoftware.NetCF.UserSettings.XmlSettings("TestFrame")

        t.WriteSettingString("Info", "Product", "Tomorrow")
        't.WriteSettingString("Info", "Time", "Noon")
        't.WriteSettingInt("Info", "DiskSpace", 8000)

        't.WriteSettingString("Startup", "CmdLine", "")
        't.WriteSettingString("Startup", "Product", "Standard SDK for Windows CE .NET")
        't.WriteSettingString("Startup", "PackageName", "STANDARD_SDK.msi")
        't.WriteSettingString("Startup", "MsiVersion", "1.00.5104.0")
        't.WriteSettingString("Startup", "EnableLangDlg", "Y")

        't.WriteSettingString("0x0409", "TITLE", "Choose Setup Language")
        't.WriteSettingString("0x0409", "DESCRIPTION", "Select the language for this installation from the choices below.")
        't.WriteSettingString("0x0409", "OK", "OK")
        't.WriteSettingString("0x0409", "CANCEL", "Cancel")
    End Sub
End Class
