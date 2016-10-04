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
Imports System.Runtime.InteropServices

Namespace CompactFramework.UnmanagedCode
    Public Class SystemInfo

        Private Const SM_CXBORDER As Int32 = 5
        Private Const SM_CYBORDER As Int32 = 6
        Private Const SM_CXCURSOR As Int32 = 13
        Private Const SM_CYCURSOR As Int32 = 14
        Private Const SM_CXDLGFRAME As Int32 = 7
        Private Const SM_CYDLGFRAME As Int32 = 8
        Private Const SM_CXEDGE As Int32 = 45
        Private Const SM_CYEDGE As Int32 = 46
        Private Const SM_CXFIXEDFRAME As Int32 = 7
        Private Const SM_CYFIXEDFRAME As Int32 = 8
        Private Const SM_CXHSCROLL As Int32 = 21
        Private Const SM_CYHSCROLL As Int32 = 3
        Private Const SM_CXICON As Int32 = 11
        Private Const SM_CYICON As Int32 = 12
        Private Const SM_CXSCREEN As Int32 = 0
        Private Const SM_CYSCREEN As Int32 = 1
        Private Const SM_CXVSCROLL As Int32 = 2
        Private Const SM_CYVSCROLL As Int32 = 20
        Private Const SM_CYMENU As Int32 = 15
        Private Const SM_CYCAPTION As Int32 = 4

        <DllImport("Coredll.dll")> _
        Private Shared Function GetSystemMetrics(ByVal nIndex As Int32) As Int32
        End Function

        Public Shared ReadOnly Property ScreenSize() As Point
            Get
                Dim retX As Int32 = GetSystemMetrics(SM_CXSCREEN)
                Dim retY As Int32 = GetSystemMetrics(SM_CYSCREEN)
                Dim p As Point = New Point(retX, retY)
                Return p
            End Get
        End Property

        Public Shared ReadOnly Property CursorSize() As Point
            Get
                Dim retX As Int32 = GetSystemMetrics(SM_CXCURSOR)
                Dim retY As Int32 = GetSystemMetrics(SM_CYCURSOR)
                Dim p As Point = New Point(retX, retY)
                Return p
            End Get
        End Property

        Public Shared ReadOnly Property IconSize() As Point
            Get
                Dim retX As Int32 = GetSystemMetrics(SM_CXICON)
                Dim retY As Int32 = GetSystemMetrics(SM_CYICON)
                Dim p As Point = New Point(retX, retY)
                Return p
            End Get
        End Property

        Public Shared ReadOnly Property BorderSize() As Int32
            Get
                Return GetSystemMetrics(SM_CXBORDER)
            End Get
        End Property

        Public Shared ReadOnly Property HorizontalScrollHeight() As Int32
            Get
                Return GetSystemMetrics(SM_CYHSCROLL)
            End Get
        End Property

        Public Shared ReadOnly Property VerticalScrollWidth() As Int32
            Get
                Return GetSystemMetrics(SM_CXVSCROLL)
            End Get
        End Property

    End Class
End Namespace
