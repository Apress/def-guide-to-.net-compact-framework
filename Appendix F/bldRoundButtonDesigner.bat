@ECHO OFF
CLS
SET BLDCTRL_DLL=APress.RoundButton.dll
SET BLDCTRL_SRC=RoundButton.cs
SET BLDCTRL_ASM=AssemblyInfo.cs
SET BLDCTRL_SLN=RoundButton.sln
SET BLDCTRL_PFX=Designer

ECHO Microsoft (R) Batch Build for .NETCF Designer Controls
ECHO for Microsoft (R) .NET Compact Framework version 1.0.5000
ECHO Copyright (C) Microsoft Corporation 2001-2002. All rights reserved.
ECHO.
ECHO --------------------------------------
ECHO Press Calendar
ECHO --------------------------------------
ECHO.


IF "%VSINSTALLDIR%"=="" GOTO NoVSEnv
SET NETCFDIR=%VSINSTALLDIR%\..\..\CompactFrameWorkSDK\v1.0.5000\Windows CE\


ECHO.
ECHO [BUILDING %BLDCTRL_PFX%.%BLDCTRL_DLL% from %BLDCTRL_SRC%]
csc /noconfig /define:NETCFDESIGNTIME /target:library /out:%BLDCTRL_PFX%.%BLDCTRL_DLL% %BLDCTRL_SRC% %BLDCTRL_ASM% %4 %5 /r:"%NETCFDIR%Designer\System.CF.Design.dll" /r:"%NETCFDIR%Designer\System.CF.Windows.Forms.dll" /r:"%NETCFDIR%Designer\System.CF.Drawing.dll" /r:System.Windows.Forms.dll /r:System.dll /r:System.data.dll /nowarn:1595 


ECHO.
ECHO [COPYING %BLDCTRL_PFX%.%BLDCTRL_DLL%]
COPY "%BLDCTRL_PFX%.%BLDCTRL_DLL%" "%NETCFDIR%Designer\"
IF EXIST ".\%BLDCTRL_PFX%.%BLDCTRL_DLL%" DEL ".\%BLDCTRL_PFX%.%BLDCTRL_DLL%"


ECHO.
ECHO [BUILDING %BLDCTRL_DLL% from %BLDCTRL_SRC%]
csc /noconfig /target:library /out:%BLDCTRL_DLL% %BLDCTRL_SRC% %BLDCTRL_ASM% %4 %5 /r:"%NETCFDIR%mscorlib.dll" /r:"%NETCFDIR%System.dll" /r:"%NETCFDIR%System.XML.dll" /r:"%NETCFDIR%System.Data.dll" /r:"%NETCFDIR%System.Drawing.dll" /r:"%NETCFDIR%System.Windows.Forms.dll"  /r:"%NETCFDIR%Designer\System.CF.Design.dll" /r:"%NETCFDIR%Designer\System.CF.Windows.Forms.dll" /r:"%NETCFDIR%Designer\System.CF.Drawing.dll" /nowarn:1595

ECHO.
ECHO [COPYING %BLDCTRL_DLL%]
COPY "%BLDCTRL_DLL%" "%NETCFDIR%"
IF EXIST ".\%BLDCTRL_DLL%" DEL ".\%BLDCTRL_DLL%"
ECHO.

ECHO.
ECHO [PLEASE READ]
ECHO.
ECHO Your Designer Controls have been built and moved to:
ECHO.
ECHO "%NETCFDIR%Designers\"
ECHO.
ECHO Type "START %BLDCTRL_SLN%" to open your solution
ECHO.

GOTO EndAll

:NoVSEnv
ECHO [ERROR] Please run this command from a Visual Studio .NET Command Prompt.
ECHO         This can usually be accessed from the following Start Menu location:
ECHO.
ECHO           Start \ Programs \ Microsoft Visual Studio .NET 2003 \
ECHO           Visual Studio .NET Tools \ Visual Studio .NET 2003 Command Prompt
ECHO.
ECHO.
PAUSE

:EndAll
