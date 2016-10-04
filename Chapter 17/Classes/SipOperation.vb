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
Imports System.Text

Namespace CompactFramework.UnmanagedCode
    Public Class SipOperation
        Private Sub New()
        End Sub

#Region "Enums and Constants"
        Private Const SW_HIDE As Integer = 0
        Private Const SW_SHOWNORMAL As Integer = 1
        Private Const SW_SHOW As Integer = 5

        Private Const SHFS_SHOWTASKBAR As Integer = &H1
        Private Const SHFS_HIDETASKBAR As Integer = &H2
        Private Const SHFS_SHOWSIPBUTTON As Integer = &H4
        Private Const SHFS_HIDESIPBUTTON As Integer = &H8
        Private Const SHFS_SHOWSTARTICON As Integer = &H10
        Private Const SHFS_HIDESTARTICON As Integer = &H20
        Private Const HWND_TOPMOST As Integer = -1
        Private Const HWND_NOTOPMOST As Integer = -2

        Private Const SWP_SHOWWINDOW As Integer = &H40
        Private Const HHTASKBARHEIGHT As Integer = 26

		Public Enum eSIPStatus As Long
			SipOff = &H0
			SipOn = &H1
			SipDocked = &H2
			SipLocked = &H4
		End Enum

		Private Enum SipInfoActions As Integer
			SPI_SETCOMPLETIONINFO = 223
			SPI_SETSIPINFO
			SPI_GETSIPINFO
			SPI_SETCURRENTIM
			SPI_GETCURRENTIM
		End Enum

		Private Const SIP_STATUS_UNAVAILABLE As Int32 = 0
		Private Const SIP_STATUS_AVAILABLE As Int32 = 1

		Private Const SIPF_OFF As Int32 = &H0
		Private Const SIPF_ON As Int32 = &H1
		Private Const SIPF_DOCKED As Int32 = &H2
		Private Const SIPF_LOCKED As Int32 = &H4

		Private Const SPI_SETCOMPLETIONINFO As Int32 = 223
		Private Const SPI_SETSIPINFO As Int32 = 224
		Private Const SPI_GETSIPINFO As Int32 = 225
		Private Const SPI_SETCURRENTIM As Int32 = 226
		Private Const SPI_GETCURRENTIM As Int32 = 227

#End Region

#Region "Declare Statements"
        <DllImport("aygshell.dll")> _
        Private Shared Function SipStatus() As Int32
        End Function

        <DllImport("coredll.dll")> _
        Private Shared Function FindWindow(ByVal lpCLassName As String, ByVal lpWindowsName As String) As IntPtr
        End Function

        <DllImport("aygshell.dll")> _
        Private Shared Function SHFullScreen(ByVal hwndRequester As IntPtr, ByVal dwState As Integer) As Boolean
        End Function

        <DllImport("aygshell.dll")> _
        Private Shared Function SHSipInfo(ByVal uiAction As Int32, ByVal uiParam As Int32, ByVal pvParam As IntPtr, ByVal fWinIni As Int32) As Boolean
        End Function

		<DllImport("SipInfo.dll", EntryPoint:="GetCurrentInputMethod")> _
		Private Shared Function GetCurrentInputMethod() As IntPtr
		End Function

		<DllImport("SipInfo.dll", EntryPoint:="GetCurrentInputMethodID")> _
		Private Shared Function GetCurrentInputMethodID() As Int32
		End Function

		<DllImport("SipInfo.dll", EntryPoint:="GetCurrentInputMethodEx")> _
		Private Shared Function GetCurrentInputMethodEx(ByVal lpData As StringBuilder, ByRef lpcbData As Int32) As Int32
		End Function

		<DllImport("SipInfo.dll", EntryPoint:="IsSipVisible")> _
		Private Shared Function IsSipVisible() As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Int32
		End Function

		'	BOOL WINAPI SipShowIM(DWORD)
		<DllImport("coredll.dll")> _
		Private Shared Function SipShowIM(ByVal i As Int32) As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Private Shared Function SetForegroundWindow(ByVal hwnd As IntPtr) As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Private Shared Function MoveWindow(ByVal hwnd As IntPtr, ByVal x As Int32, _
		  ByVal y As Int32, ByVal nWidth As Int32, ByVal nHeight As Int32, ByVal bRepaint As Boolean) As Int32
		End Function
#End Region

        Public Shared ReadOnly Property IsVisible() As Boolean
			Get
				Dim uig As IntPtr = GetCurrentInputMethod()
				Dim str As String = Marshal.PtrToStringUni(uig)

				Dim strValue As StringBuilder = New StringBuilder(50)
				Dim pLen As Integer
				Dim lRet As Int32 = GetCurrentInputMethodEx(strValue, pLen)

				lRet = GetCurrentInputMethodID()

				Return IsSipVisible()
			End Get
		End Property

        Public Shared Sub Show()
            SipShowIM(eSIPStatus.SipOn)
        End Sub

        Public Shared Sub Hide()
            SipShowIM(eSIPStatus.SipOff)
        End Sub

        Public Shared Sub ShowFullScreen(ByVal strWindowName As String)
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            ShowWindow(hWnd, SW_SHOWNORMAL)
            SetForegroundWindow(hWnd)
            SHFullScreen(hWnd, SHFS_HIDETASKBAR)
            Dim screenWidth As Int32 = Apress.CompactFramework.UnmanagedCode.SystemInfo.ScreenSize.X
            Dim screenHeight As Int32 = Apress.CompactFramework.UnmanagedCode.SystemInfo.ScreenSize.Y
            Dim lret As Int32 = MoveWindow(hWnd, 0, 0, _
                screenWidth, screenHeight + HHTASKBARHEIGHT, False)
        End Sub

        Public Shared Sub ShowScreenNormal(ByVal strWindowName As String)
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            ShowWindow(hWnd, SW_SHOWNORMAL)
            SetForegroundWindow(hWnd)
            SHFullScreen(hWnd, SHFS_SHOWTASKBAR)
            Dim screenWidth As Int32 = Apress.CompactFramework.UnmanagedCode.SystemInfo.ScreenSize.X
            Dim screenHeight As Int32 = Apress.CompactFramework.UnmanagedCode.SystemInfo.ScreenSize.Y
            Dim lret As Int32 = MoveWindow(hWnd, 0, HHTASKBARHEIGHT, _
                screenWidth, screenHeight, True)
        End Sub

        Public Shared Function HideStartMenu(ByVal strWindowName As String) As Boolean
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            Return SHFullScreen(hWnd, SHFS_HIDESTARTICON)
        End Function

        Public Shared Function HideSipButton(ByVal strWindowName As String) As Boolean
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            Return SHFullScreen(hWnd, SHFS_HIDESIPBUTTON)
        End Function

        Public Shared Function HideTaskBar(ByVal strWindowName As String) As Boolean
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            If Not IntPtr.Zero.Equals(hWnd) Then
                SetForegroundWindow(hWnd)
                Return SHFullScreen(hWnd, SHFS_HIDETASKBAR)
            End If
        End Function

        Public Shared Function ShowStartMenu(ByVal strWindowName As String) As Boolean
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            Return SHFullScreen(hWnd, SHFS_SHOWSTARTICON)
        End Function

        Public Shared Function ShowSipButton(ByVal strWindowName As String) As Boolean
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            Return SHFullScreen(hWnd, SHFS_SHOWSIPBUTTON)
        End Function

        Public Shared Function ShowTaskBar(ByVal strWindowName As String) As Boolean
            Dim hWnd As IntPtr = FindWindow(Nothing, strWindowName)
            If Not IntPtr.Zero.Equals(hWnd) Then
                Return SHFullScreen(hWnd, SHFS_SHOWTASKBAR)
            End If
        End Function

    End Class

End Namespace

