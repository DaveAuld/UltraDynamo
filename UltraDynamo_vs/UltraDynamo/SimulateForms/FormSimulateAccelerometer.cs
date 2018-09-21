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
    public partial class FormSimulateAccelerometer : Form
    {
        MyAccelerometer myAccelerometer;
        
        public FormSimulateAccelerometer()
        {
            InitializeComponent();

            //myAccelerometer = new MyAccelerometer();
            myAccelerometer = MySensorManager.Instance.Accelerometer;

            trackX.Minimum = (int)myAccelerometer.MinimumX * 100;
            trackX.Maximum = (int)myAccelerometer.MaximumX * 100;
            trackY.Minimum = (int)myAccelerometer.MinimumY * 100;
            trackY.Maximum = (int)myAccelerometer.MaximumY * 100;
            trackZ.Minimum = (int)myAccelerometer.MinimumZ * 100;
            trackZ.Maximum = (int)myAccelerometer.MaximumZ * 100;

            myAccelerometer.AccelerometerChange += MyAccelerometer_AccelerometerChange;

            checkSimulateEnable.Checked = myAccelerometer.Simulated;

        }

        void MyAccelerometer_AccelerometerChange(MyAccelerometer sender, AccelerometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyAccelerometer_AccelerometerChange(sender, e); }));
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
            myAccelerometer.setSimulated(checkSimulateEnable.Checked);
        }

        private void track_Scroll(object sender, EventArgs e)
        {
            myAccelerometer.setSimulatedValue(
                (double)trackX.Value / 100,
                (double)trackY.Value / 100,
                (double)trackZ.Value / 100);
        }
    }
}
