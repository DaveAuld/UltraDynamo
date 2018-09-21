namespace UltraDynamo
{
    partial class FormContentNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContentNotice));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkDisplayStartup = new System.Windows.Forms.CheckBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonReject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(438, 280);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // checkDisplayStartup
            // 
            this.checkDisplayStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkDisplayStartup.AutoSize = true;
            this.checkDisplayStartup.Location = new System.Drawing.Point(12, 326);
            this.checkDisplayStartup.Name = "checkDisplayStartup";
            this.checkDisplayStartup.Size = new System.Drawing.Size(117, 17);
            this.checkDisplayStartup.TabIndex = 1;
            this.checkDisplayStartup.Text = "Show On App Start";
            this.checkDisplayStartup.UseVisualStyleBackColor = true;
            this.checkDisplayStartup.CheckedChanged += new System.EventHandler(this.checkDisplayStartup_CheckedChanged);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.Location = new System.Drawing.Point(240, 298);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(210, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Accept && Continue";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonReject
            // 
            this.buttonReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReject.Location = new System.Drawing.Point(240, 326);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(210, 23);
            this.buttonReject.TabIndex = 2;
            this.buttonReject.Text = "Reject && Exit Application";
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // FormContentNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 355);
            this.ControlBox = false;
            this.Controls.Add(this.buttonReject);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.checkDisplayStartup);
            this.Controls.Add(this.textBox1);
            this.Name = "FormContentNotice";
            this.Text = "Content Notice";
            this.Load += new System.EventHandler(this.FormContentNotice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkDisplayStartup;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonReject;
    }
}