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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents cmdBind As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Dim cn As System.Data.SqlServerCe.SqlCeConnection
    Dim cmd As New System.Data.SqlServerCe.SqlCeCommand
    Dim da As System.Data.SqlServerCe.SqlCeDataAdapter
    Dim dt As System.Data.DataTable = New System.Data.DataTable("Employees")

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
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.txtFirstName = New System.Windows.Forms.TextBox
Me.txtLastName = New System.Windows.Forms.TextBox
Me.cmdBind = New System.Windows.Forms.Button
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 10)
Me.Label1.Size = New System.Drawing.Size(72, 20)
Me.Label1.Text = "First name:"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 38)
Me.Label2.Size = New System.Drawing.Size(72, 20)
Me.Label2.Text = "Last name:"
'
'txtFirstName
'
Me.txtFirstName.Location = New System.Drawing.Point(81, 8)
Me.txtFirstName.Size = New System.Drawing.Size(151, 22)
Me.txtFirstName.Text = ""
'
'txtLastName
'
Me.txtLastName.Location = New System.Drawing.Point(81, 36)
Me.txtLastName.Size = New System.Drawing.Size(151, 22)
Me.txtLastName.Text = ""
'
'cmdBind
'
Me.cmdBind.Location = New System.Drawing.Point(160, 64)
Me.cmdBind.Size = New System.Drawing.Size(72, 28)
Me.cmdBind.Text = "Bind"
'
'Form1
'
Me.Controls.Add(Me.cmdBind)
Me.Controls.Add(Me.txtLastName)
Me.Controls.Add(Me.txtFirstName)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Simple Binding Demo"

    End Sub

#End Region


  Private Sub cmdBind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBind.Click

' Open the connection.
  Try
    cn = New _
    System.Data.SqlServerCe.SqlCeConnection( _
      "Data Source=" & ApplicationLocation() & "\NorthwindDemo.sdf")

' Configure and execute the command.
    cmd.CommandText = "SELECT * FROM Employees"
    cmd.Connection = cn

' Load the DataTable.
    da = New System.Data.SqlServerCe.SqlCeDataAdapter(cmd)
    da.Fill(dt)

' Bind the TextBoxes.
    txtFirstName.DataBindings.Add(New Binding("Text", dt, "FirstName"))
    txtLastName.DataBindings.Add(New Binding("Text", dt, "LastName"))

' Handle any exceptions that may occur.
  Catch sqlex As SqlServerCe.SqlCeException
    MsgBox(sqlex.Message.ToString)

  Catch ex As Exception
    MsgBox(ex.Message.ToString)
  End Try

  End Sub

  Private Function ApplicationLocation() As String

' Fetch and return the location where the application was launched.
    ApplicationLocation = _
      System.IO.Path.GetDirectoryName(Reflection.Assembly. _
      GetExecutingAssembly().GetName().CodeBase.ToString())

  End Function

  Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    da.Update(dt)
    MsgBox("saved...")
  End Sub
End Class
