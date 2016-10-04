Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
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
  Friend WithEvents btnLoad As System.Windows.Forms.Button
  Friend WithEvents btnDelete As System.Windows.Forms.Button
  Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.ComboBox1 = New System.Windows.Forms.ComboBox
Me.btnLoad = New System.Windows.Forms.Button
Me.btnDelete = New System.Windows.Forms.Button
Me.btnDisplay = New System.Windows.Forms.Button
'
'ComboBox1
'
Me.ComboBox1.Location = New System.Drawing.Point(8, 12)
Me.ComboBox1.Size = New System.Drawing.Size(224, 22)
'
'btnLoad
'
Me.btnLoad.Location = New System.Drawing.Point(8, 232)
Me.btnLoad.Size = New System.Drawing.Size(72, 24)
Me.btnLoad.Text = "Load"
'
'btnDelete
'
Me.btnDelete.Location = New System.Drawing.Point(85, 232)
Me.btnDelete.Size = New System.Drawing.Size(72, 24)
Me.btnDelete.Text = "Delete"
'
'btnDisplay
'
Me.btnDisplay.Location = New System.Drawing.Point(162, 232)
Me.btnDisplay.Size = New System.Drawing.Size(72, 24)
Me.btnDisplay.Text = "Display"
'
'Form1
'
Me.Controls.Add(Me.btnDisplay)
Me.Controls.Add(Me.btnDelete)
Me.Controls.Add(Me.btnLoad)
Me.Controls.Add(Me.ComboBox1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "ComboBox Demo"

    End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    ComboBox1.Items.Clear()
    ComboBox1.Items.Add("Senior")
    ComboBox1.Items.Add("Junior")
    ComboBox1.Items.Add("Sophomore")
    ComboBox1.Items.Add("Freshman")
  End Sub

  Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    ComboBox1.Items.Remove(ComboBox1.Items.Item(ComboBox1.SelectedIndex))
  End Sub

  Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
    Dim mb As MessageBox
    mb.Show("The selected item is " & _
      ComboBox1.SelectedIndex.ToString & _
      " with the value of " & _
      ComboBox1.SelectedItem)
  End Sub

End Class
