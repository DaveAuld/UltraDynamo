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
    public partial class FormSimulateInclinometer : Form
    {
        MyInclinometer myInclinometer;
        
        public FormSimulateInclinometer()
        {
            InitializeComponent();

            //myInclinometer = new MyInclinometer();
            myInclinometer = MySensorManager.Instance.Inclinometer;

            trackPitch.Minimum = (int)myInclinometer.MinimumPitch * 100;
            trackPitch.Maximum = (int)myInclinometer.MaximumPitch * 100;
            trackRoll.Minimum = (int)myInclinometer.MinimumRoll * 100;
            trackRoll.Maximum = (int)myInclinometer.MaximumRoll * 100;
            trackYaw.Minimum = (int)myInclinometer.MinimumYaw * 100;
            trackYaw.Maximum = (int)myInclinometer.MaximumYaw * 100;

            myInclinometer.InclinometerChange += MyInclinometer_InclinometerChange;

            checkSimulateEnable.Checked = myInclinometer.Simulated;
        }

        void MyInclinometer_InclinometerChange(MyInclinometer sender, InclinometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyInclinometer_InclinometerChange(sender, e); }));
                return;
            }
                    
            checkAvailable.Checked = e.Available;
            checkSimulated.Checked = e.Simulated;
            checkSimulateEnable.Checked = e.Simulated;

            labelPitch.Text = e.Pitch.ToString("#0.0000");
            labelRoll.Text = e.Roll.ToString("#0.0000");
            labelYaw.Text = e.Yaw.ToString("#0.0000");
            labelRawPitch.Text = e.rawPitch.ToString("#0.0000");
            labelRawRoll.Text = e.rawRoll.ToString("#0.0000");
            labelRawYaw.Text = e.rawYaw.ToString("#0.0000");
            labelSimPitch.Text = e.simPitch.ToString("#0.0000");
            labelSimRoll.Text = e.simRoll.ToString("#0.0000");
            labelSimYaw.Text = e.simYaw.ToString("#0.0000");
        }

        private void checkSimulateEnable_CheckedChanged(object sender, EventArgs e)
        {
            myInclinometer.setSimulated(checkSimulateEnable.Checked);
        }

        private void track_Scroll(object sender, EventArgs e)
        {
            myInclinometer.setSimulatedValue(
                (float)trackPitch.Value /100,
                (float)trackRoll.Value /100,
                (float)trackYaw.Value /100);
        }
    }
}
