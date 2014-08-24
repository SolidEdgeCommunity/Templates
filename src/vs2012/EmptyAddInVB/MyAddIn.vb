Imports SolidEdgeCommunity.Extensions ' https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Using-Extension-Methods
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

' See https://github.com/SolidEdgeCommunity/SolidEdge.Community for documentation.
' To register your addin, use package manager console command: Register-SolidEdgeAddIn
' https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Package-Manager-Console-Powershell-Reference#register-solidedgeaddin
' To unregister your addin, use package manager console command: Unregister-SolidEdgeAddIn
' https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Package-Manager-Console-Powershell-Reference#unregister-solidedgeaddin
<ComVisible(True)>
<Guid("$guid3$")>
<ProgId("$safeprojectname$.MyAddIn")>
Public Class MyAddIn
    Inherits SolidEdgeCommunity.AddIn.SolidEdgeAddIn

    ''' <summary>
    ''' Called when the addin is first loaded by Solid Edge.
    ''' </summary>
    Public Overrides Sub OnConnection(application As SolidEdgeFramework.Application, ConnectMode As SolidEdgeFramework.SeConnectMode, AddInInstance As SolidEdgeFramework.AddIn)
        ' If you makes changes to your ribbon, be sure to increment the GuiVersion or your ribbon
        ' will not initialize properly.
        AddInEx.GuiVersion = 1
    End Sub

    ''' <summary>
    ''' Called when the addin first connects to a new Solid Edge environment.
    ''' </summary>
    Public Overrides Sub OnConnectToEnvironment(environment As SolidEdgeFramework.Environment, firstTime As Boolean)

    End Sub

    ''' <summary>
    ''' Called when the addin is about to be unloaded by Solid Edge.
    ''' </summary>
    Public Overrides Sub OnDisconnection(DisconnectMode As SolidEdgeFramework.SeDisconnectMode)

    End Sub

    ''' <summary>
    ''' Called when Solid Edge raises the SolidEdgeFramework.ISEAddInEdgeBarEvents[Ex].AddPage() event.
    ''' </summary>
    Public Overrides Sub OnCreateEdgeBarPage(ByVal controller As SolidEdgeCommunity.AddIn.EdgeBarController, ByVal document As SolidEdgeFramework.SolidEdgeDocument)
        ' Note: Confirmed with Solid Edge development, OnCreateEdgeBarPage does not get called when Solid Edge is first open and the first document is open.
        ' i.e. Under the hood, SolidEdgeFramework.ISEAddInEdgeBarEvents[Ex].AddPage() is not getting called.
        ' As an alternative, you can call MyAddIn.Instance.EdgeBarController.Add() in some other event if you need.

        ' Get the document type of the passed in document.
        Dim documentType = document.Type

        ' Image ID is defined in AssemblyInfo.vb.
        Dim imageId = 1

        ' Depending on the document type, you may have different edgebar controls.
        Select Case documentType
            Case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument
                controller.Add(Of MyEdgeBarControl)(document, imageId)
            Case SolidEdgeFramework.DocumentTypeConstants.igDraftDocument
                controller.Add(Of MyEdgeBarControl)(document, imageId)
            Case SolidEdgeFramework.DocumentTypeConstants.igPartDocument
                controller.Add(Of MyEdgeBarControl)(document, imageId)
            Case SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument
                controller.Add(Of MyEdgeBarControl)(document, imageId)
        End Select
    End Sub

    ''' <summary>
    ''' Called directly after OnConnectToEnvironment() to give you an opportunity to configure a ribbon for a specific environment.
    ''' </summary>
    Public Overrides Sub OnCreateRibbon(ByVal controller As SolidEdgeCommunity.AddIn.RibbonController, ByVal environmentCategory As Guid, ByVal firstTime As Boolean)
        ' Depending on environment, you may or may not want to load different ribbons.
        If environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.Assembly) Then
            ' Assembly Environment
            controller.Add(Of MyRibbon)(environmentCategory, firstTime)
        ElseIf environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.Draft) Then
            ' Draft Environment
            controller.Add(Of MyRibbon)(environmentCategory, firstTime)
        ElseIf environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.Part) Then
            ' Traditional Part Environment
            controller.Add(Of MyRibbon)(environmentCategory, firstTime)
        ElseIf environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.DMPart) Then
            ' Synchronous Part Environment
            controller.Add(Of MyRibbon)(environmentCategory, firstTime)
        ElseIf environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.SheetMetal) Then
            ' Traditional SheetMetal Environment
            controller.Add(Of MyRibbon)(environmentCategory, firstTime)
        ElseIf environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.DMSheetMetal) Then
            ' Synchronous SheetMetal Environment
            controller.Add(Of MyRibbon)(environmentCategory, firstTime)
        End If
    End Sub

    ''' <summary>
    ''' Called when regasm.exe is executed against the assembly.
    ''' </summary>
    <ComRegisterFunction> _
    Public Shared Sub OnRegister(ByVal t As Type)
        Dim title As String = "My title"
        Dim summary As String = "My summary"
        Dim enabled = True ' You have the option to register the addin in a disabled state.

        ' List of environments that your addin supports.
        Dim environments() As Guid =
            {
                SolidEdgeSDK.EnvironmentCategories.Application,
                SolidEdgeSDK.EnvironmentCategories.AllDocumentEnvrionments
            }

        Try
            MyAddIn.Register(t, title, summary, enabled, environments)
        Catch ex As System.Exception
            MessageBox.Show(ex.StackTrace, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Called when regasm.exe /u is executed against the assembly.
    ''' </summary>
    <ComUnregisterFunction> _
    Public Shared Sub OnUnregister(ByVal t As Type)
        MyAddIn.Unregister(t)
    End Sub
End Class
