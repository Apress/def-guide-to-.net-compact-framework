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

Public Class frmCryptography
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnHash As System.Windows.Forms.Button
    Friend WithEvents btnEncrypt As System.Windows.Forms.Button
    Friend WithEvents txtEncrypt As System.Windows.Forms.TextBox

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
    Friend WithEvents txtHashValue As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnHash = New System.Windows.Forms.Button
        Me.btnEncrypt = New System.Windows.Forms.Button
        Me.txtHashValue = New System.Windows.Forms.TextBox
        Me.txtEncrypt = New System.Windows.Forms.TextBox
        '
        'btnHash
        '
        Me.btnHash.Location = New System.Drawing.Point(16, 32)
        Me.btnHash.Text = "Hash"
        '
        'btnEncrypt
        '
        Me.btnEncrypt.Location = New System.Drawing.Point(16, 104)
        Me.btnEncrypt.Size = New System.Drawing.Size(88, 20)
        Me.btnEncrypt.Text = "Encrypt"
        '
        'txtHashValue
        '
        Me.txtHashValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtHashValue.Location = New System.Drawing.Point(32, 56)
        Me.txtHashValue.Size = New System.Drawing.Size(200, 22)
        Me.txtHashValue.Text = "p@ssw*rd"
        '
        'txtEncrypt
        '
        Me.txtEncrypt.ForeColor = System.Drawing.Color.Green
        Me.txtEncrypt.Location = New System.Drawing.Point(32, 128)
        Me.txtEncrypt.Size = New System.Drawing.Size(200, 22)
        Me.txtEncrypt.Text = "Encrypt This!"
        '
        'frmCryptography
        '
        Me.Controls.Add(Me.txtEncrypt)
        Me.Controls.Add(Me.txtHashValue)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Controls.Add(Me.btnHash)
        Me.Text = "frmCryptography"

    End Sub

#End Region

    Private Sub btnHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHash.Click
        Dim ctp As CryptoAPI = New CryptoAPI

        txtHashValue.Text = ctp.GenerateHash(Me.txtHashValue.Text)
        btnHash.Enabled = False
    End Sub

    Private Sub btnEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click
        Dim ctp As CryptoAPI = New CryptoAPI

        If txtEncrypt.ForeColor.Equals(Color.Red) Then
            txtEncrypt.Text = ctp.DecryptString(Me.txtEncrypt.Text)
            txtEncrypt.ForeColor = Color.Green
            btnEncrypt.Text = "Encrypt"
        Else
            txtEncrypt.Text = ctp.EncryptString(Me.txtEncrypt.Text)
            txtEncrypt.ForeColor = Color.Red
            btnEncrypt.Text = "Decrypt"
        End If
    End Sub
End Class
