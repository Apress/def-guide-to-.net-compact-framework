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

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnDisplayReport As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Dim cn As System.Data.SqlServerCe.SqlCeConnection
    Dim cmd As New System.Data.SqlServerCe.SqlCeCommand
    Dim dr As System.Data.SqlServerCe.SqlCeDataReader

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
  Friend WithEvents HtmlViewer1 As Intelliprog.Windows.Forms.HTMLViewer
  Friend WithEvents htmlViewer As Intelliprog.Windows.Forms.HTMLViewer
  Friend WithEvents chkFitToWindow As System.Windows.Forms.CheckBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnDisplayReport = New System.Windows.Forms.Button
Me.htmlViewer = New Intelliprog.Windows.Forms.HTMLViewer
Me.chkFitToWindow = New System.Windows.Forms.CheckBox
'
'btnDisplayReport
'
Me.btnDisplayReport.Location = New System.Drawing.Point(119, 241)
Me.btnDisplayReport.Size = New System.Drawing.Size(116, 24)
Me.btnDisplayReport.Text = "Display Report"
'
'htmlViewer
'
Me.htmlViewer.ClearType = False
Me.htmlViewer.ControlBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.htmlViewer.FitToWindow = True
Me.htmlViewer.HideScrollbar = False
Me.htmlViewer.Size = New System.Drawing.Size(240, 236)
Me.htmlViewer.Text = "[no report]"
Me.htmlViewer.ZoomLevel = Intelliprog.Windows.Forms.ZoomLevels.Smaller
'
'chkFitToWindow
'
Me.chkFitToWindow.Checked = True
Me.chkFitToWindow.CheckState = System.Windows.Forms.CheckState.Checked
Me.chkFitToWindow.Location = New System.Drawing.Point(4, 244)
Me.chkFitToWindow.Text = "fit to window"
'
'Form1
'
Me.Controls.Add(Me.chkFitToWindow)
Me.Controls.Add(Me.htmlViewer)
Me.Controls.Add(Me.btnDisplayReport)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "HTML Reporting"

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub btnDisplayReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayReport.Click
    Dim ReportHtml As String

  ' Let the user know that there is a process in progress.
    Cursor.Current = Cursors.WaitCursor

  ' Retrieve the data.
    RetrieveData()

  ' Generate the report.
    ReportHtml = ProduceReport()

  ' Display the report.
    DisplayReport(ReportHtml)

  ' We are done so reset the cursor.
    Cursor.Current = Cursors.Default

  End Sub

  Private Sub chkFitToWindow_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFitToWindow.CheckStateChanged
  ' Toggle the HTML viewer mode.
    htmlViewer.FitToWindow = chkFitToWindow.Checked
  End Sub

#End Region

#Region " General Procedures "

  Sub DisplayReport(ByVal ReportHtml As String)
  ' Display the report by loading it into the HTML control.
    htmlViewer.SetText(ReportHtml)
  End Sub

  Function ProduceReport() As String
    Dim HTML As String

  ' Build the report header.
    HTML = "<HTML>"
    HTML += "<BODY>"
    HTML += "<H1><FONT COLOR=Blue>Customer List</FONT></H1>"
    HTML += "<TABLE>"
    HTML += "<TR>"
    HTML += "<TD><B>COMPANY</B></TD>"
    HTML += "<TD><B>CONTACT</B></TD>"
    HTML += "<TD><B>PHONE</B></TD>"

  ' Loop through the data.
    While dr.Read()
      HTML += "<TR>"
      HTML += "<TD><FONT SIZE=-1>" & dr("CompanyName") & "</TD>"
      HTML += "<TD><FONT SIZE=-1>" & dr("ContactName") & "</TD>"
      HTML += "<TD><FONT SIZE=-1>" & dr("Phone") & "</TD>"
      HTML += "</TR>"
    End While

  ' Add the report footer.
    HTML += "</TABLE>"
    HTML += "</BODY>"
    HTML += "</HTML>"

  ' Return the report.
    Return HTML

  End Function

  Sub RetrieveData()

  ' Open the connection.
    cn = New _
      System.Data.SqlServerCe.SqlCeConnection( _
      "Data Source=\Windows\Start Menu\Programs\Apress\NorthwindDemo.sdf")
    cn.Open()

  ' Configure and execute the command.
    cmd.CommandText = "SELECT * FROM Customers"
    cmd.Connection = cn
    dr = cmd.ExecuteReader

  End Sub

#End Region

End Class
