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
Imports System.Reflection
Imports System.IO

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Private offscreenBitmap As Bitmap
    Private offscreenGraphics As Graphics

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkTransparent As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkTransparent = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(24, 240)
        Me.Label1.Size = New System.Drawing.Size(192, 20)
        Me.Label1.Text = "It Worked!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 216)
        Me.Button1.Size = New System.Drawing.Size(224, 20)
        Me.Button1.Text = "Draw"
        '
        'chkTransparent
        '
        Me.chkTransparent.Location = New System.Drawing.Point(152, 16)
        Me.chkTransparent.Size = New System.Drawing.Size(64, 20)
        Me.chkTransparent.Text = "Transparent"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 16)
        Me.Button2.Size = New System.Drawing.Size(64, 20)
        Me.Button2.Text = "Start Scroll"
        '
        'Timer1
        '
        Me.Timer1.Interval = 25
        '
        'Form1
        '
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.chkTransparent)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Form1"

    End Sub

#End Region

    '    Friend WithEvents btnRound As New RoundButton.RoundButton

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'btnRound.ButtonColor = Color.Red
        'btnRound.ButtonColorDisabled = Color.LightGray
        'btnRound.Top = 10
        'btnRound.Left = 10
        'btnRound.Width = 100
        'btnRound.Height = 20
        'btnRound.Text = "Touch Me!"
        'btnRound.Font = New Font("Arial", 8, FontStyle.Bold)
        'btnRound.Visible = False
        'Me.Controls.Add(btnRound)

        Dim assm As [Assembly]
        Dim str As Stream

        assm = [Assembly].GetExecutingAssembly()
        str = assm.GetManifestResourceStream("ButtonTest.BookCover.bmp")

        bmpBookCover = New Bitmap(str)

        Me.offscreenBitmap = New Bitmap(bmpBookCover.Width, bmpBookCover.Height)
        Me.offscreenGraphics = Graphics.FromImage(Me.offscreenBitmap)
    End Sub

    'Private Sub btnRound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRound.Click
    '    Label1.Visible = True
    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As System.Drawing.Graphics = Me.CreateGraphics()

        Dim assm As [Assembly]
        Dim str As Stream

        assm = [Assembly].GetExecutingAssembly()
        str = assm.GetManifestResourceStream("ButtonTest.BookCover.bmp")

        Dim ia As Imaging.ImageAttributes = New Imaging.ImageAttributes
        ia.SetColorKey(Color.White, Color.White)
        Dim bmp As Bitmap = New Bitmap(str)
        If Me.chkTransparent.Checked Then
            Dim tarRect As Rectangle = New Rectangle((Me.ClientRectangle.Width - bmp.Width) / 2, 35, bmp.Width, bmp.Height)
            Me.Refresh()
            g.DrawImage(bmp, tarRect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia)
        Else
            '            g.DrawImage(bmp, (Me.ClientRectangle.Width - bmp.Width) / 2, 35)
            'g.DrawIcon(New Icon("myIcon"), (Me.ClientRectangle.Width - bmp.Width) / 2, 35)
            Dim srcRect As Rectangle = New Rectangle(0, 0, _
                bmpBookCover.Width, bmpBookCover.Height)
            g.DrawImage(bmp, 35, 35, srcRect, GraphicsUnit.Pixel)
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Timer1.Enabled Then
            Timer1.Enabled = False
            Button2.Text = "Start Scroll"
        Else
            'If bmpBookCover Is Nothing Then
            '    Dim assm As [Assembly]
            '    Dim str As Stream

            '    assm = [Assembly].GetExecutingAssembly()
            '    str = assm.GetManifestResourceStream("ButtonTest.BookCover.bmp")

            '    bmpBookCover = New Bitmap(str)

            'End If
            Timer1.Enabled = True
            Button2.Text = "Stop Scroll"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Invalidate()
    End Sub

    Private posCurrent As Integer = 0
    Private bmpBookCover As Bitmap = Nothing
    Private rectBookCover As Rectangle

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Timer1.Enabled = True Then
            If Not chkTransparent.Checked Then
                '   Only paint this if the time is on
                '   draw the bookcover bitmap from the current position to the end, and then add the front to the back
                If (posCurrent >= bmpBookCover.Width) Then
                    posCurrent = 0
                End If
                Dim rectSrc As Rectangle = New Rectangle(posCurrent, 0, bmpBookCover.Width - posCurrent, bmpBookCover.Height)
                Dim rectSrc2 As Rectangle = New Rectangle(0, 0, posCurrent, bmpBookCover.Height)

                e.Graphics.DrawImage(bmpBookCover, (Me.ClientRectangle.Width - bmpBookCover.Width) / 2, 35, rectSrc, GraphicsUnit.Pixel)
                e.Graphics.DrawImage(bmpBookCover, ((Me.ClientRectangle.Width - bmpBookCover.Width) / 2) + (bmpBookCover.Width - posCurrent), 35, rectSrc2, GraphicsUnit.Pixel)
                posCurrent += 2
            Else
                '   Only paint this if the time is on
                '   draw the bookcover bitmap from the current position to the end, and then add the front to the back
                If (posCurrent >= bmpBookCover.Width) Then
                    posCurrent = 0
                End If
                '   Draw it to the in memory image first
                Dim rectSrc As Rectangle = New Rectangle(posCurrent, 0, bmpBookCover.Width - posCurrent, bmpBookCover.Height)
                Dim rectSrc2 As Rectangle = New Rectangle(0, 0, posCurrent, bmpBookCover.Height)

                offscreenGraphics.DrawImage(bmpBookCover, 0, 0, rectSrc, GraphicsUnit.Pixel)
                offscreenGraphics.DrawImage(bmpBookCover, bmpBookCover.Width - posCurrent, 0, rectSrc2, GraphicsUnit.Pixel)
                posCurrent += 1

                '   Slap it to the screen
                e.Graphics.DrawImage(offscreenBitmap, (Me.ClientRectangle.Width - bmpBookCover.Width) / 2, 35)
            End If
        End If
    End Sub
End Class
