namespace UltraDynamo.DisplayForms
{
    partial class FormInclinometerGauge
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
            this.aquaGaugeInclinometer = new AquaControls.AquaGauge();
            this.SuspendLayout();
            // 
            // aquaGaugeInclinometer
            // 
            this.aquaGaugeInclinometer.BackColor = System.Drawing.Color.Transparent;
            this.aquaGaugeInclinometer.DialColor = System.Drawing.Color.GreenYellow;
            this.aquaGaugeInclinometer.DialText = null;
            this.aquaGaugeInclinometer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aquaGaugeInclinometer.Glossiness = 11.36364F;
            this.aquaGaugeInclinometer.Location = new System.Drawing.Point(0, 0);
            this.aquaGaugeInclinometer.MaxValue = 0F;
            this.aquaGaugeInclinometer.MinValue = 0F;
            this.aquaGaugeInclinometer.Name = "aquaGaugeInclinometer";
            this.aquaGaugeInclinometer.RecommendedValue = 0F;
            this.aquaGaugeInclinometer.Size = new System.Drawing.Size(284, 284);
            this.aquaGaugeInclinometer.TabIndex = 0;
            this.aquaGaugeInclinometer.ThresholdPercent = 0F;
            this.aquaGaugeInclinometer.Value = 0F;
            // 
            // FormInclinometerGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.aquaGaugeInclinometer);
            this.Name = "FormInclinometerGauge";
            this.Text = "Inclinometer";
            this.Resize += new System.EventHandler(this.FormInclinometerGauge_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private AquaControls.AquaGauge aquaGaugeInclinometer;
    }
}