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
Imports Microsoft.WindowsCE.Forms

Public Class frmMessages
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
	Friend WithEvents btnStart As System.Windows.Forms.Button
	Friend WithEvents btnStop As System.Windows.Forms.Button
	Friend WithEvents lblDataDisplay As System.Windows.Forms.Label
	Friend WithEvents btnRaiseEvent As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.btnStart = New System.Windows.Forms.Button
		Me.btnStop = New System.Windows.Forms.Button
		Me.lblDataDisplay = New System.Windows.Forms.Label
		Me.btnRaiseEvent = New System.Windows.Forms.Button
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(8, 16)
		Me.btnStart.Size = New System.Drawing.Size(224, 20)
		Me.btnStart.Text = "Start Data Flow - PostMessage"
		'
		'btnStop
		'
		Me.btnStop.Location = New System.Drawing.Point(8, 168)
		Me.btnStop.Size = New System.Drawing.Size(224, 20)
		Me.btnStop.Text = "Stop Data Flow"
		'
		'lblDataDisplay
		'
		Me.lblDataDisplay.Location = New System.Drawing.Point(16, 104)
		Me.lblDataDisplay.Size = New System.Drawing.Size(200, 20)
		Me.lblDataDisplay.Text = "Label1"
		Me.lblDataDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'btnRaiseEvent
		'
		Me.btnRaiseEvent.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
		Me.btnRaiseEvent.Location = New System.Drawing.Point(8, 48)
		Me.btnRaiseEvent.Size = New System.Drawing.Size(224, 20)
		Me.btnRaiseEvent.Text = "Start Data Flow - RaiseEvent"
		'
		'frmMessages
		'
		Me.Controls.Add(Me.btnRaiseEvent)
		Me.Controls.Add(Me.lblDataDisplay)
		Me.Controls.Add(Me.btnStop)
		Me.Controls.Add(Me.btnStart)
		Me.Text = "frmMessages"

	End Sub

#End Region

	Private myFormThread As System.Threading.Thread = System.Threading.Thread.CurrentThread

	Private Function CalledOnFormThread() As Boolean
		If Me.myFormThread.Equals(System.Threading.Thread.CurrentThread) Then
			' the call was made on the form's thread
			Return True
		End If

		' the call was made on a thread other than the form's thread
		Return False
	End Function

	Private WithEvents _dataGenerator As Apress.DataGenerator
	Private _messageWindow As MessageHandler

	Private Sub frmMessages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	End Sub

	Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
		_messageWindow = New MessageHandler(Me)
		_dataGenerator = New Apress.DataGenerator(10, _messageWindow.Hwnd, False)
		_dataGenerator.Start()
	End Sub
	Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
		_dataGenerator.Stop()
	End Sub

	Private _count As Int32

	Private Sub UpdateWithInvoke(ByVal sender As Object, ByVal e As EventArgs)
		Me.lblDataDisplay.Text = _count.ToString()
	End Sub

	Private Sub testfunc(ByVal count As Int32) Handles _dataGenerator.DataChanged
		If Not CalledOnFormThread() Then
			_count = count
			Me.Invoke(New EventHandler(AddressOf UpdateWithInvoke))
		Else
			Me.lblDataDisplay.Text = count.ToString()
		End If

	End Sub

	Public Sub MessageInBox(ByVal count As Int32)
		If Not CalledOnFormThread() Then
			_count = count
			Me.Invoke(New EventHandler(AddressOf UpdateWithInvoke))
		Else
			Me.lblDataDisplay.Text = count.ToString()
			Me.lblDataDisplay.Refresh()
		End If
	End Sub

	Private Sub btnRaiseEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRaiseEvent.Click
		_messageWindow = New MessageHandler(Me)
		_dataGenerator = New Apress.DataGenerator(10, _messageWindow.Hwnd, True)
		_dataGenerator.Start()
	End Sub
End Class

