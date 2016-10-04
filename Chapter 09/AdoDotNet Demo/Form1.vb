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
Me.cmbTables.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
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
Me.chkAddToDataSet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
Me.chkAddToDataSet.Location = New System.Drawing.Point(8, 128)
Me.chkAddToDataSet.Size = New System.Drawing.Size(200, 16)
Me.chkAddToDataSet.Text = "Add to DataSet"
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
Me.Label4.Location = New System.Drawing.Point(8, 72)
Me.Label4.Size = New System.Drawing.Size(136, 16)
Me.Label4.Text = "Table name:"
'
'txtTableName
'
Me.txtTableName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
Me.txtTableName.Location = New System.Drawing.Point(8, 88)
Me.txtTableName.Size = New System.Drawing.Size(224, 22)
Me.txtTableName.Text = "Customers"
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
Me.Label2.Location = New System.Drawing.Point(8, 8)
Me.Label2.Size = New System.Drawing.Size(160, 16)
Me.Label2.Text = "Select statement:"
'
'txtSelect
'
Me.txtSelect.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
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
Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
Me.Label3.Location = New System.Drawing.Point(8, 0)
Me.Label3.Size = New System.Drawing.Size(136, 16)
Me.Label3.Text = "XML filename:"
'
'txtXML
'
Me.txtXML.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
Me.txtXML.Location = New System.Drawing.Point(8, 16)
Me.txtXML.Multiline = True
Me.txtXML.Size = New System.Drawing.Size(224, 48)
Me.txtXML.Text = "\Windows\Start Menu\Programs\larryroof\example.xml"
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
'
'Form1
'
Me.BackColor = System.Drawing.Color.White
Me.ClientSize = New System.Drawing.Size(240, 270)
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

  Private Sub mnuConfigureSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigureSelect.Click
    ShowPanel(pnlSelect)
  End Sub

  Sub ShowPanel(ByVal pnlToShow As Panel)
    pnlDisplay.Left = 300
    pnlSelect.Left = 300
    pnlXML.Left = 300

    pnlToShow.Left = 0
  End Sub
End Class
