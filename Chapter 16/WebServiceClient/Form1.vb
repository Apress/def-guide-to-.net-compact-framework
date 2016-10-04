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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents CalcPage As System.Windows.Forms.TabPage
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Dim asyncws As New Chapter16.Demo

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtHours As System.Windows.Forms.TextBox
  Friend WithEvents txtRate As System.Windows.Forms.TextBox
  Friend WithEvents txtPay As System.Windows.Forms.TextBox
  Friend WithEvents btnCalc As System.Windows.Forms.Button
  Friend WithEvents StructurePage As System.Windows.Forms.TabPage
  Friend WithEvents ClassPage As System.Windows.Forms.TabPage
  Friend WithEvents DataSetPage As System.Windows.Forms.TabPage
  Friend WithEvents AsyncPage As System.Windows.Forms.TabPage
  Friend WithEvents cmbStructureListings As System.Windows.Forms.ComboBox
  Friend WithEvents txtStructureListing As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtClassListing As System.Windows.Forms.TextBox
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents btnGrabData As System.Windows.Forms.Button
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtAsyncHours As System.Windows.Forms.TextBox
  Friend WithEvents txtAsyncRate As System.Windows.Forms.TextBox
  Friend WithEvents txtAsyncPay As System.Windows.Forms.TextBox
  Friend WithEvents btnCalcAsync As System.Windows.Forms.Button
  Friend WithEvents cmbClassListings As System.Windows.Forms.ComboBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.CalcPage = New System.Windows.Forms.TabPage
Me.btnCalc = New System.Windows.Forms.Button
Me.txtPay = New System.Windows.Forms.TextBox
Me.txtRate = New System.Windows.Forms.TextBox
Me.txtHours = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.StructurePage = New System.Windows.Forms.TabPage
Me.Label4 = New System.Windows.Forms.Label
Me.txtStructureListing = New System.Windows.Forms.TextBox
Me.cmbStructureListings = New System.Windows.Forms.ComboBox
Me.ClassPage = New System.Windows.Forms.TabPage
Me.cmbClassListings = New System.Windows.Forms.ComboBox
Me.Label5 = New System.Windows.Forms.Label
Me.txtClassListing = New System.Windows.Forms.TextBox
Me.DataSetPage = New System.Windows.Forms.TabPage
Me.btnGrabData = New System.Windows.Forms.Button
Me.DataGrid1 = New System.Windows.Forms.DataGrid
Me.AsyncPage = New System.Windows.Forms.TabPage
Me.btnCalcAsync = New System.Windows.Forms.Button
Me.txtAsyncPay = New System.Windows.Forms.TextBox
Me.txtAsyncRate = New System.Windows.Forms.TextBox
Me.txtAsyncHours = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
'
'TabControl1
'
Me.TabControl1.Controls.Add(Me.CalcPage)
Me.TabControl1.Controls.Add(Me.StructurePage)
Me.TabControl1.Controls.Add(Me.ClassPage)
Me.TabControl1.Controls.Add(Me.DataSetPage)
Me.TabControl1.Controls.Add(Me.AsyncPage)
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(240, 270)
'
'CalcPage
'
Me.CalcPage.Controls.Add(Me.btnCalc)
Me.CalcPage.Controls.Add(Me.txtPay)
Me.CalcPage.Controls.Add(Me.txtRate)
Me.CalcPage.Controls.Add(Me.txtHours)
Me.CalcPage.Controls.Add(Me.Label3)
Me.CalcPage.Controls.Add(Me.Label2)
Me.CalcPage.Controls.Add(Me.Label1)
Me.CalcPage.Location = New System.Drawing.Point(4, 4)
Me.CalcPage.Size = New System.Drawing.Size(232, 244)
Me.CalcPage.Text = "Calc"
'
'btnCalc
'
Me.btnCalc.Location = New System.Drawing.Point(152, 216)
Me.btnCalc.Text = "Calc"
'
'txtPay
'
Me.txtPay.Location = New System.Drawing.Point(80, 84)
Me.txtPay.Text = ""
'
'txtRate
'
Me.txtRate.Location = New System.Drawing.Point(80, 48)
Me.txtRate.Text = ""
'
'txtHours
'
Me.txtHours.Location = New System.Drawing.Point(80, 12)
Me.txtHours.Text = ""
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(16, 87)
Me.Label3.Size = New System.Drawing.Size(64, 20)
Me.Label3.Text = "Pay:"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(16, 51)
Me.Label2.Size = New System.Drawing.Size(64, 20)
Me.Label2.Text = "Rate:"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(16, 15)
Me.Label1.Size = New System.Drawing.Size(64, 20)
Me.Label1.Text = "Hours:"
'
'StructurePage
'
Me.StructurePage.Controls.Add(Me.Label4)
Me.StructurePage.Controls.Add(Me.txtStructureListing)
Me.StructurePage.Controls.Add(Me.cmbStructureListings)
Me.StructurePage.Location = New System.Drawing.Point(4, 4)
Me.StructurePage.Size = New System.Drawing.Size(232, 244)
Me.StructurePage.Text = "Structure"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(13, 16)
Me.Label4.Size = New System.Drawing.Size(51, 20)
Me.Label4.Text = "Listing:"
'
'txtStructureListing
'
Me.txtStructureListing.Location = New System.Drawing.Point(12, 44)
Me.txtStructureListing.Multiline = True
Me.txtStructureListing.Size = New System.Drawing.Size(208, 180)
Me.txtStructureListing.Text = "[ no listing ]"
'
'cmbStructureListings
'
Me.cmbStructureListings.Items.Add("11111")
Me.cmbStructureListings.Items.Add("22222")
Me.cmbStructureListings.Items.Add("33333")
Me.cmbStructureListings.Location = New System.Drawing.Point(68, 12)
Me.cmbStructureListings.Size = New System.Drawing.Size(104, 22)
'
'ClassPage
'
Me.ClassPage.Controls.Add(Me.cmbClassListings)
Me.ClassPage.Controls.Add(Me.Label5)
Me.ClassPage.Controls.Add(Me.txtClassListing)
Me.ClassPage.Location = New System.Drawing.Point(4, 4)
Me.ClassPage.Size = New System.Drawing.Size(232, 244)
Me.ClassPage.Text = "Class"
'
'cmbClassListings
'
Me.cmbClassListings.Items.Add("11111")
Me.cmbClassListings.Items.Add("22222")
Me.cmbClassListings.Items.Add("33333")
Me.cmbClassListings.Location = New System.Drawing.Point(68, 12)
Me.cmbClassListings.Size = New System.Drawing.Size(104, 22)
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(13, 16)
Me.Label5.Size = New System.Drawing.Size(51, 20)
Me.Label5.Text = "Listing:"
'
'txtClassListing
'
Me.txtClassListing.Location = New System.Drawing.Point(12, 44)
Me.txtClassListing.Multiline = True
Me.txtClassListing.Size = New System.Drawing.Size(208, 180)
Me.txtClassListing.Text = "[ no listing ]"
'
'DataSetPage
'
Me.DataSetPage.Controls.Add(Me.btnGrabData)
Me.DataSetPage.Controls.Add(Me.DataGrid1)
Me.DataSetPage.Location = New System.Drawing.Point(4, 4)
Me.DataSetPage.Size = New System.Drawing.Size(232, 244)
Me.DataSetPage.Text = "DataSet"
'
'btnGrabData
'
Me.btnGrabData.Location = New System.Drawing.Point(152, 216)
Me.btnGrabData.Text = "Grab Data"
'
'DataGrid1
'
Me.DataGrid1.Size = New System.Drawing.Size(240, 200)
Me.DataGrid1.Text = "DataGrid1"
'
'AsyncPage
'
Me.AsyncPage.Controls.Add(Me.btnCalcAsync)
Me.AsyncPage.Controls.Add(Me.txtAsyncPay)
Me.AsyncPage.Controls.Add(Me.txtAsyncRate)
Me.AsyncPage.Controls.Add(Me.txtAsyncHours)
Me.AsyncPage.Controls.Add(Me.Label8)
Me.AsyncPage.Controls.Add(Me.Label7)
Me.AsyncPage.Controls.Add(Me.Label6)
Me.AsyncPage.Location = New System.Drawing.Point(4, 4)
Me.AsyncPage.Size = New System.Drawing.Size(232, 244)
Me.AsyncPage.Text = "Async"
'
'btnCalcAsync
'
Me.btnCalcAsync.Location = New System.Drawing.Point(152, 216)
Me.btnCalcAsync.Text = "Calc Async"
'
'txtAsyncPay
'
Me.txtAsyncPay.Location = New System.Drawing.Point(80, 84)
Me.txtAsyncPay.Text = ""
'
'txtAsyncRate
'
Me.txtAsyncRate.Location = New System.Drawing.Point(80, 48)
Me.txtAsyncRate.Text = ""
'
'txtAsyncHours
'
Me.txtAsyncHours.Location = New System.Drawing.Point(80, 12)
Me.txtAsyncHours.Text = ""
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(16, 87)
Me.Label8.Size = New System.Drawing.Size(64, 20)
Me.Label8.Text = "Pay:"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(16, 51)
Me.Label7.Size = New System.Drawing.Size(64, 20)
Me.Label7.Text = "Rate:"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(16, 15)
Me.Label6.Size = New System.Drawing.Size(64, 20)
Me.Label6.Text = "Hours:"
'
'Form1
'
Me.Controls.Add(Me.TabControl1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Web Service Client"

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
    Dim ws As New Chapter16.Demo

  ' Call the CalcPay Web Service method.
    Cursor.Current = Cursors.WaitCursor
    txtPay.Text = ws.CalcPay(CSng(txtHours.Text), CSng(txtRate.Text))
    Cursor.Current = Cursors.Default

  End Sub

  Private Sub btnCalcAsync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcAsync.Click
    Dim cb As New AsyncCallback(AddressOf DisplayPayCallBack)

  ' Call the CalcPay Web Service method asynchronously.
    Cursor.Current = Cursors.WaitCursor
    asyncws.BeginCalcPay(CSng(txtAsyncHours.Text), CSng(txtAsyncRate.Text), cb, Nothing)
    Cursor.Current = Cursors.Default

  End Sub

  Private Sub btnGrabData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabData.Click
    Dim ws As New Chapter16.Demo
    Dim ds As DataSet

  ' Retrieve the data.
    Cursor.Current = Cursors.WaitCursor
    ds = ws.DsDemo

  ' We need a DataTable for the binding process.
    Dim dt As DataTable = ds.Tables(0)

  ' Bind the DataGrid.
    DataGrid1.Visible = False
    DataGrid1.DataSource = dt
    DataGrid1.Visible = True
    Cursor.Current = Cursors.Default

  End Sub

  Private Sub cmbClassListings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassListings.SelectedIndexChanged
    Dim ws As New Chapter16.Demo
    Dim Listing As Chapter16.DemoClass

  ' Call the Class Demo Web Service method.
    Cursor.Current = Cursors.WaitCursor
    Listing = ws.ClassDemo(cmbClassListings.Text)
    Cursor.Current = Cursors.Default

  ' Display the listing.
    DisplayClassListing(txtClassListing, Listing)

  End Sub

  Private Sub cmbStructureListings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStructureListings.SelectedIndexChanged
    Dim ws As New Chapter16.Demo
    Dim Listing As Chapter16.ListingSpecs

  ' Call the Structure Demo Web Service method.
    Cursor.Current = Cursors.WaitCursor
    Listing = ws.StructureDemo(cmbStructureListings.Text)
    Cursor.Current = Cursors.Default

  ' Display the listing.
    DisplayStructureListing(txtStructureListing, Listing)

  End Sub

#End Region

#Region " General Procedures "

  Sub DisplayClassListing(ByVal myTextBox As TextBox, ByVal Listing As Chapter16.DemoClass)
    Dim temp As String

  ' Format the listing.
    temp = "Price: " & Listing.Price & vbCrLf
    temp += "Address: " & Listing.Address & vbCrLf
    temp += "Square Feet: " & Listing.Size & vbCrLf
    temp += "Baths: " & Listing.Baths & vbCrLf
    temp += "Bedrooms: " & Listing.Bedrooms & vbCrLf
    temp += "Rooms: " & Listing.Rooms & vbCrLf

  ' Display the listing.
    myTextBox.Text = temp

  End Sub

  Sub DisplayPayCallBack(ByVal ar As IAsyncResult)

  ' Handle the delayed response from the web service.
    txtAsyncPay.Text = asyncws.EndCalcPay(ar)

  End Sub

  Sub DisplayStructureListing(ByVal myTextBox As TextBox, ByVal Listing As Chapter16.ListingSpecs)
    Dim temp As String

  ' Format the listing.
    temp = "Price: " & Listing.Price & vbCrLf
    temp += "Address: " & Listing.Address & vbCrLf
    temp += "Square Feet: " & Listing.Size & vbCrLf
    temp += "Baths: " & Listing.Baths & vbCrLf
    temp += "Bedrooms: " & Listing.Bedrooms & vbCrLf
    temp += "Rooms: " & Listing.Rooms & vbCrLf

  ' Display the listing.
    myTextBox.Text = temp

  End Sub

#End Region

End Class
