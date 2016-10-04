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
    Public Class Notification

        Dim m_clsid As Guid
        Private m_baseID As Int32
        Private m_NotificationCount As Int32

        '   Notification priority
        Private Const SHNP_INFORM As Int32 = &H1B1       'bubble shown for duration, then goes away
        Private Const SHNP_ICONIC As Int32 = &H0        'no bubble, icon shown for duration then goes away

        '   Notification update mask

        Private Const SHNUM_PRIORITY As Int32 = &H1
        Private Const SHNUM_DURATION As Int32 = &H2
        Private Const SHNUM_ICON As Int32 = &H4
        Private Const SHNUM_HTML As Int32 = &H8
        Private Const SHNUM_TITLE As Int32 = &H10

        '   Flags

        '//For SHNP_INFORM priority and above, don't display the notification
        '//bubble when it's initially added; the icon will display for the
        '//duration then it will go straight into the tray. The user can
        '//view the icon / see the bubble by opening the tray.
        Private Const SHNF_STRAIGHTTOTRAY As Int32 = &H1
        '//Critical information - highlights the border and title of the bubble.
        Private Const SHNF_CRITICAL As Int32 = &H2
        '//Force the message (bubble) to display even if settings says not to.
        Private Const SHNF_FORCEMESSAGE As Int32 = &H8


        '			<StructLayout(LayoutKind.Sequential)> _
        Public Structure SHNOTIFICATIONDATA
            Public cbStruct As Int32    '//For verification and versioning
            Public dwID As Int32        '//Identifier for this particular notification
            Public npPriority As Int32  '//Priority
            Public csDuration As Int32  '//Duration of the notification (usage depends on priority)
            Public hicon As IntPtr      '//Icon for the notification
            Public grfFlags As Int32    '//Flags
            Public clsid As Guid        '//Unique identifier for the notification class
            Public hwndSink As IntPtr   '//Window to receive command choices, dismiss, etc.
            Public pszHTML As StringBuilder '//HTML content for the bubble
            Public pszTitle As StringBuilder '//Optional title for bubble
            Public lParam As Int32       '//User-defined parameter
        End Structure

        '//Add
        <DllImport("aygshell.dll", CallingConvention:=CallingConvention.Winapi, EntryPoint:="#155")> _
        Private Shared Function SHNotificationAdd(ByRef shinfo As SHNOTIFICATIONDATA) As Integer
        End Function
        '//Remove
        <DllImport("aygshell.dll", EntryPoint:="#157")> _
        Private Shared Function SHNotificationRemove(ByRef clsid As Guid, ByVal dwID As Int32) As Integer
        End Function
        '//Update
        <DllImport("aygshell.dll", EntryPoint:="#158")> _
        Private Shared Function SHNotificationUpdate(ByVal grnumUpdateMask As Int32, ByRef shinfo As SHNOTIFICATIONDATA) As Integer
        End Function
        '//Icon
        <DllImport("coredll.dll")> _
        Private Shared Function LoadIcon(ByVal hInstance As IntPtr, ByVal Icon As Int32) As IntPtr
        End Function

#Region "Methods"

        Public Sub New()
            m_clsid = New Guid("{F1370B91-BDEB-405c-A175-508D4F0DC868}")
            m_baseID = 0
            m_NotificationCount = 0
        End Sub

        '   This function adds a notification (asynchronously) to the notification tray.
        '   HTML content for the notification bubble
        Public Sub Add(ByVal Message As String)     'unsafe
            NotificationAdd(Message, String.Empty, 0, IntPtr.Zero, 0, m_clsid)
        End Sub

        '/// <summary>
        '/// This function adds a notification (asynchronously) to the notification tray.
        '/// </summary>
        '/// <param name="Message">HTML content for the notification bubble.</param>
        '/// <param name="Title">Optional title for notification bubble.</param>
        Public Sub Add(ByVal Message As String, ByVal Title As String) 'unsafe
            NotificationAdd(Message, Title, 0, IntPtr.Zero, 0, m_clsid)
        End Sub

        '/// <summary>
        '/// This function adds a notification (asynchronously) to the notification tray.
        '/// </summary>
        '/// <param name="Message">HTML content for the notification bubble.</param>
        '/// <param name="Title">Optional title for notification bubble.</param>
        '/// <param name="Duration">Duration of the notification. The usage depends on the priority.</param>
        Public Sub Add(ByVal Message As String, ByVal Title As String, ByVal Duration As Int32)
            NotificationAdd(Message, Title, Duration, IntPtr.Zero, 0, m_clsid)
        End Sub

        '/// <summary>
        '/// This function adds a notification (asynchronously) to the notification tray.
        '/// </summary>
        '/// <param name="Message">HTML content for the notification bubble.</param>
        '/// <param name="Title">Optional title for notification bubble.</param>
        '/// <param name="hIcon">The icon for the notification.</param>
        Public Sub Add(ByVal Message As String, ByVal Title As String, ByVal hIcon As IntPtr)
            NotificationAdd(Message, Title, 0, hIcon, 0, m_clsid)
        End Sub

        '/// <summary>
        '/// This function adds a notification (asynchronously) to the notification tray.
        '/// </summary>
        '/// <param name="Message">HTML content for the notification bubble.</param>
        '/// <param name="Title">Optional title for notification bubble.</param>
        '/// <param name="Duration">Duration of the notification. The usage depends on the priority.</param>
        '/// <param name="hIcon">The icon for the notification.</param>
        Public Sub Add(ByVal Message As String, ByVal Title As String, ByVal Duration As Int32, ByVal hIcon As IntPtr)
            NotificationAdd(Message, Title, Duration, hIcon, 0, m_clsid)
        End Sub

        '/// <summary>
        '/// This function adds a notification (asynchronously) to the notification tray.
        '/// </summary>
        '/// <param name="Message">HTML content for the notification bubble.</param>
        '/// <param name="Title">Optional title for notification bubble.</param>
        '/// <param name="Duration">Duration of the notification. The usage depends on the priority.</param>
        '/// <param name="MessageID">Identifier for this particular notification.</param>
        Public Sub Add(ByVal Message As String, ByVal Title As String, ByVal Duration As Int32, ByVal MessageID As Int32)
            NotificationAdd(Message, Title, Duration, IntPtr.Zero, MessageID, m_clsid)
        End Sub

        '/// <summary>
        '/// This function adds a notification (asynchronously) to the notification tray.
        '/// </summary>
        '/// <param name="Message">HTML content for the notification bubble.</param>
        '/// <param name="Title">Optional title for notification bubble.</param>
        '/// <param name="Duration">Duration of the notification. The usage depends on the priority.</param>
        '/// <param name="clsid">Unique identifier for the notification class.</param>
        Public Sub Add(ByVal Message As String, ByVal Title As String, ByVal Duration As Int32, ByVal clsid As String)
            m_clsid = New Guid(clsid)
            NotificationAdd(Message, Title, Duration, IntPtr.Zero, 0, m_clsid)
        End Sub

        '/// <summary>
        '/// This function adds a notification (asynchronously) to the notification tray.
        '/// </summary>
        '/// <param name="Message">HTML content for the notification bubble.</param>
        '/// <param name="Title">Optional title for notification bubble.</param>
        '/// <param name="Duration">Duration of the notification. The usage depends on the priority.</param>
        '/// <param name="MessageID">Identifier for this particular notification.</param>
        '/// <param name="clsid">Unique identifier for the notification class.</param>
        Public Sub Add(ByVal Message As String, ByVal Title As String, ByVal Duration As Single, ByVal MessageID As Int32, ByVal clsid As String)
            m_clsid = New Guid(clsid)
            NotificationAdd(Message, Title, Duration, IntPtr.Zero, MessageID, m_clsid)
        End Sub

#End Region
        Public Sub NotificationAdd(ByVal Message As String, ByVal Title As String, ByVal Duration As Int32, ByVal hIcon As IntPtr, ByVal ID As Int32, ByVal clsid As Guid) ' unsafe

            Dim shinfo As SHNOTIFICATIONDATA = New SHNOTIFICATIONDATA

            If Message Is Nothing Then
                Message = String.Empty
            Else
                shinfo.pszHTML = New StringBuilder(Message)
            End If

            If Title Is Nothing Then
                Title = String.Empty
            Else
                shinfo.pszTitle = New StringBuilder(Title)
            End If

            If Duration <> 0 Then
                shinfo.csDuration = Duration
            Else
                shinfo.csDuration = 20
            End If

            If ID <> 0 Then
                shinfo.dwID = ID
            Else
                m_baseID += 1
                shinfo.dwID = m_baseID
            End If

            '//Guid
            If (clsid.Equals(Nothing)) Then
                shinfo.clsid = clsid
            Else
                shinfo.clsid = m_clsid
            End If

            '//Fill the structure's remaining members
            shinfo.cbStruct = CType(Marshal.SizeOf(shinfo), Int32)
            shinfo.npPriority = SHNP_ICONIC

            shinfo.pszTitle = New StringBuilder(Title)
            shinfo.pszHTML = New StringBuilder(Message)
            Dim err As Int32 = SHNotificationAdd(shinfo)

            If err <> 0 Then
                MsgBox("opps")
            Else
                m_NotificationCount += 1
            End If

            'fixed (char* pTitle = Title.ToCharArray())
            '{
            '	fixed (char* pHTML = Message.ToCharArray())
            '	{
            '		shinfo.pszTitle = pTitle;
            '		shinfo.pszHTML = pHTML;

            '        Try
            '		{
            '			int err = SHNotificationAdd(ref shinfo);

            '			if (err != 0)
            '				throw (new Exception("Invalid return from SHNotificationAdd"));
            '            Else
            '				m_NotificationCount +=1;
            '		}
            '		catch(Exception ex)
            '		{
            '			//Trace the error out
            '		}
            '	}
            '}

        End Sub

        '//Remove a notification
        Private Sub NotificationRemove(ByVal clsid As Guid, ByVal id As Int32)
            If m_NotificationCount > 0 Then
                If id = 0 Then
                    id = m_baseID
                End If

                Dim err As Int32 = SHNotificationRemove(clsid, id)

                If err <> 0 Then
                    Throw (New Exception("Invalid return from SHNotificationRemove"))
                Else
                    m_NotificationCount -= 1
                End If
            End If
        End Sub


    End Class

End Namespace

