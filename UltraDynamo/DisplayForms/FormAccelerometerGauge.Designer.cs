namespace UltraDynamo.DisplayForms
{
    partial class FormAccelerometerGauge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.aquaGaugeAccelerometer = new AquaControls.AquaGauge();
            this.SuspendLayout();
            // 
            // aquaGaugeAccelerometer
            // 
            this.aquaGaugeAccelerometer.BackColor = System.Drawing.Color.Transparent;
            this.aquaGaugeAccelerometer.DialColor = System.Drawing.Color.CornflowerBlue;
            this.aquaGaugeAccelerometer.DialText = null;
            this.aquaGaugeAccelerometer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aquaGaugeAccelerometer.Glossiness = 11.36364F;
            this.aquaGaugeAccelerometer.Location = new System.Drawing.Point(0, 0);
            this.aquaGaugeAccelerometer.MaxValue = 0F;
            this.aquaGaugeAccelerometer.MinValue = 0F;
            this.aquaGaugeAccelerometer.Name = "aquaGaugeAccelerometer";
            this.aquaGaugeAccelerometer.RecommendedValue = 0F;
            this.aquaGaugeAccelerometer.Size = new System.Drawing.Size(284, 284);
            this.aquaGaugeAccelerometer.TabIndex = 0;
            this.aquaGaugeAccelerometer.ThresholdPercent = 0F;
            this.aquaGaugeAccelerometer.Value = 0F;
            // 
            // FormAccelerometerGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.aquaGaugeAccelerometer);
            this.Name = "FormAccelerometerGauge";
            this.Text = "Accelerometer";
            this.Load += new System.EventHandler(this.FormAccelerometerGauge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AquaControls.AquaGauge aquaGaugeAccelerometer;
    }
}