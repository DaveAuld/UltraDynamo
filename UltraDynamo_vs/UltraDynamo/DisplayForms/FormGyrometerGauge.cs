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
    public enum GyrometerViewOptions
    {
        X,
        Y,
        Z
    }

    public partial class FormGyrometerGauge : Form
    {
        public GyrometerViewOptions view { get; private set; }

        private MyGyrometer myGyrometer;
        
        public FormGyrometerGauge()
        {
            InitializeComponent();

            //Default to Pitch View
            this.view = GyrometerViewOptions.X;

            //myGyrometer = new MyGyrometer();
            myGyrometer = MySensorManager.Instance.Gyrometer;

            //Monitor for changes in source sensor
            myGyrometer.GyrometerChange += MyGyrometer_GyrometerChange;

            aquaGaugeGyrometer.MinValue = -90;
            aquaGaugeGyrometer.MaxValue = 90;
        }

        void MyGyrometer_GyrometerChange(MyGyrometer sender, GyrometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyGyrometer_GyrometerChange(sender, e); }));
                return;
            }
            
            switch (this.view)
            {
                case GyrometerViewOptions.X:
                    aquaGaugeGyrometer.Value = (float)e.X;
                    aquaGaugeGyrometer.DialText = "X";
                    break;
                case GyrometerViewOptions.Y:
                    aquaGaugeGyrometer.Value = (float)e.Y;
                    aquaGaugeGyrometer.DialText = "Y";
                    break;
                case GyrometerViewOptions.Z:
                    aquaGaugeGyrometer.Value = (float)e.Z;
                    aquaGaugeGyrometer.DialText = "Z";
                    break;
            }
        }

        private void FormGyrometerGauge_Load(object sender, EventArgs e)
        {
            switch (this.view)
            {
                case GyrometerViewOptions.X:
                    aquaGaugeGyrometer.MinValue = (float)myGyrometer.MinimumX;
                    aquaGaugeGyrometer.MaxValue = (float)myGyrometer.MaximumX;
                    break;
                case GyrometerViewOptions.Y:
                    aquaGaugeGyrometer.MinValue = (float)myGyrometer.MinimumY;
                    aquaGaugeGyrometer.MaxValue = (float)myGyrometer.MaximumY;
                    break;
                case GyrometerViewOptions.Z:
                    aquaGaugeGyrometer.MinValue = (float)myGyrometer.MinimumZ;
                    aquaGaugeGyrometer.MaxValue = (float)myGyrometer.MaximumZ;
                    break;
            }
        }
        public FormGyrometerGauge(GyrometerViewOptions gyrometerview) : this()
        {
            setGyrometerMode(gyrometerview);
        }

        public void setGyrometerMode(GyrometerViewOptions view)
        {
            this.view = view;
            switch (this.view)
            {
                case GyrometerViewOptions.X:
                    this.Text = "Gyrometer - X";
                    break;
                case GyrometerViewOptions.Y:
                    this.Text = "Gyrometer - Y";
                    break;
                case GyrometerViewOptions.Z:
                    this.Text = "Gyrometer - Z";
                    break;
            }

        }

        private void aquaGaugeGyrometer_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }


    }
}
