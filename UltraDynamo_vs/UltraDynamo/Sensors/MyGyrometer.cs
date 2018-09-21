using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Devices.Sensors;

namespace UltraDynamo.Sensors
{
    public class MyGyrometer
    {
        public bool Available { get; private set; }
        public bool Simulated { get; private set; }

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public double rawX { get; private set; }
        public double rawY { get; private set; }
        public double rawZ { get; private set; }

        public double simX { get; private set; }
        public double simY { get; private set; }
        public double simZ { get; private set; }

        public double MinimumX { get; set; }
        public double MaximumX { get; set; }
        public double MinimumY { get; set; }
        public double MaximumY { get; set; }
        public double MinimumZ { get; set; }
        public double MaximumZ { get; set; }

        Gyrometer gyrometer = null;

        //Events
        public event ChangeHandler GyrometerChange;
        public delegate void ChangeHandler(MyGyrometer sender, GyrometerReadingEventArgs e);

        //default update interval (milliseconds)
        private uint defaultUpdateInterval = 1000;

        //Pseudo Intial Event Timer
        System.Timers.Timer forceIntialUpdate;

        public MyGyrometer()
        {
            gyrometer = Gyrometer.GetDefault();

            MinimumX = -90;
            MaximumX = 90;
            MinimumY = -90;
            MaximumY = 90;
            MinimumZ = -90;
            MaximumZ = 90;

            if (gyrometer != null)
            {
                setAvailable(true);
                setSimulated(false);

                //Set update interval
                gyrometer.ReportInterval = defaultUpdateInterval;
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
            var args = new GyrometerReadingEventArgs();
            args.Available = this.Available;
            args.Simulated = this.Simulated;

            args.rawX = this.rawX;
            args.rawY = this.rawY;
            args.rawZ = this.rawZ;

            args.simX = this.simX;
            args.simY = this.simY;
            args.simZ = this.simZ;

            args.X = this.X;
            args.Y = this.Y;
            args.Z = this.Z;

            if (GyrometerChange != null)
            {
                GyrometerChange(this, args);
            }
        }

        void gyrometer_ReadingChanged(Gyrometer sender, GyrometerReadingChangedEventArgs args)
        {
            //throw new NotImplementedException();
            rawX = args.Reading.AngularVelocityX;
            rawY = args.Reading.AngularVelocityY;
            rawZ = args.Reading.AngularVelocityZ;

            if (!Simulated)
            {
                X = rawX;
                Y = rawY;
                Z = rawZ;
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

        public void setSimulatedValue(double valueX, double valueY, double valueZ)
        {
            simX = valueX;
            simY = valueY;
            simZ = valueZ;

            if (Simulated)
            {
                X = simX;
                Y = simY;
                Z = simZ;
            }

            //raise event
            TriggerEvent();

        }

        /// <summary>
        /// Set the sensor to highspeed
        /// </summary>
        public void setUpdateIntervalToMinimum()
        {
            if (gyrometer != null)
            {
                EventHandling(false);
                gyrometer.ReportInterval = gyrometer.MinimumReportInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Set the sensor to a default update interval
        /// </summary>
        public void setUpdateIntervalDefault(uint milliseconds)
        {
            defaultUpdateInterval = milliseconds;

            if (gyrometer != null)
            {
                EventHandling(false);
                gyrometer.ReportInterval = defaultUpdateInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Return the minimum update interval that the sensor provides
        /// </summary>
        /// <returns>uint - milliseconds</returns>
        public uint getMinimumUpdateInterval()
        {
            if (gyrometer != null)
            {
                return gyrometer.MinimumReportInterval;
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
            if (gyrometer != null)
            {
                return gyrometer.ReportInterval;
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
            if (gyrometer != null)
            {
                if (milliseconds > getMinimumUpdateInterval())
                {
                    EventHandling(false);
                    gyrometer.ReportInterval = milliseconds;
                    EventHandling(true);
                }
            }
        }

        private void EventHandling(bool enable)
        {
            if (enable)
            {
                gyrometer.ReadingChanged += gyrometer_ReadingChanged;
            }
            else
            {
                gyrometer.ReadingChanged -= gyrometer_ReadingChanged;
            }
        }
    }
}
