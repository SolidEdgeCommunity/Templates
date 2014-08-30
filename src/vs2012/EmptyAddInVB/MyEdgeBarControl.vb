Imports SolidEdgeCommunity.Extensions ' https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Using-Extension-Methods
Imports System.Drawing

Public Class MyEdgeBarControl
    Inherits SolidEdgeCommunity.AddIn.EdgeBarControl
    Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'richTextBox1
        '
        Me.richTextBox1.Dock = Windows.Forms.DockStyle.Fill
        Me.richTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(133, 117)
        Me.richTextBox1.TabIndex = 2
        Me.richTextBox1.Text = ""
        '
        'MyEdgeBarControl
        '
        Me.Controls.Add(Me.richTextBox1)
        Me.Name = "MyEdgeBarControl"
		Me.ToolTip = "My EdgeBar Control"
        Me.ResumeLayout(False)

    End Sub

    Private Sub MyEdgeBarControl_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Trick to use the default system font.
        Me.Font = SystemFonts.MessageBoxFont
    End Sub

    Private Sub MyEdgeBarControl_AfterInitialize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.AfterInitialize
        ' These properties are not initialized until AfterInitialize is called.
        Dim objEdgeBarPage = Me.EdgeBarPage
        Dim objDocument = Me.Document
        Dim objApplication = objDocument.Application

        ' Populate the richtextbox with some text.
        Me.richTextBox1.Text = objApplication.GetGlobalParameter(Of System.String)(SolidEdgeFramework.ApplicationGlobalConstants.seApplicationGlobalSystemInfo)
    End Sub
End Class
