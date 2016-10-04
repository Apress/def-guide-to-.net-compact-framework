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
Imports System.Diagnostics
Imports System.Environment
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text

Namespace ForestSoftware.NetCF.UserSettings

#Region " Interface Definition "
	Public Interface UserSettings
		Function ReadSettingInt(ByVal section As String, ByVal entry As String, ByVal defaultVal As Int32) As Int32
		Function ReadSettingString(ByVal section As String, ByVal entry As String, ByVal defaultVal As String) As String
		Function WriteSettingString(ByVal section As String, ByVal entry As String, ByVal dataValue As String) As Boolean
		Function WriteSettingInt(ByVal section As String, ByVal entry As String, ByVal dataValue As Int32) As Boolean
		Function GetSectionNames() As String()
		Sub DeleteKey(ByVal SectionName As String, ByVal KeyName As String)
	End Interface
#End Region

#Region " SettingSupport Class "
	Public Class SettingSupport
		Public Shared Function CallingAppPath() As String
			CallingAppPath = _
			System.IO.Path.GetDirectoryName(Reflection.Assembly. _
			 GetCallingAssembly().GetName().CodeBase.ToString())
		End Function
		Public Shared Function CallingAppName() As String
			CallingAppName = _
			Reflection.Assembly.GetCallingAssembly().GetName().Name
		End Function
		Public Shared Function AppPath() As String
			' Return the path to this application.
			AppPath = _
			System.IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString())
		End Function
		Public Shared Function AppName() As String
			AppName = _
			Reflection.Assembly.GetExecutingAssembly().GetName().Name
		End Function
	End Class
#End Region

#Region " IniSettings Class Implementation "
	Public Class IniSettings : Implements UserSettings
		Private _AppName As String
		Private _fileName As String

		Private Sub New()
		End Sub
		Public Sub New(ByVal strAppName As String)
			_AppName = strAppName
			_fileName = SettingSupport.AppPath() & "\" & strAppName & ".ini"
		End Sub

		Private Function OpenFileWrite() As System.IO.StreamWriter
			Dim sr As System.IO.StreamWriter

			' Check to see if the file exists. If it does open and read the file.
			If (System.IO.File.Exists(_fileName)) Then
				sr = System.IO.File.AppendText(_fileName)
			Else
				sr = System.IO.File.CreateText(_fileName)
			End If

			Return sr
		End Function
		Private Function ReadSettingValue(ByVal section As String, ByVal key As String, ByVal defaultVal As Object) As String
			'	Create or open the file
			Dim strContent As String
			Dim strContentBackup As String
			Dim posSection As Int32
			Dim iPos As Int32 = 0
			Dim sr As System.IO.StreamReader

			Try
				If (System.IO.File.Exists(_fileName)) Then
					'	If it does exist, open it, read in the entire file
					sr = File.OpenText(_fileName)
					strContent = sr.ReadToEnd()
					sr.Close()

					strContentBackup = strContent.ToLower
					section = section.ToLower
					key = key.ToLower

					'Look for the requested section
					posSection = strContentBackup.IndexOf("[" & section & "]")
					If posSection <> -1 Then
						' found it
						'	Break the INI file into sections
						strContent = strContent.Replace(vbTab, "")
						Dim strSections() As String = strContentBackup.Split(Convert.ToChar("["))
						Dim sectionNumber As Int32
						iPos = 0
						Dim sPos As Int32
						Dim bPos As Int32
						For Each s As String In strSections
							'	make sure that this is the correct section first
							If s.StartsWith(section & "]") Then

								bPos = s.IndexOf(key & "=")
								If bPos <> -1 Then
									'	Make certain that this is not embedded in another word
									'	If it is not there will be a control character as the previous character
									If Char.IsControl(s.Chars(bPos - 1)) Then
										'	The entry we want to read is present
										Dim q As String = String.Empty
										sPos = bPos + key.Length + 1

										'walk from here until I find a non-hexdigit
										'	or acomment character ;
										While Not Char.IsControl(s.Chars(sPos)) And s.Chars(sPos) <> ";"
											sPos += 1
										End While
										Dim readValue As String = s.Substring(bPos + key.Length + 1, sPos - (bPos + key.Length + 1))
										Return readValue
									End If
								End If
								iPos += 1
							End If

						Next
					End If
				Else
				End If
				Return CType(defaultVal, String)
			Catch ex As Exception
				Return String.Empty
			Finally
				sr.Close()
			End Try
		End Function
		Public Function ReadSettingInt(ByVal section As String, _
		  ByVal key As String, _
		  ByVal defaultVal As Int32) As Int32 Implements UserSettings.ReadSettingInt
			Return CType(ReadSettingValue(section, key, defaultVal), Int32)
		End Function
		Public Function ReadSettingString(ByVal section As String, _
		  ByVal key As String, _
		  ByVal defaultVal As String) As String Implements UserSettings.ReadSettingString
			Return ReadSettingValue(section, key, defaultVal)
		End Function
		Public Function WriteSettingString(ByVal section As String, _
		ByVal key As String, _
		ByVal defaultVal As String) As Boolean Implements UserSettings.WriteSettingString
			Dim posSection As Int32
			Dim iPos As Int32 = 0
			'Dim bSectionExists As Boolean = False
			Dim bEntryFound As Boolean = False

			Dim strSection As String = "[" & section & "]"
			Dim strEntry As String = key & "="

			Dim strInput As String = String.Empty

			If (System.IO.File.Exists(_fileName)) Then
				'	If it does exist, open it, read in the entire file
				Dim sr As System.IO.StreamReader
				Dim sw As System.IO.StreamWriter
				sr = File.OpenText(_fileName)
				sw = New StreamWriter(_fileName & ".txt")

				Try
					While True
						strInput = sr.ReadLine()
						If strInput Is Nothing Then
							Exit While
						End If
						If strInput.StartsWith(strSection) Then
							'
							'	We found the section
							'							bSectionExists = True
							'
							'	Write the section marker out to the temp file
							sw.WriteLine(strInput)
							'
							'	Now read in one line at a time, looking for an enrty match
							'	or for the next section
							Dim intInput As Int32
							While True
								strInput = sr.ReadLine()
								If strInput Is Nothing Then
									Exit While
								End If
								If strInput.StartsWith("[") And Not bEntryFound Then
									'
									'	Didn't find the entry
									'	Write our new data to the temp file
									sw.WriteLine(strEntry & defaultVal)
									'	Write the sectionheader to file
									sw.WriteLine(strInput)
									Exit While
								ElseIf strInput.IndexOf(strEntry) = -1 Then
									'	not the entry I wanted
									sw.WriteLine(strInput)
								Else
									'	FOUND IT!!'	Write the new value to the file
									sw.WriteLine(strEntry & defaultVal)
									bEntryFound = True
								End If
							End While

							'    Successful read of the entire file
							'    Be sure to close the file first
							sr.Close()
							sw.Close()
							'    copy the new file over the old file
							System.IO.File.Copy(_fileName & ".txt", _fileName, True)
						Else
							'	Anything other than a section marker we need to it back to our temp file
							sw.WriteLine(strInput)
						End If
					End While
				Catch ex As Exception
					MsgBox(ex.Message)
				Finally
					sw.Close()
					sr.Close()
				End Try
			Else
				Dim sw As System.IO.StreamWriter
				sw = New StreamWriter(_fileName)
				sw.WriteLine(strSection)
				sw.WriteLine(strEntry & defaultVal)
				sw.Close()
			End If
			Return bEntryFound
		End Function
		Public Function WriteSettingInt(ByVal section As String, ByVal key As String, ByVal dataValue As Int32) As Boolean Implements UserSettings.WriteSettingInt
			Return WriteSettingString(section, key, dataValue.ToString())
		End Function
		Public Function GetSectionNames() As String() Implements UserSettings.GetSectionNames
			Return Nothing
		End Function
		Public Sub DeleteKey(ByVal SectionName As String, ByVal KeyName As String) Implements UserSettings.DeleteKey
		End Sub
	End Class
#End Region

#Region " RegistrySettings Implementation "
	Public Class RegistrySettings : Implements UserSettings
		Private _AppName As String
		Private _RootKey As RegistryAPI.RegistryRootKeys
		Private _BaseSubKey As String

		Private Sub New()
		End Sub

		Public Sub New(ByVal strAppName As String)
			_AppName = strAppName
			_BaseSubKey = "Software\" & strAppName & "\"
			_RootKey = RegistryAPI.RegistryRootKeys.HkeyLocalMachine
		End Sub
		Public Sub New(ByVal strAppname As String, ByVal bPrivate As Boolean)
			_AppName = strAppname
			_BaseSubKey = "Software\" & strAppname & "\"
			If bPrivate Then
				_RootKey = RegistryAPI.RegistryRootKeys.HkeyCurrentUser
			Else
				_RootKey = RegistryAPI.RegistryRootKeys.HkeyLocalMachine
			End If
		End Sub

		Public Function ReadSettingInt(ByVal section As String, ByVal entry As String, ByVal defaultVal As Int32) As Int32 Implements UserSettings.ReadSettingInt
			Dim ra As RegistryAPI = New RegistryAPI
			Dim retEntry As Int32
			If ra.QueryValue(_RootKey, _BaseSubKey & section, entry, retEntry) Then
				Return retEntry
			Else
				Return defaultVal
			End If
		End Function
		Public Function ReadSettingString(ByVal section As String, ByVal entry As String, ByVal defaultVal As String) As String Implements UserSettings.ReadSettingString
			Dim ra As RegistryAPI = New RegistryAPI
			Dim retEntry As String
			If ra.QueryValue(_RootKey, _BaseSubKey & section, entry, retEntry) Then
				Return retEntry
			Else
				Return defaultVal
			End If
		End Function
		Public Function WriteSettingString(ByVal section As String, ByVal entry As String, ByVal dataValue As String) As Boolean Implements UserSettings.WriteSettingString
			Dim ra As RegistryAPI = New RegistryAPI

			Return ra.SetValue(_RootKey, _BaseSubKey & section, entry, dataValue)
		End Function
		Public Function WriteSettingInt(ByVal section As String, ByVal entry As String, ByVal dataValue As Int32) As Boolean Implements UserSettings.WriteSettingInt
			Dim ra As RegistryAPI = New RegistryAPI

			Return ra.SetValue(_RootKey, _BaseSubKey & section, entry, dataValue)
		End Function
		Public Function GetSectionNames() As String() Implements UserSettings.GetSectionNames
			Return Nothing
		End Function
		Public Sub DeleteKey(ByVal SectionName As String, ByVal KeyName As String) Implements UserSettings.DeleteKey
		End Sub
	End Class
#End Region

#Region " XmlSettings Implementation "
	Public Class XmlSettings : Implements UserSettings

		Private m_sXMLFileName As String

		Private Sub New()
		End Sub
		Public Sub New(ByVal AppName As String)
			'default to appname.xml in app.path
			m_sXMLFileName = SettingSupport.CallingAppPath() & "\" & AppName & ".config"
		End Sub

		Private Function ReadSettingValue(ByVal section As String, ByVal key As String, ByVal defaultVal As String) As String
			Dim dr As XmlTextReader
			Dim strRetValue As String = defaultVal

			Try
				dr = New XmlTextReader(m_sXMLFileName)
				dr.WhitespaceHandling = WhitespaceHandling.None

				While dr.Read()
					'	Look for the <configuration> section
					'	This lets us add several peices in the config file
					If dr.Name = "configuration" Then
						'	We are in the correct space, now for the requested section
						While dr.Read
							If dr.NodeType = XmlNodeType.Element AndAlso dr.HasAttributes AndAlso dr.Name = "Section" Then
								'	Check to see if the attribute is the section we are looking for
								dr.MoveToFirstAttribute()
								If dr.Name = "Name" And dr.Value = section Then
									'	We found the section, now look for the correct entry (key) item
									While dr.Read
										If dr.NodeType = XmlNodeType.Element AndAlso dr.Name.ToString() = "Key" AndAlso dr.HasAttributes Then
											'  Walk and look at all elements
											dr.MoveToFirstAttribute()
											If dr.Name = "Name" AndAlso dr.Value = key AndAlso dr.HasAttributes Then
												'get the next attribute
												dr.MoveToNextAttribute()
												If dr.Name = "Value" Then
													Return dr.Value
												End If
											End If
										End If
									End While
								End If
							End If
						End While
					End If
				End While
				'    If we get here, nothing was found
				Return defaultVal
			Finally
				dr.Close()
			End Try

		End Function
		Public Function ReadSettingInt(ByVal section As String, ByVal key As String, ByVal defaultVal As Int32) As Int32 Implements UserSettings.ReadSettingInt
			Return Convert.ToInt32(ReadSettingValue(section, key, defaultVal.ToString()))
		End Function
		Public Function ReadSettingString(ByVal section As String, ByVal key As String, ByVal defaultVal As String) As String Implements UserSettings.ReadSettingString
			Return ReadSettingValue(section, key, defaultVal)
		End Function

		Public Function WriteSettingValue(ByVal section As String, ByVal key As String, ByVal dataValue As String) As Boolean
			'	Does the file exist?
			Try
				Dim xd As XmlDocument = New XmlDocument
				xd.Load(m_sXMLFileName)

				Dim xe As XmlElement = xd.DocumentElement

				'    check the name to see if the node is <configuration
				If xe.Name = "configuration" Then
					'    each child node is a 'section' marker
					For Each xce As XmlElement In xe.ChildNodes
						'    Make certain if the structure of the file
						If xce.Name = "Section" Then
							'	check the attribute of the section
							If xce.Attributes(0).Name = "Name" And xce.Attributes(0).Value = section Then
								'    The AppendChild method will remove the element if it already exists
								Dim xe2 As XmlElement = xd.CreateElement("Key")
								xe2.SetAttribute("Name", key)
								xe2.SetAttribute("Value", dataValue)

								xce.AppendChild(xe2)
								Exit For
							End If
						End If
					Next
				End If
				'    write the document back to disk
				xd.Save(m_sXMLFileName)
			Catch ex As FileNotFoundException
				'    file does not exist
				Dim newDoc As XmlDocument = New XmlDocument
				Dim xe As XmlElement

				xe = newDoc.CreateElement("configuration")

				Dim sectionElement As XmlElement = newDoc.CreateElement("Section")
				sectionElement.SetAttribute("Name", section)

				Dim keyElement As XmlElement = newDoc.CreateElement("Key")
				keyElement.SetAttribute("Name", section)
				keyElement.SetAttribute("Value", dataValue)
				sectionElement.AppendChild(keyElement)

				newDoc.AppendChild(sectionElement)
				newDoc.Save(m_sXMLFileName)
			Finally
			End Try
		End Function
		Public Function WriteSettingString(ByVal section As String, ByVal key As String, ByVal dataValue As String) As Boolean Implements UserSettings.WriteSettingString
			Return WriteSettingValue(section, key, dataValue)
		End Function
		Public Function WriteSettingInt(ByVal section As String, ByVal key As String, ByVal dataValue As Int32) As Boolean Implements UserSettings.WriteSettingInt
			Return WriteSettingValue(section, key, dataValue.ToString())
		End Function
		Public Function GetSectionNames() As String() Implements UserSettings.GetSectionNames
			Return Nothing
		End Function
		Public Sub DeleteKey(ByVal SectionName As String, ByVal KeyName As String) Implements UserSettings.DeleteKey
		End Sub

	End Class
#End Region

#Region " RegistryAPI "
	Public Class RegistryAPI

#Region "Enums and Structs"
		Public Enum ReturnValues
			Successful = 0
			[Error] = 1
		End Enum

		Public Enum RegistryRootKeys
			HkeyCurrentUser = &H80000001
			HkeyLocalMachine = &H80000002
			HkeyClassesRoot = &H80000000
		End Enum

		Public Enum RegistryDataType
			[String] = 1
			Binary = 3
			Number = 4
		End Enum

		Public Const KeyAllAccess = &H3F
		Public Const RegOptionNonVolatile = 0
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

#Region "Public Methods"
		Public Function CreateKey(ByVal key As RegistryRootKeys, ByVal subKey As String) As Boolean
			Return CreateNewKey(key, subKey)
		End Function

		Public Function DeleteKey(ByVal key As RegistryRootKeys, ByVal subKey As String) As Boolean
			RegDeleteKey(key, subKey)
		End Function

		Public Function DeleteValue() As Boolean

		End Function
		Public Function QueryValue(ByVal key As RegistryRootKeys, ByVal subKey As String, ByVal valueName As String, ByRef valueData As String) As Boolean
			Dim bRet As Boolean = False
			Dim hkey As Int32
			Dim vValue As Object

			Try
				valueData = String.Empty
				If RegOpenKeyEx(key, subKey, 0, KeyAllAccess, hkey) = ReturnValues.Successful Then
					Try
						If QueryValueEx(hkey, valueName, vValue) = ReturnValues.Successful Then
							valueData = CType(vValue, String)
							bRet = True
						End If
					Catch ex As Exception
						Throw ex
					Finally
						RegCloseKey(hkey)
					End Try
				End If
			Catch ex As Exception
				Throw ex
			End Try

			Return bRet
		End Function
		Public Function QueryValue(ByVal key As RegistryRootKeys, ByVal subKey As String, ByVal valueName As String, ByRef valueData As Int32) As Boolean
			Dim bRet As Boolean = False
			Dim hkey As Int32
			Dim vValue As Object

			Try
				If RegOpenKeyEx(key, subKey, 0, KeyAllAccess, hkey) = ReturnValues.Successful Then
					Try
						If QueryValueEx(hkey, valueName, vValue) = ReturnValues.Successful Then
							valueData = CType(vValue, Int32)
							bRet = True
						End If
					Catch ex As Exception
						Throw ex
					Finally
						RegCloseKey(hkey)
					End Try
				End If
			Catch ex As Exception
				Throw ex
			End Try

			Return bRet
		End Function
		Public Function QueryValue(ByVal key As RegistryRootKeys, ByVal subKey As String, ByVal valueName As String, ByRef valueData As Object) As Boolean
			Dim bRet As Boolean = False
			Dim hkey As Int32
			Dim vValue As Object

			Try
				valueData = String.Empty
				If RegOpenKeyEx(key, subKey, 0, KeyAllAccess, hkey) = ReturnValues.Successful Then
					Try
						If QueryValueEx(hkey, valueName, vValue) = ReturnValues.Successful Then
							valueData = vValue
							bRet = True
						End If
					Catch ex As Exception
						Throw ex
					Finally
						RegCloseKey(hkey)
					End Try
				End If
			Catch ex As Exception
				Throw ex
			End Try

			Return bRet
		End Function

		Public Function SetValue(ByVal key As RegistryRootKeys, ByVal subKey As String, ByVal valueName As String, ByVal valueData As String) As Boolean
			Dim bRet As Boolean = False
			Dim hkey As Int32
			Dim dwDisposition As Int32

			Try
				If RegCreateKeyEx(key, subKey, 0, KeyAllAccess, 0, 0, Nothing, hkey, dwDisposition) = ReturnValues.Successful Then
					Try
						If SetValueEx(hkey, valueName, RegistryDataType.String, valueData) = ReturnValues.Successful Then
							bRet = True
						End If
					Catch ex As Exception
						Throw ex
					Finally
						RegCloseKey(hkey)
					End Try
				End If
			Catch ex As Exception
				Throw ex
			End Try

			Return bRet
		End Function
		Public Function SetValue(ByVal key As RegistryRootKeys, ByVal subKey As String, ByVal valueName As String, ByVal valueData As Int32) As Boolean
			Dim bRet As Boolean = False
			Dim hkey As Int32
			Dim dwDisposition As Int32

			Try
				If RegCreateKeyEx(key, subKey, 0, KeyAllAccess, 0, 0, Nothing, hkey, dwDisposition) = ReturnValues.Successful Then
					Try
						If SetValueEx(hkey, valueName, RegistryDataType.Number, valueData) = ReturnValues.Successful Then
							bRet = True
						End If
					Catch ex As Exception
						Throw ex
					Finally
						RegCloseKey(hkey)
					End Try
				End If
			Catch ex As Exception
				Throw ex
			End Try

			Return bRet
		End Function
#End Region

#Region "Private Methods"
		Private Function CreateNewKey(ByVal rootSection As RegistryRootKeys, ByVal sNewKeyName As String) As Boolean
			Dim hNewKey As Int32
			Dim lRet As Int32

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
					If intRet = ReturnValues.Successful Then
						vValue = sValue.ToString
					Else
						vValue = String.Empty
					End If

				Case RegistryDataType.Number
					intRet = RegQueryValueLong(lhKey, szValueName, 0, lType, lValue, lenData)
					If intRet = ReturnValues.Successful Then
						vValue = lValue
					End If

				Case 7012
					intRet = RegQueryValueLong(lhKey, szValueName, 0, lType, lValue, lenData)
					If intRet = ReturnValues.Successful Then
						vValue = lValue
					End If

				Case Else
					intRet = -1

			End Select

			Return intRet
		End Function
#End Region

	End Class

#End Region

End Namespace