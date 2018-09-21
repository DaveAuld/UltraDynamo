namespace UltraDynamo.DisplayForms
{
    partial class FormHorizontalTrend
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
            this.uiTrend = new UltraDynamo.Controls.UITrendHorizontal();
            this.SuspendLayout();
            // 
            // uiTrend
            // 
            this.uiTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTrend.Location = new System.Drawing.Point(0, 0);
            this.uiTrend.Name = "uiTrend";
            this.uiTrend.Size = new System.Drawing.Size(284, 261);
            this.uiTrend.TabIndex = 0;
            // 
            // FormHorizontalTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.uiTrend);
            this.Name = "FormHorizontalTrend";
            this.Text = "FormHorizontalTrend";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UITrendHorizontal uiTrend;
    }
}