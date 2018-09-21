using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UltraDynamo.Sensors;

namespace UltraDynamo.Controls
{
    public partial class UICompassHeadingLetters : UserControl
    {
        //Source Compass
        MyCompass myCompass;
        CompassReadingEventArgs compassValues;

        //Does this instance need to show the Simulate / Sensor State markers
        public bool ShowSimulateState { get; set; }
        public bool ShowSensorState { get; set; }

        public UICompassHeadingLetters()
        {
            InitializeComponent();

            //Initialise a compass
            compassValues = new CompassReadingEventArgs();      //intialises some default data for paint event
            //myCompass = new MyCompass();
            myCompass = MySensorManager.Instance.Compass;

            //Initialise the default simulate/sensor status
            this.ShowSensorState = true;
            this.ShowSimulateState = true;

            //Track changes on the compass
            myCompass.CompassChange += MyCompass_CompassChange;

        }

        void MyCompass_CompassChange(MyCompass sender, CompassReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyCompass_CompassChange(sender, e); }));
                return;
            }
            
            compassValues = e;
            this.Refresh();
        }

        private void UICompassHeadingLetters_Paint(object sender, PaintEventArgs e)
        {
            String output = "N"; //Default to North removes need for two ifs below
            //Get the string representation of the heading
            double heading = compassValues.Heading;

            if (heading >= 22.5 && heading < 67.5)
                output = "NE";

            if (heading >= 67.5 && heading < 112.5)
                output = "E";

            if (heading >= 112.5 && heading < 157.5)
                output = "SE";

            if (heading >= 157.5 && heading < 202.5)
                output = "S";

            if (heading >= 202.5 && heading < 247.5)
                output = "SW";

            if (heading >= 247.5 && heading < 292.5)
                output = "W";

            if (heading >= 292.5 && heading < 337.5)
                output = "NW";

            //Establish base fonts and graphics objects
            Graphics g = e.Graphics;

            Font f = this.Font;
            Font newFont = this.Font;
            SizeF testSize;
            float fHeight=0;
            float fWidth=0;
            bool fontGood = true;
            
            for (int newSize = 1; fontGood; newSize++)
            {
                //Increase the size and test height again)
                newFont=new Font(f.Name,newSize,f.Style);
                testSize = g.MeasureString(output,newFont);
            
                //Determine boundary size for the text
                fHeight = testSize.Height;
                fWidth = testSize.Width;

                //Test the text height and width against control size
                if ((fHeight > (this.Height)) | (fWidth > (this.Width)))
                {
                    fontGood = false;
                    newSize--;  //go back by 1 size, recalculate size required for positioning central on control
                    if (newSize <6 ) { newSize=6;};
                    newFont = new Font(f.Name,newSize,f.Style);
                    testSize = g.MeasureString(output,newFont);
                    fHeight = testSize.Height;
                    fWidth = testSize.Width;
                }
            }            

            //Draw the text heading on the control
            g.DrawString(output, newFont, Brushes.Green, new Point((this.Width - (int)fWidth) / 2, (this.Height - (int)fHeight) / 2));

            //Add a Blue dot to show simulate status in top left corner
            if (this.ShowSimulateState && compassValues.Simulated)
                g.FillEllipse(Brushes.Blue, 0, 0, 5, 5);

            //Add a Red/Green dot to show sensor availability in top right corner
            if (this.ShowSensorState)
            {
                if (compassValues.Available)
                    g.FillEllipse(Brushes.Green, this.Width - 5, 0, 5, 5);
                else
                    g.FillEllipse(Brushes.Red, this.Width - 5, 0, 5, 5);
            }

        }
    }
}
