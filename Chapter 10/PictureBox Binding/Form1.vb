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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnBind As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

' Declare the data-related objects.
  Dim cn As System.Data.SqlServerCe.SqlCeConnection
  Dim cmd As New System.Data.SqlServerCe.SqlCeCommand
  Dim da As System.Data.SqlServerCe.SqlCeDataAdapter
  Dim dt As System.Data.DataTable = New System.Data.DataTable("Test")

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
Me.PictureBox1 = New System.Windows.Forms.PictureBox
Me.btnBind = New System.Windows.Forms.Button
'
'PictureBox1
'
Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
Me.PictureBox1.Size = New System.Drawing.Size(224, 180)
'
'btnBind
'
Me.btnBind.Location = New System.Drawing.Point(156, 200)
Me.btnBind.Size = New System.Drawing.Size(76, 28)
Me.btnBind.Text = "Bind"
'
'Form1
'
Me.Controls.Add(Me.btnBind)
Me.Controls.Add(Me.PictureBox1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "PictureBox Binding"

    End Sub

#End Region

  Private Sub btnBind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBind.Click

' Open the connection.
    Try
      cn = New _
      System.Data.SqlServerCe.SqlCeConnection( _
        "Data Source=" & ApplicationLocation() & "\test.sdf")

' Configure and execute the command.
      cmd.CommandText = "SELECT * FROM Test"
      cmd.Connection = cn

' Load the DataTable.
      da = New System.Data.SqlServerCe.SqlCeDataAdapter(cmd)
      da.Fill(dt)

' Bind the PictureBox.
      Dim pbBinding As New Binding("Image", dt, "Photo")
      AddHandler pbBinding.Format, AddressOf ConvertImage
      PictureBox1.DataBindings.Add(pbBinding)

' Handle any exceptions that may occur.
    Catch sqlex As SqlServerCe.SqlCeException
      MsgBox(sqlex.Message.ToString)

    Catch ex As Exception
      MsgBox(ex.Message.ToString)
    End Try

  End Sub

  Private Sub ConvertImage(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
  ' Convert the byte string into an image.
    cevent.Value = New Bitmap(New System.IO.MemoryStream(CType(cevent.Value, Byte())))
  End Sub

  Private Function ApplicationLocation() As String

' Fetch and return the location where the application was launched.
    ApplicationLocation = _
      System.IO.Path.GetDirectoryName(Reflection.Assembly. _
      GetExecutingAssembly().GetName().CodeBase.ToString())

  End Function

End Class
