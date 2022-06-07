
namespace kurs
{
    partial class Form_chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_restart = new System.Windows.Forms.Button();
            this.label_width_line = new System.Windows.Forms.Label();
            this.label_type_line = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 5);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(788, 562);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 596);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(794, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "График";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_restart);
            this.tabPage2.Controls.Add(this.label_width_line);
            this.tabPage2.Controls.Add(this.label_type_line);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(794, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Форматирование";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_restart
            // 
            this.button_restart.Location = new System.Drawing.Point(444, 13);
            this.button_restart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(94, 36);
            this.button_restart.TabIndex = 11;
            this.button_restart.Text = "Сбросить";
            this.button_restart.UseVisualStyleBackColor = true;
            this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
            // 
            // label_width_line
            // 
            this.label_width_line.AutoSize = true;
            this.label_width_line.Location = new System.Drawing.Point(243, 13);
            this.label_width_line.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_width_line.Name = "label_width_line";
            this.label_width_line.Size = new System.Drawing.Size(49, 13);
            this.label_width_line.TabIndex = 1;
            this.label_width_line.Text = "Ширина:";
            // 
            // label_type_line
            // 
            this.label_type_line.AutoSize = true;
            this.label_type_line.Location = new System.Drawing.Point(97, 13);
            this.label_type_line.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_type_line.Name = "label_type_line";
            this.label_type_line.Size = new System.Drawing.Size(62, 13);
            this.label_type_line.TabIndex = 0;
            this.label_type_line.Text = "Тип линии:";
            // 
            // Form_chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 675);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_chart";
            this.Text = "График";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_chart_FormClosing);
            this.Load += new System.EventHandler(this.Form_chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label_width_line;
        private System.Windows.Forms.Label label_type_line;
        public System.Windows.Forms.Button button_restart;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}