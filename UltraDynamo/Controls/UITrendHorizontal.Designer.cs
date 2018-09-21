namespace UltraDynamo.Controls
{
    partial class UITrendHorizontal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.SuspendLayout();
            // 
            // chartData
            // 
            chartArea2.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea2);
            this.chartData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartData.Legends.Add(legend2);
            this.chartData.Location = new System.Drawing.Point(0, 0);
            this.chartData.Name = "chartData";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartData.Series.Add(series2);
            this.chartData.Size = new System.Drawing.Size(309, 281);
            this.chartData.TabIndex = 0;
            this.chartData.Text = "chart1";
            // 
            // UITrendHorizontal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartData);
            this.Name = "UITrendHorizontal";
            this.Size = new System.Drawing.Size(309, 281);
            this.Load += new System.EventHandler(this.UITrendHorizontal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
    }
}
