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
    Friend WithEvents tabWeather As System.Windows.Forms.TabPage
    Friend WithEvents tabStock As System.Windows.Forms.TabPage
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

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
  Friend WithEvents txtZipcode As System.Windows.Forms.TextBox
  Friend WithEvents lvwWeather As System.Windows.Forms.ListView
  Friend WithEvents btnFetchWeather As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtSymbol As System.Windows.Forms.TextBox
  Friend WithEvents btnFetchStock As System.Windows.Forms.Button
  Friend WithEvents lvwStock As System.Windows.Forms.ListView
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.tabWeather = New System.Windows.Forms.TabPage
Me.btnFetchWeather = New System.Windows.Forms.Button
Me.lvwWeather = New System.Windows.Forms.ListView
Me.txtZipcode = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.tabStock = New System.Windows.Forms.TabPage
Me.lvwStock = New System.Windows.Forms.ListView
Me.btnFetchStock = New System.Windows.Forms.Button
Me.txtSymbol = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
'
'TabControl1
'
Me.TabControl1.Controls.Add(Me.tabWeather)
Me.TabControl1.Controls.Add(Me.tabStock)
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(240, 268)
'
'tabWeather
'
Me.tabWeather.Controls.Add(Me.btnFetchWeather)
Me.tabWeather.Controls.Add(Me.lvwWeather)
Me.tabWeather.Controls.Add(Me.txtZipcode)
Me.tabWeather.Controls.Add(Me.Label1)
Me.tabWeather.Location = New System.Drawing.Point(4, 4)
Me.tabWeather.Size = New System.Drawing.Size(232, 242)
Me.tabWeather.Text = "Weather"
'
'btnFetchWeather
'
Me.btnFetchWeather.Location = New System.Drawing.Point(171, 8)
Me.btnFetchWeather.Size = New System.Drawing.Size(60, 20)
Me.btnFetchWeather.Text = "Fetch"
'
'lvwWeather
'
Me.lvwWeather.Location = New System.Drawing.Point(8, 36)
Me.lvwWeather.Size = New System.Drawing.Size(224, 200)
'
'txtZipcode
'
Me.txtZipcode.Location = New System.Drawing.Point(66, 8)
Me.txtZipcode.Size = New System.Drawing.Size(68, 22)
Me.txtZipcode.Text = ""
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(9, 11)
Me.Label1.Size = New System.Drawing.Size(56, 20)
Me.Label1.Text = "Zipcode:"
'
'tabStock
'
Me.tabStock.Controls.Add(Me.lvwStock)
Me.tabStock.Controls.Add(Me.btnFetchStock)
Me.tabStock.Controls.Add(Me.txtSymbol)
Me.tabStock.Controls.Add(Me.Label2)
Me.tabStock.Location = New System.Drawing.Point(4, 4)
Me.tabStock.Size = New System.Drawing.Size(232, 242)
Me.tabStock.Text = "Stock"
'
'lvwStock
'
Me.lvwStock.Location = New System.Drawing.Point(8, 36)
Me.lvwStock.Size = New System.Drawing.Size(224, 200)
'
'btnFetchStock
'
Me.btnFetchStock.Location = New System.Drawing.Point(171, 8)
Me.btnFetchStock.Size = New System.Drawing.Size(60, 20)
Me.btnFetchStock.Text = "Fetch"
'
'txtSymbol
'
Me.txtSymbol.Location = New System.Drawing.Point(66, 8)
Me.txtSymbol.Size = New System.Drawing.Size(86, 22)
Me.txtSymbol.Text = "msft, coke"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(9, 11)
Me.Label2.Size = New System.Drawing.Size(56, 20)
Me.Label2.Text = "Symbol:"
'
'Form1
'
Me.Controls.Add(Me.TabControl1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Web Service Sampler"

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub btnFetchStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFetchStock.Click
    Dim ws As New com.swanandmokashi.www.StockQuotes
    Dim quotes() As com.swanandmokashi.www.Quote
    Dim quote As com.swanandmokashi.www.Quote
    Dim lvItem As ListViewItem

  ' Retrieve the stock information.
    Cursor.Current = Cursors.WaitCursor
    quotes = ws.GetStockQuotes(txtSymbol.Text)
    Cursor.Current = Cursors.Default

  ' Clear any existing stocks.
    lvwStock.Items.Clear()

  ' Display the stock details
    For Each quote In quotes
      lvItem = New ListViewItem
      With lvItem
        .Text = quote.StockTicker
        .SubItems.Add(quote.StockQuote)
        .SubItems.Add(quote.Change)
        .SubItems.Add(quote.Volume)
      End With
      lvwStock.Items.Add(lvItem)
    Next

  End Sub

  Private Sub btnFetchWeather_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFetchWeather.Click
    Dim ws As New com.ejse.www.Service
    Dim forecast As com.ejse.www.ExtendedWeatherInfo
    Dim aDaysForecast As com.ejse.www.DayForecastInfo

  ' Retrieve the forecast.
    Cursor.Current = Cursors.WaitCursor
    forecast = ws.GetExtendedWeatherInfo(txtZipcode.Text)
    Cursor.Current = Cursors.Default

  ' Clear any existing forecast.
    lvwWeather.Items.Clear()

  ' Display the forecast for the first day.
    aDaysForecast = forecast.Day1
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the second day.
    aDaysForecast = forecast.Day2
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the third day.
    aDaysForecast = forecast.Day3
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the fourth day.
    aDaysForecast = forecast.Day4
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the fifth day.
    aDaysForecast = forecast.Day5
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the sixth day.
    aDaysForecast = forecast.Day6
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the seventh day.
    aDaysForecast = forecast.Day7
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the eigth day.
    aDaysForecast = forecast.Day8
    AddDaysForecast(aDaysForecast)

  ' Display the forecast for the ninth day.
    aDaysForecast = forecast.Day9
    AddDaysForecast(aDaysForecast)

  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    FormatWeatherView()
    FormatStockView()
  End Sub
#End Region

#Region " General Routines "

  Sub AddDaysForecast(ByVal aDaysForecast As com.ejse.www.DayForecastInfo)
    Dim lvItem As ListViewItem

  ' Add the forecast for the specified day to the ListView.
    lvItem = New ListViewItem
    With lvItem
      .Text = aDaysForecast.Date
      .SubItems.Add(aDaysForecast.High)
      .SubItems.Add(aDaysForecast.Low)
      .SubItems.Add(aDaysForecast.Forecast)
    End With
    lvwWeather.Items.Add(lvItem)

  End Sub

  Sub FormatStockView()
  ' This routine handles configuring the stock ListView control.
    With lvwStock
      .View = View.Details
      .Columns.Add("Sym", 50, HorizontalAlignment.Center)
      .Columns.Add("Quote", 50, HorizontalAlignment.Center)
      .Columns.Add("Chg", 50, HorizontalAlignment.Center)
      .Columns.Add("Volume", 80, HorizontalAlignment.Left)
    End With

  End Sub

  Sub FormatWeatherView()
  ' This routine handles configuring the weather ListView control.
    With lvwWeather
      .View = View.Details
      .Columns.Add("Date", 60, HorizontalAlignment.Left)
      .Columns.Add("High", 50, HorizontalAlignment.Center)
      .Columns.Add("Low", 50, HorizontalAlignment.Center)
      .Columns.Add("Forcast", 100, HorizontalAlignment.Left)
    End With

  End Sub

#End Region

End Class
