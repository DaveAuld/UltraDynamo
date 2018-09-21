using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UltraDynamo.Sensors;

namespace UltraDynamo.SimulateForms
{
    public partial class FormSimulateCompass : Form
    {
        MyCompass myCompass;

        public FormSimulateCompass()
        {
            InitializeComponent();
            //myCompass = new MyCompass();
            myCompass = MySensorManager.Instance.Compass;

            myCompass.CompassChange += MyCompass_CompassChange;

            checkSimulateEnable.Checked = myCompass.Simulated;

        }

        void MyCompass_CompassChange(MyCompass sender, CompassReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyCompass_CompassChange(sender, e); }));
                return;
            }
            
            checkAvailable.Checked = e.Available;
            checkSimulated.Checked = e.Simulated;
            checkSimulateEnable.Checked = e.Simulated;

            labelRawValue.Text = e.rawHeading.ToString("#0.00");
            labelUsedValue.Text = e.Heading.ToString("#0.00");
            labelSimulatedValue.Text = e.simHeading.ToString("#0.00");
        }

        private void trackSimulateValue_ValueChanged(object sender, EventArgs e)
        {
            myCompass.setSimulatedValue((double)trackSimulateValue.Value/100);
        }

        private void checkSimulateEnable_CheckedChanged(object sender, EventArgs e)
        {
            myCompass.setSimulated(checkSimulateEnable.Checked);
        }
    }
}
