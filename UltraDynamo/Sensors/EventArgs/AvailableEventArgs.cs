using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    public class AvailableEventArgs : EventArgs
    {
        private bool available;

        public AvailableEventArgs(bool availableState)
        {
            available = availableState;
        }
        public bool Available
        {
            get { return available; }
        }
    }
}
