using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    public sealed class CompassReadingEventArgs : EventArgs
    {
        public bool Available { get; set; }
        public bool Simulated { get; set; }

        public double Heading { get; set; }
        public double rawHeading { get; set; }
        public double simHeading { get; set; }
    }
}
