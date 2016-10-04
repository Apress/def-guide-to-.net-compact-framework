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

Module DirectoryRoutines

' Pocket PC folder values for use with the SHGetSpecialFolderPath
' function nFolder argument.
Public Enum CSIDL As Integer
  DESKTOP = 0           ' \My Documents
  PROGRAMS = 2          ' \Windows\Start Menu\Programs
  PERSONAL = 5          ' \My Documents
  FAVORITES = 6         ' \Windows\Start Menu
  STARTUP = 7           ' \Windows\StartUp
  STARTMENU = &HB       ' \Windows\Start Menu
  FONTS = &H14          ' \Windows\Fonts
End Enum

' Windows API function that returns the paths to common folders.
<System.Runtime.InteropServices.DllImport("coredll.dll")> _
  Private Function SHGetSpecialFolderPath( _
    ByVal hwndOwner As Integer, _
    ByVal lpszPath As String, _
    ByVal nFolder As CSIDL, _
    ByVal fCreate As Boolean _
    ) As Boolean
  End Function

Public Structure ReturnStatus
  Dim Success As Boolean
  Dim Message As String
End Structure

Function CopyFile(ByVal strSource As String, ByVal strTarget As String) As ReturnStatus
' Copies a file. 
' The strSource argument is the full path to the file to copy.
' The strTarget argument is the full path to the new file.
  Dim MyReturn As ReturnStatus

' Check to see if source file exists.
  If Not (System.IO.File.Exists(strSource)) Then
    MyReturn.Success = False
    MyReturn.Message = "Source file does not exist."
    Return MyReturn
    Exit Function
  End If

' Check to see if target file exists.
  If System.IO.Directory.Exists(strTarget) Then
    MyReturn.Success = False
    MyReturn.Message = "Target file already exists."
    Return MyReturn
    Exit Function
  End If

' Copy the file.
  Try
    System.IO.File.Copy(strSource, strTarget)
    MyReturn.Success = True
    MyReturn.Message = strTarget
    Return MyReturn

' An exception occurred, so let the calling program
' know what happened.
  Catch ex As Exception
    MyReturn.Success = False
    MyReturn.Message = ex.Message
    Return MyReturn
  End Try
End Function

Function CreateDirectory(ByVal strDirectory As String) As ReturnStatus
' Creates a directory. 
' The strDirectory argument is the full path to the directory to create.
  Dim MyReturn As ReturnStatus

' Check to see if the directory exists.
  If System.IO.Directory.Exists(strDirectory) Then
    MyReturn.Success = False
    MyReturn.Message = "Directory already exists."
    Return MyReturn
    Exit Function
  End If

' Create the directory.
  Try
    System.IO.Directory.CreateDirectory(strDirectory)
    MyReturn.Success = True
    MyReturn.Message = strDirectory
    Return MyReturn

' An exception occurred, so let the calling program
' know what happened.
  Catch ex As Exception
    MyReturn.Success = False
    MyReturn.Message = ex.Message
    Return MyReturn
  End Try
End Function

Function DeleteDirectory(ByVal strSource As String) As ReturnStatus
' Deletes a directory. 
' The strSource argument is the full path to the directory to delete.
  Dim MyReturn As ReturnStatus

' Confirm that the directory exists before attempting to delete it.
  If Not (System.IO.Directory.Exists(strSource)) Then
    MyReturn.Success = False
    MyReturn.Message = "Directory does not exist."
    Return MyReturn
    Exit Function
  End If

' Delete the directory.
  Try
    System.IO.Directory.Delete(strSource)
    MyReturn.Success = True
    MyReturn.Message = strSource
    Return MyReturn

' An exception occurred, so let the calling program
' know what happened.
  Catch ex As Exception
    MyReturn.Success = False
    MyReturn.Message = ex.Message
    Return MyReturn
  End Try
End Function

Function DeleteFile(ByVal strSource As String) As ReturnStatus
' Deletes a file. 
' The strSource argument is the full path to the file to delete.
  Dim MyReturn As ReturnStatus

' Confirm that the file exists before attempting to delete it.
  If Not (System.IO.File.Exists(strSource)) Then
    MyReturn.Success = False
    MyReturn.Message = "File does not exist."
    Return MyReturn
    Exit Function
  End If

' Delete the file.
  Try
    System.IO.File.Delete(strSource)
    MyReturn.Success = True
    MyReturn.Message = strSource
    Return MyReturn

' An exception occurred, so let the calling program
' know what happened.
  Catch ex As Exception
    MyReturn.Success = False
    MyReturn.Message = ex.Message
    Return MyReturn
  End Try
End Function

Function GetApplicationFolder() As String

' Fetch and return the location where the application was launched.
  GetApplicationFolder = _
      System.IO.Path.GetDirectoryName(Reflection.Assembly. _
      GetExecutingAssembly().GetName().CodeBase.ToString())

End Function

Function GetLastTimeDirectoryWasChanged(ByVal strdirectory As String) As Date
' Returns the last time the directory was changed. 
' The strDirectory argument is the full path to the directory to check.

  GetLastTimeDirectoryWasChanged = System.IO.Directory.GetLastWriteTime(strdirectory)

End Function

Private Function GetSpecialFolderPath(ByVal MyCSIDL As CSIDL) As String
  Dim strWorkingPath As String = New String(" "c, 260)
  Dim intEndOfPath As Integer

' Retrieve the requested path.
  Try
    SHGetSpecialFolderPath(0, strWorkingPath, MyCSIDL, False)

' Locate the end of the path name.
    intEndOfPath = strWorkingPath.IndexOf(Chr(0))

' Extract just that path name.
    If intEndOfPath > -1 Then
      strWorkingPath = strWorkingPath.Substring(0, intEndOfPath)
    End If
  Catch ex As Exception
    strWorkingPath = ex.Message
  End Try

' Send the path name back to the calling program.
  Return strWorkingPath

End Function

Public Function GetPersonalFolder() As String
' Return the Personal folder, which on English-based
' devices is \My Documents.
   Return GetSpecialFolderPath(CSIDL.PERSONAL)
End Function

Public Function GetProgramsFolder() As String
' Return the Programs folder, which on English-based
' devices is \Windows\Start Menu\Programs.
    Return GetSpecialFolderPath(CSIDL.PROGRAMS)
End Function

Public Function GetStartMenuFolder() As String
' Return the Start Menu folder, which on English-based
' devices is \Windows\Start Menu.
    Return GetSpecialFolderPath(CSIDL.STARTMENU)
End Function

Public Function GetStartupFolder() As String
' Return the Startup folder, which on English-based
' devices is \Windows\Startup.
    Return GetSpecialFolderPath(CSIDL.STARTUP)
End Function

Public Function GetWindowsFolder() As String
' Return the Windows folder, which on English-based
' devices is \Windows.
  Dim intLoc As Integer
  Dim strWorking As String

' Since the function does not have an argument for just
' the \Windows folder, we must obtain this information
' with a bit of parsing.

' First, get the location of the Fonts folder.
  strWorking = GetSpecialFolderPath(CSIDL.FONTS)

' At this point strWorking contains the directory of the 
' Fonts folder on your device. For example on English-based
' systems it would contain \Windows\Fonts. 
'
' All that we need to do is to remove everything afer the 
' last "\" character, effectively leaving us with only the 
' Windows folder.
  intLoc = strWorking.LastIndexOf("\")
  If intLoc > -1 Then
      strWorking = strWorking.Substring(0, intLoc)
  End If

' Return the \Windows folder.
  Return strWorking

End Function

Function MoveDirectory(ByVal strSource As String, ByVal strTarget As String) As ReturnStatus
' Moves a directory. 
' The strSource argument is the full path to the directory to move.
' The strTarget argument is the full path to the new directory.
  Dim MyReturn As ReturnStatus

' Check to see if source directory exists.
  If Not (System.IO.Directory.Exists(strSource)) Then
    MyReturn.Success = False
    MyReturn.Message = "Source directory does not exist."
    Return MyReturn
    Exit Function
  End If

' Check to see if target directory exists.
  If System.IO.Directory.Exists(strTarget) Then
    MyReturn.Success = False
    MyReturn.Message = "Target directory already exists."
    Return MyReturn
    Exit Function
  End If

' Move the directory.
  Try
    System.IO.Directory.Move(strSource, strTarget)
    MyReturn.Success = True
    MyReturn.Message = strTarget
    Return MyReturn

' An exception occurred, so let the calling program
' know what happened.
  Catch ex As Exception
    MyReturn.Success = False
    MyReturn.Message = ex.Message
    Return MyReturn
  End Try
End Function

Function MoveFile(ByVal strSource As String, ByVal strTarget As String) As ReturnStatus
' Moves a file. 
' The strSource argument is the full path to the file to move.
' The strTarget argument is the full path to the new file.
  Dim MyReturn As ReturnStatus

' Check to see if source file exists.
  If Not (System.IO.File.Exists(strSource)) Then
    MyReturn.Success = False
    MyReturn.Message = "Source directory does not exist."
    Return MyReturn
    Exit Function
  End If

' Check to see if target file exists.
  If System.IO.File.Exists(strTarget) Then
    MyReturn.Success = False
    MyReturn.Message = "Target file already exists."
    Return MyReturn
    Exit Function
  End If

' Move the file.
  Try
    System.IO.File.Move(strSource, strTarget)
    MyReturn.Success = True
    MyReturn.Message = strTarget
    Return MyReturn

' An exception occurred, so let the calling program
' know what happened.
  Catch ex As Exception
    MyReturn.Success = False
    MyReturn.Message = ex.Message
    Return MyReturn
  End Try
End Function

End Module
