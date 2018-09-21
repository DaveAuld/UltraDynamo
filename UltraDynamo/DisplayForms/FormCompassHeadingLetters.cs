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
    public partial class FormCompassHeadingLetters : Form
    {
        public FormCompassHeadingLetters()
        {
            InitializeComponent();

            UICompassHeadingLetters compassHeading = new UICompassHeadingLetters();

            compassHeading.Dock = DockStyle.Fill;
            this.Controls.Add(compassHeading);
            
        }

        private void FormCompassHeadingLetters_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
