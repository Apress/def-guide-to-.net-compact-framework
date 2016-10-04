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

Public Class RoundButton
    Inherits System.Windows.Forms.Control

    Dim _buttonDrawnDown As Boolean = False
    Dim _btnColor As Color = Color.LightGreen
    Dim _btnDisabledColor As Color = Color.DarkGreen

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        DrawButton(e.Graphics, Me.ForeColor, _btnColor)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            If e.Button = MouseButtons.Left Then
                If ((e.X > Me.ClientRectangle.Top And e.X < Me.ClientRectangle.Bottom) And (e.Y > Me.ClientRectangle.Left And e.Y < Me.ClientRectangle.Right)) Then
                    If (_buttonDrawnDown) Then
                        '   I'm inside the button face
                        Dim g As Graphics = Me.CreateGraphics()
                        DrawButton(g, Me.ForeColor, _btnColor)
                        g.Dispose()
                        _buttonDrawnDown = False
                    End If
                Else
                    '	Moving outside the button
                    If _buttonDrawnDown Then
                        Dim g As Graphics = Me.CreateGraphics()
                        DrawButton(g, Me.ForeColor, Color.Black)
                        g.Dispose()
                        _buttonDrawnDown = True
                    End If
                End If
            End If
            '           End If
            MyBase.OnMouseMove(e)
        Catch
        End Try
    End Sub

    Private Sub DrawButton(ByVal g As Graphics, ByVal fColor As Color, ByVal bColor As Color)
        '    use the button height as the diameter of the round end
        Dim bRadius As Int32 = Me.ClientRectangle.Height / 2
        '    Create a Brush object and initialize it to Nothinb
        Dim sb As Brush = Nothing

        If Me.Enabled Then
            sb = New SolidBrush(bColor)
        Else
            sb = New SolidBrush(_btnDisabledColor)
        End If

        '    Create variables to hold button size for calculations
        Dim aTop As Int32 = Me.ClientRectangle.Top
        Dim aLeft As Int32 = Me.ClientRectangle.Left
        Dim aWidth As Int32 = Me.ClientRectangle.Width
        Dim aHeight As Int32 = Me.ClientRectangle.Height

        '    First, draw the semi-circle that is the left end of the button
        g.FillEllipse(sb, aLeft, aTop, 2 * bRadius, 2 * bRadius)
        '    Now, draw the rectangle for the button body
        g.FillRectangle(sb, aLeft + bRadius, aTop, aWidth - (2 * bRadius), aHeight)
        '    Lastly, draw the semi-circle that is the right end of the button
        g.FillEllipse(sb, aWidth - (2 * bRadius), aTop, 2 * bRadius, 2 * bRadius)

        '    Now write the text to the button face
        '    Use the font set in the base control property
        Dim fnt As Font = New Font(Me.Font.Name, Me.Font.Size, Me.Font.Style)
        '    We measure the string to see if
        Dim siz As SizeF = g.MeasureString(Me.Text, fnt)
        '    Here we draw the string, centering it in the buttons client space
        '    Note that it is centered both horizontally and verticlaly in the space
        g.DrawString(Me.Text, fnt, New SolidBrush(fColor), _
            (aWidth - siz.Width) / 2, (aHeight - siz.Height) / 2)
        sb.Dispose()
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        Dim g As Graphics = Me.CreateGraphics()
        If Me.Enabled Then
            DrawButton(g, Me.ForeColor, _btnColor)
        Else
            DrawButton(g, Me.ForeColor, _btnDisabledColor)
        End If
        g.Dispose()
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            Dim g As Graphics = Me.CreateGraphics()
            DrawButton(g, Me.ForeColor, _btnColor)
            g.Dispose()
            _buttonDrawnDown = False
            MyBase.OnMouseUp(e)
        Catch
        End Try
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            Dim g As Graphics = Me.CreateGraphics()
            DrawButton(g, Color.White, Color.Black)
            g.Dispose()
            _buttonDrawnDown = True
            MyBase.OnMouseDown(e)
        Catch
        End Try
    End Sub

    Property ButtonColor() As Color
        Get
            Return _btnColor
        End Get
        Set(ByVal Value As Color)
            _btnColor = Value
        End Set
    End Property
    Property ButtonColorDisabled() As Color
        Get
            Return _btnDisabledColor
        End Get
        Set(ByVal Value As Color)
            _btnDisabledColor = Value
        End Set
    End Property

End Class
