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
Imports System.Runtime.InteropServices
Imports System.Text

Namespace CompactFramework.UnmanagedCode
    Public Class SpecialFolderInformation

        Private Enum specialFolders As Integer
            Desktop = &H0
            Programs = &H2
            MyDocuments = &H5
            StartUp = &H7
            Recent = &H8
            StartMenu = &HB
            Fonts = &H14
            Favorites = &H16
        End Enum

        <DllImport("coredll.dll", SetLastError:=True)> _
        Private Shared Function SHGetSpecialFolderPath(ByVal hwndOwner As Integer, ByVal lpszPath As StringBuilder, ByVal nFolder As specialFolders, ByVal fCreate As Boolean) As Boolean
        End Function

        Private Sub New()
        End Sub

        Public Shared ReadOnly Property DesktopFolder()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.Desktop, 0) Then
                        Return sPath.ToString()
                    End If

                    Return String.Empty
                Catch ex As Exception
                    Return String.Empty
                End Try
            End Get
        End Property
        Public Shared ReadOnly Property ProgramsFolder()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.Programs, False) Then
                        Return sPath.ToString()
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception

                End Try
            End Get
        End Property
        Public Shared ReadOnly Property MyDocumentsFolder()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.MyDocuments, False) Then
                        Return sPath.ToString()
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception

                End Try
            End Get
        End Property
        Public Shared ReadOnly Property StartUpFolder()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.StartUp, False) Then
                        Return sPath.ToString()
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception
                End Try
            End Get
        End Property
        Public Shared ReadOnly Property Recent()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.Recent, False) Then
                        Return sPath.ToString()
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception
                End Try
            End Get
        End Property
        Public Shared ReadOnly Property StartMenuFolder()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.StartMenu, False) Then
                        Return sPath.ToString()
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception
                End Try
            End Get
        End Property
        Public Shared ReadOnly Property FontsFolder()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.Fonts, False) Then
                        Return sPath.ToString()
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception
                End Try
            End Get
        End Property
        Public Shared ReadOnly Property FavoritesFolder()
            Get
                Dim sPath As New StringBuilder(254)
                Try
                    If SHGetSpecialFolderPath(0, sPath, specialFolders.Favorites, False) Then
                        Return sPath.ToString()
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception
                End Try
            End Get
        End Property
    End Class
End Namespace
