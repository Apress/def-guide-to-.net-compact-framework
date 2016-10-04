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

Public Class TextBoxPlus
  Inherits TextBox

' Implement the Locked property.
  Private mLocked As Boolean
  Public Property Locked() As Boolean
  Get
    Locked = mLocked
  End Get
  Set(ByVal Value As Boolean)
    mLocked = Value
  End Set
  End Property

' Implement the InputPanel property.
  Private mInputPanel As Microsoft.WindowsCE.Forms.InputPanel
  Private mSipDefined As Boolean
  Public Property InputPanel() As Microsoft.WindowsCE.Forms.InputPanel
  Get
    InputPanel = mInputPanel
  End Get
  Set(ByVal Value As Microsoft.WindowsCE.Forms.InputPanel)
    mInputPanel = Value
    mSipDefined = True
  End Set
  End Property

' Tweak the OkKeyDown event of the underlying control, to circumvent the
' event when the control is locked.
  Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
    If (mLocked = False) Then
      MyBase.OnKeyDown(e)
    Else
    End If
  End Sub

' Tweak the OkKeyPress event of the underlying control, to circumvent the
' event and throw away the key value when the control is locked.
  Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If (mLocked = False) Then
      MyBase.OnKeyPress(e)
    Else
      e.Handled = True
    End If
  End Sub

' Tweak the OkKeyUp event of the underlying control, to circumvent the
' event when the control is locked.
  Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
    If (mLocked = False) Then
      MyBase.OnKeyUp(e)
    Else
    End If
  End Sub

' Augment the OnGotFocus event to include showing the SIP, if 1) the
' control is not locked and 2) an InputPanel control has been defined.
  Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
    If (mLocked = False) Then
      If (mSipDefined) Then
        mInputPanel.Enabled = True
      End If
    End If
    MyBase.OnGotFocus(e)
  End Sub

' Augment the OnLostFocus event to include hiding the SIP, if 1) the
' control is not locked and 2) an InputPanel control has been defined.
  Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
    If (mLocked = False) Then
      If (mSipDefined) Then
        mInputPanel.Enabled = False
      End If
    End If
    MyBase.OnLostFocus(e)
  End Sub

End Class
