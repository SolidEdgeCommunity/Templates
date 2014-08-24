Imports SolidEdgeCommunity.AddIn
Imports SolidEdgeCommunity.Extensions ' https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Using-Extension-Methods

Public Class $safeitemname$
    Inherits SolidEdgeCommunity.AddIn.Ribbon

    Private _button1 As RibbonButton

    Public Sub New()
        ' Get a reference to the current assembly. This is where the ribbon XML is embedded.
        Dim assembly = System.Reflection.Assembly.GetExecutingAssembly()

        ' In this example, XML file must have a build action of "Embedded Resource".
        Dim embeddedResourceName = String.Format("{0}.xml", Me.GetType().FullName)
        Me.LoadXml(assembly, embeddedResourceName)

        ' Example of how to bind a local variable to a particular ribbon control.
        _button1 = GetButton(0)

        ' Example of how to bind a particular ribbon control click event.
        AddHandler _button1.Click, AddressOf _button1_Click
    End Sub

    Public Overrides Sub OnControlClick(ByVal control As RibbonControl)
        Dim application = MyAddIn.Instance.Application

        ' Demonstrate how to handle commands without binding to a local variable.
        Select Case control.CommandId
            Case 0
        End Select
    End Sub

    Private Sub _button1_Click(ByVal control As RibbonControl)
    End Sub
End Class
