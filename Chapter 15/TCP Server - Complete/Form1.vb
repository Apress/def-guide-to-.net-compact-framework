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
' You can obtain updates to the samples included with
' this title at the following sites:
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

Imports System.Net.Sockets
Imports System.Threading

Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim ActiveThreads As Integer          ' Number of threads currently active.
    Dim Listener As TcpListener
    Dim MaxConnections As Integer = 100   ' Maximum number of connections to support.
    Private StopListener As Boolean       ' Flag used to control to listening process.

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' Open a port for listening
        Listener = New TcpListener(System.Net.IPAddress.Any, txtPort.Text)
        Listener.Start()

        timMain.Enabled = True

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
  Friend WithEvents timMain As System.Windows.Forms.Timer
  Friend WithEvents txtPort As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.txtDisplay = New System.Windows.Forms.TextBox
Me.timMain = New System.Windows.Forms.Timer(Me.components)
Me.txtPort = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'txtDisplay
'
Me.txtDisplay.Location = New System.Drawing.Point(0, 32)
Me.txtDisplay.Multiline = True
Me.txtDisplay.Name = "txtDisplay"
Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDisplay.Size = New System.Drawing.Size(256, 172)
Me.txtDisplay.TabIndex = 0
Me.txtDisplay.Text = "[status display]"
'
'timMain
'
'
'txtPort
'
Me.txtPort.Location = New System.Drawing.Point(30, 5)
Me.txtPort.Name = "txtPort"
Me.txtPort.Size = New System.Drawing.Size(62, 20)
Me.txtPort.TabIndex = 3
Me.txtPort.Text = "1234"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(0, 8)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(36, 16)
Me.Label2.TabIndex = 4
Me.Label2.Text = "Port:"
'
'Form1
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(256, 205)
Me.Controls.Add(Me.txtPort)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtDisplay)
Me.Name = "Form1"
Me.Text = "TCP Server"
Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
  ' Turn off the timer.
    timMain.Stop()

  ' Terminate the listener.
    If Not Listener Is Nothing Then
      Listener.Stop()
    End If

  End Sub

  Private Sub timMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timMain.Tick
    Dim CurrentThreadStart As ThreadStart
    Dim CurrentThread As Thread
    Dim ThreadCount As Integer

  ' Is there a client waiting to connect? If not, exit this routine.
    If Not Listener.Pending() Then
      Exit Sub
    End If

  ' If we get to here there is a client waiting. Temporarily disable
  ' the timer so that we don't try to process any additional connections
  ' until this one is complete.
    timMain.Enabled = False

  ' Have we reached the maximum number of connections we'll accept? If
  ' so, turn the turn the timer back on and leave the requesting client
  ' waiting.
    If ActiveThreads > MaxConnections Then
      timMain.Enabled = True
      Exit Sub
    End If

  ' If we get to here then we are going to accept the client. Define a new
  ' thread to use with this connection.
    CurrentThreadStart = New ThreadStart(AddressOf ProcessRequest)
    CurrentThread = New Thread(CurrentThreadStart)

  ' Start the thread.
    CurrentThread.Start()

  ' Have all of the other threads wait while we increment the counter.
    SyncLock CurrentThread
      ActiveThreads += 1
    End SyncLock

  ' We're done, so restart the timer.
    timMain.Enabled = True

  End Sub

#End Region

#Region " General Procedures "

  Protected Sub ProcessRequest()
    Dim Buffer(100) As Byte
    Dim Bytes As Integer
    Dim CurrentThread As Thread
    Dim CurSocket As Socket
    Dim InboundPacket As String
    Dim OutboundPacket As String
    Dim Temp As String

  ' Get the current running thread.
    CurrentThread = System.Threading.Thread.CurrentThread()

  ' Accept the pending socket request. 
    CurSocket = Listener.AcceptSocket

  ' Listen on this socket until we are told to stop.
    While Not StopListener

  ' Is there anything waiting to be read? If so, read it.
      If CurSocket.Available > 0 Then
        Bytes = CurSocket.Receive(Buffer, Buffer.Length, 0)
        SyncLock CurrentThread
        InboundPacket = System.Text.Encoding.Default.GetString(Buffer)
        End SyncLock
        Exit While
      End If

  ' Relinquish control to the system so that the other threads may run.
      Application.DoEvents()

  ' Check to see if the connection is still active.
      If Not CurSocket.Connected Then
        StopListener = True
      End If
    End While

  ' Process the packet that was received.
    OutboundPacket = ProcessPacket(InboundPacket)

  ' Update the display to show both the message received and sent.
    txtDisplay.Text += vbCrLf & InboundPacket
    txtDisplay.Text += vbCrLf & OutboundPacket

  ' Format the return message.
    Buffer = System.Text.Encoding.Default.GetBytes(OutboundPacket.ToCharArray)

  ' Send the messsage to the client.
    CurSocket.Send(Buffer, Buffer.Length, 0)
    CurSocket.Close()
    SyncLock CurrentThread
    ActiveThreads -= 1
    End SyncLock

  End Sub

  Function ProcessPacket(ByVal InboundPacket As String) As String
    Dim OutboundPacket As String
    Dim Params As String() = Nothing
    Dim ResultString As String

  ' Parse the packet.
    Params = InboundPacket.Split("|")

  ' Determine what type of packet we received.
    Select Case Params(0)

      Case "DAT" ' Data message

  ' Build the message header.
        OutboundPacket = "DRP|"

  ' Add the dual-device info.
        OutboundPacket += "SUCCESS|"
        OutboundPacket += Now.ToString & "|"

      Case Else ' Unknown message type
        Return "unknown"

    End Select

  ' Return the packet.
    Return OutboundPacket

  End Function

#End Region

End Class
