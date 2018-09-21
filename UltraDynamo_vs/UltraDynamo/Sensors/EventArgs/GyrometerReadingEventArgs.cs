using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    public sealed class GyrometerReadingEventArgs : EventArgs
    {
        public bool Available { get; set; }
        public bool Simulated { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double rawX { get; set; }
        public double rawY { get; set; }
        public double rawZ { get; set; }

        public double simX { get; set; }
        public double simY { get; set; }
        public double simZ { get; set; }

        public GyrometerReadingEventArgs()
            : base()
        { }

    }
}
