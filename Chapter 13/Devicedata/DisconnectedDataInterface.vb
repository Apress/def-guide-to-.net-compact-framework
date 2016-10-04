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
Imports System.Data.SqlServerCe
Imports System.Text

Public Class DataInterfaceDisconnected
    Implements IDisposable

    Private m_localDatabaseName As String = "\My Documents\Chapter13.sdf"
    Private m_localDataSource As String = "Data Source=" & m_localDatabaseName & ";"
    Private m_localConnection As SqlCeConnection

    Public Sub New()
        m_localConnection = New SqlCeConnection(m_localDataSource)
    End Sub

#Region "Create Database Methods"
    Public Function CreateDatabase() As Boolean
        Dim boolCreateNewDatabase As Boolean = True

        '   Does the database already exist?
        If System.IO.File.Exists(m_localDatabaseName) Then
            System.IO.File.Delete(m_localDatabaseName)
            '   Ask if we should delete it
            boolCreateNewDatabase = True
        End If

        If boolCreateNewDatabase Then
            Dim eng As SqlCeEngine = New SqlCeEngine(m_localDataSource)
            eng.CreateDatabase()
        End If
    End Function

    Public Function CreateDatabase(ByVal strPassword As String) As Boolean
        Dim boolCreateNewDatabase As Boolean = True
        Dim connectString As String

        If strPassword = String.Empty Then
            Throw New ArgumentNullException
        End If

        '   Does the database already exist?
        If System.IO.File.Exists(m_localDatabaseName) Then
            '   Ask if we should delete it
            boolCreateNewDatabase = False
        End If

        If boolCreateNewDatabase Then
            m_localDataSource = m_localDataSource & "password=" & strPassword & ";"
            Dim eng As SqlCeEngine = New SqlCeEngine(m_localDataSource)
            eng.CreateDatabase()
        End If
    End Function

    Public Function CreateDatabase(ByVal strPassword As String, ByVal bEncrypt As Boolean) As Boolean
        Dim boolCreateNewDatabase As Boolean = True
        Dim connectString As String

        If strPassword.Empty Then
            Throw New ArgumentNullException
        End If

        '   Does the database already exist?
        If System.IO.File.Exists(m_localDataSource) Then
            '   Ask if we should delete it
            boolCreateNewDatabase = False
        End If

        If boolCreateNewDatabase Then
            Dim eng As SqlCeEngine
            m_localDataSource = m_localDataSource & "password=" & strPassword & ";"

            If bEncrypt Then
                eng = New SqlCeEngine(m_localDataSource & "Encrypt Database=true;")
            Else
                eng = New SqlCeEngine(m_localDataSource)
            End If
            eng.CreateDatabase()
        End If
    End Function
#End Region

    Public Sub CreateTable()
        Dim localConnection As SqlCeConnection
        localConnection = New SqlCeConnection(m_localDataSource)

        '   Create the tables
        Dim buildTables As StringBuilder = New StringBuilder(100)

        buildTables.Append("CREATE TABLE Authors (")
        buildTables.Append("AuthorID int IDENTITY (10,1) PRIMARY KEY")
        buildTables.Append(", Name nvarchar(50) not null")
        buildTables.Append(")")

        Dim cmdCreateTable As SqlCeCommand

        localConnection.Open()
        cmdCreateTable = New SqlCeCommand(buildTables.ToString(), localConnection)
        cmdCreateTable.CommandType = CommandType.Text
        cmdCreateTable.ExecuteNonQuery()

        buildTables.Append("CREATE TABLE Books (")
        buildTables.Append("BookID uniqueidentifier DEFAULT (newid()) not null")
        buildTables.Append(", Title nvarchar(100) not null")
        buildTables.Append(", AuthorID int REFERENCES Authors(AuthorID) not null")
        buildTables.Append(", ISBN nvarchar(25) not null")
        buildTables.Append(", PubDate nvarchar(50) not null")
        buildTables.Append(", Pages int not null")
        buildTables.Append(", Price nvarchar(10) not null")
        buildTables.Append(", Cover nvarchar(100)  null")
        buildTables.Append(")")
        cmdCreateTable.CommandText = buildTables.ToString
        cmdCreateTable.ExecuteNonQuery()
        localConnection.Close()

        AddData()
    End Sub

    Public Function GetData() As SqlCeDataReader
        Try
            Dim localConnection As SqlCeConnection
            localConnection = New SqlCeConnection(m_localDataSource)

            '   Get the Data
            Dim dr As SqlCeDataReader
            Dim cmdGetData As SqlCeCommand

            localConnection.Open()
            cmdGetData = New SqlCeCommand("SELECT * FROM Books", localConnection)
            cmdGetData.CommandType = CommandType.Text
            dr = cmdGetData.ExecuteReader(CommandBehavior.CloseConnection)

            Return dr
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function GetDataSet() As DataSet
        Try
            Dim localConnection As SqlCeConnection
            localConnection = New SqlCeConnection(m_localDataSource)

            '   Get the Data
            Dim da As SqlCeDataAdapter = New SqlCeDataAdapter
            Dim ds As DataSet = New DataSet
            da.SelectCommand = New SqlCeCommand("SELECT * FROM Books", localConnection)
            da.Fill(ds)

            Return ds
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Sub RunNonQuery(ByVal sqlCommandText As String)
        Dim cmdCreateTable As SqlCeCommand

        m_localConnection.Open()
        cmdCreateTable = New SqlCeCommand(sqlCommandText, m_localConnection)
        cmdCreateTable.CommandType = CommandType.Text
        cmdCreateTable.ExecuteNonQuery()
        m_localConnection.Close()

        cmdCreateTable.Dispose()
    End Sub

    Private Sub AddData()
        Dim localConnection As SqlCeConnection
        localConnection = New SqlCeConnection(m_localDataSource)

        Dim insertData As String
        insertData = "INSERT INTO Authors (Name) VALUES('Fergus')"

        Dim cmdCreateTable As SqlCeCommand

        localConnection.Open()
        cmdCreateTable = New SqlCeCommand(insertData, localConnection)
        cmdCreateTable.CommandType = CommandType.Text
        cmdCreateTable.ExecuteNonQuery()

        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Roof')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Abbott')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Allen')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Appleman')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Baker')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Barnaby')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Baum')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Bischof')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Bock')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Borge')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Cagle')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Chand')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Chen')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Clark')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Cook')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Cornell')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Curtin')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Dillon')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Drol')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Duncan')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Ferguson')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Finsel')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Fraser')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Frenz')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Gibbons')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Gilmore')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Golomshtok')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Goodwill')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Gross')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Gunnerson')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Gupta')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Hempel')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Hetland')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Holub')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Jorelid')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Kilburn')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Knudsen')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Kofler')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Kurata')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Kurniawan')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Lafler')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Lakshman')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Lathrop')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Levinson')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Macdonald')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Marquis')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('McCarter')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Monday')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Moore')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Morrill')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Authors (Name) VALUES('Morrison')"
        cmdCreateTable.ExecuteNonQuery()

        cmdCreateTable.CommandText = "INSERT INTO Books (Title, AuthorID, ISBN, PubDate, Pages, Price) VALUES('The Definitive Guide to the Compact Framework', 10, '11111', 'Jul-03', 680, '$59.99')"
        cmdCreateTable.ExecuteNonQuery()
        cmdCreateTable.CommandText = "INSERT INTO Books (Title, AuthorID, ISBN, PubDate, Pages, Price) VALUES('The Definitive Guide to the Compact Framework', 11, '11111', 'Jul-03', 680, '$59.99')"
        cmdCreateTable.ExecuteNonQuery()

    End Sub

    Public Class FieldDescription
        Dim Name As String
        Dim dataType As String
        Dim allowNull As Boolean
        Dim primaryKey As Boolean
    End Class

    Public Sub Dispose() Implements System.IDisposable.Dispose
        m_localConnection.Dispose()
    End Sub
End Class

