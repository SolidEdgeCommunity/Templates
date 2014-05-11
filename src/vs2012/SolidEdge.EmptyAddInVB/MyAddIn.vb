Imports SolidEdgeContrib.AddIn
Imports SolidEdgeContrib.Extensions
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

' Please see https://github.com/SolidEdgeCommunity/SolidEdgeContrib/wiki for documentation.
Namespace $safeprojectname$

    <ComVisible(True), Guid("$guid3$"), ProgId("$safeprojectname$.MyAddin")> _
    Public Class MyAddIn
        Inherits SolidEdgeContrib.AddIn.SolidEdgeAddIn

        Public Overrides Sub OnConnection(ByVal application As SolidEdgeFramework.Application, ByVal ConnectMode As SolidEdgeFramework.SeConnectMode, ByVal AddInInstance As SolidEdgeFramework.AddIn)
            MyBase.OnConnection(application, ConnectMode, AddInInstance)

            ' Put your custom OnConnection code here.
        End Sub

        Public Overrides Sub OnConnectToEnvironment(ByVal environment As SolidEdgeFramework.Environment, ByVal firstTime As Boolean)
            MyBase.OnConnectToEnvironment(environment, firstTime)

            ' Put your custom OnConnectToEnvironment code here.
        End Sub

        Public Overrides Sub OnDisconnection(ByVal DisconnectMode As SolidEdgeFramework.SeDisconnectMode)
            MyBase.OnDisconnection(DisconnectMode)

            ' Put your custom OnDisconnection code here.
        End Sub

        Public Overrides Sub OnInitializeRibbon(ByVal ribbon As Ribbon, ByVal firstTime As Boolean)
            ' Let the base class handle initializing the ribbon via addin.manifest.
            MyBase.OnInitializeRibbon(ribbon, firstTime)

            ' Put your custom OnInitializeRibbon code here.
        End Sub

        Public Overrides Sub OnRibbonControl(ByVal ribbonControl As RibbonControl)
            ' Base class doesn't do anything special when a ribbon control is invoked unless a macro is assigned.
            MyBase.OnRibbonControl(ribbonControl)

            ' Put your custom OnInitializeRibbon code here.
        End Sub

        Public Overrides ReadOnly Property NativeResourcesDllPath() As String
            Get
                ' You can override the path to your native images if you need.
                Return MyBase.NativeResourcesDllPath
            End Get
        End Property

        <ComRegisterFunction> _
        Public Shared Sub OnRegister(ByVal t As Type)
            Try
                ' SolidEdgeAddIn.Register() will throw an exception if it cannot locate an embedded resource named [DEFAULT_NAMESPACE].addin.manifest.
                ' If you want to take control of the registration process, simply don't call SolidEdgeAddIn.Register().
                SolidEdgeContrib.AddIn.SolidEdgeAddIn.Register(t)
            Catch ex As System.Exception
                MessageBox.Show(ex.StackTrace, ex.Message)
            End Try

            ' Perform any additional registration procedures if needed.
        End Sub

        <ComUnregisterFunction> _
        Public Shared Sub OnUnregister(ByVal t As Type)
            SolidEdgeContrib.AddIn.SolidEdgeAddIn.Unregister(t)
        End Sub

    End Class

End Namespace