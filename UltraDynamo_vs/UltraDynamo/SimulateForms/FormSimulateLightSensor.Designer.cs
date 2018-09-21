namespace UltraDynamo.SimulateForms
{
    partial class FormSimulateLightSensor
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
            this.checkSimulateEnable = new System.Windows.Forms.CheckBox();
            this.trackSimulateValue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUsedValue = new System.Windows.Forms.Label();
            this.labelRawValue = new System.Windows.Forms.Label();
            this.checkSimulated = new System.Windows.Forms.CheckBox();
            this.checkAvailable = new System.Windows.Forms.CheckBox();
            this.labelSimulatedValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackSimulateValue)).BeginInit();
            this.SuspendLayout();
            // 
            // checkSimulateEnable
            // 
            this.checkSimulateEnable.AutoSize = true;
            this.checkSimulateEnable.Location = new System.Drawing.Point(9, 10);
            this.checkSimulateEnable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkSimulateEnable.Name = "checkSimulateEnable";
            this.checkSimulateEnable.Size = new System.Drawing.Size(108, 17);
            this.checkSimulateEnable.TabIndex = 0;
            this.checkSimulateEnable.Text = "Simulate Enabled";
            this.checkSimulateEnable.UseVisualStyleBackColor = true;
            this.checkSimulateEnable.CheckedChanged += new System.EventHandler(this.checkSimulateEnable_CheckedChanged);
            // 
            // trackSimulateValue
            // 
            this.trackSimulateValue.LargeChange = 1000;
            this.trackSimulateValue.Location = new System.Drawing.Point(9, 91);
            this.trackSimulateValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackSimulateValue.Maximum = 10000;
            this.trackSimulateValue.Name = "trackSimulateValue";
            this.trackSimulateValue.Size = new System.Drawing.Size(328, 45);
            this.trackSimulateValue.SmallChange = 100;
            this.trackSimulateValue.TabIndex = 1;
            this.trackSimulateValue.TickFrequency = 100;
            this.trackSimulateValue.ValueChanged += new System.EventHandler(this.trackSimulateValue_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Used Value:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Raw Sensor Value:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Simulated Value:";
            // 
            // labelUsedValue
            // 
            this.labelUsedValue.AutoSize = true;
            this.labelUsedValue.Location = new System.Drawing.Point(110, 38);
            this.labelUsedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsedValue.Name = "labelUsedValue";
            this.labelUsedValue.Size = new System.Drawing.Size(13, 13);
            this.labelUsedValue.TabIndex = 3;
            this.labelUsedValue.Text = "0";
            // 
            // labelRawValue
            // 
            this.labelRawValue.AutoSize = true;
            this.labelRawValue.Location = new System.Drawing.Point(110, 52);
            this.labelRawValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawValue.Name = "labelRawValue";
            this.labelRawValue.Size = new System.Drawing.Size(13, 13);
            this.labelRawValue.TabIndex = 3;
            this.labelRawValue.Text = "0";
            // 
            // checkSimulated
            // 
            this.checkSimulated.AutoSize = true;
            this.checkSimulated.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSimulated.Enabled = false;
            this.checkSimulated.Location = new System.Drawing.Point(268, 32);
            this.checkSimulated.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkSimulated.Name = "checkSimulated";
            this.checkSimulated.Size = new System.Drawing.Size(72, 17);
            this.checkSimulated.TabIndex = 5;
            this.checkSimulated.Text = "Simulated";
            this.checkSimulated.UseVisualStyleBackColor = true;
            // 
            // checkAvailable
            // 
            this.checkAvailable.AutoSize = true;
            this.checkAvailable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkAvailable.Enabled = false;
            this.checkAvailable.Location = new System.Drawing.Point(272, 10);
            this.checkAvailable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkAvailable.Name = "checkAvailable";
            this.checkAvailable.Size = new System.Drawing.Size(69, 17);
            this.checkAvailable.TabIndex = 5;
            this.checkAvailable.Text = "Available";
            this.checkAvailable.UseVisualStyleBackColor = true;
            // 
            // labelSimulatedValue
            // 
            this.labelSimulatedValue.AutoSize = true;
            this.labelSimulatedValue.Location = new System.Drawing.Point(110, 66);
            this.labelSimulatedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSimulatedValue.Name = "labelSimulatedValue";
            this.labelSimulatedValue.Size = new System.Drawing.Size(13, 13);
            this.labelSimulatedValue.TabIndex = 3;
            this.labelSimulatedValue.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 118);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Lux";
            // 
            // FormSimulateLightSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 139);
            this.Controls.Add(this.label10);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSimulateLightSensor";
            this.Text = "Simulate Light Sensor";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.trackSimulateValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkSimulateEnable;
        private System.Windows.Forms.TrackBar trackSimulateValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUsedValue;
        private System.Windows.Forms.Label labelRawValue;
        private System.Windows.Forms.CheckBox checkSimulated;
        private System.Windows.Forms.CheckBox checkAvailable;
        private System.Windows.Forms.Label labelSimulatedValue;
        private System.Windows.Forms.Label label10;
    }
}