
Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnListen As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
  Friend WithEvents lstColor As System.Windows.Forms.ListBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnListen = New System.Windows.Forms.Button
Me.btnSend = New System.Windows.Forms.Button
Me.Label1 = New System.Windows.Forms.Label
Me.lstColor = New System.Windows.Forms.ListBox
'
'btnListen
'
Me.btnListen.Location = New System.Drawing.Point(4, 132)
Me.btnListen.Text = "Listen"
'
'btnSend
'
Me.btnSend.Location = New System.Drawing.Point(164, 132)
Me.btnSend.Text = "Send"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(4, 7)
Me.Label1.Size = New System.Drawing.Size(100, 16)
Me.Label1.Text = "Select Color:"
'
'lstColor
'
Me.lstColor.Items.Add("Red")
Me.lstColor.Items.Add("Blue")
Me.lstColor.Items.Add("Green")
Me.lstColor.Items.Add("Yellow")
Me.lstColor.Items.Add("Black")
Me.lstColor.Items.Add("White")
Me.lstColor.Location = New System.Drawing.Point(4, 22)
Me.lstColor.Size = New System.Drawing.Size(232, 100)
'
'Form1
'
Me.Controls.Add(Me.lstColor)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.btnSend)
Me.Controls.Add(Me.btnListen)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "IrDA Demo"

    End Sub

#End Region

End Class
