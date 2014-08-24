﻿Imports SolidEdgeCommunity.AddIn
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' BMP|PNG images that will be embedded as Win32 resources after build.
<Assembly: NativeResource(1, "res\EdgeBar_20x20.png")> 
<Assembly: NativeResource(100, "res\Ribbon_32x32.png")> 

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("$projectname$")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("$registeredorganization$")> 
<Assembly: AssemblyProduct("$projectname$")> 
<Assembly: AssemblyCopyright("Copyright © $registeredorganization$ $year$")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("$guid1$")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.0.0")> 
<Assembly: AssemblyFileVersion("1.0.0.0")> 