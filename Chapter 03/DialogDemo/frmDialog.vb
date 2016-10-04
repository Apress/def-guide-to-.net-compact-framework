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

Public Class frmDialog
    Inherits System.Windows.Forms.Form
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.txtName = New System.Windows.Forms.TextBox
Me.txtPhone = New System.Windows.Forms.TextBox
Me.btnCancel = New System.Windows.Forms.Button
'
'txtName
'
Me.txtName.Location = New System.Drawing.Point(8, 16)
Me.txtName.Size = New System.Drawing.Size(224, 22)
Me.txtName.Text = "[name]"
'
'txtPhone
'
Me.txtPhone.Location = New System.Drawing.Point(8, 48)
Me.txtPhone.Size = New System.Drawing.Size(224, 22)
Me.txtPhone.Text = "[phone]"
'
'btnCancel
'
Me.btnCancel.Location = New System.Drawing.Point(160, 240)
Me.btnCancel.Text = "Cancel"
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
'
'frmDialog
'
Me.Controls.Add(Me.btnCancel)
Me.Controls.Add(Me.txtPhone)
Me.Controls.Add(Me.txtName)
Me.Text = "frmDialog"

    End Sub

#End Region

  Private Sub frmDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  ' Link the cancel button to the cancel result.
    btnCancel.DialogResult = DialogResult.Cancel
  End Sub

  Public ReadOnly Property CustomersInfo() As CustomerInfo
  ' Create an instance of the CustomerInfo object to use to pass values.
    Get
      Dim ci As New CustomerInfo
      ci.Name = Me.txtName.Text
      ci.Phone = Me.txtPhone.Text
      Return ci
    End Get
  End Property

End Class

Public Class CustomerInfo
   Public Name As String
   Public Phone As String
End Class