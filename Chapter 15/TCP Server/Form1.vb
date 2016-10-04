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

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents txtPort As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
  Friend WithEvents timMain As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.txtPort = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.txtDisplay = New System.Windows.Forms.TextBox
Me.timMain = New System.Windows.Forms.Timer(Me.components)
Me.SuspendLayout()
'
'txtPort
'
Me.txtPort.Location = New System.Drawing.Point(30, 3)
Me.txtPort.Name = "txtPort"
Me.txtPort.Size = New System.Drawing.Size(62, 20)
Me.txtPort.TabIndex = 6
Me.txtPort.Text = "1234"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(2, 7)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(36, 16)
Me.Label2.TabIndex = 7
Me.Label2.Text = "Port:"
'
'txtDisplay
'
Me.txtDisplay.Location = New System.Drawing.Point(2, 31)
Me.txtDisplay.Multiline = True
Me.txtDisplay.Name = "txtDisplay"
Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDisplay.Size = New System.Drawing.Size(256, 172)
Me.txtDisplay.TabIndex = 5
Me.txtDisplay.Text = "[status display]"
'
'Form1
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(260, 205)
Me.Controls.Add(Me.txtPort)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtDisplay)
Me.Name = "Form1"
Me.Text = "TCP Server"
Me.ResumeLayout(False)

    End Sub

#End Region

End Class
