using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Devices.Sensors;

namespace UltraDynamo.Sensors
{
    public class MyAccelerometer
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

        Accelerometer accelerometer = null;

        //Events
        public event ChangeHandler AccelerometerChange;
        public delegate void ChangeHandler(MyAccelerometer sender, AccelerometerReadingEventArgs e);

        //default update interval (milliseconds)
        private uint defaultUpdateInterval = 1000;

        //Pseudo Intial Event Timer
        System.Timers.Timer forceIntialUpdate;

        public MyAccelerometer()
        {
            accelerometer = Accelerometer.GetDefault();

                MinimumX = -2;
                MaximumX = 2;
                MinimumY = -2;
                MaximumY = 2;
                MinimumZ = -2;
                MaximumZ = 2;

            if (accelerometer != null)
            {
                setAvailable(true);
                setSimulated(false);

                //Set update interval
                accelerometer.ReportInterval = defaultUpdateInterval;

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

        private void TriggerEvent()
        {
            var args = new AccelerometerReadingEventArgs();
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
            

            if (AccelerometerChange != null)
            {
                AccelerometerChange(this, args);
            }
        }

        void accelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs e)
        {
            //throw new NotImplementedException();
            rawX = e.Reading.AccelerationX;
            rawY = e.Reading.AccelerationY;
            rawZ = e.Reading.AccelerationZ;

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
            if (accelerometer != null)
            {
                
                EventHandling(false);
                //Change the interval
                accelerometer.ReportInterval = accelerometer.MinimumReportInterval;
                EventHandling(true);

            }
        }

        /// <summary>
        /// Set the sensor to a default update interval
        /// </summary>
        public void setUpdateIntervalDefault(uint milliseconds)
        {
            defaultUpdateInterval = milliseconds;
            
            if (accelerometer != null)
            {
                EventHandling(false);
                accelerometer.ReportInterval = defaultUpdateInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Return the minimum update interval that the sensor provides
        /// </summary>
        /// <returns>uint - milliseconds</returns>
        public uint getMinimumUpdateInterval()
        {
            if (accelerometer != null)
            {
                return accelerometer.MinimumReportInterval;
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
            if (accelerometer != null)
            {
                return accelerometer.ReportInterval;
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
            if (accelerometer != null)
            {
                if (milliseconds > getMinimumUpdateInterval())
                {
                    EventHandling(false);
                    accelerometer.ReportInterval = milliseconds;
                    EventHandling(true);
                }
            }
        }

        private void EventHandling(bool enable)
        {
            if (enable)
            {
                accelerometer.ReadingChanged += accelerometer_ReadingChanged;
            }
            else
            {
                accelerometer.ReadingChanged -= accelerometer_ReadingChanged;
            }
        }


    }
}
