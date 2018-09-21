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
using UltraDynamo.DisplayForms;

namespace UltraDynamo.DisplayForms
{
    public partial class FormHorizontalTrend : Form
    {
        public FormHorizontalTrend()
        {
            InitializeComponent();
        }

        public FormHorizontalTrend(RealtimeTrendSource source)
            : this()
        {
            uiTrend.setSourceSensor(source);

            switch (source)
            {
                case RealtimeTrendSource.Compass:
                    this.Text = "Compass";
                    break;

                case RealtimeTrendSource.Accelerometer:
                    this.Text = "Accelerometer";
                    break;

                case RealtimeTrendSource.Gyrometer:
                    this.Text = "Gyrometer";
                    break;

                case RealtimeTrendSource.AmbientLight:
                    this.Text = "Light Sensor";
                    break;
                
                case RealtimeTrendSource.Inclinometer:
                    this.Text = "Inclinometer";
                    break;
                case RealtimeTrendSource.Speedometer:
                    this.Text = "Speedometer";
                    break;
            }


        }
    }
}
