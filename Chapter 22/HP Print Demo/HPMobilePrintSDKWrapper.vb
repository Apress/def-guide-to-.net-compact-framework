Imports System
Imports System.Runtime.InteropServices

Namespace HPMobilePrintSDK
  Public Enum HPP_RESULT As Byte
    HPP_NOERROR = 0                   '!< There was no error in submission
    HPP_MEMORY_ERROR                  '!< Memory error - probably out of available memory
    HPP_USER_CANCELLED                '!< The user canceled the submission
    HPP_CT_NOT_AVAILABLE              '!< There is no content transformation available for the document type
    HPP_NULL_POINTER                  '!< There was a NULL pointer error in the HP Mobile Printing SDK module
    HPP_DOCUMENT_ERROR                '!< There was a problem reading the document
    HPP_PRINTER_BUSY                  '!< The printer is currently busy and cannot be used
    HPP_INTERNAL_ERROR                '!< There was in internal error in the HP Mobile Printing SDK module
    HPP_PRINT_SUBSYSTEM_BUSY          '!< The background printing process is currently busy and can't be used
  End Enum

  Public Class HPMobilePrintSDKWrapper
    Public Declare Function PrintJob Lib "HPMobilePrintSDKWrapper.dll" _
      (ByVal szContentName As String) _
      As Boolean
    Public Declare Function GetLastPrintError Lib "HPMobilePrintSDKWrapper.dll" () _
      As HPP_RESULT
  End Class
End Namespace
