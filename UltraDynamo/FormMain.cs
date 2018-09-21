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
using UltraDynamo.DisplayForms;
using UltraDynamo.SimulateForms;
using UltraDynamo.Tasks;
using AquaControls;

namespace UltraDynamo
{
    public enum  SpeedometerUnitOptions
    {
        metres_per_second,
        kilometers_per_hour,
        miles_per_hour
    }

    public enum AccelerometerVehicleFront
    {
        X_Axis,
        Y_Axis
    }
    
    public partial class FormMain : Form
    {
        MyCompass myCompass;
        MyLightSensor myLightSensor;
        MyAccelerometer myAccelerometer;
        MyGyrometer myGyrometer;
        MyInclinometer myInclinometer;
        MyGeolocation myGeolocation;

        //SpeedometerUnitOptions speedometerUnit;

        private double currentSpeed = 0;
        private double currentAcceleration = 0;
        
        public FormMain()
        {
            InitializeComponent();

            //myCompass = new MyCompass();
            //myLightSensor = new MyLightSensor();
            //myAccelerometer = new MyAccelerometer();
            //myGyrometer = new MyGyrometer();
            //myInclinometer = new MyInclinometer();
            //myGeolocation = new MyGeolocation();

            myCompass = MySensorManager.Instance.Compass;
            myLightSensor = MySensorManager.Instance.LightSensor;
            myAccelerometer = MySensorManager.Instance.Accelerometer;
            myGyrometer = MySensorManager.Instance.Gyrometer;
            myInclinometer = MySensorManager.Instance.Inclinometer;
            myGeolocation = MySensorManager.Instance.GeoLocation;

            //Add a compass to the mainform
            myCompass.CompassChange += MyCompass_CompassChange;           
            
            //Light Sensor
            myLightSensor.LightReadingChange += MyLightSensor_LightReadingChange;

            //Accelerometer
            myAccelerometer.AccelerometerChange += MyAccelerometer_AccelerometerChange;

            //Gyrometer
            myGyrometer.GyrometerChange += MyGyrometer_GyrometerChange;

            //Inclinometer
            myInclinometer.InclinometerChange += MyInclinometer_InclinometerChange;

            //GPS
            myGeolocation.GPSPositionChange += myGeolocation_GPSPositionChange;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Accelerometer Settings
            //Set the vehicle front default
            comboAccelerometerFront.SelectedIndex = (int)AccelerometerVehicleFront.X_Axis;
            numericAccelerometerUpdate.Value = Properties.Settings.Default.AccelerometerDefaultUpdateInterval;
            myAccelerometer.setUpdateIntervalDefault(Properties.Settings.Default.AccelerometerDefaultUpdateInterval);
            myAccelerometer.setUpdateInterval(Properties.Settings.Default.AccelerometerDefaultUpdateInterval);

            //Incinometer
            numericInclinometerUpdate.Value = Properties.Settings.Default.InclinometerDefaultUpdateInterval;
            myInclinometer.setUpdateIntervalDefault(Properties.Settings.Default.InclinometerDefaultUpdateInterval);
            myInclinometer.setUpdateInterval(Properties.Settings.Default.InclinometerDefaultUpdateInterval);

            //Gyrometer
            numericGyrometerUpdate.Value = Properties.Settings.Default.GyrometerDefaultUpdateInterval;
            myGyrometer.setUpdateIntervalDefault(Properties.Settings.Default.GyrometerDefaultUpdateInterval);
            myGyrometer.setUpdateInterval(Properties.Settings.Default.GyrometerDefaultUpdateInterval);

            //Compass
            numericCompassUpdate.Value = Properties.Settings.Default.CompassDefaultUpdateInterval;
            myCompass.setUpdateIntervalDefault(Properties.Settings.Default.CompassDefaultUpdateInterval);
            myCompass.setUpdateInterval(Properties.Settings.Default.CompassDefaultUpdateInterval);

            //Light Sensor
            numericLightSensorUpdate.Value = Properties.Settings.Default.LightSensorDefaultUpdateInterval;
            myLightSensor.setUpdateIntervalDefault(Properties.Settings.Default.LightSensorDefaultUpdateInterval);
            myLightSensor.setUpdateInterval(Properties.Settings.Default.LightSensorDefaultUpdateInterval);

            //Geolocation
            numericGPSUpdate.Value = Properties.Settings.Default.GeolocationDefaultUpdateInterval;
            myGeolocation.setUpdateIntervalDefault(Properties.Settings.Default.GeolocationDefaultUpdateInterval);
            myGeolocation.setUpdateInterval(Properties.Settings.Default.GeolocationDefaultUpdateInterval);
            
            //Set the speedo config unit to mph
            comboSpeedometerUnit.SelectedIndex = Properties.Settings.Default.SpeedometerUnits;
            
            //Set the speedo vmax
            aquaGaugeSpeedometer.MinValue = 0;
            aquaGaugeSpeedometer.MaxValue = (float)Properties.Settings.Default.SpeedometerVMax; 

            //Set the BHP max
            aquaGaugeHorsePower.MinValue = 0;
            aquaGaugeHorsePower.MaxValue = (float)Properties.Settings.Default.HorsepowerMax;

            //Vehicle Weight
            numericVehicleWeight.Value = Properties.Settings.Default.VehicleWeightKg;
            comboWeightUnits.SelectedIndex = 1; //kg

            //Switch off the compass and heading status blobs
            uiCompassFull.ShowSensorState = false;
            uiCompassFull.ShowSimulateState = false;
            uiCompassHeadingLetters.ShowSensorState = false;
            uiCompassHeadingLetters.ShowSimulateState = false;


            //Content Notice Form
            if ((Properties.Settings.Default.AcceptContentNotice == false) | (Properties.Settings.Default.HideContentNotice == false))
            {
                FormContentNotice form = new FormContentNotice();
                form.ShowDialog();
            }

        }

        void myGeolocation_GPSPositionChange(MyGeolocation sender, GeoLocationReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { myGeolocation_GPSPositionChange(sender, e); }));
                return;
            }
            
            checkGPSAvailable.Checked = e.Available;
            labelGPSStatus.Text = e.Status;
            if (e.Position != null)
            {

                if (e.Position.Coordinate.Speed == null)
                {
                    labelGPSSpeed.Text = "n/a";
                    currentSpeed = 0;       //Used by Horsepower
                    setSpeedometerValue(0);
                }
                else
                {
                    double speed = e.Position.Coordinate.Speed ?? 0;
                    labelGPSSpeed.Text = speed.ToString("#0.000");
                    currentSpeed = speed;    //Used by Horesepower
                    setSpeedometerValue((speed));
                }

                if (e.Position.Coordinate.Altitude == null)
                {
                    labelGPSAltitude.Text = "n/a";
                }
                else
                {
                    double altitude = e.Position.Coordinate.Altitude ?? 0;
                    labelGPSAltitude.Text = altitude.ToString("#0.000") + " (+- " + ((double)(e.Position.Coordinate.AltitudeAccuracy ?? 0)).ToString("#0") + ")";
                }
                textGPSLocations.Text = e.Position.CivicAddress.City + "\n" + e.Position.CivicAddress.State + "\n" + e.Position.CivicAddress.PostalCode + "\n" + e.Position.CivicAddress.Country;

                labelGPSLatitude.Text = e.Position.Coordinate.Latitude.ToString("#0.0000000000");
                labelGPSLongitude.Text = e.Position.Coordinate.Longitude.ToString("#0.0000000000");
                labelGPSAccuracy.Text = e.Position.Coordinate.Accuracy.ToString("#0.00");
                labelGPSHeading.Text = (e.Position.Coordinate.Heading ?? 0).ToString("#0.0000");
            }


            labelGPSUpdateInterval.Text = myGeolocation.getCurrentUpdateInterval().ToString();
            labelGPSUpdateIntervalMinimum.Text = myGeolocation.getMinimumUpdateInterval().ToString();
        }

        /// <summary>
        /// This checks the current configured display unit and then coverts the
        /// GPS speed from meters per second to selected unit
        /// </summary>
        /// <param name="speed"></param>
        void setSpeedometerValue(double speed)
        {
            double output = speed;  //set default to input for m/s
            
            switch (comboSpeedometerUnit.SelectedIndex)
            {
                case 0:
                    //metres/second
                    aquaGaugeSpeedometer.DialText = "M/S";
                    break;

                case 1:
                    //meters per second to km/h
                    aquaGaugeSpeedometer.DialText = "KPH";
                    output = (speed * 3600) / 1000;
                    break;
                case 2:
                    aquaGaugeSpeedometer.DialText = "MPH";
                    output = speed * 2.23693629;        //Google says: 1 metre / second = 2.23693629 mph //TODO: Move this to a central app constant
                    break;
            }

            aquaGaugeSpeedometer.Value = (float)output;

            //Update Horsepower
            setHorsePowerValue();

        }


        /// <summary>
        /// Calculate the horsepower based on the speed/acceleration and weight
        /// </summary>
        /// <param name="speed">Vehicle speed in m/s</param>
        void setHorsePowerValue()
        {
            //The horsepower is calculated based on
            //((currentAcceleration (in g) (- offset) )X currentSpeed (in MPH) X weight (in LBS) ) / 375

            double weight;
            double acceleration;
            double speed;
            double accelerationOffset;

            double output;

            //get variables
            acceleration = Math.Abs(currentAcceleration);       //Remove the sign from acceleration, we don't care if going forward or backward.
            speed = currentSpeed * SpeedConstants.MStoMPH; 

            if (comboWeightUnits.SelectedIndex == 0)        //0==lbs, 1==kgs
            {
                //lbs
                weight = (double)numericVehicleWeight.Value;
            }
            else
            {
                //kgs
                weight = (double)numericVehicleWeight.Value * WeightConstants.KGtoLBS; 
            }

            if (comboAccelerometerFront.SelectedIndex == 0)
            {
                accelerationOffset = double.Parse(labelAccelerationOffsetX.Text);
            }
            else
            {
                accelerationOffset = double.Parse(labelAccelerationOffsetY.Text);
            }

            output = ((acceleration - accelerationOffset) * speed * weight) / 375;

            aquaGaugeHorsePower.Value = (float)output;

        }


        void MyCompass_CompassChange(MyCompass sender, CompassReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyCompass_CompassChange(sender, e); }));
                return;
            }
            
            checkCompassAvailable.Checked = e.Available;
            checkCompassSimulated.Checked = e.Simulated;
            labelCompassHeading.Text = e.Heading.ToString("#0.0000");

            labelCompassUpdateInterval.Text = myCompass.getCurrentUpdateInterval().ToString();
            labelCompassUpdateIntervalMinimum.Text = myCompass.getMinimumUpdateInterval().ToString();
        }

        void MyInclinometer_InclinometerChange(MyInclinometer sender, InclinometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyInclinometer_InclinometerChange(sender, e); }));
                return;
            }
             
            checkInclinometerAvailable.Checked = e.Available;
            checkInclinometerSimulated.Checked = e.Simulated;
            labelInclinometerPitch.Text = e.Pitch.ToString("#0.0000");
            labelInclinometerRoll.Text = e.Roll.ToString("#0.0000");
            labelInclinometerYaw.Text = e.Yaw.ToString("#0.0000");

            aquaGaugePitch.MinValue = myInclinometer.MinimumPitch;
            aquaGaugePitch.MaxValue = myInclinometer.MaximumPitch;
            aquaGaugePitch.Value = e.Pitch;

            aquaGaugeRoll.MinValue = myInclinometer.MinimumRoll;
            aquaGaugeRoll.MaxValue = myInclinometer.MaximumRoll;
            aquaGaugeRoll.Value = e.Roll;

            aquaGaugeYaw.MinValue = myInclinometer.MinimumYaw;
            aquaGaugeYaw.MaxValue = myInclinometer.MaximumYaw;
            aquaGaugeYaw.Value = e.Yaw;


            labelInclinometerUpdateInterval.Text = myInclinometer.getCurrentUpdateInterval().ToString();
            labelInclinometerUpdateIntervalMinimum.Text = myInclinometer.getMinimumUpdateInterval().ToString();

        }

        void MyGyrometer_GyrometerChange(MyGyrometer sender, GyrometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyGyrometer_GyrometerChange(sender, e); }));
                return;
            }
            
            checkGyrometerAvailable.Checked = e.Available;
            checkGyrometerSimulated.Checked = e.Simulated;
            labelGyrometerX.Text = e.X.ToString("#0.0000");
            labelGyrometerY.Text = e.Y.ToString("#0.0000");
            labelGyrometerZ.Text = e.Z.ToString("#0.0000");

            aquaGaugeGyrometerX.MinValue = (float)myGyrometer.MinimumX;
            aquaGaugeGyrometerX.MaxValue = (float)myGyrometer.MaximumX;
            aquaGaugeGyrometerX.Value = (float)e.X;

            aquaGaugeGyrometerY.MinValue = (float)myGyrometer.MinimumY;
            aquaGaugeGyrometerY.MaxValue = (float)myGyrometer.MaximumY;
            aquaGaugeGyrometerY.Value = (float)e.Y;

            aquaGaugeGyrometerZ.MinValue = (float)myGyrometer.MinimumZ;
            aquaGaugeGyrometerZ.MaxValue = (float)myGyrometer.MaximumZ;
            aquaGaugeGyrometerZ.Value = (float)e.Z;


            labelGyrometerUpdateInterval.Text = myGyrometer.getCurrentUpdateInterval().ToString();
            labelGyrometerUpdateIntervalMinimum.Text = myGyrometer.getMinimumUpdateInterval().ToString();
        }

        void MyAccelerometer_AccelerometerChange(MyAccelerometer sender, AccelerometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyAccelerometer_AccelerometerChange(sender, e); }));
                return;
            }
            
            checkAccelerometerAvailable.Checked = e.Available;
            checkAccelerometerSimulated.Checked = e.Simulated;
            labelAccelerometerX.Text = e.X.ToString("#0.0000");
            labelAccelerometerY.Text = e.Y.ToString("#0.0000");
            labelAccelerometerZ.Text = e.Z.ToString("#0.0000");


            aquaGaugeAccelerometerX.MinValue = (float)myAccelerometer.MinimumX;
            aquaGaugeAccelerometerX.MaxValue = (float)myAccelerometer.MaximumX;
            aquaGaugeAccelerometerX.Value = (float)e.X;

            aquaGaugeAccelerometerY.MinValue = (float)myAccelerometer.MinimumY;
            aquaGaugeAccelerometerY.MaxValue = (float)myAccelerometer.MaximumX;
            aquaGaugeAccelerometerY.Value = (float)e.Y;

            aquaGaugeAccelerometerZ.MinValue = (float)myAccelerometer.MinimumZ;
            aquaGaugeAccelerometerZ.MaxValue = (float)myAccelerometer.MaximumZ;
            aquaGaugeAccelerometerZ.Value = (float)e.Z;

            if (comboAccelerometerFront.SelectedIndex == 0)
            {
                //X-axis to front
                currentAcceleration = e.X;                
            }
            else
            {
                //y-axis to front
                currentAcceleration = e.Y;                
            }

            //Update HP gauge
            setHorsePowerValue();


            labelAccelerometerUpdateInterval.Text = myAccelerometer.getCurrentUpdateInterval().ToString();
            labelAccelerometerUpdateIntervalMinimum.Text = myAccelerometer.getMinimumUpdateInterval().ToString();
        }

        void MyLightSensor_LightReadingChange(MyLightSensor sender, LightReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyLightSensor_LightReadingChange(sender, e); }));
                return;
            }
            checkLightSensorAvailable.Checked = e.Available;
            checkLightSensorSimulated.Checked = e.Simulated;
            labelLightReading.Text = e.LightReading.ToString("#0.00");

            labelLightSensorUpdateInterval.Text = myLightSensor.getCurrentUpdateInterval().ToString();
            labelLightSensorUpdateIntervalMinimum.Text = myLightSensor.getMinimumUpdateInterval().ToString();
        }

        private void lightSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check instance of form does not already exist
            bool exists = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name.Equals( "FormSimulateLightSensor"))
                {
                    item.Activate();
                    return;
                }
            }

            if (!exists)
            {
                FormSimulateLightSensor form = new FormSimulateLightSensor();
                form.Show();
            }
        }

        private void accelerometerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check instance of form does not already exist
            bool exists = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name.Equals( "FormSimulateAccelerometer"))
                {
                    item.Activate();
                    return;
                }
            }

            if (!exists)
            {
                FormSimulateAccelerometer form = new FormSimulateAccelerometer();
                form.Show();
            }
        }

        private void gyrometerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check instance of form does not already exist
            bool exists = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name.Equals( "FormSimulateGyrometer"))
                {
                    item.Activate();
                    return;
                }
            }

            if (!exists)
            {
                FormSimulateGyrometer form = new FormSimulateGyrometer();
                form.Show();
            }
        }

        private void inclinometerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check instance of form does not already exist
            bool exists = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name.Equals( "FormSimulateInclinometer"))
                {
                    item.Activate();
                    return;
                }
            }

            if (!exists)
            {
                FormSimulateInclinometer form = new FormSimulateInclinometer();
                form.Show();
            }
        }

        private void compassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check instance of form does not already exist
            bool exists = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name.Equals( "FormSimulateCompass"))
                {
                    item.Activate();
                    return;
                }
            }

            if (!exists)
            {
                FormSimulateCompass form = new FormSimulateCompass();
                form.Show();
            }
        }

        private void compassToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCompassFull form = new FormCompassFull();
            form.Show();
        }

        private void compassHeadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCompassHeadingLetters form = new FormCompassHeadingLetters();
            form.Show();
        }

        private void inclinometerPitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInclinometer form = new FormInclinometer(InclinometerViewOptions.Pitch);
            form.Text = "Inclinometer - Pitch";
            form.Show();
        }

        private void inclinometerRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInclinometer form = new FormInclinometer(InclinometerViewOptions.Roll);
            form.Text = "Inclinometer - Roll";
            form.Show();
        }

        private void inclinometerYawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInclinometer form = new FormInclinometer(InclinometerViewOptions.Yaw);
            form.Text = "Inclinometer - Yaw";
            form.Show();
        }


        private void menuRealTimeCompass_Click(object sender, EventArgs e)
        {
            FormHorizontalTrend form = new FormHorizontalTrend(UltraDynamo.Controls.RealtimeTrendSource.Compass);
            form.Show();
        }

        private void menuRealTimeAccelerometer_Click(object sender, EventArgs e)
        {
            FormHorizontalTrend form = new FormHorizontalTrend(UltraDynamo.Controls.RealtimeTrendSource.Accelerometer);
            form.Show();
        }

        private void menuRealTimeGyrometer_Click(object sender, EventArgs e)
        {
            FormHorizontalTrend form = new FormHorizontalTrend(UltraDynamo.Controls.RealtimeTrendSource.Gyrometer);
            form.Show();
        }

        private void menuRealTimeInclinometer_Click(object sender, EventArgs e)
        {
            FormHorizontalTrend form = new FormHorizontalTrend(UltraDynamo.Controls.RealtimeTrendSource.Inclinometer);
            form.Show();
        }

        private void menuRealTimeSpeedometer_Click(object sender, EventArgs e)
        {
            FormHorizontalTrend form = new FormHorizontalTrend(UltraDynamo.Controls.RealtimeTrendSource.Speedometer);
            form.Show();
        }


        private void menuItemGaugesAccelerometerX_Click(object sender, EventArgs e)
        {
            FormAccelerometerGauge form = new FormAccelerometerGauge(AccelerometerViewOptions.X);
            form.Show();
        }

        private void menuItemGaugesAccelerometerY_Click(object sender, EventArgs e)
        {
            FormAccelerometerGauge form = new FormAccelerometerGauge(AccelerometerViewOptions.Y);
            form.Show();
        }

        private void menuItemGaugesAccelerometerZ_Click(object sender, EventArgs e)
        {
            FormAccelerometerGauge form = new FormAccelerometerGauge(AccelerometerViewOptions.Z);
            form.Show();
        }

        private void menuItemGaugesGyrometerX_Click(object sender, EventArgs e)
        {
            FormGyrometerGauge form = new FormGyrometerGauge(GyrometerViewOptions.X);
            form.Show();
        }

        private void menuItemGaugesGyrometerY_Click(object sender, EventArgs e)
        {
            FormGyrometerGauge form = new FormGyrometerGauge(GyrometerViewOptions.Y);
            form.Show();
        }

        private void menuItemGaugesGyrometerZ_Click(object sender, EventArgs e)
        {
            FormGyrometerGauge form = new FormGyrometerGauge(GyrometerViewOptions.Z);
            form.Show();
        }

        private void menuGaugesInclinometerPitch_Click(object sender, EventArgs e)
        {
            FormInclinometerGauge form = new FormInclinometerGauge(InclinometerViewOptions.Pitch);
            form.Show();
        }

        private void menuGaugesInclinometerRoll_Click(object sender, EventArgs e)
        {
            FormInclinometerGauge form = new FormInclinometerGauge(InclinometerViewOptions.Roll);
            form.Show();
        }

        private void menuGaugesInclinometerYaw_Click(object sender, EventArgs e)
        {
            FormInclinometerGauge form = new FormInclinometerGauge(InclinometerViewOptions.Yaw);
            form.Show();
        }

        private void menuGaugesSpeedometer_Click(object sender, EventArgs e)
        {
            FormSpeedometerGauge form = new FormSpeedometerGauge((SpeedometerUnitOptions)Properties.Settings.Default.SpeedometerUnits, (double)numericSpeedometerMax.Value);
            form.Show();
        }

        //----- Task Menu Items -----
        private void menuTaskReactionTimer_Click(object sender, EventArgs e)
        {
            FormTaskReactionTimer form = new FormTaskReactionTimer();
            form.Show();
        }

        private void menuTaskSprintTimer_Click(object sender, EventArgs e)
        {
            FormTaskZeroToX form = new FormTaskZeroToX();
            form.Show();
        }

        private void numericSpeedometerMax_ValueChanged(object sender, EventArgs e)
        {
            //Save the changed value
            Properties.Settings.Default.SpeedometerVMax = numericSpeedometerMax.Value;
            Properties.Settings.Default.Save();

            //Update the speed max
            aquaGaugeSpeedometer.MaxValue = (float)Properties.Settings.Default.SpeedometerVMax;
        }

        private void comboAccelerometerFront_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Save to the settings
            Properties.Settings.Default.AccelerometerAxisVehicleFront = comboAccelerometerFront.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void comboSpeedometerUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Save the selected index
            Properties.Settings.Default.SpeedometerUnits = comboSpeedometerUnit.SelectedIndex;
            Properties.Settings.Default.Save();

            //Update the speedo on main Dashboard
            switch (comboSpeedometerUnit.SelectedIndex)
            {
                case 0: //metres/second
                    aquaGaugeSpeedometer.DialText = "M/S";
                    break;
                case 1:
                    aquaGaugeSpeedometer.DialText = "KPH";
                    break;
                case 2:
                    aquaGaugeSpeedometer.DialText = "MPH";
                    break;
            }
        }

        private void numericAccelerometerUpdate_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AccelerometerDefaultUpdateInterval = (uint)numericAccelerometerUpdate.Value;
            Properties.Settings.Default.Save();
            myAccelerometer.setUpdateIntervalDefault(Properties.Settings.Default.AccelerometerDefaultUpdateInterval);

        }

        /// <summary>
        /// Used by both the numberic vehicle weight and the combo vehicle weight units
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vehicleWeight_ValuesChanged(object sender, EventArgs e)
        {
            if (comboWeightUnits.SelectedIndex == 1)
            {
                //already in kg
                Properties.Settings.Default.VehicleWeightKg = numericVehicleWeight.Value;
            }
            else
            {
                // in lbs
                Properties.Settings.Default.VehicleWeightKg = (decimal)((double)numericVehicleWeight.Value / WeightConstants.KGtoLBS);
            }

            Properties.Settings.Default.Save();

        }

        private void numericInclinometerUpdate_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.InclinometerDefaultUpdateInterval = (uint)numericInclinometerUpdate.Value;
            Properties.Settings.Default.Save();
            myInclinometer.setUpdateIntervalDefault(Properties.Settings.Default.InclinometerDefaultUpdateInterval);
        }

        private void numericGyrometerUpdate_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GyrometerDefaultUpdateInterval = (uint)numericGyrometerUpdate.Value;
            Properties.Settings.Default.Save();
            myGyrometer.setUpdateIntervalDefault(Properties.Settings.Default.GyrometerDefaultUpdateInterval);
        }

        private void numericCompassUpdate_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompassDefaultUpdateInterval = (uint)numericCompassUpdate.Value;
            Properties.Settings.Default.Save();
            myCompass.setUpdateIntervalDefault(Properties.Settings.Default.CompassDefaultUpdateInterval);
        }

        private void numericLightSensorUpdate_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LightSensorDefaultUpdateInterval = (uint)numericLightSensorUpdate.Value;
            Properties.Settings.Default.Save();
            myLightSensor.setUpdateIntervalDefault(Properties.Settings.Default.LightSensorDefaultUpdateInterval);
        }

        private void numericGPSUpdate_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GeolocationDefaultUpdateInterval = (uint)numericGPSUpdate.Value;
            Properties.Settings.Default.Save();
            myGeolocation.setUpdateIntervalDefault(Properties.Settings.Default.GeolocationDefaultUpdateInterval);
        }

        private void numericHorsepowerMax_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HorsepowerMax = (int)numericHorsepowerMax.Value;
            Properties.Settings.Default.Save();

            aquaGaugeHorsePower.MaxValue = (float)numericHorsepowerMax.Value;

        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }

        private void contentNoticeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Display the content notice dialog
            FormContentNotice form = new FormContentNotice();
            form.ShowDialog();
        }

        private void aboutUltradynamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.Process.Start("http://www.dave-auld.net/");
        }

        private void buttonGrabOffsets_Click(object sender, EventArgs e)
        {
            //Grab the accelerometer values and remove any sign
            labelAccelerationOffsetX.Text = (Math.Abs(double.Parse(labelAccelerometerX.Text))).ToString("#0.00000");
            labelAccelerationOffsetY.Text = (Math.Abs(double.Parse(labelAccelerometerY.Text))).ToString("#0.00000");
            labelAccelerationOffsetZ.Text = (Math.Abs(double.Parse(labelAccelerometerZ.Text))).ToString("#0.00000");

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string file = Application.StartupPath + "\\ReadMe.txt";
            
            if (System.IO.File.Exists(file))
            {
                System.Diagnostics.Process.Start(file);
            }
            else
            {
                MessageBox.Show("The ReadMe.txt file could not be found in the executables folder.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string file = Application.StartupPath + "\\ChangeLog.txt";

            if (System.IO.File.Exists(file))
            {
                System.Diagnostics.Process.Start(file);
            }
            else
            {
                MessageBox.Show("The ChangeLog.txt file could not be found in the executables folder.","File Not Found",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void buttonRestartApp_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }


}
