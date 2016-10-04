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

Imports FieldSoftware.PrinterCE_NetCF
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.Strings

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents txtOrdered As System.Windows.Forms.TextBox
    Friend WithEvents txtShipped As System.Windows.Forms.TextBox
    Friend WithEvents lblShipped As System.Windows.Forms.Label
    Friend WithEvents lblOrdered As System.Windows.Forms.Label
    Friend WithEvents lvwOrder As System.Windows.Forms.ListView
    Friend WithEvents cmbOrders As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCustomers As System.Windows.Forms.ComboBox
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
  Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.txtOrdered = New System.Windows.Forms.TextBox
Me.txtShipped = New System.Windows.Forms.TextBox
Me.lblShipped = New System.Windows.Forms.Label
Me.lblOrdered = New System.Windows.Forms.Label
Me.lvwOrder = New System.Windows.Forms.ListView
Me.cmbOrders = New System.Windows.Forms.ComboBox
Me.cmbCustomers = New System.Windows.Forms.ComboBox
Me.mnuPrint = New System.Windows.Forms.MenuItem
'
'MainMenu1
'
Me.MainMenu1.MenuItems.Add(Me.mnuPrint)
'
'txtOrdered
'
Me.txtOrdered.Location = New System.Drawing.Point(48, 55)
Me.txtOrdered.Size = New System.Drawing.Size(72, 22)
Me.txtOrdered.Text = ""
'
'txtShipped
'
Me.txtShipped.Location = New System.Drawing.Point(156, 55)
Me.txtShipped.Size = New System.Drawing.Size(72, 22)
Me.txtShipped.Text = ""
'
'lblShipped
'
Me.lblShipped.Location = New System.Drawing.Point(124, 59)
Me.lblShipped.Size = New System.Drawing.Size(32, 16)
Me.lblShipped.Text = "Ship:"
'
'lblOrdered
'
Me.lblOrdered.Location = New System.Drawing.Point(8, 59)
Me.lblOrdered.Size = New System.Drawing.Size(56, 16)
Me.lblOrdered.Text = "Order:"
'
'lvwOrder
'
Me.lvwOrder.Location = New System.Drawing.Point(8, 79)
Me.lvwOrder.Size = New System.Drawing.Size(224, 184)
'
'cmbOrders
'
Me.cmbOrders.Location = New System.Drawing.Point(8, 31)
Me.cmbOrders.Size = New System.Drawing.Size(224, 22)
'
'cmbCustomers
'
Me.cmbCustomers.Location = New System.Drawing.Point(8, 7)
Me.cmbCustomers.Size = New System.Drawing.Size(224, 22)
'
'mnuPrint
'
Me.mnuPrint.Text = "Print"
'
'Form1
'
Me.Controls.Add(Me.txtOrdered)
Me.Controls.Add(Me.txtShipped)
Me.Controls.Add(Me.lblShipped)
Me.Controls.Add(Me.lblOrdered)
Me.Controls.Add(Me.lvwOrder)
Me.Controls.Add(Me.cmbOrders)
Me.Controls.Add(Me.cmbCustomers)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Northwind Mobile"

    End Sub

#End Region

#Region " Event Procedures "

  Private Sub cmbCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomers.SelectedIndexChanged

  ' Load the orders for the selected customer.
    LoadOrders()

  ' Select the first order for this customer.
    cmbOrders.SelectedIndex = 0

  End Sub

  Private Sub cmbOrders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrders.SelectedIndexChanged
  ' Load the order details for the selected order.
    LoadOrderDetails()
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  ' Format the ListView control.
    FormatListView()

  ' Load the Customer combo box.
    LoadCustomers()

  End Sub

  Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
    PrintInvoice()
  End Sub

#End Region

#Region " General Procedures "

  Private Function ApplicationLocation() As String
    Dim strTemp As String

  ' Fetch and return the location where the application was launched.
    strTemp = System.IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString())
    If (Microsoft.VisualBasic.Strings.Right(strTemp, 1) <> "/") Then
      ApplicationLocation = strTemp & "\"
    Else
      ApplicationLocation = strTemp
    End If

  End Function

  Private Sub FormatListView()
' This routine handles configuring the listview control.
    lvwOrder.View = View.Details

    lvwOrder.Columns.Add("Product", 120, HorizontalAlignment.Left)
    lvwOrder.Columns.Add("Qty", 40, HorizontalAlignment.Right)
    lvwOrder.Columns.Add("Price", 50, HorizontalAlignment.Right)
    lvwOrder.Columns.Add("Disc", 50, HorizontalAlignment.Right)
    lvwOrder.Columns.Add("Total", 90, HorizontalAlignment.Right)

  End Sub

  Private Sub LoadCustomers()
    Dim cn As SqlCeConnection
    Dim cmd As SqlCeCommand
    Dim dtr As SqlCeDataReader

  ' Open the database.
    cn = New SqlCeConnection
    cn.ConnectionString = "Data Source = " & ApplicationLocation() & "NorthwindDemo.sdf"
    cn.Open()

  ' Retrieve a list of the customers.
    cmd = New SqlCeCommand("SELECT * FROM Customers", cn)
    dtr = cmd.ExecuteReader()

  ' Load the list into the customer combo box.
    cmbCustomers.Items.Clear()
    While dtr.Read()
      cmbCustomers.Items.Add(dtr("CompanyName"))
    End While

  ' Clean-up.
    dtr.Close()
    cn.Close()

  ' Select the first customer.
    cmbCustomers.SelectedIndex = 0

  End Sub

  Private Sub LoadOrders()
    Dim cn As System.Data.SqlServerCe.SqlCeConnection
    Dim cmd As System.Data.SqlServerCe.SqlCeCommand
    Dim dtr As System.Data.SqlServerCe.SqlCeDataReader
    Dim SQL As String

  ' Open the database.
    cn = New SqlCeConnection
    cn.ConnectionString = "Data Source = " & ApplicationLocation() & "NorthwindDemo.sdf"
    cn.Open()

  ' Retrieve the orders for the selected customer.
    SQL = "SELECT Orders.OrderID FROM Orders INNER JOIN Customers ON "
    SQL = SQL & "Orders.CustomerID = Customers.CustomerID WHERE "
    SQL = SQL & "(Customers.CompanyName = '" & cmbCustomers.Text
    SQL = SQL & "')"
    cmd = New SqlCeCommand(SQL, cn)
    dtr = cmd.ExecuteReader()

  ' Load the list into the order combo box.
    cmbOrders.Items.Clear()
    While dtr.Read()
      cmbOrders.Items.Add(dtr("OrderID"))
    End While

  ' Clean-up.
    dtr.Close()
    cn.Close()

  End Sub

  Private Sub LoadOrderDetails()
    Dim cn As System.Data.SqlServerCe.SqlCeConnection
    Dim cmd As System.Data.SqlServerCe.SqlCeCommand
    Dim Discount As Single
    Dim dtr As System.Data.SqlServerCe.SqlCeDataReader
    Dim ItemTotal As Single
    Dim LVItem As ListViewItem
    Dim OrderTotal As Single
    Dim Quantity As Int16
    Dim SQL As String
    Dim UnitPrice As Single

  ' Open the database.
    cn = New SqlCeConnection
    cn.ConnectionString = "Data Source = " & ApplicationLocation() & "NorthwindDemo.sdf"
    cn.Open()

  ' Retrieve the order summary information.
    SQL = "SELECT OrderDate, ShippedDate FROM Orders WHERE "
    SQL = SQL & "OrderID = " & cmbOrders.Text
    cmd = New SqlCeCommand(SQL, cn)
    dtr = cmd.ExecuteReader()

    dtr.Read()
    txtOrdered.Text = dtr("OrderDate")
    txtShipped.Text = dtr("ShippedDate")
    dtr.Close()

  ' Retrieve the order details for the selected order.
    SQL = "SELECT " & Chr(34) & "Order Details" & Chr(34) & ".UnitPrice, " & Chr(34) & "Order Details" & Chr(34) & ".Quantity, "
    SQL = SQL & Chr(34) & "Order Details" & Chr(34) & ".Discount, Products.ProductName FROM " & Chr(34) & "Order Details" & Chr(34) & " "
    SQL = SQL & "INNER JOIN Products ON "
    SQL = SQL & Chr(34) & "Order Details" & Chr(34) & ".ProductID = Products.ProductID WHERE "
    SQL = SQL & Chr(34) & "Order Details" & Chr(34) & ".OrderID = " & cmbOrders.Text
    cmd = New SqlCeCommand(SQL, cn)
    dtr = cmd.ExecuteReader()

  ' Load the order details into the ListView control.
    lvwOrder.Items.Clear()
    While dtr.Read()
      LVItem = New ListViewItem
      LVItem.Text = dtr("ProductName")
      Quantity = dtr("Quantity")
      LVItem.SubItems.Add(Quantity.ToString)
      UnitPrice = dtr("UnitPrice")
      LVItem.SubItems.Add(UnitPrice.ToString("N2"))
      Discount = dtr("Discount")
      LVItem.SubItems.Add(Discount.ToString("N2"))

      ItemTotal = Quantity * UnitPrice * (1 - Discount)
      OrderTotal = OrderTotal + ItemTotal
      LVItem.SubItems.Add(ItemTotal.ToString("N2"))

      lvwOrder.Items.Add(LVItem)

    End While

  ' Add the total for the order.
    LVItem = New ListViewItem
    LVItem.Text = "TOTAL"
    LVItem.SubItems.Add("")
    LVItem.SubItems.Add("")
    LVItem.SubItems.Add("")
    LVItem.SubItems.Add(OrderTotal.ToString("N2"))
    lvwOrder.Items.Add(LVItem)

  ' Clean-up.
    dtr.Close()
    cn.Close()

  End Sub

  Private Sub PrintInvoice()
    Dim curItemTotal As Single
    Dim curTotalAmount As Single
    Dim intCounter As Integer
    Dim prce As PrinterCE

  ' Create an instance of the printer object.
    prce = New PrinterCE(PrinterCE.EXCEPTION_LEVEL.ABORT_JOB, "YourLicense")

  ' Prompt the user to select printing attributes.
    prce.SelectPrinter(True)

  ' Setup the layout and margins.
    With prce
      .PrOrientation = PrinterCE_Base.ORIENTATION.PORTRAIT ' Portrait mode
      .ScaleMode = PrinterCE_Base.MEASUREMENT_UNITS.INCHES ' Work in inches
      .PrLeftMargin = 0.5
      .PrTopMargin = 0.7
      .PrRightMargin = 0.5
      .PrBottomMargin = 0.7
      .DrawWidth = 0.02

  ' Begin to draw the invoice starting with the top rectangle.
      .DrawRect(0, 0, 5.7, 0.5)

  ' Add a shaded rectangle.
      .FillColor = System.Drawing.Color.LightGray
      .FillStyle = PrinterCE.FILL_STYLE.SOLID
      .DrawRect(0, 0, 5.7, 0.25)
      .DrawLine(2, 0, 2, 0.5)
      .DrawLine(3.8, 0, 3.8, 0.5)

  ' Add the top headers.
      .FontSize = 12
      .FontBold = True
      .ForeColor = System.Drawing.Color.Black
      .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.CENTER
      .JustifyVert = PrinterCE_Base.JUSTIFY_VERT.CENTER

      .DrawText("Account Number", 1, 0.125)
      .DrawText("Order Number", 2.9, 0.125)
      .DrawText("Payment Due By", 4.75, 0.125)

  ' Add the total amount box. This is accomplished by drawing a
  ' black box with a smaller white box over top of it.
      .FillColor = System.Drawing.Color.DarkGray
      .DrawRect(5.7, 0, 7.5, 0.7)
      .ForeColor = System.Drawing.Color.White
      .FontSize = 9
      .FontBoldVal = 1000      ' Set to maximum value.
      .DrawText("PLEASE PAY THIS AMOUNT", 6.6, 0.1)
      .FillColor = System.Drawing.Color.White
      .DrawRoundedRect(5.8, 0.2, 7.4, 0.6, 0.15, 0.15)

  ' Set the drawing color back to black after finishing the white box.
      .ForeColor = System.Drawing.Color.Black

  ' Add late payment box.
      .FontSize = 12
      .FontBold = False
      .DrawRect(5, 1.9, 7.5, 2.6)
      .DrawText("To avoid Late Payment charge,", 6.25, 2.05)
      .DrawText("full payment must be received by", 6.25, 2.25)

   ' Add invoice footer.
      .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.LEFT
      .FontSize = 8
      .DrawText("PLEASE RETURN THIS STUB WITH PAYMENT", 0, 2.8)
      .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.RIGHT
      .DrawText("TO ENSURE PROPER CREDIT, PLEASE WRITE YOUR " & _
        "ACCOUNT NUMBER ON YOU CHECK.", 7.5, 2.8)
      .FontSize = 14
      .FontBold = True
      .FontItalic = True
      .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.CENTER
      .DrawText("THANK YOU FOR YOUR PROMPT PAYMENT", 2.5, 2.5)

   ' Add the item header bar.
      .FillColor = System.Drawing.Color.LightGray
      .FillStyle = PrinterCE.FILL_STYLE.SOLID
      .DrawRect(0, 3.1, 7.5, 3.35)
      .DrawLine(2, 3.1, 2, 3.35)
      .DrawLine(3.8, 3.1, 3.8, 3.35)
      .DrawLine(5.7, 3.1, 5.7, 3.35)

   ' Add the item header titles.
      .FontSize = 12
      .FontBold = True
      .FontItalic = False
      .ForeColor = System.Drawing.Color.Black
      .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.CENTER
      .JustifyVert = PrinterCE_Base.JUSTIFY_VERT.CENTER

      .DrawText("Product", 1, 3.225)
      .DrawText("Quantity", 2.9, 3.225)
      .DrawText("Unit Price", 4.75, 3.225)
      .DrawText("Item Total", 6.75, 3.225)

   ' Fill in data component of the invoice. Some of the content
   ' is hardcoded, but could just as easily be retrieved from a
   ' database.
      .FontBold = False
      .FontItalic = False
      .FillStyle = PrinterCE.FILL_STYLE.TRANSPARENT

   ' Print the account number and order number.
      .DrawText("06-036171-408", 1, 0.375)
      .DrawText("R52581782D-AB", 2.9, 0.375)

   ' Add the due dates.
      .DrawText(DateAdd(DateInterval.Day, 30, Date.Today), 4.75, 0.375)
      .FontSize = 12
      .DrawText(DateAdd(DateInterval.Day, 30, Date.Today), 6.25, 2.45)

   ' Add the line items.
      .FontSize = 14
      For intCounter = 0 To lvwOrder.Items.Count - 2
        .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.LEFT
        .DrawText(lvwOrder.Items(intCounter).Text, 0, _
           3.5 + (intCounter * 0.25))
        .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.RIGHT
        .DrawText(lvwOrder.Items(intCounter).SubItems(1).Text, _
          2.9, 3.5 + (intCounter * 0.25))
        .DrawText(lvwOrder.Items(intCounter).SubItems(2).Text, _
           5.0, 3.5 + (intCounter * 0.25))

   ' Calculate and print the total of this line item.
        curItemTotal = (CSng(lvwOrder.Items(intCounter).SubItems(1).Text) * _
         CSng(lvwOrder.Items(intCounter).SubItems(2).Text))
        .DrawText(FormatCurrency(curItemTotal.ToString), 7, 3.5 + (intCounter * 0.25))

   ' Add the amount of this line item to the running total.
        curTotalAmount = curTotalAmount + curItemTotal

      Next intCounter

   ' Add the total amount.
     .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.CENTER
     .FontSize = 16
     .FontBold = True
     .DrawText(FormatCurrency(curTotalAmount), 6.6, 0.4)

     .JustifyHoriz = PrinterCE_Base.JUSTIFY_HORIZ.LEFT
     .FontSize = 16
     .FontBold = False
     .DrawText(cmbCustomers.Items(cmbCustomers.SelectedIndex), _
        0.5, 1.2)
     .DrawText("1217 5th Avenue")
     .DrawText("New York, NY 10010")

   ' Add line between header and order content.
     .DrawWidth = 0.01
     .DrawLine(0, 3, 7.5, 3)

   ' Complete the print document.
     .EndDoc()
   End With
End Sub

#End Region

End Class
