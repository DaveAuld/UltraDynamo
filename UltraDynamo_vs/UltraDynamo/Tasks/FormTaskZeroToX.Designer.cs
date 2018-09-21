namespace UltraDynamo.Tasks
{
    partial class FormTaskZeroToX
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
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.radioOptionZeroToX = new System.Windows.Forms.RadioButton();
            this.radioOptionZeroToXToZero = new System.Windows.Forms.RadioButton();
            this.numericTargetSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboTargetUnits = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.aquaGaugeSpeedometer = new AquaControls.AquaGauge();
            this.aquaGaugeAccelerometer = new AquaControls.AquaGauge();
            this.groupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.buttonStart);
            this.groupOptions.Controls.Add(this.comboTargetUnits);
            this.groupOptions.Controls.Add(this.label1);
            this.groupOptions.Controls.Add(this.numericTargetSpeed);
            this.groupOptions.Controls.Add(this.radioOptionZeroToXToZero);
            this.groupOptions.Controls.Add(this.radioOptionZeroToX);
            this.groupOptions.Location = new System.Drawing.Point(12, 12);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(263, 118);
            this.groupOptions.TabIndex = 0;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // radioOptionZeroToX
            // 
            this.radioOptionZeroToX.AutoSize = true;
            this.radioOptionZeroToX.Location = new System.Drawing.Point(6, 19);
            this.radioOptionZeroToX.Name = "radioOptionZeroToX";
            this.radioOptionZeroToX.Size = new System.Drawing.Size(75, 17);
            this.radioOptionZeroToX.TabIndex = 0;
            this.radioOptionZeroToX.TabStop = true;
            this.radioOptionZeroToX.Text = "Sprint (0-x)";
            this.radioOptionZeroToX.UseVisualStyleBackColor = true;
            // 
            // radioOptionZeroToXToZero
            // 
            this.radioOptionZeroToXToZero.AutoSize = true;
            this.radioOptionZeroToXToZero.Location = new System.Drawing.Point(6, 42);
            this.radioOptionZeroToXToZero.Name = "radioOptionZeroToXToZero";
            this.radioOptionZeroToXToZero.Size = new System.Drawing.Size(124, 17);
            this.radioOptionZeroToXToZero.TabIndex = 0;
            this.radioOptionZeroToXToZero.TabStop = true;
            this.radioOptionZeroToXToZero.Text = "Sprint + Brake (0-x-0)";
            this.radioOptionZeroToXToZero.UseVisualStyleBackColor = true;
            // 
            // numericTargetSpeed
            // 
            this.numericTargetSpeed.Location = new System.Drawing.Point(90, 65);
            this.numericTargetSpeed.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericTargetSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTargetSpeed.Name = "numericTargetSpeed";
            this.numericTargetSpeed.Size = new System.Drawing.Size(47, 20);
            this.numericTargetSpeed.TabIndex = 1;
            this.numericTargetSpeed.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericTargetSpeed.ValueChanged += new System.EventHandler(this.numericTargetSpeed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Target Speed :";
            // 
            // comboTargetUnits
            // 
            this.comboTargetUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTargetUnits.FormattingEnabled = true;
            this.comboTargetUnits.Items.AddRange(new object[] {
            "Miles per hour",
            "Km per hour",
            "Metres per second"});
            this.comboTargetUnits.Location = new System.Drawing.Point(143, 64);
            this.comboTargetUnits.Name = "comboTargetUnits";
            this.comboTargetUnits.Size = new System.Drawing.Size(114, 21);
            this.comboTargetUnits.TabIndex = 3;
            this.comboTargetUnits.SelectedIndexChanged += new System.EventHandler(this.comboTargetUnits_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(281, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 118);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instructions";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(143, 89);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(114, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Let\'s Do It!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textStatus);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(330, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 312);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Run Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Brake Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Accelerate Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Maximum Speed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Status";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 193);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(150, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 147);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(150, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 102);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(150, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textStatus
            // 
            this.textStatus.BackColor = System.Drawing.Color.LightSlateGray;
            this.textStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textStatus.Location = new System.Drawing.Point(6, 32);
            this.textStatus.Name = "textStatus";
            this.textStatus.ReadOnly = true;
            this.textStatus.Size = new System.Drawing.Size(150, 31);
            this.textStatus.TabIndex = 3;
            this.textStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // aquaGaugeSpeedometer
            // 
            this.aquaGaugeSpeedometer.BackColor = System.Drawing.Color.Transparent;
            this.aquaGaugeSpeedometer.DialColor = System.Drawing.Color.Lavender;
            this.aquaGaugeSpeedometer.DialText = null;
            this.aquaGaugeSpeedometer.Glossiness = 11.36364F;
            this.aquaGaugeSpeedometer.Location = new System.Drawing.Point(498, 136);
            this.aquaGaugeSpeedometer.MaxValue = 0F;
            this.aquaGaugeSpeedometer.MinValue = 0F;
            this.aquaGaugeSpeedometer.Name = "aquaGaugeSpeedometer";
            this.aquaGaugeSpeedometer.RecommendedValue = 0F;
            this.aquaGaugeSpeedometer.Size = new System.Drawing.Size(312, 312);
            this.aquaGaugeSpeedometer.TabIndex = 3;
            this.aquaGaugeSpeedometer.ThresholdPercent = 0F;
            this.aquaGaugeSpeedometer.Value = 0F;
            // 
            // aquaGaugeAccelerometer
            // 
            this.aquaGaugeAccelerometer.BackColor = System.Drawing.Color.Transparent;
            this.aquaGaugeAccelerometer.DialColor = System.Drawing.Color.Lavender;
            this.aquaGaugeAccelerometer.DialText = null;
            this.aquaGaugeAccelerometer.Glossiness = 11.36364F;
            this.aquaGaugeAccelerometer.Location = new System.Drawing.Point(12, 136);
            this.aquaGaugeAccelerometer.MaxValue = 0F;
            this.aquaGaugeAccelerometer.MinValue = 0F;
            this.aquaGaugeAccelerometer.Name = "aquaGaugeAccelerometer";
            this.aquaGaugeAccelerometer.RecommendedValue = 0F;
            this.aquaGaugeAccelerometer.Size = new System.Drawing.Size(312, 312);
            this.aquaGaugeAccelerometer.TabIndex = 2;
            this.aquaGaugeAccelerometer.ThresholdPercent = 0F;
            this.aquaGaugeAccelerometer.Value = 0F;
            // 
            // FormTaskZeroToX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 557);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.aquaGaugeSpeedometer);
            this.Controls.Add(this.aquaGaugeAccelerometer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupOptions);
            this.Name = "FormTaskZeroToX";
            this.Text = "Sprint Timing";
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.ComboBox comboTargetUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericTargetSpeed;
        private System.Windows.Forms.RadioButton radioOptionZeroToXToZero;
        private System.Windows.Forms.RadioButton radioOptionZeroToX;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private AquaControls.AquaGauge aquaGaugeAccelerometer;
        private AquaControls.AquaGauge aquaGaugeSpeedometer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}