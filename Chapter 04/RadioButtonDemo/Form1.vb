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
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
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
  Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.RadioButton1 = New System.Windows.Forms.RadioButton
Me.RadioButton2 = New System.Windows.Forms.RadioButton
Me.RadioButton3 = New System.Windows.Forms.RadioButton
Me.RadioButton4 = New System.Windows.Forms.RadioButton
Me.btnDisplay = New System.Windows.Forms.Button
'
'RadioButton1
'
Me.RadioButton1.Location = New System.Drawing.Point(14, 15)
Me.RadioButton1.Text = "Senior"
'
'RadioButton2
'
Me.RadioButton2.Location = New System.Drawing.Point(14, 41)
Me.RadioButton2.Text = "Junior"
'
'RadioButton3
'
Me.RadioButton3.Location = New System.Drawing.Point(14, 67)
Me.RadioButton3.Text = "Sophomore"
'
'RadioButton4
'
Me.RadioButton4.Location = New System.Drawing.Point(14, 93)
Me.RadioButton4.Text = "Freshman"
'
'btnDisplay
'
Me.btnDisplay.Location = New System.Drawing.Point(160, 244)
Me.btnDisplay.Text = "Display"
'
'Form1
'
Me.Controls.Add(Me.btnDisplay)
Me.Controls.Add(Me.RadioButton4)
Me.Controls.Add(Me.RadioButton3)
Me.Controls.Add(Me.RadioButton2)
Me.Controls.Add(Me.RadioButton1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "RadioButton Demo"

    End Sub

#End Region

  Dim ButtonSelected As String

  Private Sub RadioButtonHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
  ' Determine which button was selected.
    ButtonSelected = CType(sender, System.Windows.Forms.RadioButton).Text
  End Sub

  Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
    Dim mb As MessageBox
  ' Display the button selected.
    mb.Show("The selected RadioButton is " & ButtonSelected & ".")
  End Sub
End Class
