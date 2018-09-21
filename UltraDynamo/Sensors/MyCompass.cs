using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;

namespace UltraDynamo.Sensors
{
    public class MyCompass
    {
        public bool Available { get; private set; }        
        public bool Simulated { get; private set; }

        public double Heading { get; private set; }
        public double rawHeading { get; private set; }
        public double simHeading { get; private set; }

        public double MinimumHeading { get; set; }
        public double MaximumHeading { get; set; }

        private Compass compass;

        //Events
        public event ChangeHandler CompassChange;
        public delegate void ChangeHandler(MyCompass sender, CompassReadingEventArgs e);

        //default update interval (milliseconds)
        private uint defaultUpdateInterval = 1000;

        //Pseudo Intial Event Timer
        System.Timers.Timer forceIntialUpdate;

        //Constructor
        public MyCompass()
        {
            //Set default minimum/maximum
            MinimumHeading = 0;
            MaximumHeading = 360;
            
            //initialise the compass
            compass = Compass.GetDefault();
            if (compass != null)
            {
                setAvailable(true);
                setSimulated(false);

                //Set update interval
                compass.ReportInterval = defaultUpdateInterval;
                EventHandling(true);
            }
            else
            {
                setAvailable(false);
                setSimulated(true);
            }

            //Pseudo initial event
            forceIntialUpdate = new System.Timers.Timer(500);
            forceIntialUpdate.Elapsed += forceIntialUpdate_Elapsed;
            forceIntialUpdate.Start();
        }

        void forceIntialUpdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Force the initial event
            TriggerEvent();

            //Stop and dispose of the timer as no longer required.
            forceIntialUpdate.Stop();
            forceIntialUpdate.Dispose();
        }

        void TriggerEvent()
        {
            var args = new CompassReadingEventArgs();
            args.Available = this.Available;
            args.Simulated = this.Simulated;
            args.Heading = this.Heading;
            args.rawHeading = this.rawHeading;
            args.simHeading = this.simHeading;

            if (CompassChange != null)
            {
                CompassChange(this, args);
            }
        }

        void compass_ReadingChanged(Compass sender, CompassReadingChangedEventArgs args)
        {
            rawHeading = args.Reading.HeadingMagneticNorth;
            if (!Simulated)
            {
                Heading = rawHeading;
            }

            //raise event
            TriggerEvent();
        }

        private void setAvailable(bool available)
        {
            Available = available;

            //raise event
            TriggerEvent();
        }

        public void setSimulated(bool simulated)
        {
            Simulated = simulated;

            //raise event
            TriggerEvent();
        }

        public void setSimulatedValue(double value)
        {
            simHeading = value;

            if (Simulated)
                Heading = value;

            //raise event
            TriggerEvent();
        }

        /// <summary>
        /// Set the sensor to highspeed
        /// </summary>
        public void setUpdateIntervalToMinimum()
        {
            if (compass != null)
            {
                EventHandling(false);
                compass.ReportInterval = compass.MinimumReportInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Set the sensor to a default update interval
        /// </summary>
        public void setUpdateIntervalDefault(uint milliseconds)
        {
            defaultUpdateInterval = milliseconds;

            if (compass != null)
            {
                EventHandling(false);
                compass.ReportInterval = defaultUpdateInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Return the minimum update interval that the sensor provides
        /// </summary>
        /// <returns>uint - milliseconds</returns>
        public uint getMinimumUpdateInterval()
        {
            if (compass != null)
            {
                return compass.MinimumReportInterval;
            }
            else
            {
                return 1000;
            }
        }

        /// <summary>
        /// Return the currently set update interval
        /// </summary>
        /// <returns></returns>
        public uint getCurrentUpdateInterval()
        {
            if (compass != null)
            {
                return compass.ReportInterval;
            }
            else
            {
                return 1000;
            }
        }


        /// <summary>
        /// Set the update interval of the sensor
        /// </summary>
        /// <param name="milliseconds"></param>
        public void setUpdateInterval(uint milliseconds)
        {
            if (compass != null)
            {
                if (milliseconds > getMinimumUpdateInterval())
                {
                    EventHandling(false);
                    compass.ReportInterval = milliseconds;
                    EventHandling(true);
                }
            }
        }

        private void EventHandling(bool enable)
        {
            if (enable)
            {
                compass.ReadingChanged += compass_ReadingChanged;
            }
            else
            {
                compass.ReadingChanged -= compass_ReadingChanged;
            }

        }

    }
}
