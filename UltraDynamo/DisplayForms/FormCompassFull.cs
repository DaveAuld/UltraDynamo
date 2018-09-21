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
    public partial class FormCompassFull : Form
    {
        public FormCompassFull()
        {
            InitializeComponent();

            UICompassFull compass = new UICompassFull();

            compass.Dock = DockStyle.Fill;
            this.Controls.Add(compass);

        }

        private void FormCompassFull_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
