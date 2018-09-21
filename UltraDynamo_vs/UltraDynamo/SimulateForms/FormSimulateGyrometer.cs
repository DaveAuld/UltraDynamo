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
    public partial class FormSimulateGyrometer : Form
    {
        MyGyrometer myGyrometer;
        
        public FormSimulateGyrometer()
        {
            InitializeComponent();

            //myGyrometer = new MyGyrometer();
            myGyrometer = MySensorManager.Instance.Gyrometer;

            myGyrometer.GyrometerChange += MyGyrometer_GyrometerChange;

            trackX.Minimum = (int)myGyrometer.MinimumX;
            trackX.Maximum = (int)myGyrometer.MaximumX;
            trackY.Minimum = (int)myGyrometer.MinimumY;
            trackY.Maximum = (int)myGyrometer.MaximumY;
            trackZ.Minimum = (int)myGyrometer.MinimumZ;
            trackZ.Maximum = (int)myGyrometer.MaximumZ;

            checkSimulateEnable.Checked = myGyrometer.Simulated;
        }

        void MyGyrometer_GyrometerChange(MyGyrometer sender, GyrometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyGyrometer_GyrometerChange(sender, e); }));
                return;
            }
            
            checkAvailable.Checked = e.Available;
            checkSimulated.Checked = e.Simulated;
            checkSimulateEnable.Checked = e.Simulated;

            labelX.Text = e.X.ToString("#0.0000");
            labelY.Text = e.Y.ToString("#0.0000");
            labelZ.Text = e.Z.ToString("#0.0000");
            labelRawX.Text = e.rawX.ToString("#0.0000");
            labelRawY.Text = e.rawY.ToString("#0.0000");
            labelRawZ.Text = e.rawZ.ToString("#0.0000");
            labelSimX.Text = e.simX.ToString("#0.0000");
            labelSimY.Text = e.simY.ToString("#0.0000");
            labelSimZ.Text = e.simZ.ToString("#0.0000");
        }

        private void checkSimulateEnable_CheckedChanged(object sender, EventArgs e)
        {
            myGyrometer.setSimulated(checkSimulateEnable.Checked);
        }

        private void track_Scroll(object sender, EventArgs e)
        {
            myGyrometer.setSimulatedValue(
                (double)trackX.Value,
                (double)trackY.Value,
                (double)trackZ.Value);
        }
    }
}
