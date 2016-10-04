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
Imports System.Data.SqlClient

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents Button1 As System.Windows.Forms.Button
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(160, 248)
        Me.Button1.Size = New System.Drawing.Size(224, 20)
        Me.Button1.Text = "Load the Data"
        Me.Button1.Visible = False
        '
        'DataGrid1
        '
        Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
        Me.DataGrid1.Size = New System.Drawing.Size(224, 232)
        Me.DataGrid1.Text = "DataGrid1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(160, 224)
        Me.Button2.Size = New System.Drawing.Size(224, 20)
        Me.Button2.Text = "Load the Data"
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(8, 248)
        Me.Button3.Size = New System.Drawing.Size(224, 20)
        Me.Button3.Text = "Load the Data via DataSet"
        '
        'Form1
        '
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button1)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim ds As DataSet = New DataSet("Sample")
        'Dim conNwindCE As SqlConnection = New SqlConnection("server=192.168.1.101;database=Nwind_SQLCE;Trusted_Connection=Yes;")
        ''        Dim conNwindCE As SqlConnection = New SqlConnection("server=192.168.1.101;database=Nwind_SQLCE;user id=sa;pwd=antietam;")
        'Dim ad As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Customers", conNwindCE)

        'Try
        '    ad.Fill(ds)
        '    Me.DataGrid1.DataSource = ds.Tables(0)
        'Catch ex As Exception
        '    Dim str As String = ex.Message
        'End Try

        CallStoredProcWithArgs()
        Return

        Dim conNwindCE As SqlConnection
        Dim cmdData As SqlCommand
        Dim strValue As String
        Dim guidValue As Guid
        Dim curValue As Data.SqlTypes.SqlMoney

        Try
            Dim connString As String

            '   Create and open a connection
            connString = "server=169.254.223.37;database=Nwind_SQLCE;"
            connString &= "user id=sa;pwd=antietam;"
            conNwindCE = New SqlConnection(connString)
            conNwindCE.Open()

            '   Reuse the command with a DataReader
            cmdData = New SqlCommand
            cmdData.CommandType = CommandType.StoredProcedure
            cmdData.CommandText = "Ten Most Expensive Products"

            'cmdData.CommandText = "SELECT * FROM Customers "
            cmdData.Connection = conNwindCE
            Dim dr As SqlDataReader = cmdData.ExecuteReader(CommandBehavior.SequentialAccess)
            '   Pull data from the reader and do some work
            While dr.Read()
                curValue = dr.GetSqlMoney(1)
                strValue = dr.Item(0)
                'strValue = dr.Item("CompanyName")
                'guidValue = dr.GetGuid(11)      '.Item("rowguid")
                'strValue = dr.Item("Contactname")
            End While
            dr.Close()
        Catch ex As Exception
        Finally
            conNwindCE.Close()
        End Try

    End Sub

    Public Sub CallStoredProcWithArgs()
        Dim conNwindCE As SqlConnection
        Dim cmdData As SqlCommand

        Try
            Dim connString As String
            Dim paramCustomerID As SqlParameter

            '   Create and open a connection
            connString = "server=antietam;database=Nwind_SQLCE;"
            connString &= "user id=sa;pwd=antietam;"
            conNwindCE = New SqlConnection(connString)
            conNwindCE.Open()

            '   Create a new SqlCommand object
            cmdData = New SqlCommand
            cmdData.CommandType = CommandType.StoredProcedure
            cmdData.CommandText = "CustOrderHist"

            paramCustomerID = New SqlParameter("@CustomerID", SqlDbType.NVarChar)
            paramCustomerID.Value = "ALFKI"
            cmdData.Parameters.Add("@CustomerID", "ALFKI")
            cmdData.Connection = conNwindCE
            Dim dr As SqlDataReader = cmdData.ExecuteReader()

            '   Pull data from the reader and do some work
            While dr.Read()
                Dim retValue = dr.Item(0)
            End While
            dr.Close()
        Catch ex As Exception
        Finally
            conNwindCE.Close()
        End Try
    End Sub

    Public Sub GetResultSets()
        Dim conNwindCE As SqlConnection
        Dim cmdData As SqlCommand
        Dim connString As String
        Dim dr As SqlDataReader

        Try
            '   Create and open a connection
            connString = "server=169.254.223.37;database=Nwind_SQLCE;"
            connString &= "user id=sa;pwd=antietam;"
            conNwindCE = New SqlConnection(connString)
            conNwindCE.Open()

            '   Create a new command object
            cmdData = New SqlCommand
            cmdData.CommandText = "SELECT * FROM Customers;SELECT * FROM CustOrderHist"
            cmdData.Connection = conNwindCE

            dr = cmdData.ExecuteReader()
            While dr.Read

            End While

            If dr.NextResult() Then
                While dr.Read

                End While
            End If
            dr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            dr.Close()
            conNwindCE.Close()
        End Try
    End Sub
    Public Function GetMyData() As SqlDataReader
        Dim conNwindCE As SqlConnection
        Dim cmdData As SqlCommand
        Dim connString As String

        Try
            '   Create and open a connection
            connString = "server=169.254.223.37;database=Nwind_SQLCE;"
            connString &= "user id=sa;pwd=antietam;"
            conNwindCE = New SqlConnection(connString)
            conNwindCE.Open()

            '   Create a new command object
            cmdData = New SqlCommand
            cmdData.CommandText = "SELECT * FROM Customers"
            cmdData.Connection = conNwindCE

            Return cmdData.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            '            conNwindCE.Close()
        End Try
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim iRet As Integer
        Dim conNwindCE As SqlConnection
        Dim bRet As Boolean

        Try
            Dim connString As String

            '   Create and open a connection
            connString = "server=169.254.223.37;database=Nwind_SQLCE;user id=sa;pwd=antietam;"
            conNwindCE = New SqlConnection(connString)
            conNwindCE.Open()

            '   Create a command object
            Dim cmdData As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM Customers", conNwindCE)
            iRet = cmdData.ExecuteScalar()

            '   Reuse the command object
            cmdData.CommandText = "DELETE FROM Customers WHERE CustomerID=?"
            Dim parameter As SqlParameter = cmdData.Parameters.Add("CustomerID", SqlDbType.VarChar)
            parameter.Value = "HILAA"
            cmdData.ExecuteNonQuery()

            cmdData.CommandText = "SELECT * FROM Customers AS AUTO XML"
            Dim xml As Xml.XmlReader = cmdData.ExecuteXmlReader()

            '   Reuse the command with a DataReader
            cmdData.CommandText = "SELECT * FROM Customers;SELECT * FROM Categories"
            Dim dr As SqlDataReader = cmdData.ExecuteReader()
            dr.Read()
            bRet = dr.NextResult()
            dr.Read()
            bRet = dr.NextResult()
            dr.Read()
            dr.Close()
        Catch ex As Exception
        Finally
            conNwindCE.Close()
        End Try

    End Sub
    Public Sub DoingTransactions()
        Dim conNwindCE As SqlConnection
        Dim cmdData As SqlCommand
        Dim connString As String
        Dim transNwindCE As SqlTransaction

        Try
            '   Create and open a connection
            connString = "server=169.254.223.37;database=Nwind_SQLCE;"
            connString &= "user id=sa;pwd=antietam;"
            conNwindCE = New SqlConnection(connString)
            conNwindCE.Open()

            Dim myCommand As SqlCommand = conNwindCE.CreateCommand()

            '   Create a transaction!
            transNwindCE = conNwindCE.BeginTransaction("ShowTransaction")
            myCommand.Connection = conNwindCE
            myCommand.Transaction = transNwindCE

            myCommand.CommandText = "INSERT INTO <more stuff>"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = "INSERT INTO <different stuff>"
            myCommand.ExecuteNonQuery()
            transNwindCE.Commit()
        Catch ex As SqlException
            transNwindCE.Rollback("ShowTransaction")
            MessageBox.Show("An exception of type " & _
                ex.GetType().ToString() & _
                " has occured")
        Finally
            conNwindCE.Close()
        End Try

    End Sub

    Public Function GetMyDataSet() As DataSet
        Dim conNwindCE As SqlConnection
        Dim adapterData As SqlDataAdapter
        Dim cmdData As SqlCommand
        Dim connString As String

        Try
            '   Create and open a connection
            connString = "server=antietam;database=Apress;"
            connString &= "user id=webUser;pwd=passw0rd;"
            conNwindCE = New SqlConnection(connString)

            '   Create a new command object
            adapterData = New SqlDataAdapter("SELECT * FROM Customers", connString)

            Dim ds As DataSet = New DataSet
            adapterData.Fill(ds)

            Dim strCustomerID As String
            Dim strCustomerName As String
            Dim strContactName As String

            For Each dr As DataRow In ds.Tables(0).Rows
                strCustomerID = dr.Item(0)
                strCustomerName = dr.Item(1)
                strContactName = dr.Item("ContactName")
            Next
            Return ds
        Catch ex As SqlException
            Dim errCollection As SqlErrorCollection = ex.Errors
            For Each err As SqlError In errCollection
                MessageBox.Show(err.Message)
            Next
            MessageBox.Show(ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            Dim ds As DataSet = GetMyDataSet()
            Me.DataGrid1.DataSource = GetMyData() 'ds.Tables(0)
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try
    End Sub
End Class
