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

Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnAsyncFetchHttp As System.Windows.Forms.Button
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents btnFetchHttp As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

  Private Shared BUFFER_SIZE As Integer = 1024

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
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnAsyncFetchHttp = New System.Windows.Forms.Button
Me.txtSource = New System.Windows.Forms.TextBox
Me.txtUrl = New System.Windows.Forms.TextBox
Me.btnFetchHttp = New System.Windows.Forms.Button
'
'btnAsyncFetchHttp
'
Me.btnAsyncFetchHttp.Location = New System.Drawing.Point(4, 241)
Me.btnAsyncFetchHttp.Size = New System.Drawing.Size(132, 20)
Me.btnAsyncFetchHttp.Text = "Async Fetch"
'
'txtSource
'
Me.txtSource.Location = New System.Drawing.Point(4, 37)
Me.txtSource.Multiline = True
Me.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtSource.Size = New System.Drawing.Size(232, 200)
Me.txtSource.Text = "[no content]"
'
'txtUrl
'
Me.txtUrl.Location = New System.Drawing.Point(4, 9)
Me.txtUrl.Size = New System.Drawing.Size(232, 22)
Me.txtUrl.Text = "http://www.microsoft.com"
'
'btnFetchHttp
'
Me.btnFetchHttp.Location = New System.Drawing.Point(164, 241)
Me.btnFetchHttp.Text = "Fetch"
'
'Form1
'
Me.Controls.Add(Me.btnAsyncFetchHttp)
Me.Controls.Add(Me.txtSource)
Me.Controls.Add(Me.txtUrl)
Me.Controls.Add(Me.btnFetchHttp)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "HTTP Demo"

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub btnFetchHttp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFetchHttp.Click
    Dim Reader As StreamReader
    Dim Response As WebResponse
    Dim ResponseStream As Stream
    Dim Request As WebRequest

  ' Toggle on the wait cursor.
    Cursor.Current = Cursors.WaitCursor
    txtSource.Text = "[waiting]"

    Try

  ' Retrieve the requested page.
      Request = WebRequest.Create(txtUrl.Text)
      Response = Request.GetResponse
      ResponseStream = Response.GetResponseStream

  ' Convert the response to text.
      Reader = New StreamReader(ResponseStream)
      txtSource.Text = Reader.ReadToEnd

  ' The request failed, so figure out why.
  ' Was it an invalid URI (URL)?
    Catch uriex As UriFormatException
      txtSource.Text = "The page you requested is in an invalid format."

  ' Was there a problem with either the web response or request objects?
    Catch webex As WebException
      txtSource.Text = "An exception occurred relating to the use of " & _
        "a web response or request object. The specific exception was:" & _
        vbCrLf & webex.Message

  ' Did some type of general exception occur?
    Catch ex As Exception
      txtSource.Text = "A general exception occurred while attempting to " & _
        "retrieve the requested page." & _
        vbCrLf & ex.Message()

  ' Clean up before exiting.
    Finally
      Cursor.Current = Cursors.Default
      Response.Close()

    End Try

  End Sub

  Private Sub btnAsyncFetchHttp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsyncFetchHttp.Click
    Dim AsyncResult As IAsyncResult
    Dim Request As WebRequest
    Dim rs As RequestState

  ' Toggle on the wait cursor.
    Cursor.Current = Cursors.WaitCursor
    txtSource.Text = "[waiting]"

    Try

  ' Request the page asynchrounously.
      Request = WebRequest.Create(txtUrl.Text)
      rs = New RequestState
      rs.request = Request
      AsyncResult = CType(Request.BeginGetResponse(AddressOf ResponseCallback, rs), IAsyncResult)

  ' The request failed, so figure out why.
  ' Was there a problem with either the web response or request objects?
    Catch webex As WebException
      txtSource.Text = "An exception occurred relating to the use of " & _
        "a web response or request object. The specific exception was:" & _
        vbCrLf & webex.Message

  ' Did some type of general exception occur?
    Catch ex As Exception
      txtSource.Text = "A general exception occurred while attempting to " & _
        "retrieve the requested page." & _
        vbCrLf & ex.Message()

    Finally
  ' Toggle off the wait cursor.
      Cursor.Current = Cursors.Default

    End Try

  End Sub

#End Region

#Region " General Procedures "

  Sub ResponseCallback(ByVal AsyncResult As IAsyncResult)
    Dim AsyncResultRead As IAsyncResult
    Dim rs As RequestState
    Dim Request As WebRequest
    Dim Response As Stream

    Try

  ' Configure the state of the request to be asynchronous.
      rs = CType(AsyncResult.AsyncState, RequestState)
      Request = rs.request

  ' Terminate the asynchronouns response.
      rs.response = Request.EndGetResponse(AsyncResult)

  ' Retrieve the response.
      Response = rs.response.GetResponseStream
      rs.responseStream = Response

  ' Initiate reading the response.
      AsyncResultRead = Response.BeginRead(rs.bufferRead, 0, BUFFER_SIZE, AddressOf ReadCallBack, rs)

  ' The request failed, so figure out why.
  ' Was there a problem with either the web response or request objects?
    Catch webex As WebException
      txtSource.Text = "An exception occurred relating to the use of " & _
        "a web response or request object. The specific exception was:" & _
        vbCrLf & webex.Message

  ' Did some type of general exception occur?
    Catch ex As Exception
      txtSource.Text = "A general exception occurred while attempting to " & _
        "retrieve the requested page." & _
        vbCrLf & ex.Message()
    End Try

  End Sub

  Sub ReadCallBack(ByVal AsyncResult As IAsyncResult)
    Dim AsyncResultRead As IAsyncResult
    Dim rs As RequestState
    Dim Response As Stream
    Dim ReadCount As Integer

    Try
      rs = CType(AsyncResult.AsyncState, RequestState)
      Response = rs.responseStream
      ReadCount = Response.EndRead(AsyncResult)

  ' Is there anything waiting to read?
      If (ReadCount > 0) Then
        rs.requestData.Append(Encoding.ASCII.GetString(rs.bufferRead, 0, ReadCount))
        AsyncResultRead = Response.BeginRead(rs.bufferRead, 0, BUFFER_SIZE, AddressOf ReadCallBack, rs)

  ' We are done, so display the source for the requested page.
      Else
        If rs.requestData.Length > 1 Then
          Dim sringContent As String
          sringContent = rs.requestData.ToString()
          txtSource.Text = sringContent
        End If
        Response.Close()

      End If

  ' The request failed, so figure out why.
  ' Was there a problem with either the web response or request objects?
    Catch webex As WebException
      txtSource.Text = "An exception occurred relating to the use of " & _
        "a web response or request object. The specific exception was:" & _
        vbCrLf & webex.Message

  ' Did some type of general exception occur?
    Catch ex As Exception
      txtSource.Text = "A general exception occurred while attempting to " & _
        "retrieve the requested page." & _
        vbCrLf & ex.Message()
    End Try

  End Sub

#End Region

End Class
