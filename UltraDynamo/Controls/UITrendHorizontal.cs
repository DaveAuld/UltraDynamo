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
    public enum RealtimeTrendSource
    {
        Compass,
        Accelerometer,
        Gyrometer,
        Inclinometer,
        AmbientLight,
        Speedometer
    }
    
    public partial class UITrendHorizontal : UserControl
    {
        private Timer updateTimer;

        private int maxPoints = 600; //1 Minutes (10 points per second @100ms/point)

        public RealtimeTrendSource sourceSensor { get; private set; }

        private object sourceData;
        
        public UITrendHorizontal()
        {
            InitializeComponent();

            //Setup the timer
            updateTimer = new Timer();
            updateTimer.Interval = 100;     //100ms update interval
            updateTimer.Tick += updateTimer_Tick;
        }

        public UITrendHorizontal(RealtimeTrendSource source)
            : this()
        {
            setSourceSensor(source);
        }

        private void UITrendHorizontal_Load(object sender, EventArgs e)
        {
            //Detect parent form closing to terminate the timer
            this.ParentForm.FormClosing += UITrendHorizontal_FormClosing;

            this.Refresh();
        }

        void UITrendHorizontal_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.Stop();
            updateTimer.Dispose();
        }

        void updateTimer_Tick(object sender, EventArgs e)
        {
            switch (this.sourceSensor)
                {
                    case RealtimeTrendSource.AmbientLight:
                        chartData.Series["Light"].Points.Add(((MyLightSensor)sourceData).LightReading);
                        break;

                    case RealtimeTrendSource.Compass:
                        chartData.Series["Compass"].Points.Add(((MyCompass)sourceData).Heading);
                        break;

                    case RealtimeTrendSource.Accelerometer:
                        chartData.Series["AccelerometerX"].Points.Add(((MyAccelerometer)sourceData).X);
                        chartData.Series["AccelerometerY"].Points.Add(((MyAccelerometer)sourceData).Y);
                        chartData.Series["AccelerometerZ"].Points.Add(((MyAccelerometer)sourceData).Z);
                        break;

                    case RealtimeTrendSource.Gyrometer:
                        chartData.Series["GyrometerX"].Points.Add(((MyGyrometer)sourceData).X);
                        chartData.Series["GyrometerY"].Points.Add(((MyGyrometer)sourceData).Y);
                        chartData.Series["GyrometerZ"].Points.Add(((MyGyrometer)sourceData).Z);
                        break;

                    case RealtimeTrendSource.Inclinometer:
                        chartData.Series["Pitch"].Points.Add(((MyInclinometer)sourceData).Pitch);
                        chartData.Series["Roll"].Points.Add(((MyInclinometer)sourceData).Roll);
                        chartData.Series["Yaw"].Points.Add(((MyInclinometer)sourceData).Yaw);
                        break;

                case RealtimeTrendSource.Speedometer:

                        double speed = (((MyGeolocation)sourceData).Position.Coordinate.Speed ?? 0);

                        switch (Properties.Settings.Default.SpeedometerUnits)
                        {
                            case 0: // m/s
                                //do nothing aleady in m/s
                                break;
                            case 1: //kph
                                speed = (speed * 3600) / 1000;
                                break;
                            case 2: //mph
                                speed = speed * 2.23693629;        //Google says: 1 metre / second = 2.23693629 mph
                                break;
                        }
                        chartData.Series["Speedometer"].Points.Add(speed);
                        break;
                }

                //Remove excess points
                foreach (System.Windows.Forms.DataVisualization.Charting.Series series in chartData.Series)
                {
                    while (series.Points.Count > maxPoints)
                    {
                        series.Points.RemoveAt(0);
                    }
                }

        }

        public void setSourceSensor(RealtimeTrendSource source)
        {
            this.sourceSensor = source;

            switch (this.sourceSensor)
            {
                case RealtimeTrendSource.Accelerometer:
                    //sourceData = new MyAccelerometer();
                    sourceData = MySensorManager.Instance.Accelerometer;
                    break;

                case RealtimeTrendSource.AmbientLight:
                    //sourceData = new MyLightSensor();
                    sourceData = MySensorManager.Instance.LightSensor;
                    break;

                case RealtimeTrendSource.Compass:
                    //sourceData = new MyCompass();
                    sourceData = MySensorManager.Instance.Compass;
                    break;

                case RealtimeTrendSource.Gyrometer:
                    //sourceData = new MyGyrometer();
                    sourceData = MySensorManager.Instance.Gyrometer;
                    break;

                case RealtimeTrendSource.Inclinometer:
                    //sourceData = new MyInclinometer();
                    sourceData = MySensorManager.Instance.Inclinometer;
                    break;

                case RealtimeTrendSource.Speedometer:
                    //sourceData = new MyGeolocation();
                    sourceData = MySensorManager.Instance.GeoLocation;
                    break;
            }

            updateTimer.Stop();
            BuildChartView();
        }

        private void BuildChartView()
        {
            //Configure Series
            switch (this.sourceSensor)
            {
                case RealtimeTrendSource.AmbientLight:
                    chartData.Series.Clear();
                    chartData.Series.Add("Light");
                    chartData.Series["Light"].LegendText = "Lux";
                    chartData.Series["Light"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyLightSensor)sourceData).Minimum;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyLightSensor)sourceData).Maximum;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 1000;

                    //Preload maxPoints with 0 data 
                    for (int x = 0; x < maxPoints; x++)
                    {
                        chartData.Series["Light"].Points.Add(0D);
                    }
                    break;

                case RealtimeTrendSource.Compass:
                    chartData.Series.Clear();
                    chartData.Series.Add("Compass");
                    chartData.Series["Compass"].LegendText = "Heading";
                    chartData.Series["Compass"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyCompass)sourceData).MinimumHeading;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyCompass)sourceData).MaximumHeading;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 90;

                    //Preload maxPoints with 0 data 
                    for (int x = 0; x < maxPoints; x++)
                    {
                        chartData.Series["Compass"].Points.Add(0D);
                    }
                    break;

                case RealtimeTrendSource.Accelerometer:
                    chartData.Series.Clear();
                    chartData.Series.Add("AccelerometerX");
                    chartData.Series["AccelerometerX"].LegendText = "X";
                    chartData.Series["AccelerometerX"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyAccelerometer)sourceData).MinimumX;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyAccelerometer)sourceData).MaximumX;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;
                    chartData.Series.Add("AccelerometerY");
                    chartData.Series["AccelerometerY"].LegendText = "Y";
                    chartData.Series["AccelerometerY"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyAccelerometer)sourceData).MinimumY;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyAccelerometer)sourceData).MaximumY;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;
                    chartData.Series.Add("AccelerometerZ");
                    chartData.Series["AccelerometerZ"].LegendText = "Z";
                    chartData.Series["AccelerometerZ"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyAccelerometer)sourceData).MinimumZ;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyAccelerometer)sourceData).MaximumZ;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;

                    //Preload maxPoints with 0 data 
                    for (int x = 0; x < maxPoints; x++)
                    {
                        chartData.Series["AccelerometerX"].Points.Add(0D);
                        chartData.Series["AccelerometerY"].Points.Add(0D);
                        chartData.Series["AccelerometerZ"].Points.Add(0D);
                    }
                    break;

                case RealtimeTrendSource.Gyrometer:
                    chartData.Series.Clear();
                    chartData.Series.Add("GyrometerX");
                    chartData.Series["GyrometerX"].LegendText = "X";
                    chartData.Series["GyrometerX"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyGyrometer)sourceData).MinimumX;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyGyrometer)sourceData).MaximumX;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 15;
                    chartData.Series.Add("GyrometerY");
                    chartData.Series["GyrometerY"].LegendText = "Y";
                    chartData.Series["GyrometerY"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyGyrometer)sourceData).MinimumY;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyGyrometer)sourceData).MaximumY;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 15;
                    chartData.Series.Add("GyrometerZ");
                    chartData.Series["GyrometerZ"].LegendText = "Z";
                    chartData.Series["GyrometerZ"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyGyrometer)sourceData).MinimumZ;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyGyrometer)sourceData).MaximumZ;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 15;
                    //Preload maxPoints with 0 data 
                    for (int x = 0; x < maxPoints; x++)
                    {
                        chartData.Series["GyrometerX"].Points.Add(0D);
                        chartData.Series["GyrometerY"].Points.Add(0D);
                        chartData.Series["GyrometerZ"].Points.Add(0D);
                    }
                    break;

                case RealtimeTrendSource.Inclinometer:
                    chartData.Series.Clear();
                    chartData.Series.Add("Pitch");
                    chartData.Series["Pitch"].LegendText = "Pitch";
                    chartData.Series["Pitch"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyInclinometer)sourceData).MinimumPitch;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyInclinometer)sourceData).MaximumPitch;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 15;
                    chartData.Series.Add("Roll");
                    chartData.Series["Roll"].LegendText = "Roll";
                    chartData.Series["Roll"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyInclinometer)sourceData).MinimumRoll;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyInclinometer)sourceData).MaximumRoll;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 15;
                    chartData.Series.Add("Yaw");
                    chartData.Series["Yaw"].LegendText = "Yaw";
                    chartData.Series["Yaw"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = ((MyInclinometer)sourceData).MinimumYaw;
                    chartData.ChartAreas[0].AxisY.Maximum = ((MyInclinometer)sourceData).MaximumYaw;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 15;
                    //Preload maxPoints with 0 data 
                    for (int x = 0; x < maxPoints; x++)
                    {
                        chartData.Series["Pitch"].Points.Add(0D);
                        chartData.Series["Roll"].Points.Add(0D);
                        chartData.Series["Yaw"].Points.Add(0D);
                    }
                    break;
                
                case RealtimeTrendSource.Speedometer:
                    chartData.Series.Clear();
                    chartData.Series.Add("Speedometer");

                    switch (Properties.Settings.Default.SpeedometerUnits)
                    {
                        case 0: //m/s
                            chartData.Series["Speedometer"].LegendText = "M/S";
                            break;
                        case 1: //kmh
                            chartData.Series["Speedometer"].LegendText = "KPH";
                            break;
                        case 2: //mph
                            chartData.Series["Speedometer"].LegendText = "MPH";
                            break;
                    }

                    chartData.Series["Speedometer"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartData.ChartAreas[0].AxisY.Minimum = 0;
                    chartData.ChartAreas[0].AxisY.Maximum = (double)Properties.Settings.Default.SpeedometerVMax;
                    chartData.ChartAreas[0].AxisY.MajorTickMark.Interval = 10;

                    //Preload maxPoints with 0 data 
                    for (int x = 0; x < maxPoints; x++)
                    {
                        chartData.Series["Speedometer"].Points.Add(0D);
                    }
                    break;
            }

            //restart the timer
            updateTimer.Start();
        }
    }
}
