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

Imports System.Web.Services

<System.Web.Services.WebService(Namespace:="http://tempuri.org/WebServiceDemo/Demo")> _
Public Class Demo
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    <WebMethod()> _
    Public Function HelloWorld() As String
       Return "Hello World"
    End Function

    Public Structure ListingSpecs
      Public ListingNumber As String
      Public Address As String
      Public Rooms As Integer
      Public Bedrooms As Single
      Public Baths As Single
      Public Size As Integer
      Public Price As String
    End Structure

    <WebMethod()> _
    Public Function CalcPay(ByVal Hours As Single, ByVal Rate As Single) As Single

    ' Calculate the employee's pay.
       Return Hours * Rate

    End Function

    <WebMethod()> _
    Public Function StructureDemo(ByVal ListingNumber As String) As ListingSpecs
      Dim mySpec As ListingSpecs

    ' Grab the specs for the requested listing.
      Select Case ListingNumber
        Case "11111"
          mySpec.ListingNumber = "11111"
          mySpec.Address = "111 Main Street"
          mySpec.Rooms = 10
          mySpec.Bedrooms = 3
          mySpec.Baths = 2.5
          mySpec.Size = 2400
          mySpec.Price = "$240,000"
        Case "22222"
          mySpec.ListingNumber = "22222"
          mySpec.Address = "222 East Maple Street"
          mySpec.Rooms = 8
          mySpec.Bedrooms = 2
          mySpec.Baths = 1.5
          mySpec.Size = 1800
          mySpec.Price = "$190,000"
        Case "33333"
          mySpec.ListingNumber = "33333"
          mySpec.Address = "333 Front Street"
          mySpec.Rooms = 9
          mySpec.Bedrooms = 3
          mySpec.Baths = 2
          mySpec.Size = 2050
          mySpec.Price = "$225,000"
      End Select

    ' Return the selected listing.
      Return mySpec

    End Function

    <WebMethod()> _
    Public Function ClassDemo(ByVal ListingNumber As String) As DemoClass
      Dim myDemo As New DemoClass

    ' Grab the specs for the requested listing.
      Select Case ListingNumber
        Case "11111"
          myDemo.ListingNumber = "11111"
          myDemo.Address = "111 Main Street"
          myDemo.Rooms = 10
          myDemo.Bedrooms = 3
          myDemo.Baths = 2.5
          myDemo.Size = 2400
          myDemo.Price = "$240,000"
        Case "22222"
          myDemo.ListingNumber = "22222"
          myDemo.Address = "222 East Maple Street"
          myDemo.Rooms = 8
          myDemo.Bedrooms = 2
          myDemo.Baths = 1.5
          myDemo.Size = 1800
          myDemo.Price = "$190,000"
        Case "33333"
          myDemo.ListingNumber = "33333"
          myDemo.Address = "333 Front Street"
          myDemo.Rooms = 9
          myDemo.Bedrooms = 3
          myDemo.Baths = 2
          myDemo.Size = 2050
          myDemo.Price = "$225,000"
      End Select

    ' Return the selected listing.
      Return myDemo

    End Function

    <WebMethod()> _
    Public Function DsDemo() As DataSet
      Dim strSQL As String
      Dim cn As SqlClient.SqlConnection
      Dim da As SqlClient.SqlDataAdapter
      Dim ds As DataSet

    ' Retrieve the Employees table.
      strSQL = "SELECT * FROM Employees"
      cn = New SqlClient.SqlConnection("Server=localhost;UID=sa;Database=Northwind")
      da = New SqlClient.SqlDataAdapter(strSQL, cn)

    ' Add the table to a dataset.
      ds = New DataSet
      da.Fill(ds, "Employees")

    ' Return the dataset.
      Return ds

    End Function

End Class
