Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents mnuConfigure As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConfigureXML As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConfigureSelect As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLoad As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLoadSqlCe As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLoadXML As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveXML As System.Windows.Forms.MenuItem
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents cmbTables As System.Windows.Forms.ComboBox
    Friend WithEvents lvwDisplay As System.Windows.Forms.ListView
    Friend WithEvents pnlSelect As System.Windows.Forms.Panel
    Friend WithEvents chkAddToDataSet As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSelect As System.Windows.Forms.TextBox
    Friend WithEvents pnlXML As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtXML As System.Windows.Forms.TextBox

    Dim ds As New System.Data.DataSet

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
Me.mnuConfigure = New System.Windows.Forms.MenuItem
Me.mnuConfigureXML = New System.Windows.Forms.MenuItem
Me.mnuConfigureSelect = New System.Windows.Forms.MenuItem
Me.mnuLoad = New System.Windows.Forms.MenuItem
Me.mnuLoadSqlCe = New System.Windows.Forms.MenuItem
Me.mnuLoadXML = New System.Windows.Forms.MenuItem
Me.mnuSave = New System.Windows.Forms.MenuItem
Me.mnuSaveXML = New System.Windows.Forms.MenuItem
Me.pnlDisplay = New System.Windows.Forms.Panel
Me.cmbTables = New System.Windows.Forms.ComboBox
Me.lvwDisplay = New System.Windows.Forms.ListView
Me.pnlSelect = New System.Windows.Forms.Panel
Me.chkAddToDataSet = New System.Windows.Forms.CheckBox
Me.Label4 = New System.Windows.Forms.Label
Me.txtTableName = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.txtSelect = New System.Windows.Forms.TextBox
Me.pnlXML = New System.Windows.Forms.Panel
Me.Label3 = New System.Windows.Forms.Label
Me.txtXML = New System.Windows.Forms.TextBox
'
'MainMenu1
'
Me.MainMenu1.MenuItems.Add(Me.mnuConfigure)
Me.MainMenu1.MenuItems.Add(Me.mnuLoad)
Me.MainMenu1.MenuItems.Add(Me.mnuSave)
'
'mnuConfigure
'
Me.mnuConfigure.MenuItems.Add(Me.mnuConfigureXML)
Me.mnuConfigure.MenuItems.Add(Me.mnuConfigureSelect)
Me.mnuConfigure.Text = "Configure"
'
'mnuConfigureXML
'
Me.mnuConfigureXML.Text = "XML filename"
'
'mnuConfigureSelect
'
Me.mnuConfigureSelect.Text = "Select statement"
'
'mnuLoad
'
Me.mnuLoad.MenuItems.Add(Me.mnuLoadSqlCe)
Me.mnuLoad.MenuItems.Add(Me.mnuLoadXML)
Me.mnuLoad.Text = "Load"
'
'mnuLoadSqlCe
'
Me.mnuLoadSqlCe.Text = "from SQL Server CE"
'
'mnuLoadXML
'
Me.mnuLoadXML.Text = "from XML"
'
'mnuSave
'
Me.mnuSave.MenuItems.Add(Me.mnuSaveXML)
Me.mnuSave.Text = "Save"
'
'mnuSaveXML
'
Me.mnuSaveXML.Text = "as XML"
'
'pnlDisplay
'
Me.pnlDisplay.Controls.Add(Me.cmbTables)
Me.pnlDisplay.Controls.Add(Me.lvwDisplay)
Me.pnlDisplay.Location = New System.Drawing.Point(300, 0)
Me.pnlDisplay.Size = New System.Drawing.Size(240, 264)
'
'cmbTables
'
Me.cmbTables.Location = New System.Drawing.Point(8, 8)
Me.cmbTables.Size = New System.Drawing.Size(224, 22)
'
'lvwDisplay
'
Me.lvwDisplay.Location = New System.Drawing.Point(8, 32)
Me.lvwDisplay.Size = New System.Drawing.Size(224, 224)
Me.lvwDisplay.View = System.Windows.Forms.View.Details
'
'pnlSelect
'
Me.pnlSelect.Controls.Add(Me.chkAddToDataSet)
Me.pnlSelect.Controls.Add(Me.Label4)
Me.pnlSelect.Controls.Add(Me.txtTableName)
Me.pnlSelect.Controls.Add(Me.Label2)
Me.pnlSelect.Controls.Add(Me.txtSelect)
Me.pnlSelect.Location = New System.Drawing.Point(300, 0)
Me.pnlSelect.Size = New System.Drawing.Size(240, 264)
'
'chkAddToDataSet
'
Me.chkAddToDataSet.Checked = True
Me.chkAddToDataSet.CheckState = System.Windows.Forms.CheckState.Checked
Me.chkAddToDataSet.Location = New System.Drawing.Point(8, 128)
Me.chkAddToDataSet.Size = New System.Drawing.Size(200, 16)
Me.chkAddToDataSet.Text = "Add to DataSet"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 72)
Me.Label4.Size = New System.Drawing.Size(136, 16)
Me.Label4.Text = "Table name:"
'
'txtTableName
'
Me.txtTableName.Location = New System.Drawing.Point(8, 88)
Me.txtTableName.Size = New System.Drawing.Size(224, 22)
Me.txtTableName.Text = "Customers"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 8)
Me.Label2.Size = New System.Drawing.Size(160, 16)
Me.Label2.Text = "Select statement:"
'
'txtSelect
'
Me.txtSelect.Location = New System.Drawing.Point(8, 24)
Me.txtSelect.Multiline = True
Me.txtSelect.Size = New System.Drawing.Size(224, 40)
Me.txtSelect.Text = "Select * From Customers"
'
'pnlXML
'
Me.pnlXML.Controls.Add(Me.Label3)
Me.pnlXML.Controls.Add(Me.txtXML)
Me.pnlXML.Location = New System.Drawing.Point(300, 0)
Me.pnlXML.Size = New System.Drawing.Size(240, 264)
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 0)
Me.Label3.Size = New System.Drawing.Size(136, 16)
Me.Label3.Text = "XML filename:"
'
'txtXML
'
Me.txtXML.Location = New System.Drawing.Point(8, 16)
Me.txtXML.Multiline = True
Me.txtXML.Size = New System.Drawing.Size(224, 48)
Me.txtXML.Text = "\Windows\Start Menu\Programs\larryroof\example.xml"
'
'Form1
'
Me.Controls.Add(Me.pnlXML)
Me.Controls.Add(Me.pnlSelect)
Me.Controls.Add(Me.pnlDisplay)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "AdoDotNet Demo"

    End Sub

#End Region

  Private Sub mnuConfigureXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigureXML.Click
    ShowPanel(pnlXML)
  End Sub

  Sub DisplayData()
    Dim dt As System.Data.DataTable

  ' Clear the ComboBox control.
    cmbTables.Items.Clear()

  ' Load the ComboBox with a list of available tables.
    For Each dt In ds.Tables
      cmbTables.Items.Add(dt.TableName.ToString)
    Next

  ' Finally, trigger the displaying of the first table.
    cmbTables.SelectedIndex = 0

  End Sub

  Private Sub mnuConfigureSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigureSelect.Click
    ShowPanel(pnlSelect)
  End Sub

  Sub ShowPanel(ByVal pnlToShow As Panel)
    pnlDisplay.Left = 300
    pnlSelect.Left = 300
    pnlXML.Left = 300

    pnlToShow.Left = 0
  End Sub

  Private Sub mnuSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveXML.Click

  ' Write the DataSet contents out to an XML file.
    ds.WriteXml(txtXML.Text)

  End Sub

  Private Sub mnuLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadXML.Click

  ' Read in data stored as XML and load it into a DataSet.
    ds.ReadXml(txtXML.Text)
    DisplayData()

  End Sub

  Private Sub cmbTables_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTables.SelectedIndexChanged
    Dim dr As DataRow
    Dim intCnt As Int16
    Dim lvwColumn As ColumnHeader
    Dim objListItem As ListViewItem

  ' Clear the ListView control.
    lvwDisplay.Visible = False
    lvwDisplay.Clear()

  ' Add the column headers.
    For intCnt = 0 To ds.Tables(cmbTables.SelectedIndex).Columns.Count - 1
      lvwColumn = New ColumnHeader
      lvwColumn.Text = ds.Tables(cmbTables.SelectedIndex).Columns(intCnt).ColumnName
      lvwDisplay.Columns.Add(lvwColumn)
    Next

  ' Get rid of lvwColumn.
    lvwColumn = Nothing

  ' Load the data by looping through each of the rows within
  ' the table.
    For Each dr In ds.Tables(cmbTables.SelectedIndex).Rows
      objListItem = New ListViewItem

  ' Load the first field.
      If dr.IsNull(0) Then
        objListItem.Text = ""
      Else
        objListItem.Text = dr.Item(0)
      End If

  ' Now the rest of the fields.
      For intCnt = 1 To dr.ItemArray.GetUpperBound(0)
        If (dr.IsNull(intCnt)) Then
          objListItem.SubItems.Add("")
        Else
          Try
            objListItem.SubItems.Add(CStr(dr.Item(intCnt)))
          Catch
            objListItem.SubItems.Add("")
          End Try
        End If
      Next

  ' Add the item (record) into the display.
      lvwDisplay.Items.Add(objListItem)
    Next

  ' Show the ListBox
    lvwDisplay.Visible = True

  ' Finally, display the panel that contains the ListView control.
    ShowPanel(pnlDisplay)

  End Sub

  Private Sub mnuLoadSqlCe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadSqlCe.Click
    Dim cmd As System.Data.SqlServerCE.SqlCeCommand
    Dim cn As System.Data.SqlServerCe.SqlCeConnection
    Dim da As System.Data.SqlServerCe.SqlCeDataAdapter

  ' Establish a connection to the SQL Server CE database.
    Try
      cn = New System.Data.SqlServerce.SqlCeConnection("Data Source= \Windows\Start Menu\Programs\larryroof\NorthwindDemo.sdf")
      cmd = New System.Data.SqlServerCE.SqlCeCommand(txtSelect.Text, cn)
      da = New System.Data.SqlServerCE.SqlCeDataAdapter(cmd)

  ' Is this table being added to the DataSet?
      If Not chkAddToDataSet.Checked Then
        ds.Clear()
      End If

  ' Add the new table to the DataSet. 
      Dim dt As System.Data.DataTable = New System.Data.DataTable(txtTableName.Text)
      da.Fill(dt)
      ds.Tables.Add(dt)

  ' Display the DataSet.
      DisplayData()

    Catch exc As SqlServerCe.SqlCeException
      ShowError(exc)

  ' Handle general errors.
    Catch exc As Exception
      MessageBox.Show(exc.Message)

    End Try

  End Sub

  Sub ShowError(ByVal exc As SqlServerCe.SqlCeException)
    Dim bld As New System.Text.StringBuilder
    Dim err As System.Data.SqlServerCe.SqlCeError
    Dim errorCollection As System.Data.SqlServerCe.SqlCeErrorCollection = exc.Errors
    Dim errPar As String
    Dim numPar As Integer

  ' Loop through all of the errors.
    For Each err In errorCollection
      bld.Append(ControlChars.Cr & " Error Code: " & err.HResult.ToString("X"))
      bld.Append(ControlChars.Cr & " Message   : " & err.Message)
      bld.Append(ControlChars.Cr & " Minor Err.: " & err.NativeError)
      bld.Append(ControlChars.Cr & " Source    : " & err.Source)

  ' Loop through all of the numeric parameters for this specific error.
      For Each numPar In err.NumericErrorParameters
        If numPar <> 0 Then
          bld.Append(ControlChars.Cr & " Num. Par. : " & numPar.ToString())
        End If
      Next numPar

  ' Loop through all of the error parameters for this specific error.
      For Each errPar In err.ErrorParameters
        If errPar <> [String].Empty Then
          bld.Append(ControlChars.Cr & " Err. Par. : " & errPar)
        End If
      Next errPar

  ' Finally, display this error.
      MessageBox.Show(bld.ToString())

  ' Empty the string so that it can be used again.
      bld.Remove(0, bld.Length)

    Next err

  End Sub
End Class
