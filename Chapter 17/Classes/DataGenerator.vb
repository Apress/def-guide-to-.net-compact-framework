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
Imports System.Threading
Imports Microsoft.WindowsCE.Forms

Public Class DataGenerator
	'Private _intCollectionRate As Int32 = 2
	Private _th As Thread = Nothing
	Private Shared i As Int32 = 0
	Private messageWindowHwnd As IntPtr
	Private _useEvent As Boolean = False

	Public Delegate Sub DataUpdate(ByVal count As Int32)
	Public Event DataChanged As DataUpdate

	Public Sub New(ByVal rate As Int32, ByVal hWnd As IntPtr, ByVal bUseEvent As Boolean)
		'		_intCollectionRate = rate
		Dim ts As ThreadStart = New ThreadStart(AddressOf CollectData)
		_th = New Thread(ts)
		messageWindowHwnd = hWnd
		_useEvent = bUseEvent
	End Sub

	Public Sub Start()
		If _th Is Nothing Then
			Dim ts As ThreadStart = New ThreadStart(AddressOf CollectData)
			_th = New Thread(ts)
		Else
			_th.Start()
		End If
	End Sub

	Public Sub [Stop]()
		_th = Nothing
	End Sub

	Public Sub CollectData()
		While i < 100
			SyncLock i.GetType
				i += 1
				Dim q As IntPtr = New IntPtr(i)

				If _useEvent Then
					RaiseEvent DataChanged(i)
				Else
					Dim msg As Message = Message.Create(Me.messageWindowHwnd, &H401, IntPtr.Zero, q)
					MessageWindow.PostMessage(msg)
				End If
			End SyncLock

		End While
		i = 0
	End Sub
End Class
