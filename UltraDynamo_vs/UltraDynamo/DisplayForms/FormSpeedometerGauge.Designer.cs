namespace UltraDynamo.DisplayForms
{
    partial class FormSpeedometerGauge
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
            this.aquaGaugeSpeedometer = new AquaControls.AquaGauge();
            this.SuspendLayout();
            // 
            // aquaGaugeSpeedometer
            // 
            this.aquaGaugeSpeedometer.BackColor = System.Drawing.Color.Transparent;
            this.aquaGaugeSpeedometer.DialColor = System.Drawing.Color.Lavender;
            this.aquaGaugeSpeedometer.DialText = null;
            this.aquaGaugeSpeedometer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aquaGaugeSpeedometer.Glossiness = 11.36364F;
            this.aquaGaugeSpeedometer.Location = new System.Drawing.Point(0, 0);
            this.aquaGaugeSpeedometer.MaxValue = 0F;
            this.aquaGaugeSpeedometer.MinValue = 0F;
            this.aquaGaugeSpeedometer.Name = "aquaGaugeSpeedometer";
            this.aquaGaugeSpeedometer.RecommendedValue = 0F;
            this.aquaGaugeSpeedometer.Size = new System.Drawing.Size(244, 244);
            this.aquaGaugeSpeedometer.TabIndex = 0;
            this.aquaGaugeSpeedometer.ThresholdPercent = 0F;
            this.aquaGaugeSpeedometer.Value = 0F;
            // 
            // FormSpeedometerGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 246);
            this.Controls.Add(this.aquaGaugeSpeedometer);
            this.Name = "FormSpeedometerGauge";
            this.Text = "Speedometer";
            this.ResumeLayout(false);

        }

        #endregion

        private AquaControls.AquaGauge aquaGaugeSpeedometer;
    }
}