using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraDynamo.Sensors
{
    /// <summary>
    /// Contains the base properties, methods and objects that all My.... Sensors will derive from
    /// </summary>
    abstract public class MySensorBase
    {
        /// <summary>
        /// Is the sensor in a simulated state
        /// </summary>
        public bool Simulated { get; set; }

        /// <summary>
        /// Is the real sensor reporting available (i.e. not null when instantiated
        /// </summary>
        public bool Available { get; set; }


        //Events
        public event EventHandler<SimulatedEventArgs> SimulatedChanged;

        protected virtual void OnSimulatedChanged(SimulatedEventArgs e)
        {
            EventHandler<SimulatedEventArgs> handler = SimulatedChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<AvailableEventArgs> AvailableChanged;

        protected virtual void OnAvailableChanged(AvailableEventArgs e)
        {
            EventHandler<AvailableEventArgs> handler = AvailableChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        // Methods
        abstract public void TriggerEvent();

        /// <summary>
        /// Switch the simulated mode on or off.
        /// </summary>
        /// <param name="simulated">Switch on (TRUE) or off (FALSE) simulation mode</param>
        public void setSimulated(bool simulated)
        {
            Simulated = simulated;

            //rasie event
            OnSimulatedChanged(new SimulatedEventArgs(Simulated));

            TriggerEvent();
        }

        /// <summary>
        /// Set the status flag for availability of underlying sensor
        /// </summary>
        /// <param name="available">True == Available, False != Available</param>
        public void setAvailable(bool available)
        {
            Available = available;

            //raise event
            OnAvailableChanged(new AvailableEventArgs(Available));

            TriggerEvent();
        }
        
    }
}
