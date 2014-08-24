using SolidEdgeCommunity.AddIn;
using SolidEdgeCommunity.Extensions; // https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Using-Extension-Methods
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace $safeprojectname$
{
	class MyRibbon : SolidEdgeCommunity.AddIn.Ribbon
	{
        private RibbonButton _button1;

        public MyRibbon()
        {
            // Get a reference to the current assembly. This is where the ribbon XML is embedded.
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // Note: In this example, the ribbon XML file has a build action of "Embedded Resource".
            var _embeddedResourceName = String.Format("{0}.xml", this.GetType().FullName);
            this.LoadXml(assembly, _embeddedResourceName);

            // Example of how to bind a local variable to a particular ribbon control.
            _button1 = GetButton(0);

            // Example of how to bind a particular ribbon control click event.
            _button1.Click += _button1_Click;
        }

        public override void OnControlClick(RibbonControl control)
        {
            var application = MyAddIn.Instance.Application;

            // Demonstrate how to handle commands without binding to a local variable.
            switch (control.CommandId)
            {
                case 0:
                    break;
            }
        }

        void _button1_Click(RibbonControl control)
        {
            var nativeWindow = MyAddIn.Instance.Application.GetNativeWindow();
            System.Windows.Forms.MessageBox.Show(nativeWindow, control.Label, "RibbonControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
	}
}
