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
Imports System.Drawing

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
    Friend WithEvents MainMenu2 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MainMenu2 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        '
        'MainMenu2
        '
        Me.MainMenu2.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem4)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem5)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem6)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem7)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem8)
        Me.MenuItem1.Text = "Shapes"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "8-Sided"
        '
        'MenuItem3
        '
        Me.MenuItem3.Text = "Rectangles"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "Simple Ellipses"
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "MS Example"
        '
        'MenuItem6
        '
        Me.MenuItem6.Text = "Fill Region"
        '
        'MenuItem7
        '
        Me.MenuItem7.Text = "Draw a Line"
        '
        'MenuItem8
        '
        Me.MenuItem8.Text = "Draw String"
        '
        'Form1
        '
        Me.Menu = Me.MainMenu2
        Me.MinimizeBox = False
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim activeBrush As SolidBrush = New SolidBrush(Color.Blue)
        Dim activePen As Pen = New Pen(Color.Red)

        activePen.Dispose()
        activeBrush.Dispose()

        Dim g As Drawing.Graphics = Me.CreateGraphics()
        Dim rect As Rectangle = New Rectangle(0, 0, 100, 100)
        Dim pnt As Point = New Point(0, 0)

        Dim arrayPoints() As Point = New Point(3) _
            {New Point(0, 0), New Point(10, 0), New Point(10, 10), New Point(0, 10)}

        Me.Invalidate()
    End Sub

    Private intShapeToDraw As Int32 = 1
    Private bDoPaint As Boolean = False

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim arrayPoints() As Point
        Dim g As System.Drawing.Graphics = e.Graphics

        If intShapeToDraw = 1 Then
            arrayPoints = New Point(7) { _
                New Point(100, 50), _
                New Point(150, 50), _
                New Point(200, 100), _
                New Point(200, 150), _
                New Point(150, 200), _
                New Point(100, 200), _
                New Point(50, 150), _
                New Point(50, 100)}
            Dim penLine As Pen = New Pen(Color.Red)
            g.DrawPolygon(penLine, arrayPoints)
            penLine.Dispose()
        ElseIf intShapeToDraw = 2 Then
            Dim bshRectFill As SolidBrush = New SolidBrush(Color.LightBlue)
            g.FillRectangle(bshRectFill, Me.ClientRectangle)
            bshRectFill.Dispose()
            Dim xPos As Integer = Me.ClientRectangle.Left + 5
            Dim yPos As Integer = Me.ClientRectangle.Top + 5
            Dim cxPos As Integer = Me.ClientRectangle.Width - 10
            Dim cyPos As Integer = cxPos

            Dim penRect As Pen = New Pen(Color.Black)
            penRect.Color = Color.Red
            g.DrawRectangle(penRect, xPos, yPos, cxPos, cyPos)

            '   draw a circle
            xPos += 5
            yPos += 5
            cxPos -= 10
            cyPos -= 10
            bshRectFill.Color = Color.Plum
            g.FillEllipse(bshRectFill, xPos, yPos, cxPos, cyPos)

            xPos += 20
            yPos += 20
            cxPos -= 40
            cyPos -= 40
            arrayPoints = New Point(3) _
                {New Point(xPos, yPos), New Point(xPos + cxPos, yPos), New Point(xPos + cxPos, yPos + cyPos), New Point(xPos, yPos + cyPos)}
            bshRectFill.Color = Color.Red
            g.FillPolygon(bshRectFill, arrayPoints)
            penRect.Dispose()
            ElseIf intShapeToDraw = 3 Then
                Try
                    Dim myColor = Color.FromArgb(155, 155, 155)
                    Dim myColor2 = Color.FromArgb(&H7800FF00)

                    g.FillEllipse(New SolidBrush(myColor), 75, 25, 100, 100)
                    g.FillEllipse(New SolidBrush(myColor2), 125, 100, 100, 100)
                    g.FillEllipse(New SolidBrush(Color.FromArgb(75, 0, 75)), 25, 100, 100, 100)
                Catch ex As Exception
                    MessageBox.Show("An error occurred createing the images")
                End Try
            ElseIf intShapeToDraw = 4 Then
                ' Transparent red, green, and blue brushes.
                Dim trnsRedBrush As New SolidBrush(Color.FromArgb(&H78FF0000))
                Dim trnsGreenBrush As New SolidBrush(Color.FromArgb(&H7800FF00))
                Dim trnsBlueBrush As New SolidBrush(Color.FromArgb(&H780000FF))
                ' Base and height of the triangle that is used to position the
                ' circles. Each vertex of the triangle is at the center of one of
                ' the 3 circles. The base is equal to the diameter of the circle.
                Dim triBase As Single = 100
                Dim triHeight As Single = CSng(Math.Sqrt((3 * (triBase * _
                triBase) / 4)))
                ' Coordinates of first circle's bounding rectangle.
                Dim x1 As Single = 40
                Dim y1 As Single = 40
                ' Fill 3 over-lapping circles. Each circle is a different color.
                g.FillEllipse(trnsRedBrush, x1, y1, 2 * triHeight, 2 * triHeight)
                g.FillEllipse(trnsGreenBrush, x1 + triBase / 2, y1 + triHeight, _
                2 * triHeight, 2 * triHeight)
                g.FillEllipse(trnsBlueBrush, x1 + triBase, y1, 2 * triHeight, _
                2 * triHeight)
            ElseIf intShapeToDraw = 5 Then
                Dim regionBrush As SolidBrush = New SolidBrush(Color.Red)
                Dim excludeRegion As Region = New Region(New Rectangle(75, 75, 100, 100))

                excludeRegion.Xor(New Rectangle(50, 50, 75, 150))
                excludeRegion.Intersect(New Rectangle(50, 50, 100, 100))
                g.FillRegion(regionBrush, excludeRegion)
                excludeRegion.Dispose()
            ElseIf intShapeToDraw = 6 Then
                Dim penLine As Pen = New Pen(Color.DodgerBlue)
                g.DrawLine(penLine, 0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
            ElseIf intShapeToDraw = 7 Then
                g.DrawString("This is a string", New Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Red), 0, 150)

                Dim fnt As Font = New Font("Arial", 12, FontStyle.Bold)
                Dim brush As SolidBrush = New SolidBrush(Color.Red)
                Dim siz As SizeF = g.MeasureString("This is a Test String", fnt)
                g.DrawString("This is a Test String", fnt, brush, New RectangleF(0, 0, siz.Width, siz.Height))
            End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        intShapeToDraw = 1
        Me.Invalidate()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        intShapeToDraw = 2
        Me.Invalidate()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        intShapeToDraw = 3
        Me.Invalidate()
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        intShapeToDraw = 4
        Me.Invalidate()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        intShapeToDraw = 5
        Me.Invalidate()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        intShapeToDraw = 6
        Me.Invalidate()
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        intShapeToDraw = 7
        Me.Invalidate()
    End Sub
End Class
