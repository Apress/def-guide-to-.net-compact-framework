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
Imports System
Imports System.Runtime.InteropServices

Namespace CompactFramework.UnmanagedCode
	Public Class BatteryInformation
		'DWORD WINAPI GetSystemPowerStatusEx(PSYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx,BOOL fUpdate) 
		<DllImport("coredll", SetLastError:=True)> _
		Public Shared Function GetSystemPowerStatusEx(ByRef pStatus As SystemPowerStatusEx, ByVal fUpdate As Boolean) As Boolean
		End Function

		'DWORD WINAPI GetSystemPowerStatusEx2(PSYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx2,DWORD dwLen,BOOL fUpdate) 
		<DllImport("coredll", SetLastError:=True)> _
		Public Shared Function GetSystemPowerStatusEx2(ByRef sps As SystemPowerStatusEx2, ByVal dwLen As Int32, ByVal fUpdate As Boolean) As Boolean
		End Function

		<DllImport("Coredll.dll")> _
		Public Shared Function GetLastError() As Int32
		End Function

		<StructLayout(LayoutKind.Sequential)> _
		Public Structure SystemPowerStatusEx
			Public ACLineStatus As Byte
			Public BatteryFlag As Byte
			Public BatteryLifePercent As Byte
			Public Reserved1 As Byte
			Public BatteryLifeTime As Int32
			Public BatteryFullLifeTime As Int32
			Public Reserved2 As Byte
			Public BackupBatteryFlag As Byte
			Public BackupBatteryLifePercent As Byte
			Public Reserved3 As Byte
			Public BackupBatteryLifeTime As Int32
			Public BackupBatteryFullLifeTime As Int32
		End Structure
		Private Enum BatteryFlagState As Integer
			BATTERY_FLAG_HIGH = &H1
			BATTERY_FLAG_LOW = &H2
			BATTERY_FLAG_CRITICAL = &H4
			BATTERY_FLAG_CHARGING = &H8
			BATTERY_FLAG_NO_BATTERY = &H80
			BATTERY_FLAG_UNKNOWN = &HFF
		End Enum


		Public Enum BatteryChemistryType As Integer
			Alkaline = &H1
			Nicad = &H2
			Nimh = &H3
			LIon = &H4
			LiPoly = &H5
			Unknown = &HFF
		End Enum

		<StructLayout(LayoutKind.Sequential)> _
		Public Structure SystemPowerStatusEx2
			Public ACLineStatus As Byte
			Public BatteryFlag As Byte
			Public BatteryLifePercent As Byte
			Public Reserved1 As Byte
			Public BatteryLifeTime As Int32
			Public BatteryFullLifeTime As Int32
			Public Reserved2 As Byte
			Public BackupBatteryFlag As Byte
			Public BackupBatteryLifePercent As Byte
			Public Reserved3 As Byte
			Public BackupBatteryLifeTime As Int32
			Public BackupBatteryFullLifeTime As Int32
			'   The Ex2 version has these additional fields
			Public BatteryVoltage As Int32
			Public BatteryCurrent As Int32
			Public BatteryAverageCurrent As Int32
			Public BatteryAverageInterval As Int32
			Public BatteryAHourConsumed As Int32
			Public BatteryTemperaure As Int32
			Public BackupBatteryVoltage As Int32
			Public BatteryChemistry As Byte
		End Structure

		Private Const BATTERY_PERCENTAGE_UNKNOWN As Int32 = &HFF
		Private Const BATTERY_LIFE_UNKNOWN As Int32 = &HFFFFFFFF

		Private _PowerStatus As SystemPowerStatusEx2

#Region "Properties"
		Public ReadOnly Property LineStatus() As String
			Get
				If _PowerStatus.ACLineStatus = 0 Then
					Return "OffLine"
				ElseIf _PowerStatus.ACLineStatus = 1 Then
					Return "OnLine"
				Else
					Return "Unknown"
				End If
			End Get
		End Property
		Public ReadOnly Property LineStatusN() As Byte
			Get
				Return _PowerStatus.ACLineStatus
			End Get
		End Property

		Public ReadOnly Property BatteryFlag() As String
			Get
				Dim bflg As String
				Select Case _PowerStatus.BatteryFlag
					Case BatteryFlagState.BATTERY_FLAG_HIGH
						bflg = "High"
					Case BatteryFlagState.BATTERY_FLAG_LOW
						bflg = "Low"
					Case BatteryFlagState.BATTERY_FLAG_CRITICAL
						bflg = "Critical"
					Case BatteryFlagState.BATTERY_FLAG_CHARGING
						bflg = "Charging"
					Case BatteryFlagState.BATTERY_FLAG_NO_BATTERY
						bflg = "No System Battery"
					Case BatteryFlagState.BATTERY_FLAG_UNKNOWN
						bflg = "Unknown Status"
					Case Else
						bflg = "Unknown Status"
				End Select
				Return bflg
			End Get
		End Property
		Public ReadOnly Property BatteryFlagN() As Byte
			Get
				Return _PowerStatus.BatteryFlag
			End Get
		End Property

		Public ReadOnly Property BatteryLifePercent() As String
			Get
				Return _PowerStatus.BatteryLifePercent.ToString()
			End Get
		End Property
		Public ReadOnly Property BatteryLifePercentN() As Byte
			Get
				Return _PowerStatus.BatteryLifePercent
			End Get
		End Property

		Public ReadOnly Property BackupBatteryFlag() As String
			Get
				Return _PowerStatus.BackupBatteryFlag.ToString()
			End Get
		End Property
		Public ReadOnly Property BackupBatteryFlagN() As Byte
			Get
				Return _PowerStatus.BackupBatteryFlag
			End Get
		End Property

		Public ReadOnly Property BackupBatteryLifePercent() As String
			Get
				Return _PowerStatus.BackupBatteryLifePercent.ToString()
			End Get
		End Property
		Public ReadOnly Property BackupBatteryLifePercentN() As Byte
			Get
				Return _PowerStatus.BackupBatteryLifePercent
			End Get
		End Property

		Public ReadOnly Property BatteryLifeTime() As String
			Get
				Return _PowerStatus.BatteryLifeTime.ToString()
			End Get
		End Property
		Public ReadOnly Property BatteryLifeTimeN() As Int32
			Get
				Return _PowerStatus.BatteryLifeTime
			End Get
		End Property

		Public ReadOnly Property BatteryFullLifeTime() As String
			Get
				Return _PowerStatus.BatteryFullLifeTime.ToString()
			End Get
		End Property
		Public ReadOnly Property BatteryFullLifeTimeN() As Int32
			Get
				Return _PowerStatus.BatteryFullLifeTime
			End Get
		End Property

		Public ReadOnly Property BackupBatteryLifeTime() As String
			Get
				Return _PowerStatus.BackupBatteryLifeTime.ToString()
			End Get
		End Property
		Public ReadOnly Property BackupBatteryLifeTimeN() As Int32
			Get
				Return _PowerStatus.BackupBatteryLifeTime
			End Get
		End Property

		Public ReadOnly Property BackupBatteryFullLifeTime() As String
			Get
				Return _PowerStatus.BackupBatteryFullLifeTime.ToString()
			End Get
		End Property
		Public ReadOnly Property BackupBatteryFullLifeTimeN() As Int32
			Get
				Return _PowerStatus.BackupBatteryFullLifeTime
			End Get
		End Property

		Public ReadOnly Property BatteryVoltage() As String
			Get
				Return _PowerStatus.BatteryVoltage.ToString()
			End Get
		End Property

		Public ReadOnly Property BatteryCurrent() As String
			Get
				Return _PowerStatus.BatteryCurrent.ToString()
			End Get
		End Property
		Public ReadOnly Property BatteryAverageCurrent() As String
			Get
				Return _PowerStatus.BatteryAverageCurrent.ToString()
			End Get
		End Property

		Public ReadOnly Property BatteryAverageInterval() As String
			Get
				Return _PowerStatus.BatteryAverageInterval.ToString()
			End Get
		End Property
		Public ReadOnly Property BatteryAHourConsumed() As String
			Get
				Return _PowerStatus.BatteryAHourConsumed.ToString()
			End Get
		End Property
		Public ReadOnly Property BatteryTemperaure() As String
			Get
				Return _PowerStatus.BatteryTemperaure.ToString()
			End Get
		End Property
		Public ReadOnly Property BackupBatteryVoltage() As String
			Get
				Return _PowerStatus.BackupBatteryVoltage.ToString()
			End Get
		End Property
		Public ReadOnly Property BatteryChemistry() As String
			Get
				Select Case _PowerStatus.BatteryChemistry
					Case BatteryChemistryType.Alkaline
						Return "Alkaline"
					Case BatteryChemistryType.LIon
						Return "Lion"
					Case BatteryChemistryType.LiPoly
						Return "LiPoly"
					Case BatteryChemistryType.Nicad
						Return "Nicad"
					Case BatteryChemistryType.Nimh
						Return "Nimh"
					Case BatteryChemistryType.Unknown
						Return "Unknown"
				End Select
			End Get
		End Property

#End Region
		Public Sub New()
			Refresh()
		End Sub

		Public Sub Refresh()
			Dim bRet As Boolean = False
			Try
				Dim sizeOf As Int32 = Marshal.SizeOf(_PowerStatus)
				bRet = GetSystemPowerStatusEx2(_PowerStatus, sizeOf, True)
			Catch ex As Exception
			End Try

			If Not bRet Then
				Try
					Dim sps As SystemPowerStatusEx = New SystemPowerStatusEx
					If GetSystemPowerStatusEx(sps, True) Then
						'	Store the data to our class level SystemPowerStatusEx2 structure
						_PowerStatus.ACLineStatus = sps.ACLineStatus
						_PowerStatus.BatteryFlag = sps.BatteryFlag
						_PowerStatus.BatteryLifePercent = sps.BatteryLifePercent
						_PowerStatus.BatteryLifeTime = sps.BatteryLifeTime
						_PowerStatus.BatteryFullLifeTime = sps.BatteryFullLifeTime
						_PowerStatus.BackupBatteryFlag = sps.BackupBatteryFlag
						_PowerStatus.BackupBatteryLifePercent = sps.BackupBatteryLifePercent
						_PowerStatus.BackupBatteryLifeTime = sps.BackupBatteryLifeTime
						_PowerStatus.BackupBatteryFullLifeTime = sps.BackupBatteryFullLifeTime
					End If
				Catch ex As Exception
				End Try
			End If

		End Sub
	End Class

End Namespace

