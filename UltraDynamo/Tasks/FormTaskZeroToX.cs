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
using System.Diagnostics;

namespace UltraDynamo.Tasks
{
    public partial class FormTaskZeroToX : Form
    {

        private enum StatusCode
        {
            PreStart,
            Waiting,
            Accelerating,
            NeedBrake,
            Braking,
            Finished
        }
        
        
        MyAccelerometer accelerometer;
        MyGeolocation gps;

        private double targetSpeedMS;       //target speed in Metres/Second

        private double acceleration;
        private double speed;
        private double maxSpeed;

        private double idleg;

        private StatusCode status = StatusCode.PreStart;

        Stopwatch stopwatch;
        
        public FormTaskZeroToX()
        {
            InitializeComponent();

            accelerometer = new MyAccelerometer();
            gps = new MyGeolocation();

            stopwatch = new Stopwatch();

            accelerometer.AccelerometerChange += accelerometer_AccelerometerChange;
            gps.GPSPositionChange += gps_GPSPositionChange;

            comboTargetUnits.SelectedIndex = 0;  //Default to MPH //TODO: build this into config

            aquaGaugeAccelerometer.MinValue = (float)accelerometer.MinimumY;
            aquaGaugeAccelerometer.MaxValue = (float)accelerometer.MaximumY;
            aquaGaugeAccelerometer.DialColor = Color.LightSteelBlue;
            aquaGaugeAccelerometer.DialText = "g";

            //unit defaults to Miles Per Hour and numeric value 1, so
            aquaGaugeSpeedometer.MinValue = 0;
            aquaGaugeSpeedometer.MaxValue = (float)Math.Round((double)numericTargetSpeed.Value + ((double)(numericTargetSpeed.Value) * 0.1), 0, MidpointRounding.AwayFromZero);
            aquaGaugeSpeedometer.DialColor = Color.White;
            aquaGaugeSpeedometer.DialText = "mph";

            //
            setStatusBox(status);

        }

        void gps_GPSPositionChange(MyGeolocation sender, GeoLocationReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate() { gps_GPSPositionChange(sender, e); }));
                return;
            }

            //get the speed from the GPS in m/s
            double reportedSpeed = (e.Position.Coordinate.Speed??0);
            
            //report speed in correct units
            switch (comboTargetUnits.SelectedIndex)
            {
                case 0: //MPH
                    speed = reportedSpeed * SpeedConstants.MStoMPH;
                    break;
                case 1: //KPH
                    speed = reportedSpeed * SpeedConstants.MStoKPH;
                    break;
                case 2: // m/s
                    speed = reportedSpeed;
                    break;
            }

            //update the dial
            aquaGaugeSpeedometer.Value = (float)speed;

            //
            if (status == StatusCode.Accelerating)
            {
                if (speed>maxSpeed)
                {
                    maxSpeed = speed;
                }
                
                if (speed >= targetSpeedMS)
                {
                    status = StatusCode.NeedBrake;
                    setStatusBox(status);
                }
            }

            if(status ==StatusCode.Braking)
            {
                if (speed <=0)
                {
                    status = StatusCode.Finished;
                    setStatusBox(status);
                }
            }

        }

        void accelerometer_AccelerometerChange(MyAccelerometer sender, AccelerometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate() { accelerometer_AccelerometerChange(sender, e); }));
                return;
            }
            acceleration = e.Y;

            //update the dial
            aquaGaugeAccelerometer.Value = (float)acceleration;
            
        }

        private void numericTargetSpeed_ValueChanged(object sender, EventArgs e)
        {
            updateTargetSpeed();
        }

        private void comboTargetUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTargetSpeed();
        }

        private void updateTargetSpeed()
        {
            switch (comboTargetUnits.SelectedIndex)
            {
                case 0: //MPH
                    targetSpeedMS = (double)numericTargetSpeed.Value / SpeedConstants.MStoMPH;
                    aquaGaugeSpeedometer.DialText = "mph";
                    break;
                case 1: //KPH
                    targetSpeedMS = (double)numericTargetSpeed.Value / SpeedConstants.MStoKPH;
                    aquaGaugeSpeedometer.DialText = "kph";
                    break;
                case 2: // m/s
                    targetSpeedMS = (double)numericTargetSpeed.Value;
                    aquaGaugeSpeedometer.DialText = "m/s";
                    break;
            }

            //Update the speedo max display
            aquaGaugeSpeedometer.MaxValue = (float)Math.Round((double)numericTargetSpeed.Value + ((double)(numericTargetSpeed.Value) * 0.1), 0, MidpointRounding.AwayFromZero);

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //set the mode
            status = StatusCode.Waiting;

            //set status box
            setStatusBox(status);
        }

        private void setStatusBox(StatusCode status)
        {
            switch (status)
            {
                case StatusCode.PreStart:
                    textStatus.ForeColor = Color.Black;
                    textStatus.Text = "...ready...";

                    break;
                case StatusCode.Waiting:
                    textStatus.ForeColor = Color.Orange;
                    textStatus.Text = "...waiting...";

                    break;
                case StatusCode.Accelerating:
                    textStatus.ForeColor = Color.Green;
                    textStatus.Text = "...ACCELERATING...";
                    break;
                case StatusCode.NeedBrake:
                    textStatus.ForeColor = Color.Red;
                    textStatus.Text = "...HIT BRAKES...";
                    break;
                case StatusCode.Braking:
                    textStatus.ForeColor = Color.Red;
                    textStatus.Text = "...BRAKE...";
                    break;
                case StatusCode.Finished:
                    textStatus.ForeColor = Color.Blue;
                    textStatus.Text = "...finished...";
                    break;
            }
        }

        private void finishedRun()
        {
            //set accelerometer back to default min reading
            accelerometer.setUpdateIntervalDefault(Properties.Settings.Default.AccelerometerDefaultUpdateInterval);

        }
    }
}
