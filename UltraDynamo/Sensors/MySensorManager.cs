using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    public sealed class MySensorManager
    {
        //Object for SynLocking
        private static readonly object syncLock = new Object();

        //Sensor Manager Instance
        private static volatile MySensorManager instance;

        //Sensor Instances
        private MyAccelerometer accelerometer;
        private MyCompass compass;
        private MyGeolocation geolocation;
        private MyGyrometer gyrometer;
        private MyInclinometer inclinometer;
        private MyLightSensor lightSensor;
       
        //Constructor
        private MySensorManager() { }

        //Sensor Manager Property
        public static MySensorManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new MySensorManager();
                        }
                    }
                }

                return instance;
            }
        }

        //Sensor Properties
        public MyAccelerometer Accelerometer
        {
            get
            {
                if (accelerometer == null)
                {
                    lock (syncLock)
                    {
                        if (accelerometer == null)
                        {
                            accelerometer = new MyAccelerometer();
                        }
                    }
                }

                return accelerometer;
            }
        }

        public MyCompass Compass
        {
            get
            {
                if (compass == null)
                {
                    lock (syncLock)
                    {
                        if (compass == null)
                        {
                            compass = new MyCompass();
                        }
                    }
                }

                return compass;
            }
        }

        public MyGeolocation GeoLocation
        {
            get
            {
                if (geolocation == null)
                {
                    lock (syncLock)
                    {
                        if (geolocation == null)
                        {
                            geolocation = new MyGeolocation();
                        }
                    }
                }

                return geolocation;
            }
        }

        public MyGyrometer Gyrometer
        {
            get
            {
                if (gyrometer == null)
                {
                    lock (syncLock)
                    {
                        if (gyrometer == null)
                        {
                            gyrometer = new MyGyrometer();
                        }
                    }
                }

                return gyrometer;
            }
        }

        public MyInclinometer Inclinometer
        {
            get
            {
                if (inclinometer == null)
                {
                    lock (syncLock)
                    {
                        if (inclinometer == null)
                        {
                            inclinometer = new MyInclinometer();
                        }
                    }
                }

                return inclinometer;
            }
        }       
        
        public MyLightSensor LightSensor
        {
            get
            {
                if (lightSensor == null)
                {
                    lock (syncLock)
                    {
                        if (lightSensor == null)
                        {
                            lightSensor = new MyLightSensor();
                        }
                    }
                }

                return lightSensor;
            }
        }

    }
}
