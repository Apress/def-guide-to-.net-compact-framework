Public Class ProcessInfo
  Public hProcess As Int32
  Public hThread As Int32
  Public ProcessID As Int32
  Public ThreadID As Int32
End Class

Module CreateProcess
  Public Declare Function CreateProcess Lib "coredll.dll" (ByVal imageName As String, _
    ByVal cmdLine As String, _
    ByVal lpProcessAttributes As IntPtr, _
    ByVal lpThreadAttributes As IntPtr, _
    ByVal boolInheritHandles As Int32, _
    ByVal dwCreationFlags As Int32, _
    ByVal lpEnvironment As IntPtr, _
    ByVal lpCurrentDir As IntPtr, _
    ByVal si() As Byte, _
    ByVal pi As ProcessInfo) As Int32

  Public Function LaunchApplication(ByVal Application As String, _
    ByVal CommandLine As String, _
    ByVal ProcessAttributes As IntPtr, _
    ByVal ThreadAttributes As IntPtr, _
    ByVal InheritHandles As Int32, _
    ByVal CreationFlags As Int32, _
    ByVal Environment As IntPtr, _
    ByVal CurrentDirectory As IntPtr, _
    ByVal si() As Byte, _
    ByVal pi As ProcessInfo) As Int32

    Return CreateProcess(Application, _
      CommandLine, _
      ProcessAttributes, _
      ThreadAttributes, _
      InheritHandles, _
      CreationFlags, _
      Environment, _
      CurrentDirectory, _
      si, _
      pi)

  End Function
End Module
