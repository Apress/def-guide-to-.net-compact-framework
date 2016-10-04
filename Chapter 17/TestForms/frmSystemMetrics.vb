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

Public Class frmSystemMetrics
    Inherits System.Windows.Forms.Form
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox

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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 24)
        Me.TextBox1.Size = New System.Drawing.Size(200, 22)
        Me.TextBox1.Text = "TextBox1"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(16, 70)
        Me.TextBox2.Size = New System.Drawing.Size(200, 22)
        Me.TextBox2.Text = "TextBox2"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(16, 116)
        Me.TextBox3.Size = New System.Drawing.Size(200, 22)
        Me.TextBox3.Text = "TextBox3"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(16, 162)
        Me.TextBox4.Size = New System.Drawing.Size(200, 22)
        Me.TextBox4.Text = "TextBox4"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(16, 208)
        Me.TextBox5.Size = New System.Drawing.Size(200, 22)
        Me.TextBox5.Text = "TextBox5"
        '
        'frmSystemMetrics
        '
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Text = "frmSystemMetrics"

    End Sub

#End Region

    Private Sub frmSystemMetrics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pt As Point = SystemInfo.ScreenSize()
        TextBox1.Text = "Screen Size: " & pt.X.ToString & " : " & pt.Y.ToString()
        pt = SystemInfo.CursorSize
        TextBox2.Text = "Cursor Size: " & pt.X.ToString & " : " & pt.Y.ToString()
        pt = SystemInfo.IconSize
        TextBox3.Text = "Icon Size: " & pt.X.ToString & " : " & pt.Y.ToString()
        Dim intVal As Int32 = SystemInfo.HorizontalScrollHeight
        TextBox4.Text = "ScrollBar Height: " & intVal.ToString
        intVal = SystemInfo.VerticalScrollWidth
        TextBox5.Text = "ScrollBar Width: " & intVal.ToString
    End Sub
End Class
