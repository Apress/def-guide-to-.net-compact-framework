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

    Public Class Registry
#Region "Enums and Structs"
        Public Enum tagReturnValues
            NoError = 0
        End Enum

        Public Enum tagRegistryRootKeys
            HkeyCurrentUser = &H80000001
            HkeyLocalMachine = &H80000002
            HkeyClassesRoot = &H80000000
        End Enum

		Public Enum RegistryDataType
			[String] = 1
			Number = 4
		End Enum

		Public Const KeyAllAccess = &H3F
		Public Const RegDword = 4
		Public Const RegOptionNonVolatile = 0
		Public Const RegSz = 1
#End Region

#Region "Declarations / DllImports"
        <DllImport("Coredll.dll", EntryPoint:="RegCreateKeyExW")> _
        Private Shared Function RegCreateKeyEx( _
            ByVal hkey As Int32, _
            ByVal lpSubKey As String, _
            ByVal Reserved As Int32, _
            ByVal lpClass As String, _
            ByVal dwOptions As Int32, _
            ByVal samDesired As Int32, _
            ByVal lpSecurityAttributes As Int32, _
            ByRef phkResult As Int32, _
            ByRef lpdwDisposition As Int32 _
            ) As Int32
        End Function

		<DllImport("Coredll.dll", EntryPoint:="RegCloseKey")> _
		Private Shared Function RegCloseKey(ByVal hKey As Int32) As Int32
		End Function

		<DllImport("Coredll.dll", EntryPoint:="RegDeleteKeyW")> _
		Private Shared Function RegDeleteKey( _
		  ByVal hkey As Int32, _
		  ByVal lpSubKey As String _
		  ) As Int32
		End Function

		<DllImport("Coredll.dll", EntryPoint:="RegOpenKeyExW")> _
		Private Shared Function RegOpenKeyEx( _
		  ByVal hkey As Int32, _
		  ByVal lpSubKey As String, _
		  ByVal ulOptions As Int32, _
		  ByVal samDesired As Int32, _
		  ByRef phkResult As Int32 _
		  ) As Int32
		End Function

		'WINADVAPI LONG APIENTRYRegQueryValueExW (IN HKEY hKey,IN LPCWSTR lpValueName,
		'IN LPDWORD lpReserved,OUT LPDWORD lpType,IN OUT LPBYTE lpData,IN OUT LPDWORD lpcbData);
		<DllImport("Coredll.dll", EntryPoint:="RegQueryValueExW")> _
		Private Shared Function RegQueryValueEx( _
		 ByVal hKey As Int32, _
		 ByVal lpValueName As String, _
		 ByVal lpReserved As Int32, _
		 ByRef lpType As RegistryDataType, _
		 ByVal lpData As String, _
		 ByRef lpcbData As Int32 _
		 ) As Int32
		End Function

		<DllImport("Coredll.dll", EntryPoint:="RegQueryValueExW")> _
		Private Shared Function RegQueryValueLong( _
		  ByVal hkey As Int32, _
		  ByVal lpValueName As String, _
		  ByVal lpReserved As Int32, _
		  ByRef lpType As Int32, _
		  ByRef lpData As Int32, _
		  ByRef lpcbData As Int32 _
		  ) As Int32
		End Function

		<DllImport("Coredll.dll", EntryPoint:="RegQueryValueExW")> _
		Private Shared Function RegQueryValueString( _
		  ByVal hkey As Int32, _
		  ByVal lpValueName As String, _
		  ByVal lpReserved As Int32, _
		  ByRef lpType As Int32, _
		  ByVal lpData As StringBuilder, _
		  ByRef lpcbData As Int32 _
		  ) As Int32
		End Function

		'WINADVAPI LONG APIENTRY RegSetValueExW (IN HKEY hKey, IN LPCWSTR lpValueName, 
		'IN DWORD Reserved, IN DWORD dwType, IN CONST BYTE* lpData, IN DWORD cbData);
		<DllImport("Coredll.dll", EntryPoint:="RegSetValueExW")> _
		Private Shared Function RegSetValueExLong( _
		  ByVal hkey As Int32, _
		  ByVal lpValueName As String, _
		  ByVal Reserved As Int32, _
		  ByRef dwType As Int32, _
		  ByRef lpValue As Int32, _
		  ByVal cbData As Int32 _
		  ) As Int32
		End Function

		<DllImport("Coredll.dll", EntryPoint:="RegSetValueExW")> _
		Private Shared Function RegSetValueExString( _
		  ByVal hkey As Int32, _
		  ByVal lpValueName As String, _
		  ByVal Reserved As Int32, _
		  ByVal dwType As Int32, _
		  ByVal lpValue As String, _
		  ByVal cbData As Int32 _
		  ) As Int32
		End Function
#End Region

		Public Function CreateNewKey(ByVal rootSection As tagRegistryRootKeys, ByVal sNewKeyName As String) As Boolean
			Dim hNewKey As Int32
			Dim lRet As Int32			' is non zeroif create fails

			lRet = RegCreateKeyEx(rootSection, _
				 sNewKeyName, 0, _
				 String.Empty, _
				 RegOptionNonVolatile, _
				 KeyAllAccess, _
				 0, _
				 hNewKey, lRet)

			RegCloseKey(hNewKey)
			Return lRet <> 0
		End Function
		Public Function QueryValue(ByVal lSection As Int32, ByVal sKeyName As String, ByVal sValueName As String) As Object
			Dim lRet As Int32
			Dim hkey As Int32
			Dim vValue As Object

			Try
				If RegOpenKeyEx(lSection, sKeyName, 0, KeyAllAccess, hkey) = 0 Then
					lRet = QueryValueEx(hkey, sValueName, vValue)
				End If
			Catch ex As Exception
				Throw ex
			Finally
				RegCloseKey(hkey)
			End Try

			Return CType(vValue, Object)
		End Function
		Public Function QueryStringValue(ByVal lSection As Int32, ByVal sKeyName As String, ByVal sValueName As String) As String
			Dim lRet As Int32
			Dim hkey As Int32
			Dim vValue As Object

			If RegOpenKeyEx(lSection, sKeyName, 0, KeyAllAccess, hkey) = 0 Then
				lRet = QueryValueEx(hkey, sValueName, vValue)
				RegCloseKey(hkey)
			End If

			Return CType(vValue, String)
		End Function
		Public Function QueryLongValue(ByVal lSection As Int32, ByVal sKeyName As String, ByVal sValueName As String) As Long
			Dim lRet As Int32
			Dim hkey As Int32
			Dim vValue As Object

			If RegOpenKeyEx(lSection, sKeyName, 0, KeyAllAccess, hkey) = 0 Then
				lRet = QueryValueEx(hkey, sValueName, vValue)
				RegCloseKey(hkey)
			End If

			Return CType(vValue, Int32)
		End Function
		Public Sub SetKeyValue(ByVal lSection As Int32, ByVal sKeyName As String, ByVal sValueName As String, ByVal vValueSetting As Object, ByVal lValueType As Int32)
			Dim lRet As Int32
			Dim hkey As Int32

			If RegOpenKeyEx(lSection, sKeyName, 0, KeyAllAccess, hkey) = 0 Then
				lRet = SetValueEx(hkey, sValueName, lValueType, vValueSetting)
				RegCloseKey(hkey)
			End If
		End Sub
		Public Sub DeleteKey(ByVal lSection As tagRegistryRootKeys, ByVal keyValue As String)
			RegDeleteKey(lSection, keyValue)
		End Sub

		Private Function SetValueEx(ByVal hkey As Int32, ByVal sValueName As String, ByVal lType As RegistryDataType, ByVal vValue As Object) As Int32
			Dim lValue As Int32
			Dim sValue As String

			Select Case lType
				Case RegistryDataType.String
					sValue = vValue & Chr(0)
					Return RegSetValueExString(hkey, sValueName, 0, lType, sValue, Len(sValue) * 2)
				Case RegistryDataType.Number
					lValue = vValue
					Return RegSetValueExLong(hkey, sValueName, 0, lType, lValue, 4)
			End Select
		End Function
		Private Function QueryValueEx(ByVal lhKey As Int32, ByVal szValueName As String, ByRef vValue As Object) As Int32
			Dim lenData As Int32
			Dim intRet As Int32
			Dim lType As RegistryDataType
			Dim lValue As Int32
			Dim sValue As StringBuilder

			intRet = RegQueryValueEx(lhKey, szValueName, 0, lType, 0, lenData)

			Select Case lType
				Case RegistryDataType.String
					sValue = New StringBuilder(lenData)
					intRet = RegQueryValueString(lhKey, szValueName, 0, lType, sValue, lenData)
					If intRet = tagReturnValues.NoError Then
						vValue = sValue.ToString
					Else
						vValue = String.Empty
					End If

				Case RegistryDataType.Number
					intRet = RegQueryValueLong(lhKey, szValueName, 0, lType, lValue, lenData)
					If intRet = tagReturnValues.NoError Then
						vValue = lValue
					End If

				Case Else
					intRet = -1

			End Select

			Return intRet
		End Function
	End Class
End Namespace
