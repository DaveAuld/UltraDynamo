using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Windows.Devices.Sensors;
using UltraDynamo.Sensors;

namespace UltraDynamo.SimulateForms
{
    public partial class FormSimulateLightSensor : Form
    {

        MyLightSensor myLightSensor;

        public FormSimulateLightSensor()
        {
            InitializeComponent();
            //myLightSensor = new MyLightSensor();
            myLightSensor = MySensorManager.Instance.LightSensor;

            trackSimulateValue.Minimum = (int)myLightSensor.Minimum;
            trackSimulateValue.Maximum = (int)myLightSensor.Maximum;

            myLightSensor.LightReadingChange += MyLightSensor_LightReadingChange;

            checkSimulateEnable.Checked = myLightSensor.Simulated;
        }

        void MyLightSensor_LightReadingChange(MyLightSensor sender, LightReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyLightSensor_LightReadingChange(sender, e); }));
                return;
            }
            
            checkAvailable.Checked = e.Available;
            checkSimulated.Checked = e.Simulated;
            checkSimulateEnable.Checked = e.Simulated;
            
            labelRawValue.Text = e.RawLightReading.ToString("#0.00");
            labelUsedValue.Text = e.LightReading.ToString("#0.00");
            labelSimulatedValue.Text = e.SimLightReading.ToString();

            trackSimulateValue.Value = (int)e.SimLightReading;
        }

        private void trackSimulateValue_ValueChanged(object sender, EventArgs e)
        {
            myLightSensor.setSimulatedValue((float)trackSimulateValue.Value);
        }

        private void checkSimulateEnable_CheckedChanged(object sender, EventArgs e)
        {
            myLightSensor.setSimulated(checkSimulateEnable.Checked);
        }
    }
}
