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
    public partial class FormSpeedometerGauge : Form
    {

        private MyGeolocation myGeolocation;
        private double vMax;
        private SpeedometerUnitOptions units;
        
        public FormSpeedometerGauge()
        {
            InitializeComponent();


            //myGeolocation = new MyGeolocation();
            myGeolocation = MySensorManager.Instance.GeoLocation;

            //Monitor for changes in source sensor
            myGeolocation.GPSPositionChange += myGeolocation_GPSPositionChange;

        }

        public FormSpeedometerGauge(SpeedometerUnitOptions units, double vmax)
            : this()
            {
                this.vMax = vmax;
                this.units = units;

                aquaGaugeSpeedometer.MaxValue = (float)this.vMax;

            }

        void myGeolocation_GPSPositionChange(MyGeolocation sender, GeoLocationReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate() { myGeolocation_GPSPositionChange(sender, e); }));
                return;
            }

            //Set the speedo
            setSpeedometerValue((double)(e.Position.Coordinate.Speed ?? 0));

        }

        void setSpeedometerValue(double speed)
        {
            double output = speed;  //set default to input for m/s

            switch (units)
            {
                case SpeedometerUnitOptions.metres_per_second:
                    aquaGaugeSpeedometer.DialText = "M/S";
                    break;
                case SpeedometerUnitOptions.kilometers_per_hour:
                    aquaGaugeSpeedometer.DialText = "KPH";
                    //meters per second to km/h
                    output = (speed * 3600) / 1000;
                    break;
                case SpeedometerUnitOptions.miles_per_hour:
                    aquaGaugeSpeedometer.DialText = "MPH";
                    output = speed * 2.23693629;        //Google says: 1 metre / second = 2.23693629 mph
                    break;
            }

            aquaGaugeSpeedometer.Value = (float)output;

        }
    }
}
