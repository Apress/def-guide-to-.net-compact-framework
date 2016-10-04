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
Imports System.IO
Imports System.Reflection

Public Class Form1
    Inherits System.Windows.Forms.Form
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
    Friend WithEvents tmrScroll As System.Windows.Forms.Timer
    Friend WithEvents btnToggleScroll As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.btnToggleScroll = New System.Windows.Forms.Button
        Me.tmrScroll = New System.Windows.Forms.Timer
        '
        'btnToggleScroll
        '
        Me.btnToggleScroll.Location = New System.Drawing.Point(8, 240)
        Me.btnToggleScroll.Size = New System.Drawing.Size(224, 20)
        Me.btnToggleScroll.Text = "Start Scroll"
        '
        'tmrScroll
        '
        Me.tmrScroll.Interval = 50
        '
        'Form1
        '
        Me.Controls.Add(Me.btnToggleScroll)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Form1"

    End Sub

#End Region

    Private posCurrent As Integer = 0
    Private bmpBookCover As Bitmap = Nothing

    Private rectInvalidate As Rectangle

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim assm As [Assembly] = [Assembly].GetExecutingAssembly()
        Dim str As Stream

        str = assm.GetManifestResourceStream("ScrollingImage.BookCover.bmp")
        bmpBookCover = New Bitmap(str)

        rectInvalidate = New Rectangle((Me.ClientRectangle.Width - bmpBookCover.Width) / 2, 35, bmpBookCover.Width, bmpBookCover.Height)

    End Sub

    Private Sub tmrScroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScroll.Tick
        Me.Invalidate(rectInvalidate)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.tmrScroll.Enabled Then
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
        End If
    End Sub

    Private Sub btnToggleScroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleScroll.Click
        If Me.tmrScroll.Enabled Then
            Me.tmrScroll.Enabled = False
            Me.btnToggleScroll.Text = "Start Scrolling"
        Else
            Me.tmrScroll.Enabled = True
            Me.btnToggleScroll.Text = "Stop Scrolling"
        End If
    End Sub
End Class
