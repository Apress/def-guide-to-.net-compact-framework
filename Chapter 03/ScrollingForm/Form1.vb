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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents vscPanel As System.Windows.Forms.VScrollBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
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
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.Panel1 = New System.Windows.Forms.Panel
Me.TextBox11 = New System.Windows.Forms.TextBox
Me.TextBox10 = New System.Windows.Forms.TextBox
Me.Label11 = New System.Windows.Forms.Label
Me.Label10 = New System.Windows.Forms.Label
Me.TextBox9 = New System.Windows.Forms.TextBox
Me.TextBox8 = New System.Windows.Forms.TextBox
Me.TextBox7 = New System.Windows.Forms.TextBox
Me.TextBox6 = New System.Windows.Forms.TextBox
Me.TextBox5 = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.TextBox4 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TextBox3 = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.vscPanel = New System.Windows.Forms.VScrollBar
'
'Panel1
'
Me.Panel1.Controls.Add(Me.TextBox11)
Me.Panel1.Controls.Add(Me.TextBox10)
Me.Panel1.Controls.Add(Me.Label11)
Me.Panel1.Controls.Add(Me.Label10)
Me.Panel1.Controls.Add(Me.TextBox9)
Me.Panel1.Controls.Add(Me.TextBox8)
Me.Panel1.Controls.Add(Me.TextBox7)
Me.Panel1.Controls.Add(Me.TextBox6)
Me.Panel1.Controls.Add(Me.TextBox5)
Me.Panel1.Controls.Add(Me.Label9)
Me.Panel1.Controls.Add(Me.Label8)
Me.Panel1.Controls.Add(Me.Label7)
Me.Panel1.Controls.Add(Me.Label6)
Me.Panel1.Controls.Add(Me.Label5)
Me.Panel1.Controls.Add(Me.TextBox4)
Me.Panel1.Controls.Add(Me.Label4)
Me.Panel1.Controls.Add(Me.TextBox3)
Me.Panel1.Controls.Add(Me.Label3)
Me.Panel1.Controls.Add(Me.TextBox2)
Me.Panel1.Controls.Add(Me.Label2)
Me.Panel1.Controls.Add(Me.TextBox1)
Me.Panel1.Controls.Add(Me.Label1)
Me.Panel1.Size = New System.Drawing.Size(224, 402)
'
'TextBox11
'
Me.TextBox11.Location = New System.Drawing.Point(108, 368)
Me.TextBox11.Text = ""
'
'TextBox10
'
Me.TextBox10.Location = New System.Drawing.Point(108, 332)
Me.TextBox10.Text = ""
'
'Label11
'
Me.Label11.Location = New System.Drawing.Point(8, 368)
Me.Label11.Text = "Item 11:"
'
'Label10
'
Me.Label10.Location = New System.Drawing.Point(8, 332)
Me.Label10.Text = "Item 10:"
'
'TextBox9
'
Me.TextBox9.Location = New System.Drawing.Point(108, 296)
Me.TextBox9.Text = ""
'
'TextBox8
'
Me.TextBox8.Location = New System.Drawing.Point(108, 260)
Me.TextBox8.Text = ""
'
'TextBox7
'
Me.TextBox7.Location = New System.Drawing.Point(108, 224)
Me.TextBox7.Text = ""
'
'TextBox6
'
Me.TextBox6.Location = New System.Drawing.Point(108, 188)
Me.TextBox6.Text = ""
'
'TextBox5
'
Me.TextBox5.Location = New System.Drawing.Point(108, 152)
Me.TextBox5.Text = ""
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(8, 296)
Me.Label9.Text = "Item 9:"
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(8, 260)
Me.Label8.Text = "Item 8:"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(8, 224)
Me.Label7.Text = "Item 7:"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 188)
Me.Label6.Text = "Item 6:"
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 152)
Me.Label5.Text = "Item 5:"
'
'TextBox4
'
Me.TextBox4.Location = New System.Drawing.Point(108, 117)
Me.TextBox4.Text = ""
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 117)
Me.Label4.Text = "Item 4:"
'
'TextBox3
'
Me.TextBox3.Location = New System.Drawing.Point(108, 82)
Me.TextBox3.Text = ""
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 82)
Me.Label3.Text = "Item 3:"
'
'TextBox2
'
Me.TextBox2.Location = New System.Drawing.Point(108, 47)
Me.TextBox2.Text = ""
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(5, 47)
Me.Label2.Text = "Item 2:"
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(108, 12)
Me.TextBox1.Text = ""
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Text = "Item 1:"
'
'vscPanel
'
Me.vscPanel.Location = New System.Drawing.Point(224, 4)
Me.vscPanel.Maximum = 80
Me.vscPanel.Minimum = 1
Me.vscPanel.Size = New System.Drawing.Size(12, 264)
Me.vscPanel.Value = 1
'
'Form1
'
Me.Controls.Add(Me.vscPanel)
Me.Controls.Add(Me.Panel1)
Me.Menu = Me.MainMenu1
Me.Text = "ScrollingForm"

    End Sub

#End Region

  Private Sub vscPanel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vscPanel.ValueChanged
    Panel1.Top = -1 * (vscPanel.Value * 2)
  End Sub
End Class
