using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    public class SimulatedEventArgs : EventArgs
    {
        private bool simulated;

        public SimulatedEventArgs(bool simulatedState)
        {
            simulated = simulatedState;
        }
        public bool Simulated
        {
            get { return simulated; }
        }
    }
}
