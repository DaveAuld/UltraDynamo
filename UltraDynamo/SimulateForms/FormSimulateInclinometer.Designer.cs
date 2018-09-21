namespace UltraDynamo.SimulateForms
{
    partial class FormSimulateInclinometer
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
            this.trackYaw = new System.Windows.Forms.TrackBar();
            this.trackRoll = new System.Windows.Forms.TrackBar();
            this.trackPitch = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelPitch = new System.Windows.Forms.Label();
            this.labelRawPitch = new System.Windows.Forms.Label();
            this.labelSimPitch = new System.Windows.Forms.Label();
            this.labelRoll = new System.Windows.Forms.Label();
            this.labelRawRoll = new System.Windows.Forms.Label();
            this.labelSimRoll = new System.Windows.Forms.Label();
            this.labelYaw = new System.Windows.Forms.Label();
            this.labelRawYaw = new System.Windows.Forms.Label();
            this.labelSimYaw = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPitch)).BeginInit();
            this.SuspendLayout();
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
            this.checkSimulated.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.checkSimulateEnable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkSimulateEnable.Name = "checkSimulateEnable";
            this.checkSimulateEnable.Size = new System.Drawing.Size(108, 17);
            this.checkSimulateEnable.TabIndex = 6;
            this.checkSimulateEnable.Text = "Simulate Enabled";
            this.checkSimulateEnable.UseVisualStyleBackColor = true;
            this.checkSimulateEnable.CheckedChanged += new System.EventHandler(this.checkSimulateEnable_CheckedChanged);
            // 
            // trackYaw
            // 
            this.trackYaw.Location = new System.Drawing.Point(30, 150);
            this.trackYaw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackYaw.Maximum = 900;
            this.trackYaw.Minimum = -900;
            this.trackYaw.Name = "trackYaw";
            this.trackYaw.Size = new System.Drawing.Size(305, 45);
            this.trackYaw.TabIndex = 12;
            this.trackYaw.TickFrequency = 100;
            this.trackYaw.Scroll += new System.EventHandler(this.track_Scroll);
            // 
            // trackRoll
            // 
            this.trackRoll.Location = new System.Drawing.Point(30, 122);
            this.trackRoll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackRoll.Maximum = 900;
            this.trackRoll.Minimum = -900;
            this.trackRoll.Name = "trackRoll";
            this.trackRoll.Size = new System.Drawing.Size(305, 45);
            this.trackRoll.TabIndex = 12;
            this.trackRoll.TickFrequency = 100;
            this.trackRoll.Scroll += new System.EventHandler(this.track_Scroll);
            // 
            // trackPitch
            // 
            this.trackPitch.Location = new System.Drawing.Point(30, 94);
            this.trackPitch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackPitch.Maximum = 900;
            this.trackPitch.Minimum = -900;
            this.trackPitch.Name = "trackPitch";
            this.trackPitch.Size = new System.Drawing.Size(305, 45);
            this.trackPitch.TabIndex = 12;
            this.trackPitch.TickFrequency = 100;
            this.trackPitch.Scroll += new System.EventHandler(this.track_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 98);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Pitch";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 126);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Roll";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 153);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Yaw";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPitch
            // 
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(125, 38);
            this.labelPitch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(13, 13);
            this.labelPitch.TabIndex = 14;
            this.labelPitch.Text = "0";
            this.labelPitch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRawPitch
            // 
            this.labelRawPitch.AutoSize = true;
            this.labelRawPitch.Location = new System.Drawing.Point(125, 52);
            this.labelRawPitch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawPitch.Name = "labelRawPitch";
            this.labelRawPitch.Size = new System.Drawing.Size(13, 13);
            this.labelRawPitch.TabIndex = 14;
            this.labelRawPitch.Text = "0";
            this.labelRawPitch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSimPitch
            // 
            this.labelSimPitch.AutoSize = true;
            this.labelSimPitch.Location = new System.Drawing.Point(125, 66);
            this.labelSimPitch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSimPitch.Name = "labelSimPitch";
            this.labelSimPitch.Size = new System.Drawing.Size(13, 13);
            this.labelSimPitch.TabIndex = 14;
            this.labelSimPitch.Text = "0";
            this.labelSimPitch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRoll
            // 
            this.labelRoll.AutoSize = true;
            this.labelRoll.Location = new System.Drawing.Point(176, 38);
            this.labelRoll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRoll.Name = "labelRoll";
            this.labelRoll.Size = new System.Drawing.Size(13, 13);
            this.labelRoll.TabIndex = 14;
            this.labelRoll.Text = "0";
            this.labelRoll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRawRoll
            // 
            this.labelRawRoll.AutoSize = true;
            this.labelRawRoll.Location = new System.Drawing.Point(176, 52);
            this.labelRawRoll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawRoll.Name = "labelRawRoll";
            this.labelRawRoll.Size = new System.Drawing.Size(13, 13);
            this.labelRawRoll.TabIndex = 14;
            this.labelRawRoll.Text = "0";
            this.labelRawRoll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSimRoll
            // 
            this.labelSimRoll.AutoSize = true;
            this.labelSimRoll.Location = new System.Drawing.Point(176, 66);
            this.labelSimRoll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSimRoll.Name = "labelSimRoll";
            this.labelSimRoll.Size = new System.Drawing.Size(13, 13);
            this.labelSimRoll.TabIndex = 14;
            this.labelSimRoll.Text = "0";
            this.labelSimRoll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelYaw
            // 
            this.labelYaw.AutoSize = true;
            this.labelYaw.Location = new System.Drawing.Point(221, 38);
            this.labelYaw.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelYaw.Name = "labelYaw";
            this.labelYaw.Size = new System.Drawing.Size(13, 13);
            this.labelYaw.TabIndex = 14;
            this.labelYaw.Text = "0";
            this.labelYaw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRawYaw
            // 
            this.labelRawYaw.AutoSize = true;
            this.labelRawYaw.Location = new System.Drawing.Point(221, 52);
            this.labelRawYaw.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRawYaw.Name = "labelRawYaw";
            this.labelRawYaw.Size = new System.Drawing.Size(13, 13);
            this.labelRawYaw.TabIndex = 14;
            this.labelRawYaw.Text = "0";
            this.labelRawYaw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSimYaw
            // 
            this.labelSimYaw.AutoSize = true;
            this.labelSimYaw.Location = new System.Drawing.Point(221, 66);
            this.labelSimYaw.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSimYaw.Name = "labelSimYaw";
            this.labelSimYaw.Size = new System.Drawing.Size(13, 13);
            this.labelSimYaw.TabIndex = 14;
            this.labelSimYaw.Text = "0";
            this.labelSimYaw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(117, 24);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 13);
            this.label25.TabIndex = 14;
            this.label25.Text = "Pitch";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(170, 24);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(25, 13);
            this.label26.TabIndex = 14;
            this.label26.Text = "Roll";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(214, 24);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 13);
            this.label27.TabIndex = 14;
            this.label27.Text = "Yaw";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormSimulateInclinometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 197);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.trackYaw);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.trackRoll);
            this.Controls.Add(this.labelSimYaw);
            this.Controls.Add(this.labelSimRoll);
            this.Controls.Add(this.labelSimPitch);
            this.Controls.Add(this.labelRawYaw);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.labelYaw);
            this.Controls.Add(this.labelRawRoll);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.labelRoll);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.labelRawPitch);
            this.Controls.Add(this.labelPitch);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.trackPitch);
            this.Controls.Add(this.checkAvailable);
            this.Controls.Add(this.checkSimulated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkSimulateEnable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSimulateInclinometer";
            this.Text = "Simulate Inclinometer";
            ((System.ComponentModel.ISupportInitialize)(this.trackYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPitch)).EndInit();
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
        private System.Windows.Forms.TrackBar trackYaw;
        private System.Windows.Forms.TrackBar trackRoll;
        private System.Windows.Forms.TrackBar trackPitch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.Label labelRawPitch;
        private System.Windows.Forms.Label labelSimPitch;
        private System.Windows.Forms.Label labelRoll;
        private System.Windows.Forms.Label labelRawRoll;
        private System.Windows.Forms.Label labelSimRoll;
        private System.Windows.Forms.Label labelYaw;
        private System.Windows.Forms.Label labelRawYaw;
        private System.Windows.Forms.Label labelSimYaw;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
    }
}