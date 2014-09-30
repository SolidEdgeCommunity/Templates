// See https://github.com/SolidEdgeCommunity/SolidEdge.Community for documentation.
// Useful Package Manager Console Commands: https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Package-Manager-Console-Powershell-Reference
// Register-SolidEdgeAddIn
// Unregister-SolidEdgeAddIn
// Set-DebugSolidEdge
// Install-SolidEdgeAddInRibbonSchema

using SolidEdgeCommunity.Extensions; // https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Using-Extension-Methods
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace $safeprojectname$
{
    [ComVisible(true)]
    [Guid("$guid3$")]
    [ProgId("$safeprojectname$.MyAddin")]
	public class MyAddIn : SolidEdgeCommunity.AddIn.SolidEdgeAddIn
	{
        /// <summary>
        /// Called when the addin is first loaded by Solid Edge.
        /// </summary>
        public override void OnConnection(SolidEdgeFramework.Application application, SolidEdgeFramework.SeConnectMode ConnectMode, SolidEdgeFramework.AddIn AddInInstance)
        {
            // If you makes changes to your ribbon, be sure to increment the GuiVersion or your ribbon
            // will not initialize properly.
            AddInEx.GuiVersion = 1;
        }

        /// <summary>
        /// Called when the addin first connects to a new Solid Edge environment.
        /// </summary>
        public override void OnConnectToEnvironment(SolidEdgeFramework.Environment environment, bool firstTime)
        {
        }

        /// <summary>
        /// Called when the addin is about to be unloaded by Solid Edge.
        /// </summary>
        public override void OnDisconnection(SolidEdgeFramework.SeDisconnectMode DisconnectMode)
        {
        }

        /// <summary>
        /// Called when Solid Edge raises the SolidEdgeFramework.ISEAddInEdgeBarEvents[Ex].AddPage() event.
        /// </summary>
        public override void OnCreateEdgeBarPage(SolidEdgeCommunity.AddIn.EdgeBarController controller, SolidEdgeFramework.SolidEdgeDocument document)
        {
            // Note: Confirmed with Solid Edge development, OnCreateEdgeBarPage does not get called when Solid Edge is first open and the first document is open.
            // i.e. Under the hood, SolidEdgeFramework.ISEAddInEdgeBarEvents[Ex].AddPage() is not getting called.
            // As an alternative, you can call MyAddIn.Instance.EdgeBarController.Add() in some other event if you need.

            // Get the document type of the passed in document.
            var documentType = document.Type;

            // Image ID is defined in AssemblyInfo.cs.
            var imageId = 1;

            // Depending on the document type, you may have different edgebar controls.
            switch (documentType)
            {
                case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument:
                case SolidEdgeFramework.DocumentTypeConstants.igDraftDocument:
                case SolidEdgeFramework.DocumentTypeConstants.igPartDocument:
                case SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument:
                    controller.Add<MyEdgeBarControl>(document, imageId);
                    break;
            }
        }

        /// <summary>
        /// Called directly after OnConnectToEnvironment() to give you an opportunity to configure a ribbon for a specific environment.
        /// </summary>
        public override void OnCreateRibbon(SolidEdgeCommunity.AddIn.RibbonController controller, Guid environmentCategory, bool firstTime)
        {
            // Depending on environment, you may or may not want to load different ribbons.
            if (environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.Assembly))
            {
                // Assembly Environment
                controller.Add<MyRibbon>(environmentCategory, firstTime);
            }
            else if (environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.Draft))
            {
                // Draft Environment
                controller.Add<MyRibbon>(environmentCategory, firstTime);
            }
            else if (environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.Part))
            {
                // Traditional Part Environment
                controller.Add<MyRibbon>(environmentCategory, firstTime);
            }
            else if (environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.DMPart))
            {
                // Synchronous Part Environment
                controller.Add<MyRibbon>(environmentCategory, firstTime);
            }
            else if (environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.SheetMetal))
            {
                // Traditional SheetMetal Environment
                controller.Add<MyRibbon>(environmentCategory, firstTime);
            }
            else if (environmentCategory.Equals(SolidEdgeSDK.EnvironmentCategories.DMSheetMetal))
            {
                // Synchronous SheetMetal Environment
                controller.Add<MyRibbon>(environmentCategory, firstTime);
            }
        }

        /// <summary>
        /// Called when regasm.exe is executed against the assembly.
        /// </summary>
        [ComRegisterFunction]
        public static void OnRegister(Type type)
        {
            string title = type.FullName;
            string summary = "My summary";
            var enabled = true; // You have the option to register the addin in a disabled state.

            // List of environments that your addin supports.
            Guid[] environments =
            {
                SolidEdgeSDK.EnvironmentCategories.Application,
                SolidEdgeSDK.EnvironmentCategories.AllDocumentEnvrionments
            };

            try
            {
                MyAddIn.Register(type, title, summary, enabled, environments);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }

        /// <summary>
        /// Called when regasm.exe /u is executed against the assembly.
        /// </summary>
        [ComUnregisterFunction]
        public static void OnUnregister(Type type)
        {
            MyAddIn.Unregister(type);
        }
	}
}
