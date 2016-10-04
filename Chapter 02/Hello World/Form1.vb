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

Public Class frmHelloWorld
    Inherits System.Windows.Forms.Form
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents timMain As System.Windows.Forms.Timer
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

  Dim strDirection As String
  Dim strMessage As String
  Dim strTemp As String

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
Me.txtMessage = New System.Windows.Forms.TextBox
Me.btnChange = New System.Windows.Forms.Button
Me.timMain = New System.Windows.Forms.Timer
'
'txtMessage
'
Me.txtMessage.BackColor = System.Drawing.Color.Black
Me.txtMessage.Font = New System.Drawing.Font("Tahoma", 22.0!, System.Drawing.FontStyle.Regular)
Me.txtMessage.ForeColor = System.Drawing.Color.Lime
Me.txtMessage.Location = New System.Drawing.Point(8, 8)
Me.txtMessage.Size = New System.Drawing.Size(224, 43)
Me.txtMessage.Text = ""
'
'btnChange
'
Me.btnChange.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
Me.btnChange.Location = New System.Drawing.Point(8, 56)
Me.btnChange.Size = New System.Drawing.Size(224, 24)
Me.btnChange.Text = "Change Direction"
'
'timMain
'
Me.timMain.Interval = 200
'
'frmHelloWorld
'
Me.Controls.Add(Me.btnChange)
Me.Controls.Add(Me.txtMessage)
Me.Menu = Me.MainMenu1
Me.Text = "Hello World"

    End Sub

#End Region

  Private Sub frmHelloWorld_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  ' Initialize the operating variables.
    strDirection = "forwards"
    strMessage = "Hello World from the DGNCF"
    strTemp = New String(Chr(Asc(" ")), 30) & strMessage

  ' Start the marquee.
    timMain.Enabled = True

  End Sub

  Private Sub timMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timMain.Tick
  ' Depending upon what direction we are scrolling, take
  ' either the left or right-most character off of the
  ' string and append it to the opposite end.
    If (strDirection = "forwards") Then
      strTemp = strTemp.Substring(1, strTemp.Length - 1) & _
        Mid(strTemp, 1, 1)
    Else
      strTemp = strTemp.Substring(strTemp.Length - 1, 1) & _
        Mid(strTemp, 1, Len(strTemp) - 1)
    End If

  ' Display the string, giving the feeling that the
  ' text is scrolling.
    txtMessage.Text = strTemp

  End Sub

  Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
  ' Toggle the directional flag.
    Select Case strDirection
      Case "forwards"
        strDirection = "backwards"
      Case "backwards"
        strDirection = "forwards"
    End Select
  End Sub
End Class
