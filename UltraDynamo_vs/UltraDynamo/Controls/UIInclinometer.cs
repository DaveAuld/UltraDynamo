using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using UltraDynamo.Sensors;
using UltraDynamo.DisplayForms;


namespace UltraDynamo.Controls
{
    public partial class UIInclinometer : UserControl
    {
        //Source Sensor
        MyInclinometer myInclinometer;
        InclinometerReadingEventArgs inclinometerValues;

        //Which view is this instance showing.
        private InclinometerViewOptions InclinometerViewState { get; set; }

        //Does this instance need to show the Simulate / Sensor State markers
        public bool ShowSimulateState { get; set; }
        public bool ShowSensorState { get; set; }
        //Show the current angle in the image top centre
        public bool ShowAngleValue { get; set; }
        public bool ShowAngleLines { get; set; }

        //The image used by this instance - Loaded once on instance creation.
        private Image baseImage;

        //Constructor        
        public UIInclinometer()
        {
            InitializeComponent();

            //Initialise source sensor
            //myInclinometer = new MyInclinometer();
            myInclinometer = MySensorManager.Instance.Inclinometer;

            //Set up some dummy values for initilisation (to prevent null exception on initial paint)
            inclinometerValues = new InclinometerReadingEventArgs();

            //Monitor for changes in source sensor
            myInclinometer.InclinometerChange += MyInclinometer_InclinometerChange;

            //Initialise default view to Pitch
            InclinometerViewState = InclinometerViewOptions.Pitch;

            //Initialise the default simulate/sensor status / angle value views
            this.ShowSensorState = true;
            this.ShowSimulateState = true;
            this.ShowAngleValue = true;
            this.ShowAngleLines = true;

        }

        void MyInclinometer_InclinometerChange(MyInclinometer sender, InclinometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { MyInclinometer_InclinometerChange(sender, e); }));
                return;
            }
            
            //Get the source data used by the paint;
            inclinometerValues = e;

            //Force a repaint
            this.Refresh();
        }

        //Constructor with view configuration.
        public void setInclinometerMode(InclinometerViewOptions view)
        {
            //Setup the view type
            InclinometerViewState = view;

            //Load Base image
            LoadBaseImage();
        }

        //Paint event
        private void UIInclinometerPitch_Paint(object sender, PaintEventArgs e)
        {
            //Establish graphics objects
            Graphics g = e.Graphics;
            
            g.Clear(Color.White);

            Image rotated;

            //String to the reading, may be used later if angle to be written to display
            String angle = String.Empty;

            //Get the correct image and correct sensor point
            //Load and rotate the correct image
            if (InclinometerViewState == InclinometerViewOptions.Pitch)
            {
                rotated = getRotatedImage(baseImage, inclinometerValues.Pitch);
                angle = inclinometerValues.Pitch.ToString("0.000");
            }
            else if (InclinometerViewState == InclinometerViewOptions.Roll)
            {
                rotated = getRotatedImage(baseImage, inclinometerValues.Roll);
                angle = inclinometerValues.Roll.ToString("0.000");
            }
            else
            {
                rotated = getRotatedImage(baseImage, inclinometerValues.Yaw);
                angle = inclinometerValues.Yaw.ToString("0.000");
            }

            //Draw the rotated image
            g.DrawImage(rotated,
                (this.Width - baseImage.Width) / 2,
                (this.Height - baseImage.Height) / 2,
                baseImage.Width, baseImage.Height);

            //Add Blue simulate status blob if required
            if (this.ShowSimulateState && inclinometerValues.Simulated)
                g.FillEllipse(Brushes.Blue, 0, 0, 5, 5);
            

            //Add Red or Green sensor status blobs if required
            if (this.ShowSensorState)
            {
                //Add a Red/Green dot to show sensor availability in top right corner
                if (inclinometerValues.Available)
                    g.FillEllipse(Brushes.Green, this.Width - 5, 0, 5, 5);
                else
                    g.FillEllipse(Brushes.Red, this.Width - 5, 0, 5, 5);
            }

            if (this.ShowAngleValue)
            {
                Font f = this.Font;
                f = new Font(f.FontFamily, 18, FontStyle.Bold);
                SizeF testSize = g.MeasureString(angle, f);

                g.DrawString(angle, f, Brushes.Green, new Point((this.Width - (int)testSize.Width) / 2, 0));
            }

            if (this.ShowAngleLines)
            {
                if (this.InclinometerViewState == InclinometerViewOptions.Pitch | this.InclinometerViewState == InclinometerViewOptions.Roll)
                {
                    //Pitch or Roll - Horizontal
                    g.DrawLine(Pens.Blue, new Point(0, this.Height / 2), new Point(this.Width, this.Height / 2));
                    if (this.InclinometerViewState == InclinometerViewOptions.Pitch)
                    {
                        try
                        {
                        g.DrawLine(Pens.Red,
                            new Point(0,
                                 (int)((this.Height / 2) - ((this.Width / 2) * Math.Tan(((double)inclinometerValues.Pitch * Math.PI) / 180)))),
                            new Point(this.Width,
                                 (int)((this.Height / 2) + ((this.Width / 2) * Math.Tan(((double)inclinometerValues.Pitch * Math.PI) / 180)))
                                     )
                                 );
                        }
                        catch (Exception)
                        {
                            //TODO: Pitch Overflow imporvement
                            //This is just a dirty catch for a Pitch of 90' which causes an overflow exception. - Need to find improved approach later
                            g.DrawLine(Pens.Red, new Point(this.Width/2, 0), new Point(this.Width/2, this.Height));
                        }
                    }
                    else
                    {
                        try
                        {
                        g.DrawLine(Pens.Red,
                            new Point(0,
                                        (int)((this.Height / 2) - ((this.Width / 2) * Math.Tan(((double)inclinometerValues.Roll * Math.PI) / 180)))),
                            new Point(this.Width,
                                        (int)((this.Height / 2) + ((this.Width / 2) * Math.Tan(((double)inclinometerValues.Roll * Math.PI) / 180))))
                                  );
                        }
                        catch (Exception)
                        {
                            //TODO: Roll Overflow imporvement
                            //This is just a dirty catch for a Pitch of 90' which causes an overflow exception. - Need to find improved approach later
                            g.DrawLine(Pens.Red, new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height));
                        }
                    }
                }
                else
                {
                    //Yaw - Vertical
                    g.DrawLine(Pens.Blue, new Point(this.Width/2, 0), new Point(this.Width/2, this.Height));
                    try
                    {
                        g.DrawLine(Pens.Red,
                        new Point((int)((this.Width / 2) + ((this.Height / 2) * Math.Tan(((double)inclinometerValues.Yaw * Math.PI) / 180))), 0),
                        new Point((int)((this.Width / 2) - ((this.Height / 2) * Math.Tan(((double)inclinometerValues.Yaw * Math.PI) / 180))), this.Height)
                                );
                    }
                    catch (Exception)
                    {
                        //TODO: YAW Overflow imporvement
                        //This is just a dirty catch for a yaw of 90' which causes an overflow exception. - Need to find improved approach later
                        g.DrawLine(Pens.Red, new Point(0, this.Height / 2), new Point(this.Width, this.Height / 2));
                    }
                }
            }

        }

        private void LoadBaseImage()
        {
            //Load based image used for this instance of the inclinometer
            //depending on which view is being used.
            switch (InclinometerViewState)
            {
                case InclinometerViewOptions.Pitch:
                    baseImage = Image.FromStream(LoadImage("UltraDynamo.Images.inclinometer_pitch.jpg"));
                    break;
                case InclinometerViewOptions.Roll:
                    baseImage = Image.FromStream(LoadImage("UltraDynamo.Images.inclinometer_roll.jpg"));
                    break;
                case InclinometerViewOptions.Yaw:
                    baseImage = Image.FromStream(LoadImage("UltraDynamo.Images.inclinometer_yaw.jpg"));
                    break;
            }

            Bitmap newBMP = new Bitmap(baseImage, this.ClientSize);
            baseImage = (Image)newBMP;
        }

        private Stream LoadImage(String resource)
        {
            //e.g. "UltraDynamo.Images.compass_200x200.jpg"
            Assembly _assembly;
            Stream _imageStream;

            _assembly = Assembly.GetExecutingAssembly();

            _imageStream = _assembly.GetManifestResourceStream(resource);

            return _imageStream;
        }

        private Image getRotatedImage(Image image, float angle)
        {
            //Create a new image based on the original
            Bitmap rotated = new Bitmap(image);

            //Create a graphics object to work with the image
            Graphics g = Graphics.FromImage(rotated);

            //Clear the image surface
            g.Clear(Color.White);

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

        private void UIInclinometer_Resize(object sender, EventArgs e)
        {
            //Reload the base image scaled to fit new size.
            LoadBaseImage();
        }
    }
}
