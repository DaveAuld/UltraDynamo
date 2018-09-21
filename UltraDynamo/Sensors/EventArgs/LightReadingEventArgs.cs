using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    public sealed class LightReadingEventArgs : EventArgs
    {
        public bool Available { get; set; }
        public bool Simulated { get; set; }

        public float LightReading { get; set; }
        public float RawLightReading { get; set; }
        public float SimLightReading { get; set; }

        public LightReadingEventArgs()
            : base()
        { }

    }
}
