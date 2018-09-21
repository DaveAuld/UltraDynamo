using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Devices.Sensors;
using Windows.Devices.Geolocation;

namespace UltraDynamo.Sensors
{
    public class MyGeolocation
    {      
        
        public Geoposition Position {get; set;}

        public bool Available { get; set; }
        public string Status { get; set; }

        //Source Sensor
        private Geolocator geolocator;

        //Events
        public event ChangeHandler GPSPositionChange;
        public delegate void ChangeHandler(MyGeolocation sender, GeoLocationReadingEventArgs e);

        //default update interval (milliseconds)
        private uint defaultUpdateInterval = 1000;

        //Pseudo Intial Event Timer
        System.Timers.Timer forceIntialUpdate;

        public MyGeolocation()
        {            
            //Base sensor
            geolocator = new Geolocator();

            if (geolocator != null)
            {
                setAvailable(true);

                //Set accuracy level
                geolocator.DesiredAccuracy = PositionAccuracy.High;

                //set movement threshhold (in Metres)
                geolocator.MovementThreshold = 1;

                //Set update interval
                geolocator.ReportInterval = defaultUpdateInterval;

                geolocator.StatusChanged += geolocator_StatusChanged;
                EventHandling(true);


            }
            else
            {
                setAvailable(false);
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
            var args = new GeoLocationReadingEventArgs();
            args.Position = this.Position;
            args.Available = this.Available;
            args.Status = this.Status;

            if (GPSPositionChange != null)
            {
                GPSPositionChange(this, args);
            }

        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Position = args.Position;            

            TriggerEvent();
        }

        void geolocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            
            switch (args.Status)
            {
                case PositionStatus.Disabled:
                    this.Status = "Disabled";
                    break;
                case PositionStatus.Initializing:
                    this.Status = "Intializing";
                    break;
                case PositionStatus.NoData:
                    this.Status = "No Data";
                    break;
                case PositionStatus.NotAvailable:
                    this.Status = "Not Available";
                    break;
                case PositionStatus.NotInitialized:
                    this.Status = "Not Initialized";
                    break;
                case PositionStatus.Ready:
                    this.Status = "Ready";
                    break;
            }

            TriggerEvent();
        }

        private void setAvailable(bool available)
        {
            Available = available;

            //RaiseEvent
            TriggerEvent();
        }

        /// <summary>
        /// Set the sensor to highspeed
        /// </summary>
        public void setUpdateIntervalToMinimum()
        {
            if (geolocator != null)
            {
                EventHandling(false);
                geolocator.ReportInterval = getMinimumUpdateInterval();
                EventHandling(true);
            }
        }

        /// <summary>
        /// Set the sensor to a default update interval
        /// </summary>
        public void setUpdateIntervalDefault(uint milliseconds)
        {
            defaultUpdateInterval = milliseconds;

            if (geolocator != null)
            {
                EventHandling(false);
                geolocator.ReportInterval = defaultUpdateInterval;
                EventHandling(true);
            }
        }

        /// <summary>
        /// Return the minimum update interval that the sensor provides
        /// </summary>
        /// <returns>uint - milliseconds</returns>
        public uint getMinimumUpdateInterval()
        {
            //Geolocator does not provide a minimum
            //update interval, we will assume 10ms as maximum rate
            return 10;
        }

        /// <summary>
        /// Return the currently set update interval
        /// </summary>
        /// <returns></returns>
        public uint getCurrentUpdateInterval()
        {
            if (geolocator != null)
            {
                return geolocator.ReportInterval;
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
            if (geolocator != null)
            {
                if (milliseconds > getMinimumUpdateInterval())
                {
                    EventHandling(false);
                    geolocator.ReportInterval = milliseconds;
                    EventHandling(true);
                }
            }
        }

        private void EventHandling(bool enable)
        {
            if (enable)
            {
                geolocator.PositionChanged += geolocator_PositionChanged;
            }
            else
            {
                geolocator.PositionChanged -= geolocator_PositionChanged;
            }
        }

    }
}
