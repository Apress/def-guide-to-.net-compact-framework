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
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnDisplayReport = New System.Windows.Forms.Button
'
'btnDisplayReport
'
Me.btnDisplayReport.Location = New System.Drawing.Point(116, 240)
Me.btnDisplayReport.Size = New System.Drawing.Size(116, 24)
Me.btnDisplayReport.Text = "Display Report"
'
'Form1
'
Me.Controls.Add(Me.btnDisplayReport)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "HTML Reporting"

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub btnDisplayReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayReport.Click
    Dim ReportFile As String = "\Windows\Start Menu\Programs\Apress\report.html"
    Dim ReportHtml As String

  ' Let the user know that there is a process in progress.
    Cursor.Current = Cursors.WaitCursor

  ' Retrieve the data.
    RetrieveData()

  ' Generate the report.
    ReportHtml = ProduceReport()

  ' Save the report.
    SaveReport(ReportHtml, ReportFile)

  ' Display the report.
    DisplayReport(ReportFile)

  ' We are done so reset the cursor.
    Cursor.Current = Cursors.Default

  End Sub

#End Region

#Region " General Procedures "

  Sub DisplayReport(ByVal ReportFile As String)
    Dim pi As ProcessInfo
    Dim si() As Byte
    Dim intResult As Int32

  ' Launch Pocket IE to display the report.
    intResult = LaunchApplication("\Windows\iexplore.exe", ReportFile, Nothing, Nothing, 0, _
      0, Nothing, Nothing, si, pi)

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
      HTML += "<TD><FONT SIZE=-2>" & dr("CompanyName") & "</TD>"
      HTML += "<TD><FONT SIZE=-2>" & dr("ContactName") & "</TD>"
      HTML += "<TD><FONT SIZE=-2>" & dr("Phone") & "</TD>"
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

  Sub SaveReport(ByVal ReportHtml As String, ByVal ReportFile As String)
    Dim sw As System.IO.StreamWriter

  ' Open the file.
    sw = New System.IO.StreamWriter(ReportFile)

  ' Write the report.
    sw.Write(ReportHtml)

  ' Close the file.
    sw.Close()

  End Sub

#End Region

End Class
