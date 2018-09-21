using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Devices.Sensors;

namespace UltraDynamo.Sensors
{
  
    public class MyInclinometer
    {
        public bool Available { get; private set; }
        public bool Simulated { get; private set; }

        public float Pitch { get; private set; }
        public float Roll { get; private set; }
        public float Yaw { get; private set; }

        public float rawPitch { get; private set; }
        public float rawRoll { get; private set; }
        public float rawYaw { get; private set; }

        public float simPitch { get; private set; }
        public float simRoll { get; private set; }
        public float simYaw { get; private set; }

        public float MinimumPitch { get; set; }
        public float MaximumPitch { get; set; }
        public float MinimumRoll { get; set; }
        public float MaximumRoll { get; set; }
        public float MinimumYaw { get; set; }
        public float MaximumYaw { get; set; }

        private Inclinometer inclinometer;

        //Events
        public event ChangeHandler InclinometerChange;
        public delegate void ChangeHandler(MyInclinometer sender, InclinometerReadingEventArgs e);

        //default update interval (milliseconds)
        private uint defaultUpdateInterval = 1000;

        //Pseudo Intial Event Timer
        System.Timers.Timer forceIntialUpdate;

        public MyInclinometer()
        {
            inclinometer = Inclinometer.GetDefault();

            MinimumPitch = -90;
            MaximumPitch = 90;
            MinimumRoll = -90;
            MaximumRoll = 90;
            MinimumYaw = -90;
            MaximumYaw = 90;

            if (inclinometer != null)
            {
                setAvailable(true);
                setSimulated(false);

                //Set update interval
                inclinometer.ReportInterval = defaultUpdateInterval;
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
            var args = new InclinometerReadingEventArgs();
            args.Available = this.Available;
            args.Simulated = this.Simulated;

            args.rawPitch = this.rawPitch;
            args.rawRoll = this.rawRoll;
            args.rawYaw = this.rawYaw;

            args.simPitch = this.simPitch;
            args.simRoll = this.simRoll;
            args.simYaw = this.simYaw;

            args.Pitch = this.Pitch;
            args.Roll = this.Roll;
            args.Yaw = this.Yaw;

            if (InclinometerChange != null)
            {
                InclinometerChange(this, args);
            }


        }

        void inclinometer_ReadingChanged(Inclinometer sender, InclinometerReadingChangedEventArgs args)
        {
            rawPitch = args.Reading.PitchDegrees;
            rawRoll = args.Reading.RollDegrees;
            rawYaw = args.Reading.YawDegrees;

            if (!Simulated)
            {
                Pitch = rawPitch;
                Roll = rawRoll;
                Yaw = rawYaw;
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

        public void setSimulatedValue(float pitch, float roll, float yaw)
        {
            simPitch = pitch;
            simRoll = roll;
            simYaw = yaw;

            if (Simulated)
            {
                Pitch = simPitch;
                Roll = simRoll;
                Yaw = simYaw;
            }

            //raise event
            TriggerEvent();
        }

        /// <summary>
        /// Set the sensor to highspeed
        /// </summary>
        public void setUpdateIntervalToMinimum()
        {
            if (inclinometer != null)
            {
                EventHandling(false);
                inclinometer.ReportInterval = inclinometer.MinimumReportInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Set the sensor to a default update interval
        /// </summary>
        public void setUpdateIntervalDefault(uint milliseconds)
        {
            defaultUpdateInterval = milliseconds;

            if (inclinometer != null)
            {
                EventHandling(false);
                inclinometer.ReportInterval = defaultUpdateInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Return the minimum update interval that the sensor provides
        /// </summary>
        /// <returns>uint - milliseconds</returns>
        public uint getMinimumUpdateInterval()
        {
            if (inclinometer != null)
            {
                return inclinometer.MinimumReportInterval;
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
            if (inclinometer != null)
            {
                return inclinometer.ReportInterval;
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
            if (inclinometer != null)
            {
                if (milliseconds > getMinimumUpdateInterval())
                {
                    EventHandling(false);
                    inclinometer.ReportInterval = milliseconds;
                    EventHandling(true);
                }
            }
        }

        private void EventHandling(bool enable)
        {
            if (enable)
            {
                inclinometer.ReadingChanged += inclinometer_ReadingChanged;
            }
            else
            {
                inclinometer.ReadingChanged -= inclinometer_ReadingChanged;
            }
        }

    }
}
