namespace UltraDynamo.Tasks
{
    partial class FormTaskReactionTimer
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
            this.groupIndicator = new System.Windows.Forms.GroupBox();
            this.radioIndicatorBasic = new System.Windows.Forms.RadioButton();
            this.radioIndicatorFormula1 = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelBasic = new System.Windows.Forms.Panel();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.groupInstructions = new System.Windows.Forms.GroupBox();
            this.groupStartIndicator = new System.Windows.Forms.GroupBox();
            this.groupResult = new System.Windows.Forms.GroupBox();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.groupAccelerometerData = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAccelerometerAverage = new System.Windows.Forms.Label();
            this.labelAccelerometerMax = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.checkSkipPrep = new System.Windows.Forms.CheckBox();
            this.groupIndicator.SuspendLayout();
            this.groupInstructions.SuspendLayout();
            this.groupStartIndicator.SuspendLayout();
            this.groupResult.SuspendLayout();
            this.groupAccelerometerData.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupIndicator
            // 
            this.groupIndicator.Controls.Add(this.checkSkipPrep);
            this.groupIndicator.Controls.Add(this.buttonStart);
            this.groupIndicator.Controls.Add(this.radioIndicatorFormula1);
            this.groupIndicator.Controls.Add(this.radioIndicatorBasic);
            this.groupIndicator.Location = new System.Drawing.Point(6, 67);
            this.groupIndicator.Name = "groupIndicator";
            this.groupIndicator.Size = new System.Drawing.Size(456, 44);
            this.groupIndicator.TabIndex = 0;
            this.groupIndicator.TabStop = false;
            this.groupIndicator.Text = "Indication Method";
            // 
            // radioIndicatorBasic
            // 
            this.radioIndicatorBasic.AutoSize = true;
            this.radioIndicatorBasic.Location = new System.Drawing.Point(6, 19);
            this.radioIndicatorBasic.Name = "radioIndicatorBasic";
            this.radioIndicatorBasic.Size = new System.Drawing.Size(51, 17);
            this.radioIndicatorBasic.TabIndex = 0;
            this.radioIndicatorBasic.TabStop = true;
            this.radioIndicatorBasic.Text = "Basic";
            this.radioIndicatorBasic.UseVisualStyleBackColor = true;
            // 
            // radioIndicatorFormula1
            // 
            this.radioIndicatorFormula1.AutoSize = true;
            this.radioIndicatorFormula1.Location = new System.Drawing.Point(63, 19);
            this.radioIndicatorFormula1.Name = "radioIndicatorFormula1";
            this.radioIndicatorFormula1.Size = new System.Drawing.Size(99, 17);
            this.radioIndicatorFormula1.TabIndex = 0;
            this.radioIndicatorFormula1.TabStop = true;
            this.radioIndicatorFormula1.Text = "Formula1 Lights";
            this.radioIndicatorFormula1.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(330, 16);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Let\'s Do It!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelBasic
            // 
            this.panelBasic.Location = new System.Drawing.Point(6, 19);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(444, 75);
            this.panelBasic.TabIndex = 1;
            this.panelBasic.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBasic_Paint);
            // 
            // labelInstructions
            // 
            this.labelInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInstructions.Location = new System.Drawing.Point(6, 16);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(444, 23);
            this.labelInstructions.TabIndex = 2;
            this.labelInstructions.Text = "Select Indication Method and Click Let\'s Do It!";
            this.labelInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupInstructions
            // 
            this.groupInstructions.Controls.Add(this.labelInstructions);
            this.groupInstructions.Location = new System.Drawing.Point(6, 12);
            this.groupInstructions.Name = "groupInstructions";
            this.groupInstructions.Size = new System.Drawing.Size(456, 49);
            this.groupInstructions.TabIndex = 3;
            this.groupInstructions.TabStop = false;
            this.groupInstructions.Text = "Instructions";
            // 
            // groupStartIndicator
            // 
            this.groupStartIndicator.Controls.Add(this.panelBasic);
            this.groupStartIndicator.Location = new System.Drawing.Point(6, 117);
            this.groupStartIndicator.Name = "groupStartIndicator";
            this.groupStartIndicator.Size = new System.Drawing.Size(456, 100);
            this.groupStartIndicator.TabIndex = 4;
            this.groupStartIndicator.TabStop = false;
            this.groupStartIndicator.Text = "Start Indicator";
            // 
            // groupResult
            // 
            this.groupResult.Controls.Add(this.labelResult);
            this.groupResult.Controls.Add(this.buttonAbort);
            this.groupResult.Location = new System.Drawing.Point(6, 269);
            this.groupResult.Name = "groupResult";
            this.groupResult.Size = new System.Drawing.Size(456, 50);
            this.groupResult.TabIndex = 5;
            this.groupResult.TabStop = false;
            this.groupResult.Text = "Result";
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(330, 19);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(120, 23);
            this.buttonAbort.TabIndex = 0;
            this.buttonAbort.Text = "Abort!";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Visible = false;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // groupAccelerometerData
            // 
            this.groupAccelerometerData.Controls.Add(this.labelAccelerometerMax);
            this.groupAccelerometerData.Controls.Add(this.labelAccelerometerAverage);
            this.groupAccelerometerData.Controls.Add(this.label2);
            this.groupAccelerometerData.Controls.Add(this.label1);
            this.groupAccelerometerData.Location = new System.Drawing.Point(6, 223);
            this.groupAccelerometerData.Name = "groupAccelerometerData";
            this.groupAccelerometerData.Size = new System.Drawing.Size(456, 40);
            this.groupAccelerometerData.TabIndex = 6;
            this.groupAccelerometerData.TabStop = false;
            this.groupAccelerometerData.Text = "Accelerometer Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Average :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Maximum :";
            // 
            // labelAccelerometerAverage
            // 
            this.labelAccelerometerAverage.AutoSize = true;
            this.labelAccelerometerAverage.Location = new System.Drawing.Point(65, 16);
            this.labelAccelerometerAverage.Name = "labelAccelerometerAverage";
            this.labelAccelerometerAverage.Size = new System.Drawing.Size(13, 13);
            this.labelAccelerometerAverage.TabIndex = 1;
            this.labelAccelerometerAverage.Text = "0";
            // 
            // labelAccelerometerMax
            // 
            this.labelAccelerometerMax.AutoSize = true;
            this.labelAccelerometerMax.Location = new System.Drawing.Point(272, 16);
            this.labelAccelerometerMax.Name = "labelAccelerometerMax";
            this.labelAccelerometerMax.Size = new System.Drawing.Size(13, 13);
            this.labelAccelerometerMax.TabIndex = 1;
            this.labelAccelerometerMax.Text = "0";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(6, 24);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(72, 13);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "0 milliseconds";
            // 
            // checkSkipPrep
            // 
            this.checkSkipPrep.AutoSize = true;
            this.checkSkipPrep.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSkipPrep.Location = new System.Drawing.Point(200, 20);
            this.checkSkipPrep.Name = "checkSkipPrep";
            this.checkSkipPrep.Size = new System.Drawing.Size(124, 17);
            this.checkSkipPrep.TabIndex = 2;
            this.checkSkipPrep.Text = "Skip 10s Prep period";
            this.checkSkipPrep.UseVisualStyleBackColor = true;
            // 
            // FormTaskReactionTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 331);
            this.Controls.Add(this.groupAccelerometerData);
            this.Controls.Add(this.groupResult);
            this.Controls.Add(this.groupStartIndicator);
            this.Controls.Add(this.groupInstructions);
            this.Controls.Add(this.groupIndicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTaskReactionTimer";
            this.Text = "Reaction Timer";
            this.groupIndicator.ResumeLayout(false);
            this.groupIndicator.PerformLayout();
            this.groupInstructions.ResumeLayout(false);
            this.groupStartIndicator.ResumeLayout(false);
            this.groupResult.ResumeLayout(false);
            this.groupResult.PerformLayout();
            this.groupAccelerometerData.ResumeLayout(false);
            this.groupAccelerometerData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupIndicator;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RadioButton radioIndicatorFormula1;
        private System.Windows.Forms.RadioButton radioIndicatorBasic;
        private System.Windows.Forms.Panel panelBasic;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.GroupBox groupInstructions;
        private System.Windows.Forms.GroupBox groupStartIndicator;
        private System.Windows.Forms.GroupBox groupResult;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.GroupBox groupAccelerometerData;
        private System.Windows.Forms.Label labelAccelerometerMax;
        private System.Windows.Forms.Label labelAccelerometerAverage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.CheckBox checkSkipPrep;
    }
}