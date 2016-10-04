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

Public Class Images
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 248)
        Me.Button1.Size = New System.Drawing.Size(224, 20)
        Me.Button1.Text = "Draw Book Covers"
        '
        'Images
        '
        Me.Controls.Add(Me.Button1)
        Me.MinimizeBox = False
        Me.Text = "Images"

    End Sub

#End Region

    Private bmpBookCover As Bitmap = Nothing

    Private Sub Images_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim assm As [Assembly]
        Dim str As Stream

        assm = [Assembly].GetExecutingAssembly()
        str = assm.GetManifestResourceStream("ButtonTest.BookCover.bmp")

        bmpBookCover = New Bitmap(str)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim srcRect As Rectangle = New Rectangle(0, 0, bmpBookCover.Width, bmpBookCover.Height)
        Dim targetRectSmall As Rectangle = New Rectangle(0, 0, bmpBookCover.Width / 2, bmpBookCover.Height / 2)
        Dim targetRectLarge As Rectangle = New Rectangle(targetRectSmall.Width, 0, bmpBookCover.Width * 1.5, bmpBookCover.Height * 1.5)

        Dim g As Graphics = Me.CreateGraphics()
        g.DrawImage(bmpBookCover, targetRectSmall, srcRect, GraphicsUnit.Pixel)
        g.DrawImage(bmpBookCover, targetRectLarge, srcRect, GraphicsUnit.Pixel)
        g.Dispose()
    End Sub
End Class
