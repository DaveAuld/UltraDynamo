namespace UltraDynamo.SimulateForms
{
    partial class FormSimulateAccelerometer
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
            this.checkAvailable = new System.Windows.Forms.CheckBox();
            this.checkSimulated = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkSimulateEnable = new System.Windows.Forms.CheckBox();
            this.trackX = new System.Windows.Forms.TrackBar();
            this.trackY = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelRawX = new System.Windows.Forms.Label();
            this.labelSimX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelRawY = new System.Windows.Forms.Label();
            this.labelSimY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelRawZ = new System.Windows.Forms.Label();
            this.labelSimZ = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.trackZ = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).BeginInit();
            this.SuspendLayout();
            // 
            // checkAvailable
            // 
            this.checkAvailable.AutoSize = true;
            this.checkAvailable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkAvailable.Enabled = false;
            this.checkAvailable.Location = new System.Drawing.Point(272, 10);
            this.checkAvailable.Margin = new System.Windows.Forms.Padding(2);
            this.checkAvailable.Name = "checkAvailable";
            this.checkAvailable.Size = new System.Drawing.Size(69, 17);
            this.checkAvailable.TabIndex = 10;
            this.checkAvailable.Text = "Available";
            this.checkAvailable.UseVisualStyleBackColor = true;
            // 
            // checkSimulated
            // 
            this.checkSimulated.AutoSize = true;
            this.checkSimulated.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSimulated.Enabled = false;
            this.checkSimulated.Location = new System.Drawing.Point(268, 32);
            this.checkSimulated.Margin = new System.Windows.Forms.Padding(2);
            this.checkSimulated.Name = "checkSimulated";
            this.checkSimulated.Size = new System.Drawing.Size(72, 17);
            this.checkSimulated.TabIndex = 11;
            this.checkSimulated.Text = "Simulated";
            this.checkSimulated.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Simulated Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Raw Sensor Value:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Used Value:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkSimulateEnable
            // 
            this.checkSimulateEnable.AutoSize = true;
            this.checkSimulateEnable.Location = new System.Drawing.Point(9, 10);
            this.checkSimulateEnable.Margin = new System.Windows.Forms.Padding(2);
            this.checkSimulateEnable.Name = "checkSimulateEnable";
            this.checkSimulateEnable.Size = new System.Drawing.Size(108, 17);
            this.checkSimulateEnable.TabIndex = 6;
            this.checkSimulateEnable.Text = "Simulate Enabled";
            this.checkSimulateEnable.UseVisualStyleBackColor = true;
            this.checkSimulateEnable.CheckedChanged += new System.EventHandler(this.checkSimulateEnable_CheckedChanged);
            // 
            // trackX
            // 
            this.trackX.Location = new System.Drawing.Point(9, 94);
            this.trackX.Margin = new System.Windows.Forms.Padding(2);
            this.trackX.Maximum = 50;
            this.trackX.Minimum = -50;
            this.trackX.Name = "trackX";
            this.trackX.Size = new System.Drawing.Size(326, 45);
            this.trackX.TabIndex = 12;
            this.trackX.TickFrequency = 10;
            this.trackX.Scroll += new System.EventHandler(this.track_Scroll);
            // 
            // trackY
            // 
            this.trackY.Location = new System.Drawing.Point(9, 121);
            this.trackY.Margin = new System.Windows.Forms.Padding(2);
            this.trackY.Maximum = 50;
            this.trackY.Minimum = -50;
            this.trackY.Name = "trackY";
            this.trackY.Size = new System.Drawing.Size(326, 45);
            this.trackY.TabIndex = 12;
            this.trackY.TickFrequency = 10;
            this.trackY.Scroll += new System.EventHandler(this.track_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 98);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "X";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 126);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Y";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 153);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Z";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(125, 38);
            this.labelX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(13, 13);
            this.labelX.TabIndex = 14;
            this.labelX.Text = "0";
            this.labelX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRawX
            // 
            this.labelRawX.AutoSize = true;
            this.labelRawX.Location = new System.Drawing.Point(125, 52);
            this.labelRawX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawX.Name = "labelRawX";
            this.labelRawX.Size = new System.Drawing.Size(13, 13);
            this.labelRawX.TabIndex = 14;
            this.labelRawX.Text = "0";
            this.labelRawX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSimX
            // 
            this.labelSimX.AutoSize = true;
            this.labelSimX.Location = new System.Drawing.Point(125, 66);
            this.labelSimX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSimX.Name = "labelSimX";
            this.labelSimX.Size = new System.Drawing.Size(13, 13);
            this.labelSimX.TabIndex = 14;
            this.labelSimX.Text = "0";
            this.labelSimX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(176, 38);
            this.labelY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(13, 13);
            this.labelY.TabIndex = 14;
            this.labelY.Text = "0";
            this.labelY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRawY
            // 
            this.labelRawY.AutoSize = true;
            this.labelRawY.Location = new System.Drawing.Point(176, 52);
            this.labelRawY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawY.Name = "labelRawY";
            this.labelRawY.Size = new System.Drawing.Size(13, 13);
            this.labelRawY.TabIndex = 14;
            this.labelRawY.Text = "0";
            this.labelRawY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSimY
            // 
            this.labelSimY.AutoSize = true;
            this.labelSimY.Location = new System.Drawing.Point(176, 66);
            this.labelSimY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSimY.Name = "labelSimY";
            this.labelSimY.Size = new System.Drawing.Size(13, 13);
            this.labelSimY.TabIndex = 14;
            this.labelSimY.Text = "0";
            this.labelSimY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(221, 38);
            this.labelZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(13, 13);
            this.labelZ.TabIndex = 14;
            this.labelZ.Text = "0";
            this.labelZ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRawZ
            // 
            this.labelRawZ.AutoSize = true;
            this.labelRawZ.Location = new System.Drawing.Point(221, 52);
            this.labelRawZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawZ.Name = "labelRawZ";
            this.labelRawZ.Size = new System.Drawing.Size(13, 13);
            this.labelRawZ.TabIndex = 14;
            this.labelRawZ.Text = "0";
            this.labelRawZ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSimZ
            // 
            this.labelSimZ.AutoSize = true;
            this.labelSimZ.Location = new System.Drawing.Point(221, 66);
            this.labelSimZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSimZ.Name = "labelSimZ";
            this.labelSimZ.Size = new System.Drawing.Size(13, 13);
            this.labelSimZ.TabIndex = 14;
            this.labelSimZ.Text = "0";
            this.labelSimZ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(125, 24);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 13);
            this.label25.TabIndex = 14;
            this.label25.Text = "X";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(176, 24);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(14, 13);
            this.label26.TabIndex = 14;
            this.label26.Text = "Y";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(221, 24);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 13);
            this.label27.TabIndex = 14;
            this.label27.Text = "Z";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackZ
            // 
            this.trackZ.Location = new System.Drawing.Point(9, 153);
            this.trackZ.Margin = new System.Windows.Forms.Padding(2);
            this.trackZ.Maximum = 50;
            this.trackZ.Minimum = -50;
            this.trackZ.Name = "trackZ";
            this.trackZ.Size = new System.Drawing.Size(326, 45);
            this.trackZ.TabIndex = 12;
            this.trackZ.TickFrequency = 10;
            this.trackZ.Scroll += new System.EventHandler(this.track_Scroll);
            // 
            // FormSimulateAccelerometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 200);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.trackZ);
            this.Controls.Add(this.trackY);
            this.Controls.Add(this.labelSimZ);
            this.Controls.Add(this.labelSimY);
            this.Controls.Add(this.labelSimX);
            this.Controls.Add(this.labelRawZ);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelRawY);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.labelRawX);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.trackX);
            this.Controls.Add(this.checkAvailable);
            this.Controls.Add(this.checkSimulated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkSimulateEnable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSimulateAccelerometer";
            this.Text = "Simulate Accelerometer";
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkAvailable;
        private System.Windows.Forms.CheckBox checkSimulated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkSimulateEnable;
        private System.Windows.Forms.TrackBar trackY;
        private System.Windows.Forms.TrackBar trackX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelRawX;
        private System.Windows.Forms.Label labelSimX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelRawY;
        private System.Windows.Forms.Label labelSimY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelRawZ;
        private System.Windows.Forms.Label labelSimZ;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TrackBar trackZ;
    }
}