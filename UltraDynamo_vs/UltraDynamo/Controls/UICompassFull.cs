using System;
using System.IO;
using System.Reflection;
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
    public partial class UICompassFull : UserControl
    {
        //Source Compass
        MyCompass myCompass;
        CompassReadingEventArgs compassValues;

        //Does this instance need to show the Simulate / Sensor State markers
        public bool ShowSimulateState { get; set; }
        public bool ShowSensorState { get; set; }

        //Heading Line (Approx 75% opacity Red Pen)
        Pen headingPen = new Pen(Color.FromArgb(190, 255, 0, 0), 3);

        //Constructor
        public UICompassFull()
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

        //

        private void InitializeCompontent()
        {
            this.SuspendLayout();
            this.Paint += new PaintEventHandler(this.UICompassFull_Paint);
            this.ResumeLayout(false);
        }

        private void UICompassFull_Paint(object sender, PaintEventArgs e)
        {
            this.SuspendLayout();

            Graphics g = e.Graphics;
            //Load and rotate the image
            g.DrawImage(getRotatedImage(Image.FromStream(LoadCompassImage()),(float)compassValues.Heading *-1), 0, 0, this.Width, this.Height);

            //Draw Heading Line NOTE: the -1 is to take into account the pen thickness of 3 to ensure line central
            g.DrawLine(headingPen, new Point((this.Width / 2) -1, this.Height / 2), new Point((this.Width/2)-1, (this.Height - (int)(this.Height * 0.92))));

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
            this.ResumeLayout();
        }


        private Stream LoadCompassImage()
        {
            Assembly _assembly;
            Stream _imageStream;

            _assembly = Assembly.GetExecutingAssembly();

            _imageStream = _assembly.GetManifestResourceStream("UltraDynamo.Images.compass_200x200.jpg");

            return _imageStream;
        }

        private Image getRotatedImage(Image image,float angle)
        {
            //Create a new image based on the original
            Bitmap rotated = new Bitmap(image);

            //Create a graphics object to work with the image
            Graphics g = Graphics.FromImage(rotated);

            //Move the rotation point to centre by moving image
            g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);

            //rotate
            g.RotateTransform(angle);

            //undo the image for rotation point
            g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);

            //draw source image on graphics object
            g.DrawImage(image, new Point(0, 0));

            //Retrun the rotated image
            return rotated;

        }

    }
}
