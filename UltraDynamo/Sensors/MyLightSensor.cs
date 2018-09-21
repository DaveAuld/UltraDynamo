using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;

namespace UltraDynamo.Sensors
{
    public class MyLightSensor : MySensorBase
    {        
        //public bool Available { get; private set; }
        //public bool Simulated { get; private set; }

        //Object for SynLocking
        private static readonly object syncLock = new Object();

        public float LightReading {get; private set; }
        public float rawLightReading {get; private set; }
        public float simLightReading {get; private set; }

        public float Minimum { get; set; }
        public float Maximum { get; set; }

        //Source Sensor
        private LightSensor lightSensor;

        //Events
        public event ChangeHandler LightReadingChange;
        public delegate void ChangeHandler(MyLightSensor sender, LightReadingEventArgs e);

        //default update interval (milliseconds)
        private uint defaultUpdateInterval = 1000;

        //Pseudo Intial Event Timer
        System.Timers.Timer forceIntialUpdate;

        public MyLightSensor()
        {            
            //Base sensor
            lightSensor = LightSensor.GetDefault();

            Minimum = 0;
            Maximum = 10000;

            if (lightSensor != null)
            {
                setAvailable(true);
                setSimulated(false);

                //Set update interval
                lightSensor.ReportInterval = defaultUpdateInterval;

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

        void lightSensor_ReadingChanged(object sender, LightSensorReadingChangedEventArgs e)
        {            
            rawLightReading = e.Reading.IlluminanceInLux;

            if (!Simulated)
            {
                setLightLevel(rawLightReading);
            }

            TriggerEvent();
        }

        public override void TriggerEvent()
        {
            var args = new LightReadingEventArgs();
            args.Available = this.Available;
            args.Simulated = this.Simulated;
            args.LightReading = this.LightReading;
            args.RawLightReading = this.rawLightReading;
            args.SimLightReading = this.simLightReading;

            if (LightReadingChange != null)
            {
                LightReadingChange(this, args);
            }
        }


        private void setLightLevel(float value)
        {
                LightReading = value;
        }

        //private void setAvailable(bool available)
        //{
        //    Available = available;
        //    TriggerEvent();
        //}

        //public void setSimulated(bool simulated)
        //{
        //    Simulated = simulated;
        //
        //    TriggerEvent();
        //}

        public void setSimulatedValue(float value)
        {
            simLightReading = value;

            if (Simulated)
            {
                setLightLevel(simLightReading);
            }

            TriggerEvent();
        }


        /// <summary>
        /// Set the sensor to highspeed
        /// </summary>
        public void setUpdateIntervalToMinimum()
        {
            if (lightSensor != null)
            {
                EventHandling(false);
                lightSensor.ReportInterval = lightSensor.MinimumReportInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Set the sensor to a default update interval
        /// </summary>
        public void setUpdateIntervalDefault(uint milliseconds)
        {
            defaultUpdateInterval = milliseconds;

            if (lightSensor != null)
            {
                EventHandling(false);
                lightSensor.ReportInterval = defaultUpdateInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Return the minimum update interval that the sensor provides
        /// </summary>
        /// <returns>uint - milliseconds</returns>
        public uint getMinimumUpdateInterval()
        {
            if (lightSensor != null)
            {
                return lightSensor.MinimumReportInterval;
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
            if (lightSensor != null)
            {
                return lightSensor.ReportInterval;
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
            if (lightSensor != null)
            {
                if (milliseconds > getMinimumUpdateInterval())
                {
                    EventHandling(false);
                    lightSensor.ReportInterval = milliseconds;
                    EventHandling(true);
                }
            }
        }


        private void EventHandling(bool enable)
        {
            if (enable)
            {
                lightSensor.ReadingChanged += lightSensor_ReadingChanged;
            }
            else
            {
                lightSensor.ReadingChanged -= lightSensor_ReadingChanged;
            }
        }



    }
}
