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

Imports InTheHand.PocketOutlook

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents lstTasks As System.Windows.Forms.ListBox
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Dim poApplication As New OutlookApplication
    Dim myTasks As OutlookItemCollection

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
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents btnSelect As System.Windows.Forms.Button
  Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.lstTasks = New System.Windows.Forms.ListBox
Me.btnDisplay = New System.Windows.Forms.Button
Me.btnLoad = New System.Windows.Forms.Button
Me.btnAdd = New System.Windows.Forms.Button
Me.btnSelect = New System.Windows.Forms.Button
Me.txtCategory = New System.Windows.Forms.TextBox
'
'lstTasks
'
Me.lstTasks.Location = New System.Drawing.Point(8, 8)
Me.lstTasks.Size = New System.Drawing.Size(224, 128)
'
'btnDisplay
'
Me.btnDisplay.Location = New System.Drawing.Point(84, 148)
Me.btnDisplay.Text = "Display"
'
'btnLoad
'
Me.btnLoad.Location = New System.Drawing.Point(8, 148)
Me.btnLoad.Text = "Load"
'
'btnAdd
'
Me.btnAdd.Location = New System.Drawing.Point(160, 148)
Me.btnAdd.Text = "Add"
'
'btnSelect
'
Me.btnSelect.Location = New System.Drawing.Point(160, 188)
Me.btnSelect.Text = "Select"
'
'txtCategory
'
Me.txtCategory.Location = New System.Drawing.Point(8, 188)
Me.txtCategory.Size = New System.Drawing.Size(144, 22)
Me.txtCategory.Text = "[enter category]"
'
'Form1
'
Me.Controls.Add(Me.txtCategory)
Me.Controls.Add(Me.btnSelect)
Me.Controls.Add(Me.btnAdd)
Me.Controls.Add(Me.btnLoad)
Me.Controls.Add(Me.btnDisplay)
Me.Controls.Add(Me.lstTasks)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Task Demo"

    End Sub

#End Region

  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

  ' Store the collection of tasks for future use.
    myTasks = poApplication.Tasks.Items

  ' Load the list of tasks.
    LoadTasks()

  End Sub

  Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
    Dim myTask As Task

  ' Display the selected task.
    If (lstTasks.SelectedIndex <> -1) Then
      myTask = myTasks.Item(lstTasks.SelectedIndex)
      myTask.Display()
    End If

  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    Dim myTask As Task

  ' Create a new task.
    myTask = poApplication.CreateTask

  ' Configure the task.
    With myTask
      .Body = "This is a sample task."
      .Categories = "demo"
      .DueDate = Today.Date
      .Importance = Importance.High
      .ReminderOptions = ReminderOptions.Dialog
      .ReminderSet = True
      .StartDate = Today.Date
      .Subject = "sample task"

  ' Finally, save the task.
      .Save()
    End With

  ' Let the user know that the task was added.
    MessageBox.Show("task added...")

  End Sub

  Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
    Dim strQuery As String

  ' Retrieve the selected tasks.
    strQuery = "[Categories] = " & ControlChars.Quote & txtCategory.Text & _
      ControlChars.Quote
    myTasks = poApplication.Tasks.Items.Restrict(strQuery)

  ' Load the list of tasks.
    LoadTasks()

  End Sub

  Sub LoadTasks()
    Dim intCount As Integer
    Dim myTask As Task

  ' First, make sure that the listbox is empty.
    lstTasks.Items.Clear()

  ' Next, load the tasks into the listbox.
    For intCount = 0 To myTasks.Count - 1
      myTask = myTasks.Item(intCount)
      lstTasks.Items.Add(myTask.Subject)
    Next

  End Sub
End Class
