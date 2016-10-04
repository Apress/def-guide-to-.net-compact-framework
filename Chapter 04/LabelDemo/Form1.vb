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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.Label1 = New System.Windows.Forms.Label
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 10)
Me.Label1.Size = New System.Drawing.Size(44, 16)
Me.Label1.Text = "Name:"
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(60, 8)
Me.TextBox1.Text = ""
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 48)
Me.Label2.Size = New System.Drawing.Size(224, 172)
Me.Label2.Text = "The Label control is a general-purpose control whose whole existence is to displa" & _
"y text. I like to refer to labels as the ""Vanna White"" control. I gave them that" & _
" name because for the most part they just sit on a form and point to the control" & _
" next to them, which usually is a TextBox. Labels are good well suited for situa" & _
"tions where you need to display text that you don’t want the user to modify."
'
'Form1
'
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TextBox1)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "Label Demo"

    End Sub

#End Region

End Class
