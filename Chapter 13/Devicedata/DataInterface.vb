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
Imports Microsoft.VisualBasic.ControlChars

Public Class DataInterface : Implements IDisposable
#If False Then
    Const _userName As String = "sa"
    Const _userPassword As String = "fsg-server"
    Const _strDBPath As String = "\Chapter13.SDF"

    Private _dbEngine As SqlCeEngine
    Private _cn As SqlCeConnection = New SqlCeConnection("data source=" & _strDBPath)
    Private _strRemoteConnect As String = "provider=sqloledb;data source=fsg-server;Initial Catalog=apress;" 'user id=sa;password=antietam"
    Const _strLocalConnect As String = "Data Source= " & _strDBPath
    Const _strInternetURL = "http://fsg-server/ssce20/sscesa20.dll"
#Else
    Const _userName As String = "sa"
    Const _userPassword As String = "antietam"
    Const _strDBPath As String = "\Chapter13.SDF"

    Private _dbEngine As SqlCeEngine
    Private _cn As SqlCeConnection = New SqlCeConnection("data source=" & _strDBPath)
    Private _strRemoteConnect As String = "provider=sqloledb;data source=antietam;Initial Catalog=apress;" 'user id=sa;password=antietam"
    Const _strLocalConnect As String = "Data Source= " & _strDBPath
    Const _strInternetURL = "http://antietam/ssce20/sscesa20.dll"
#End If

    ' create RDA object
    Private _rda As SqlCeRemoteDataAccess
    Private _cerepl As SqlCeReplication
    Private _sqlCommand As SqlCeCommand
    Private _dataReader As SqlCeDataReader

    Public Sub Dispose() Implements IDisposable.Dispose
        _rda.Dispose()
        _dbEngine.Dispose()
    End Sub

    Public Sub New()
        '   Try to create the database, if it fails then fine, it already exists
        Try
            _dbEngine = New SqlCeEngine(_strLocalConnect)
            _dbEngine.CreateDatabase()
        Catch ex As Exception
            '   eat the exception
        End Try
        '_strRemoteConnect &= "user id=" & _userName & ";password=" & _userPassword
        _strRemoteConnect &= "Integrated Security=SSPI;"
        _rda = New SqlCeRemoteDataAccess(_strInternetURL, _strLocalConnect)
    End Sub

    Public Sub Replication()
        Dim cerepl As SqlCeReplication = New SqlCeReplication
        With cerepl
            .InternetLogin = "Antietam\Dan"
            .InternetPassword = "scott"
            .InternetUrl = "http://antietam/ssce20/sscesa20.dll"

            '	set the publisher
            .Publication = "Apress_Pub"
            .PublisherDatabase = "Apress"
            .Publisher = "Antietam"
            .PublisherSecurityMode = SecurityType.NTAuthentication
            .PublisherLogin = String.Empty
            .PublisherPassword = String.Empty
            '       .PublisherLogin = _userName
            '       .PublisherPassword = _userPassword

            .Subscriber = "Apress_Sub"
            .SubscriberConnectionString = "data source=\Chapter13.SDF"
        End With

        Cursor.Current = Cursors.WaitCursor
        Dim flagChanges As Boolean = False

        Try
            cerepl.Synchronize()
            Cursor.Current = Cursors.Default

            If cerepl.PublisherChanges > 0 _
                    Or cerepl.PublisherConflicts > 0 _
                    Or cerepl.SubscriberChanges > 0 Then
                flagChanges = True
            End If

            MessageBox.Show("Synchronization Complete:" & vbCrLf & _
              "Publisher changes = " + cerepl.PublisherChanges.ToString() & vbCrLf & _
              "Publisher conflicts = " + cerepl.PublisherConflicts.ToString() & vbCrLf & _
              "Subscriber changes = " + cerepl.SubscriberChanges.ToString(), _
              "Apress", _
              MessageBoxButtons.OK, _
              MessageBoxIcon.Asterisk, _
              MessageBoxDefaultButton.Button1)

        Catch ex As SqlCeException
            Dim q As String = ex.Message
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub ReplSynchronize()
        Dim flagChanges As Boolean = False

        _cerepl = New SqlCeReplication
        With _cerepl
            '   Set up for anonymous access
            .InternetLogin = ""
            .InternetPassword = ""
            .InternetUrl = _strInternetURL

            '	set the publisher
            .Publication = "NWind_Pub"
            .PublisherDatabase = "NWind_SQLCE"
            .Publisher = "Antietam"
            .PublisherSecurityMode = SecurityType.DBAuthentication
            .PublisherLogin = _userName
            .PublisherPassword = _userPassword

            .Subscriber = "NWind_Sub"
            .SubscriberConnectionString = "data source=\NWindCE.SDF"
        End With

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            _cerepl.Synchronize()

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            If _cerepl.PublisherChanges > 0 Or _cerepl.PublisherConflicts > 0 Then
                flagChanges = True
            End If

            MessageBox.Show("Synchronization Complete:" & vbCrLf & _
              "Publisher changes = " + _cerepl.PublisherChanges.ToString() & vbCrLf & _
              "Publisher conflicts = " + _cerepl.PublisherConflicts.ToString() & vbCrLf & _
              "Subscriber changes = " + _cerepl.SubscriberChanges.ToString(), _
              "Apress", _
              MessageBoxButtons.OK, _
              MessageBoxIcon.Asterisk, _
              MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            Dim q As String = ex.Message
        Finally
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub DropLocalTable(ByVal tableName As String)

        Dim cn As System.Data.SqlServerCe.SqlCeConnection = Nothing
        Dim cmd As System.Data.SqlServerCe.SqlCeCommand
        Dim strSQL As String = "DROP TABLE " + tableName

        Try

            '	Drop the existing local table
            cn = New SqlCeConnection(_strLocalConnect)
            cn.Open()

            cmd = New SqlCeCommand(strSQL, cn)
            cmd.ExecuteNonQuery()

        Catch ex As SqlCeException
            Dim p As String = ex.Message
            '   eat the error.
        Finally

            If Not cn Is Nothing Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub DownloadBooks()
        Dim strSQL As String = "SELECT * FROM Authors"
        DropLocalTable("localAuthors")
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            With _rda
                .InternetLogin = "Antietam\Dan"
                .InternetPassword = "scott"
                .InternetUrl = _strInternetURL
                .LocalConnectionString = _strLocalConnect
                .Pull("localAuthors", strSQL, _strRemoteConnect, System.Data.SqlServerCe.RdaTrackOption.TrackingOnWithIndexes)
            End With
        Catch ex As SqlCeException
            Dim q As String = ex.Message
        Finally
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub DeleteCustomer(ByVal name As String)

        Dim cn As System.Data.SqlServerCe.SqlCeConnection = Nothing
        Dim cmd As System.Data.SqlServerCe.SqlCeCommand

        Try
            '	Drop the existing local table
            cn = New SqlCeConnection(_strLocalConnect)
            cn.Open()

            Dim strSQL As String = "DELETE FROM localCustomers WHERE CompanyName='" + name + "'"
            cmd = New SqlCeCommand(strSQL, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
        End Try
    End Sub

    Public Sub UploadCustomerList()
        Try
            With _rda
                .InternetLogin = String.Empty
                .InternetPassword = String.Empty
                .InternetUrl = _strInternetURL
                .LocalConnectionString = _strLocalConnect
                .Push("localCustomers", _strRemoteConnect, System.Data.SqlServerCe.RdaBatchOption.BatchingOn)
            End With
        Catch ex As SqlCeException
            Dim q As String = ex.Message
        End Try
    End Sub

    Public Function GetCustomerTable() As SqlCeDataReader

        Dim cn As System.Data.SqlServerCe.SqlCeConnection = Nothing
        Dim cmd As System.Data.SqlServerCe.SqlCeCommand
        Dim dr As System.Data.SqlServerCe.SqlCeDataReader = Nothing

        Try
            '	Drop the existing local table
            cn = New SqlCeConnection(_strLocalConnect)
            cn.Open()

            cmd = New SqlCeCommand("SELECT * FROM localCustomers", cn)
            dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

            Return dr
        Catch ex As Exception
            Throw ex
        Finally
            '	the connection is closed when the DataReader is closed
            '				if( cn != null )
            '				cn.Close();
        End Try
    End Function

    Public Sub ExecuteTsqlCommand(ByVal sqlCommandText As String)
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            With _rda
                .InternetLogin = "Antietam\Dan"
                .InternetPassword = "scott"
                .InternetUrl = "http://antietam/ssce20/sscesa20.dll"
                .LocalConnectionString = "Data Source=\Chapter13.sdf"
                .SubmitSql(sqlCommandText, _strRemoteConnect)
            End With
        Catch ex As SqlCeException
            Dim q As String = ex.Message
        Finally
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
End Class
