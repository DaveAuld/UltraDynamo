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
        public enum AccelerometerViewOptions
        {
            X,
            Y,
            Z
        } 
    
    public partial class FormAccelerometerGauge : Form
    {

        private MyAccelerometer myAccelerometer;

        public AccelerometerViewOptions view { get; private set; }
        
        public FormAccelerometerGauge()
        {
            InitializeComponent();

            this.view = AccelerometerViewOptions.X;
            //myAccelerometer = new MyAccelerometer();
            myAccelerometer = MySensorManager.Instance.Accelerometer;

            //Monitor for changes in source sensor
            myAccelerometer.AccelerometerChange += MyAccelerometer_AccelerometerChange;

        }

        void MyAccelerometer_AccelerometerChange(MyAccelerometer sender, AccelerometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyAccelerometer_AccelerometerChange(sender, e);}));
                return;
            }
            
            switch (this.view)
            {
                case AccelerometerViewOptions.X:
                    aquaGaugeAccelerometer.Value = (float)e.X;
                    break;
                case AccelerometerViewOptions.Y:
                    aquaGaugeAccelerometer.Value = (float)e.Y;
                    break;
                case AccelerometerViewOptions.Z:
                    aquaGaugeAccelerometer.Value = (float)e.Z;
                    break;
            }
        }


        private void FormAccelerometerGauge_Load(object sender, EventArgs e)
        {
            //Set default min/max based on sensor view
            switch (this.view)
            {
                case AccelerometerViewOptions.X:
                    aquaGaugeAccelerometer.MinValue = (float)myAccelerometer.MinimumX;
                    aquaGaugeAccelerometer.MaxValue = (float)myAccelerometer.MaximumX;
                    break;
                case AccelerometerViewOptions.Y:
                    aquaGaugeAccelerometer.MinValue = (float)myAccelerometer.MinimumY;
                    aquaGaugeAccelerometer.MaxValue = (float)myAccelerometer.MaximumY;
                    break;
                case AccelerometerViewOptions.Z:
                    aquaGaugeAccelerometer.MinValue = (float)myAccelerometer.MinimumZ;
                    aquaGaugeAccelerometer.MaxValue = (float)myAccelerometer.MaximumZ;
                    break;
            }
        }

        public FormAccelerometerGauge(AccelerometerViewOptions view) : this()
        {
            setAccelerometerMode(view);
        }

        public void setAccelerometerMode(AccelerometerViewOptions view)
        {

            this.view = view;
            switch (view)
            {
                case AccelerometerViewOptions.X:
                    this.Text = "Accelerometer - X";
                    aquaGaugeAccelerometer.DialText = "X";
                    break;
                case AccelerometerViewOptions.Y:
                    this.Text = "Accelerometer - Y";
                    aquaGaugeAccelerometer.DialText = "Y";
                    break;
                case AccelerometerViewOptions.Z:
                    this.Text = "Accelerometer - Z";
                    aquaGaugeAccelerometer.DialText = "Z";
                    break;
            }
        }
    }
}
