using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using UltraDynamo.Sensors;

namespace UltraDynamo.Tasks
{
    public partial class FormTaskReactionTimer : Form
    {

        private enum StartMode
        {
            Basic,
            Forumla1
        }

        private StartMode mode;
        private int lightCount = 0;
        private Stopwatch stopwatch;
        private Timer countdown;

        private int stage = 0;

        private bool isCountdown = false;

        //Accelerometer
        private MyAccelerometer accelerometer;

        private double baseline;
        private double baselineMax;

        private AccelerometerVehicleFront accelerometerFront;

        
        public FormTaskReactionTimer()
        {
            InitializeComponent();

            //initialise the sensor
            accelerometer = new MyAccelerometer();

            //Initialise the Timers
            stopwatch = new Stopwatch();
            countdown = new Timer();

            //Hide the start panels
            panelBasic.Visible = false;

            //Events
            countdown.Tick += countdown_Tick;

            accelerometer.AccelerometerChange += accelerometer_AccelerometerChange;

            accelerometerFront = (AccelerometerVehicleFront)Properties.Settings.Default.AccelerometerAxisVehicleFront;

        }

        void accelerometer_AccelerometerChange(MyAccelerometer sender, AccelerometerReadingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate() { accelerometer_AccelerometerChange(sender, e); }));
                return;
            }

            //Get a baseline average during the waiting
            if (isCountdown)
            {
               //start getting an average of the sensor reading (Y-Axis)
                if (accelerometerFront == AccelerometerVehicleFront.X_Axis)
                {
                    baseline = (e.X + baseline) / 2;

                    if (e.X > baselineMax)
                    {
                        baselineMax = e.X;
                    }
                }
                else
                {
                    baseline = (e.Y + baseline) / 2;

                    if (e.Y > baselineMax)
                    {
                        baselineMax = e.Y;
                    }
                }

            }

            labelAccelerometerAverage.Text = baseline.ToString();
            labelAccelerometerMax.Text = baselineMax.ToString();

            if (accelerometerFront == AccelerometerVehicleFront.X_Axis)
            {
                if ((e.X > baseline) & (stage > 0))
                {
                    movementDetected();
                }

            }
            else
            {
                if ((e.Y > baseline) & (stage > 0))
                {
                    movementDetected();
                }
            }
        }

        //countdown timer
        void countdown_Tick(object sender, EventArgs e)
        {
            //Stop the countdown
            countdown.Stop();

            //Basic Countdown Mode
            if (mode == StartMode.Basic)
            {
                switch (stage)
                {
                    case 0:
                        basicReactionStage1();
                        break;
                    case 1:
                        basicReactionStage2();
                        break;
                }
            }

            //Formula 1 Mode
            if (mode == StartMode.Forumla1)
            {
                switch (stage)
                {
                    case 0:
                        f1ReactionStage1();
                        break;

                    case 1:
                        if (lightCount < 5)
                        {
                            drawLights(lightCount+1);
                            panelBasic.Invalidate();
                            countdown.Start();
                        }
                        else
                        {
                            f1ReactionStage2();
                        }
                        break;
                    case 2:
                        f1ReactionStage3();
                        break;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //
            isCountdown = false;
            
            if (radioIndicatorBasic.Checked || radioIndicatorFormula1.Checked)
            {
                //basic mode
                if (radioIndicatorBasic.Checked)
                {
                    mode = StartMode.Basic;
                    if (!checkSkipPrep.Checked)
                    {
                        basicReaction();
                    }
                    else
                    {
                        basicReactionStage1();
                    }
                }
                else
                {
                    mode = StartMode.Forumla1;
                    if (!checkSkipPrep.Checked)
                    {
                        f1Reaction();
                    }
                    else
                    {
                        f1ReactionStage1();
                    }
                }

                buttonStart.Visible = false;
                buttonAbort.Visible = true;

            }
            else
            {
                MessageBox.Show("You must select a start indication method!");
            }
        }

        private void basicReaction()
        {
            //Set the stage
            stage = 0;

            //Set the panel
            panelBasic.BackColor = Color.Red;
            panelBasic.Visible = true;

            labelInstructions.Text = "Get Settled!..(10 Second Preparation Period)..";
            countdown.Interval = 10000;

            //Start the timer
            countdown.Start();

        }

        private void basicReactionStage1()
        {
            //Set the stage
            stage = 1;

            //Setup the back color
            panelBasic.BackColor = Color.Orange;
            panelBasic.Visible = true;
            labelInstructions.Text = "Get Ready! (Random time between 5 and 10 Seconds!) Go On GREEN!";
            
            //Setup the random start timer between 5 and 10 seconds
            int rand = new Random().Next(5000,10000);

            //Flag in final countdown;
            isCountdown = true;

            //Set the timer
            countdown.Interval = rand;

            //Start the timer
            countdown.Start();

            //Increase the accelerometer update internal
            accelerometer.setUpdateIntervalToMinimum();

        }

        private void basicReactionStage2()
        {
            //Set the stage
            stage = 2;
            panelBasic.BackColor = Color.Green;
            labelInstructions.Text = "GO GO GO GO GO GO GO GO GO!";
            countdown.Stop();
            stopwatch.Start();
            isCountdown = false;
            
        }

        private void f1Reaction()
        {
            //Set the stage
            stage = 0;

            //set the panel
            panelBasic.BackColor = Color.Black;
            panelBasic.Visible = true;

            drawLights(0);

            labelInstructions.Text = "Get Settled!.....(10 Second Preparation Period).";

            countdown.Interval = 10000;
            countdown.Start();

        }

        private void f1ReactionStage1()
        {         
            //Set the stage
            stage = 1;

            isCountdown = true;
            panelBasic.BackColor = Color.Black;
            panelBasic.Visible = true;
            labelInstructions.Text = "Get Ready!.....Watch those lights, go when they go out.";

            //Increase the accelerometer update internal
            accelerometer.setUpdateIntervalToMinimum();

            //Set up the light intervals
            countdown.Interval = 1000;
            countdown.Start();
            
        }

        private void f1ReactionStage2()
        {
            
            //Set the stage
            stage = 2;

            //Setup the random start timer between 4 and 7 seconds
            int rand = new Random().Next(4000, 7000);

            //Set up the random time before the lights go out
            countdown.Interval = rand;
            countdown.Start();

        }

        private void f1ReactionStage3()
        {
            //set the stage
            stage = 3;

            isCountdown = false;
            stopwatch.Start();

            //put out the lights
            drawLights(0);

            labelInstructions.Text = "GO GO GO GO GO GO GO GO GO!";
        }
        
        private void drawLights(int numberLights)
        {
            lightCount = numberLights;
            panelBasic.Invalidate();

        }
        
        private void movementDetected()
        {
            reset();
            
            //Check still not counting down - FALSE Starts!
            if (isCountdown)
            {
                MessageBox.Show("FALSE START - you jumped the lights!");
            }
            else
            {
                labelResult.Text = stopwatch.ElapsedMilliseconds.ToString() + " milliseconds.";

                MessageBox.Show("Your reaction time was: " + labelResult.Text);
            }

        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            reset();
        }


        private void reset()
        {
            //Reset the stage
            stage = 0;

            //reset the accelerometer data
            baseline = 0;
            baselineMax = 0;
                        
            //Stop the timers
            countdown.Stop();
            stopwatch.Stop();

            //Slow down the accelerometer again
            accelerometer.setUpdateIntervalDefault(Properties.Settings.Default.AccelerometerDefaultUpdateInterval);

            labelInstructions.Text = "Select Indication Method and Click Let's Do It!";
            buttonAbort.Visible = false;
            buttonStart.Visible = true;
            panelBasic.Visible = false;
            panelBasic.BackColor = Color.Black;
        }

        private void panelBasic_Paint(object sender, PaintEventArgs e)
        {
            if (mode == StartMode.Forumla1)
            {
                //draw the number of lights requested
                Graphics g = e.Graphics;

                g.FillRectangle(Brushes.Black,e.ClipRectangle);

                //draw 5 empty lights
                for (int x = 0; x < 5; x++)
                {
                    g.DrawEllipse(new Pen(Color.Gray, 2), ((e.ClipRectangle.Width / 5) * x)+2, 0, e.ClipRectangle.Width / 5, e.ClipRectangle.Height);
                }

                //draw filled lights
                for (int x = 0; x <= lightCount; x++)
                {
                    g.FillEllipse(Brushes.Red, e.ClipRectangle.Width - ((e.ClipRectangle.Width / 5) * x)-2, 0, e.ClipRectangle.Width / 5, e.ClipRectangle.Height);
                }

            }
        }


    }
}
