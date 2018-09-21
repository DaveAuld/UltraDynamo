using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    public sealed class InclinometerReadingEventArgs : EventArgs
    {
        public bool Available { get; set; }
        public bool Simulated { get; set; }

        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float Yaw { get; set; }

        public float rawPitch { get; set; }
        public float rawRoll { get; set; }
        public float rawYaw { get; set; }

        public float simPitch { get; set; }
        public float simRoll { get; set; }
        public float simYaw { get; set; }

    }
}
