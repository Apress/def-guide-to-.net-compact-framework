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
Imports System.Security.Cryptography

Namespace CompactFramework.UnmanagedCode
    Public Class CryptoAPI

        Private Const _password As String = "77709C1B61834c68AFAE8BB93323EAC7"
        Private _algorithm As Int32 = CALG_MD2
        Private _algortihm2 As Int32 = CALG_DES

#Region "Constant Definitions"
        Private Const PROV_RSA_FULL As Int32 = 1

        '// dwFlag definitions for CryptGenKey
        Private Const CRYPT_EXPORTABLE As Int32 = &H1
        Private Const CRYPT_USER_PROTECTED As Int32 = &H2
        Private Const CRYPT_CREATE_SALT As Int32 = &H4
        Private Const CRYPT_UPDATE_KEY As Int32 = &H8
        Private Const CRYPT_NO_SALT As Int32 = &H10
        Private Const CRYPT_PREGEN As Int32 = &H40

        '// Hash sub ids
        Private Const ALG_SID_MD2 As Int32 = 1
        Private Const ALG_SID_MD4 As Int32 = 2
        Private Const ALG_SID_MD5 As Int32 = 3
        Private Const ALG_SID_SHA As Int32 = 4
        Private Const ALG_SID_SHA1 As Int32 = 4
        Private Const ALG_SID_MAC As Int32 = 5
        Private Const ALG_SID_RIPEMD As Int32 = 6
        Private Const ALG_SID_RIPEMD160 As Int32 = 7
        Private Const ALG_SID_SSL3SHAMD5 As Int32 = 8
        Private Const ALG_SID_HMAC As Int32 = 9
        Private Const ALG_SID_TLS1PRF As Int32 = 10
        Private Const ALG_SID_RC2 As Int32 = 2
        Private Const ALG_SID_RC5 As Int32 = 13

        '// Algorithm classes
        Private Const ALG_CLASS_ANY As Int32 = 0
        Private Const ALG_CLASS_SIGNATURE As Int32 = 8192       '(1 << 13)
        Private Const ALG_CLASS_MSG_ENCRYPT As Int32 = 16384    '(2 << 13)
        Private Const ALG_CLASS_DATA_ENCRYPT As Int32 = 24576   '(3 << 13)
        Private Const ALG_CLASS_HASH As Int32 = 32768           '(4 << 13)
        Private Const ALG_CLASS_KEY_EXCHANGE As Int32 = 40990   '(5 << 13) = 5 * Math.Pow(2, 13)

        '// Algorithm types
        Private Const ALG_TYPE_ANY As Int32 = 0
        Private Const ALG_TYPE_DSS As Int32 = 512
        Private Const ALG_TYPE_RSA As Int32 = 1024
        Private Const ALG_TYPE_BLOCK As Int32 = 1536
        Private Const ALG_TYPE_STREAM As Int32 = 2048

        '// algorithm identifier definitions
		Private Const CALG_MD2 As Int32 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD2
		Private Const CALG_MD4 As Int32 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD4
		Private Const CALG_MD5 As Int32 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD5
		Private Const CALG_SHA As Int32 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_SHA
		Private Const CALG_SHA1 As Int32 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_SHA1
		Private Const CALG_MAC As Int32 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MAC
        Private Const CALG_DES As Int32 = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_DES
        Private Const CALG_RC2 As Int32 = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_RC2
        Private Const CALG_RC5 As Int32 = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_RC5

        Private Const HP_HASHVAL As Int32 = 2
        Private Const HP_HASHSIZE As Int32 = 4

        Private Const ALG_SID_DES As Integer = 1
        Private Const ALG_SID_3DES As Integer = 3
        Private Const ALG_SID_DESX As Integer = 4
#End Region
#Region "Declaration"
		'WINADVAPI BOOL WINAPI
		'CryptEncrypt(HCRYPTKEY hKey,HCRYPTHASH hHash,BOOL Final,DWORD dwFlags,BYTE *pbData,DWORD *pdwDataLen,DWORD dwBufLen);
		<DllImport("coredll.dll", EntryPoint:="CryptEncrypt", SetLastError:=True)> _
		Public Shared Function CryptEncrypt(ByVal hKey As IntPtr, ByVal hHash As IntPtr, ByVal Final As Boolean, _
		 ByVal dwFlags As Int32, ByVal pbData As Byte(), ByRef pdwDataLen As Int32, ByVal dwBufLen As Int32) As Boolean
		End Function

		'WINADVAPI BOOL WINAPI CryptDecrypt(HCRYPTKEY hKey,HCRYPTHASH hHash,BOOL Final,DWORD dwFlags,BYTE *pbData,DWORD *pdwDataLen);
		<DllImport("coredll.dll", SetLastError:=True)> _
		Public Shared Function CryptDecrypt(ByVal hKey As IntPtr, ByVal hHash As IntPtr, ByVal Final As Boolean, _
		  ByVal dwFlags As Int32, ByVal pbData As Byte(), ByRef pdwDataLen As Int32) As Boolean
		End Function

		'WINADVAPI BOOL WINAPI CryptDeriveKey(HCRYPTPROV hProv,ALG_ID Algid,HCRYPTHASH hBaseData,DWORD dwFlags,HCRYPTKEY *phKey);
		<DllImport("coredll.dll", SetLastError:=True)> _
		Public Shared Function CryptDeriveKey(ByVal hProv As IntPtr, ByVal Algid As Int32, ByVal hHash As IntPtr, ByVal dwFlags As Int32, ByRef hKey As IntPtr) As Boolean
		End Function

		'WINADVAPI BOOL WINAPI CryptDestroyKey(HCRYPTKEY hKey);
		<DllImport("coredll.dll")> _
		Public Shared Function CryptDestroyKey(ByVal hKey As IntPtr) As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Public Shared Function CryptAcquireContext(ByRef hProv As IntPtr, ByVal pszContainer As String, ByVal pszProvider As String, ByVal dwProvType As Int32, ByVal dwFlags As Int32) As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Public Shared Function CryptCreateHash(ByVal hProv As IntPtr, ByVal Algid As Int32, ByVal hKey As IntPtr, ByVal dwFlags As Int32, ByRef phHash As IntPtr) As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Public Shared Function CryptHashData(ByVal hHash As IntPtr, ByVal pbData As Byte(), ByVal dwDataLen As Int32, ByVal dwFlags As Int32) As Boolean
		End Function

		'WINADVAPI BOOL WINAPI
		'CryptGetHashParam(HCRYPTHASH hHash,DWORD dwParam,BYTE*pbData,DWORD *pdwDataLen,DWORD dwFlags);
		<DllImport("coredll.dll")> _
		Public Shared Function CryptGetHashParam(ByVal hHash As IntPtr, ByVal dwParam As Int32, ByVal pbData As Byte(), ByRef pdwDataLen As Int32, ByVal dwFlags As Int32) As Boolean
		End Function

		'WINADVAPI BOOL WINAPI
		'CryptGenKey(HCRYPTPROV hProv,ALG_ID Algid,DWORD dwFlags,HCRYPTKEY *phKey);
		<DllImport("coredll.dll")> _
		Private Shared Function CryptGenKey(ByVal hProv As IntPtr, ByVal Algid As Int32, ByVal dwFlags As Int32, ByRef phKey As IntPtr) As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Public Shared Function CryptDestroyHash(ByVal hHash As IntPtr) As Boolean
		End Function

		<DllImport("coredll.dll")> _
		Public Shared Function CryptReleaseContext(ByVal hProv As IntPtr, ByVal dwFlags As Int32) As Boolean
		End Function

		<DllImport("Coredll.dll")> _
		Public Shared Function GetLastError() As Int32
		End Function

#End Region

#Region " Decryption Methods "
        Public Function DecryptString(ByVal strData As String) As String
            Return DecryptStringEx(strData, _password)
        End Function
        Public Function DecryptString(ByVal strData As String, ByVal password As String) As String
            Return DecryptStringEx(strData, password)
        End Function
        Private Function DecryptStringEx(ByVal strData As String, ByVal password As String) As String
            Dim hProv As IntPtr
            Dim phKey As IntPtr

            Dim retVal As Boolean = CryptAcquireContext(hProv, Nothing, Nothing, PROV_RSA_FULL, 0)
            Dim hHash As IntPtr = IntPtr.Zero
            retVal = CryptCreateHash(hProv, _algorithm, IntPtr.Zero, 0, hHash) 'CALG_MD5
            If Not retVal Then
                Dim retError = GetLastError()
                Return String.Empty
            End If

            Dim byteValue As Byte() = System.Text.Encoding.ASCII.GetBytes(password)
            Dim byteValueLen As Int32 = byteValue.Length
            retVal = CryptHashData(hHash, byteValue, byteValueLen, 0)
            If Not retVal Then
                Dim retError = GetLastError()
                Return String.Empty
            End If

            retVal = CryptDeriveKey(hProv, _algortihm2, hHash, CRYPT_EXPORTABLE, phKey)
            If Not retVal Then
                Dim retError = GetLastError()
                Return String.Empty
            End If

            byteValue = System.Convert.FromBase64String(strData)
            Dim bLen As Integer = byteValue.Length

            retVal = CryptDecrypt(phKey, IntPtr.Zero, True, 0, byteValue, bLen)
            If Not retVal Then
                Dim retError = GetLastError()
                Return String.Empty
			End If
			retVal = CryptDestroyKey(phKey)
			retVal = CryptDestroyHash(hHash)
			retVal = CryptReleaseContext(hProv, 0)

			Return System.Text.Encoding.ASCII.GetString(byteValue, 0, bLen)
        End Function
#End Region
#Region " Encryption Methods "
        Public Function EncryptString(ByVal strData As String, ByVal password As String) As String
            Return EncryptStringEx(strData, password)
        End Function
        Public Function EncryptString(ByVal strData As String) As String
            Return EncryptStringEx(strData, _password)
        End Function
		Private Function EncryptStringEx(ByVal strData As String, ByVal password As String) As String
			Dim hProv As IntPtr
			Dim phKey As IntPtr

			Dim retVal As Boolean = CryptAcquireContext(hProv, Nothing, Nothing, PROV_RSA_FULL, 0)
			Dim hHash As IntPtr = IntPtr.Zero
			retVal = CryptCreateHash(hProv, _algorithm, IntPtr.Zero, 0, hHash)
			If Not retVal Then
				Dim retError = GetLastError()
				Return String.Empty
			End If

			Dim byteValue As Byte() = System.Text.Encoding.ASCII.GetBytes(password)
			Dim byteValueLen As Int32 = byteValue.Length
			retVal = CryptHashData(hHash, byteValue, byteValueLen, 0)
			If Not retVal Then
				Dim retError = GetLastError()
				Return String.Empty
			End If

			retVal = CryptDeriveKey(hProv, _algortihm2, hHash, CRYPT_EXPORTABLE, phKey)
			If Not retVal Then
				Dim retError = GetLastError()
				Return String.Empty
			End If

			byteValue = System.Text.Encoding.ASCII.GetBytes(strData)
			Dim bLen As Integer = byteValue.Length
			Dim requiredLen As Int32 = byteValue.Length
			Dim encryptedLen As Int32 = byteValue.Length

			'   Get the size of the buffer for the encrypted string
			retVal = CryptEncrypt(phKey, IntPtr.Zero, True, 0, Nothing, requiredLen, encryptedLen)
			If Not retVal Then
				Dim retError = GetLastError()
				Return String.Empty
			End If

			' resize the array to hold extra data after encryption
			ReDim Preserve byteValue(requiredLen)
			encryptedLen = byteValue.Length
			retVal = CryptEncrypt(phKey, IntPtr.Zero, True, 0, byteValue, bLen, encryptedLen)
			If Not retVal Then
				Dim retError As Integer = Marshal.GetLastWin32Error()
				Return String.Empty
			End If

			CryptDestroyHash(hHash)
			CryptDestroyKey(phKey)
			CryptReleaseContext(hProv, 0)

			Return System.Convert.ToBase64String(byteValue, 0, bLen)
		End Function
#End Region

        Public Function GenerateHash(ByVal value As String) As String

            Dim hProv As IntPtr
            Dim retVal As Boolean = CryptAcquireContext(hProv, Nothing, Nothing, PROV_RSA_FULL, 0)
            Dim hHash As IntPtr = IntPtr.Zero

            retVal = CryptCreateHash(hProv, CALG_SHA1, IntPtr.Zero, 0, hHash)

            Dim byteValue As Byte() = System.Text.Encoding.ASCII.GetBytes(value)
            Dim publicKeyLen As Int32 = byteValue.Length
            retVal = CryptHashData(hHash, byteValue, publicKeyLen, 0)

            Dim bufferLen As Int32
            Dim buffer As Byte()
            Dim buffLen As Byte()
            ReDim buffLen(1)

            retVal = CryptGetHashParam(hHash, HP_HASHSIZE, buffLen, 4, 0)
            bufferLen = Convert.ToInt32(buffLen(0))
            ReDim buffer(bufferLen)

            retVal = CryptGetHashParam(hHash, HP_HASHVAL, buffer, bufferLen, 0)
            retVal = CryptDestroyHash(hHash)
            retVal = CryptReleaseContext(hProv, 0)

            Return System.Convert.ToBase64String(buffer, 0, bufferLen)
        End Function

    End Class
End Namespace
