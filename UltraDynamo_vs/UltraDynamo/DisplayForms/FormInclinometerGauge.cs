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

namespace UltraDynamo.DisplayForms
{
    //Possible view types
    public enum InclinometerViewOptions
    {
        Pitch,
        Roll,
        Yaw
    }
    
    public partial class FormInclinometerGauge : Form
    {

        public InclinometerViewOptions view { get; private set; }

        private MyInclinometer myInclinometer;
        
        public FormInclinometerGauge()
        {
            InitializeComponent();
            //Default to Pitch View
            this.view = InclinometerViewOptions.Pitch;

            //myInclinometer = new MyInclinometer();
            myInclinometer = MySensorManager.Instance.Inclinometer;

            //Monitor for changes in source sensor
            myInclinometer.InclinometerChange += MyInclinometer_InclinometerChange;

            aquaGaugeInclinometer.MinValue = myInclinometer.MinimumPitch;
            aquaGaugeInclinometer.MaxValue = myInclinometer.MaximumPitch;
        }

        void MyInclinometer_InclinometerChange(MyInclinometer sender, InclinometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyInclinometer_InclinometerChange(sender, e); }));
                return;
            }
            
            switch (this.view)
            {
                case InclinometerViewOptions.Pitch:
                    aquaGaugeInclinometer.Value = (float)e.Pitch;
                    aquaGaugeInclinometer.DialText = "Pitch";
                    break;
                case InclinometerViewOptions.Roll:
                    aquaGaugeInclinometer.Value = (float)e.Roll;
                    aquaGaugeInclinometer.DialText = "Roll";
                    break;
                case InclinometerViewOptions.Yaw:
                    aquaGaugeInclinometer.Value = (float)e.Yaw;
                    aquaGaugeInclinometer.DialText = "Yaw";
                    break;
            }
        }

        public FormInclinometerGauge(InclinometerViewOptions inclinometerview) : this()
        {
            setInclinometerMode(inclinometerview);
        }

        public void setInclinometerMode(InclinometerViewOptions view)
        {
            this.view = view;
            switch (this.view)
            {
                case InclinometerViewOptions.Pitch:
                    this.Text = "Inclinometer - Pitch";
                    break;
                case InclinometerViewOptions.Roll:
                    this.Text = "Inclinometer - Roll";
                    break;
                case InclinometerViewOptions.Yaw:
                    this.Text = "Inclinometer - Yaw";
                    break;
            } 
            
        }

        private void FormInclinometerGauge_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
