namespace UltraDynamo.SimulateForms
{
    partial class FormSimulateCompass
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
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkAvailable = new System.Windows.Forms.CheckBox();
            this.checkSimulated = new System.Windows.Forms.CheckBox();
            this.labelSimulatedValue = new System.Windows.Forms.Label();
            this.labelRawValue = new System.Windows.Forms.Label();
            this.labelUsedValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackSimulateValue = new System.Windows.Forms.TrackBar();
            this.checkSimulateEnable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackSimulateValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "180 Degrees";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(402, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "359.99";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "0";
            // 
            // checkAvailable
            // 
            this.checkAvailable.AutoSize = true;
            this.checkAvailable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkAvailable.Enabled = false;
            this.checkAvailable.Location = new System.Drawing.Point(363, 12);
            this.checkAvailable.Name = "checkAvailable";
            this.checkAvailable.Size = new System.Drawing.Size(87, 21);
            this.checkAvailable.TabIndex = 25;
            this.checkAvailable.Text = "Available";
            this.checkAvailable.UseVisualStyleBackColor = true;
            // 
            // checkSimulated
            // 
            this.checkSimulated.AutoSize = true;
            this.checkSimulated.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSimulated.Enabled = false;
            this.checkSimulated.Location = new System.Drawing.Point(358, 39);
            this.checkSimulated.Name = "checkSimulated";
            this.checkSimulated.Size = new System.Drawing.Size(92, 21);
            this.checkSimulated.TabIndex = 26;
            this.checkSimulated.Text = "Simulated";
            this.checkSimulated.UseVisualStyleBackColor = true;
            // 
            // labelSimulatedValue
            // 
            this.labelSimulatedValue.AutoSize = true;
            this.labelSimulatedValue.Location = new System.Drawing.Point(146, 81);
            this.labelSimulatedValue.Name = "labelSimulatedValue";
            this.labelSimulatedValue.Size = new System.Drawing.Size(16, 17);
            this.labelSimulatedValue.TabIndex = 22;
            this.labelSimulatedValue.Text = "0";
            // 
            // labelRawValue
            // 
            this.labelRawValue.AutoSize = true;
            this.labelRawValue.Location = new System.Drawing.Point(146, 64);
            this.labelRawValue.Name = "labelRawValue";
            this.labelRawValue.Size = new System.Drawing.Size(16, 17);
            this.labelRawValue.TabIndex = 23;
            this.labelRawValue.Text = "0";
            // 
            // labelUsedValue
            // 
            this.labelUsedValue.AutoSize = true;
            this.labelUsedValue.Location = new System.Drawing.Point(146, 47);
            this.labelUsedValue.Name = "labelUsedValue";
            this.labelUsedValue.Size = new System.Drawing.Size(16, 17);
            this.labelUsedValue.TabIndex = 24;
            this.labelUsedValue.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Simulated Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Raw Sensor Value:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Used Value:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackSimulateValue
            // 
            this.trackSimulateValue.LargeChange = 100;
            this.trackSimulateValue.Location = new System.Drawing.Point(12, 112);
            this.trackSimulateValue.Maximum = 35999;
            this.trackSimulateValue.Name = "trackSimulateValue";
            this.trackSimulateValue.Size = new System.Drawing.Size(438, 56);
            this.trackSimulateValue.SmallChange = 100;
            this.trackSimulateValue.TabIndex = 18;
            this.trackSimulateValue.TickFrequency = 1000;
            this.trackSimulateValue.Scroll += new System.EventHandler(this.trackSimulateValue_ValueChanged);
            // 
            // checkSimulateEnable
            // 
            this.checkSimulateEnable.AutoSize = true;
            this.checkSimulateEnable.Location = new System.Drawing.Point(12, 12);
            this.checkSimulateEnable.Name = "checkSimulateEnable";
            this.checkSimulateEnable.Size = new System.Drawing.Size(140, 21);
            this.checkSimulateEnable.TabIndex = 17;
            this.checkSimulateEnable.Text = "Simulate Enabled";
            this.checkSimulateEnable.UseVisualStyleBackColor = true;
            this.checkSimulateEnable.CheckedChanged += new System.EventHandler(this.checkSimulateEnable_CheckedChanged);
            // 
            // FormSimulateCompass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 173);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkAvailable);
            this.Controls.Add(this.checkSimulated);
            this.Controls.Add(this.labelSimulatedValue);
            this.Controls.Add(this.labelRawValue);
            this.Controls.Add(this.labelUsedValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackSimulateValue);
            this.Controls.Add(this.checkSimulateEnable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSimulateCompass";
            this.Text = "Simulate Compass";
            ((System.ComponentModel.ISupportInitialize)(this.trackSimulateValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkAvailable;
        private System.Windows.Forms.CheckBox checkSimulated;
        private System.Windows.Forms.Label labelSimulatedValue;
        private System.Windows.Forms.Label labelRawValue;
        private System.Windows.Forms.Label labelUsedValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackSimulateValue;
        private System.Windows.Forms.CheckBox checkSimulateEnable;
    }
}