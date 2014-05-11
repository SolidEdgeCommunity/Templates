using SolidEdgeContrib.AddIn;
using SolidEdgeContrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

// Please see https://github.com/SolidEdgeCommunity/SolidEdgeContrib/wiki for documentation.
namespace $safeprojectname$
{
    [ComVisible(true)]
    [Guid("$guid3$")]
    [ProgId("$safeprojectname$.MyAddin")]
	public class MyAddIn : SolidEdgeContrib.AddIn.SolidEdgeAddIn
	{
        public override void OnConnection(SolidEdgeFramework.Application application, SolidEdgeFramework.SeConnectMode ConnectMode, SolidEdgeFramework.AddIn AddInInstance)
        {
            base.OnConnection(application, ConnectMode, AddInInstance);

            // Put your custom OnConnection code here.
        }

        public override void OnConnectToEnvironment(SolidEdgeFramework.Environment environment, bool firstTime)
        {
            base.OnConnectToEnvironment(environment, firstTime);

            // Put your custom OnConnectToEnvironment code here.
        }

        public override void OnDisconnection(SolidEdgeFramework.SeDisconnectMode DisconnectMode)
        {
            base.OnDisconnection(DisconnectMode);

            // Put your custom OnDisconnection code here.
        }

        public override void OnInitializeRibbon(Ribbon ribbon, bool firstTime)
        {
            // Let the base class handle initializing the ribbon via addin.manifest.
            base.OnInitializeRibbon(ribbon, firstTime);

            // Put your custom OnInitializeRibbon code here.
        }

        public override void OnRibbonControl(RibbonControl ribbonControl)
        {
            // Base class doesn't do anything special when a ribbon control is invoked unless a macro is assigned.
            base.OnRibbonControl(ribbonControl);

            // Put your custom OnRibbonControl code here.
        }

        public override string NativeResourcesDllPath
        {
            get
            {
                // You can override the path to your native images if you need.
                return base.NativeResourcesDllPath;
            }
        }

        [ComRegisterFunction]
        public static void OnRegister(Type t)
        {
            try
            {
                // SolidEdgeAddIn.Register() will throw an exception if it cannot locate an embedded resource named [DEFAULT_NAMESPACE].addin.manifest.
                // If you want to take control of the registration process, simply don't call SolidEdgeAddIn.Register().
                SolidEdgeAddIn.Register(t);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }

            // Perform any additional registration procedures if needed.
        }

        [ComUnregisterFunction]
        public static void OnUnregister(Type t)
        {
            SolidEdgeAddIn.Unregister(t);
        }
	}
}
