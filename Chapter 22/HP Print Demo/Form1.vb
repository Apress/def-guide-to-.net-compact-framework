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
  Friend WithEvents RichInk1 As Intelliprog.Windows.Forms.RichInk
  Friend WithEvents btnLoadInvoice As System.Windows.Forms.Button
  Friend WithEvents btnPrintInvoice As System.Windows.Forms.Button
    Private Sub InitializeComponent()
Me.MainMenu1 = New System.Windows.Forms.MainMenu
Me.btnPrintInvoice = New System.Windows.Forms.Button
Me.RichInk1 = New Intelliprog.Windows.Forms.RichInk
Me.btnLoadInvoice = New System.Windows.Forms.Button
'
'btnPrintInvoice
'
Me.btnPrintInvoice.Location = New System.Drawing.Point(136, 244)
Me.btnPrintInvoice.Size = New System.Drawing.Size(96, 20)
Me.btnPrintInvoice.Text = "Print Invoice"
'
'RichInk1
'
Me.RichInk1.InkLayer = Intelliprog.Windows.Forms.RichInkLayer.SmartInk
Me.RichInk1.PageStyle = Intelliprog.Windows.Forms.RichInkPageStyle.None
Me.RichInk1.PenMode = Intelliprog.Windows.Forms.RichInkPenMode.Select
Me.RichInk1.Size = New System.Drawing.Size(240, 240)
Me.RichInk1.Text = "[no invoice]"
Me.RichInk1.ViewMode = Intelliprog.Windows.Forms.RichInkViewMode.TypingView
Me.RichInk1.VoiceBarPosition = Intelliprog.Windows.Forms.VoiceBarPositions.Bottom
Me.RichInk1.VoiceBarVisible = False
Me.RichInk1.WrapMode = Intelliprog.Windows.Forms.RichInkWrapMode.WrapToPage
Me.RichInk1.ZoomLevel = Intelliprog.Windows.Forms.RichInkZoomLevel.ZoomLevel100
'
'btnLoadInvoice
'
Me.btnLoadInvoice.Location = New System.Drawing.Point(8, 244)
Me.btnLoadInvoice.Size = New System.Drawing.Size(96, 20)
Me.btnLoadInvoice.Text = "Load Invoice"
'
'Form1
'
Me.Controls.Add(Me.btnLoadInvoice)
Me.Controls.Add(Me.RichInk1)
Me.Controls.Add(Me.btnPrintInvoice)
Me.MaximizeBox = False
Me.Menu = Me.MainMenu1
Me.MinimizeBox = False
Me.Text = "HP Print Demo"

    End Sub

#End Region

  Private Sub btnPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintInvoice.Click
    Dim PrintError As HPMobilePrintSDK.HPP_RESULT
    Dim PrintWorked As Boolean
    Dim ErrorMessages() As String = _
      {"There was no error in submission", _
      "Memory error - probably out of available memory", _
      "The user canceled the submission", _
      "There is no content transformation available for the document type", _
      "There was a NULL pointer error in the HP Mobile Printing SDK module", _
      "There was a problem reading the document", _
      "The printer is currently busy and cannot be used", _
      "There was an internal error in the HP Mobile Printing SDK module", _
      "The background printing process is currently busy and can't be used"}

  ' Print the document.
    PrintWorked = HPMobilePrintSDK.HPMobilePrintSDKWrapper.PrintJob("/Windows/Start Menu/Programs/Apress/invoice.rtf")

  ' Check the status of the print request.
    If PrintWorked Then
      MessageBox.Show("The document was printed successfully.", "Print Status")
    Else
      PrintError = HPMobilePrintSDK.HPMobilePrintSDKWrapper.GetLastPrintError()
      MessageBox.Show(ErrorMessages(PrintError), "Print Status")
    End If

  End Sub

  Private Sub btnLoadInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadInvoice.Click
  ' Load the demo invoice.
    RichInk1.LoadFile("/Windows/Start Menu/Programs/Apress/invoice.rtf", Intelliprog.Windows.Forms.RichInkStreamType.RichText)
  End Sub
End Class
