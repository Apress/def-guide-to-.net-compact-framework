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
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents lstAppointments As System.Windows.Forms.ListBox
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
  Friend WithEvents cmbDates As System.Windows.Forms.ComboBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnSelect = New System.Windows.Forms.Button
Me.btnAdd = New System.Windows.Forms.Button
Me.btnLoad = New System.Windows.Forms.Button
Me.btnDisplay = New System.Windows.Forms.Button
Me.lstAppointments = New System.Windows.Forms.ListBox
Me.cmbDates = New System.Windows.Forms.ComboBox
'
'btnSelect
'
Me.btnSelect.Location = New System.Drawing.Point(160, 189)
Me.btnSelect.Text = "Select"
'
'btnAdd
'
Me.btnAdd.Location = New System.Drawing.Point(160, 149)
Me.btnAdd.Text = "Add"
'
'btnLoad
'
Me.btnLoad.Location = New System.Drawing.Point(8, 149)
Me.btnLoad.Text = "Load"
'
'btnDisplay
'
Me.btnDisplay.Location = New System.Drawing.Point(84, 149)
Me.btnDisplay.Text = "Display"
'
'lstAppointments
'
Me.lstAppointments.Location = New System.Drawing.Point(8, 9)
Me.lstAppointments.Size = New System.Drawing.Size(224, 128)
'
'cmbDates
'
Me.cmbDates.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
Me.cmbDates.Items.Add("today")
Me.cmbDates.Items.Add("tomorrow")
Me.cmbDates.Items.Add("next week")
Me.cmbDates.Location = New System.Drawing.Point(8, 188)
Me.cmbDates.Size = New System.Drawing.Size(144, 22)
'
'Form1
'
Me.Controls.Add(Me.cmbDates)
Me.Controls.Add(Me.btnSelect)
Me.Controls.Add(Me.btnAdd)
Me.Controls.Add(Me.btnLoad)
Me.Controls.Add(Me.btnDisplay)
Me.Controls.Add(Me.lstAppointments)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Appointment Demo"

    End Sub

#End Region

End Class
