namespace UltraDynamo.DisplayForms
{
    partial class FormGyrometerGauge
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
            this.aquaGaugeGyrometer = new AquaControls.AquaGauge();
            this.SuspendLayout();
            // 
            // aquaGaugeGyrometer
            // 
            this.aquaGaugeGyrometer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aquaGaugeGyrometer.BackColor = System.Drawing.Color.Transparent;
            this.aquaGaugeGyrometer.DialColor = System.Drawing.Color.Lavender;
            this.aquaGaugeGyrometer.DialText = null;
            this.aquaGaugeGyrometer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aquaGaugeGyrometer.Glossiness = 11.36364F;
            this.aquaGaugeGyrometer.Location = new System.Drawing.Point(0, 0);
            this.aquaGaugeGyrometer.MaxValue = 0F;
            this.aquaGaugeGyrometer.MinValue = 0F;
            this.aquaGaugeGyrometer.Name = "aquaGaugeGyrometer";
            this.aquaGaugeGyrometer.RecommendedValue = 0F;
            this.aquaGaugeGyrometer.Size = new System.Drawing.Size(276, 276);
            this.aquaGaugeGyrometer.TabIndex = 0;
            this.aquaGaugeGyrometer.ThresholdPercent = 0F;
            this.aquaGaugeGyrometer.Value = 0F;
            this.aquaGaugeGyrometer.Resize += new System.EventHandler(this.aquaGaugeGyrometer_Resize);
            // 
            // FormGyrometerGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 274);
            this.Controls.Add(this.aquaGaugeGyrometer);
            this.Name = "FormGyrometerGauge";
            this.Text = "Gyrometer";
            this.Load += new System.EventHandler(this.FormGyrometerGauge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AquaControls.AquaGauge aquaGaugeGyrometer;
    }
}