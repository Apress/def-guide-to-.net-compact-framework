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
' You can obtain updates to the samples included with this title 
' at the following sites:
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
'
Imports System.Xml

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnGoGetIt As System.Windows.Forms.Button
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
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
        Me.btnGoGetIt = New System.Windows.Forms.Button
        Me.txtInput = New System.Windows.Forms.TextBox
        Me.txtOutput = New System.Windows.Forms.TextBox
        '
        'btnGoGetIt
        '
        Me.btnGoGetIt.Location = New System.Drawing.Point(8, 56)
        Me.btnGoGetIt.Size = New System.Drawing.Size(216, 20)
        Me.btnGoGetIt.Text = "Go Get It"
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(8, 24)
        Me.txtInput.Size = New System.Drawing.Size(216, 22)
        Me.txtInput.Text = "ConnectString"
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(8, 112)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Size = New System.Drawing.Size(216, 48)
        Me.txtOutput.Text = ""
        '
        'Form1
        '
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.btnGoGetIt)
        Me.Menu = Me.MainMenu1
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub btnGoGetIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoGetIt.Click
        Dim cfr As ConfigReader = New ConfigReader

        cfr = New ConfigReader
        txtOutput.Text = cfr.GetConfig(txtInput.Text)
    End Sub
End Class

Public Class ConfigReader

    Private Function AppPath() As String
        ' Fetch the location where the application was launched.
        AppPath = _
          System.IO.Path.GetDirectoryName(Reflection.Assembly. _
          GetExecutingAssembly().GetName().CodeBase.ToString())
    End Function

    Public Sub New()
    End Sub

    Public Function GetConfig(ByVal fieldName As String) As String
        Dim dr As XmlTextReader
        Dim strPath As String = AppPath() & "\app.config"

        Try
            dr = New XmlTextReader(strPath)
            dr.WhitespaceHandling = WhitespaceHandling.None

            While dr.Read()
                If dr.NodeType = XmlNodeType.Element _
                 And dr.HasAttributes Then
                    If dr.Name.ToString() = "Setting" Then
                        '   Walk and look at all elements
                        dr.MoveToFirstAttribute()
                        If dr.Name = "Name" Then
                            If dr.Value = fieldName Then
                                'get the next attribute
                                While dr.MoveToNextAttribute()
                                    If dr.Name = "Value" Then
                                        Return dr.Value
                                    End If
                                End While
                            End If
                        End If
                    End If
                End If
            End While
            '    If we get here, nothing was found
            Return String.Empty
        Finally
            dr.Close()
        End Try

    End Function
End Class
