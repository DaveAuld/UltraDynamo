using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UltraDynamo.Controls;

namespace UltraDynamo.DisplayForms
{
    public partial class FormInclinometer : Form
    {
        UIInclinometer inclinometer;

        public FormInclinometer()
        {
            InitializeComponent();

            inclinometer  = new UIInclinometer();

            inclinometer.Dock = DockStyle.Fill;
            this.Controls.Add(inclinometer);
        }

        public FormInclinometer(InclinometerViewOptions inclinometerview) : this()
        {
            inclinometer.setInclinometerMode(inclinometerview);
         
        }

        private void FormInclinometer_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
