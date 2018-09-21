using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Devices.Sensors;
using Windows.Devices.Geolocation;

namespace UltraDynamo.Sensors
{
    public class GeoLocationReadingEventArgs : EventArgs
    {
        public bool Available { get; set; }
        public String Status { get; set; }

        public Geoposition Position { get; set; }
        public GeoLocationReadingEventArgs()
            : base()
        {

        }
    }
}
