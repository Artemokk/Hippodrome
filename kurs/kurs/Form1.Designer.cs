
namespace kurs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_record = new System.Windows.Forms.ComboBox();
            this.button_pause = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_select_horse = new System.Windows.Forms.ComboBox();
            this.button_chart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_result = new System.Windows.Forms.RichTextBox();
            this.button_main_menu = new System.Windows.Forms.Button();
            this.label_result = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox_record);
            this.panel1.Controls.Add(this.button_pause);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox_select_horse);
            this.panel1.Controls.Add(this.button_chart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.richTextBox_result);
            this.panel1.Controls.Add(this.button_main_menu);
            this.panel1.Controls.Add(this.label_result);
            this.panel1.Controls.Add(this.button_start);
            this.panel1.Location = new System.Drawing.Point(44, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 146);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(630, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "История игр:";
            // 
            // comboBox_record
            // 
            this.comboBox_record.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_record.FormattingEnabled = true;
            this.comboBox_record.Items.AddRange(new object[] {
            "Перезаписать",
            "Записать"});
            this.comboBox_record.Location = new System.Drawing.Point(633, 22);
            this.comboBox_record.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_record.Name = "comboBox_record";
            this.comboBox_record.Size = new System.Drawing.Size(104, 21);
            this.comboBox_record.TabIndex = 20;
            this.comboBox_record.SelectedIndexChanged += new System.EventHandler(this.comboBox_record_SelectedIndexChanged);
            // 
            // button_pause
            // 
            this.button_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_pause.Location = new System.Drawing.Point(169, 61);
            this.button_pause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(90, 27);
            this.button_pause.TabIndex = 19;
            this.button_pause.Text = "Пауза";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Visible = false;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Выберите лошадь:";
            // 
            // comboBox_select_horse
            // 
            this.comboBox_select_horse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_select_horse.FormattingEnabled = true;
            this.comboBox_select_horse.Location = new System.Drawing.Point(18, 52);
            this.comboBox_select_horse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_select_horse.Name = "comboBox_select_horse";
            this.comboBox_select_horse.Size = new System.Drawing.Size(102, 21);
            this.comboBox_select_horse.TabIndex = 16;
            this.comboBox_select_horse.SelectedIndexChanged += new System.EventHandler(this.comboBox_select_horse_SelectedIndexChanged);
            // 
            // button_chart
            // 
            this.button_chart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_chart.Location = new System.Drawing.Point(169, 92);
            this.button_chart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_chart.Name = "button_chart";
            this.button_chart.Size = new System.Drawing.Size(90, 27);
            this.button_chart.TabIndex = 17;
            this.button_chart.Text = "График";
            this.button_chart.UseVisualStyleBackColor = true;
            this.button_chart.Click += new System.EventHandler(this.button_chart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(304, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Результаты гонки:";
            // 
            // richTextBox_result
            // 
            this.richTextBox_result.CausesValidation = false;
            this.richTextBox_result.EnableAutoDragDrop = true;
            this.richTextBox_result.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.richTextBox_result.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox_result.Location = new System.Drawing.Point(307, 21);
            this.richTextBox_result.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox_result.Name = "richTextBox_result";
            this.richTextBox_result.ReadOnly = true;
            this.richTextBox_result.Size = new System.Drawing.Size(269, 119);
            this.richTextBox_result.TabIndex = 15;
            this.richTextBox_result.Text = "";
            this.richTextBox_result.Visible = false;
            // 
            // button_main_menu
            // 
            this.button_main_menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_main_menu.Location = new System.Drawing.Point(760, 7);
            this.button_main_menu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_main_menu.Name = "button_main_menu";
            this.button_main_menu.Size = new System.Drawing.Size(126, 24);
            this.button_main_menu.TabIndex = 15;
            this.button_main_menu.Text = "Вернуться в меню";
            this.button_main_menu.UseVisualStyleBackColor = true;
            this.button_main_menu.Click += new System.EventHandler(this.button_main_menu_Click);
            // 
            // label_result
            // 
            this.label_result.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_result.Location = new System.Drawing.Point(607, 63);
            this.label_result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(253, 64);
            this.label_result.TabIndex = 12;
            this.label_result.Text = "Ждем результата гонки";
            this.label_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_start
            // 
            this.button_start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(169, 28);
            this.button_start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(90, 27);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "Старт";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(980, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File_ToolStripMenuItem
            // 
            this.File_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.downloadToolStripMenuItem});
            this.File_ToolStripMenuItem.Name = "File_ToolStripMenuItem";
            this.File_ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.File_ToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem.Text = "Сохранить настройки";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.downloadToolStripMenuItem.Text = "Загрузить настройки";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 368);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Ипподром";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.Button button_main_menu;
        private System.Windows.Forms.RichTextBox richTextBox_result;
        private System.Windows.Forms.ComboBox comboBox_select_horse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_chart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.ComboBox comboBox_record;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
    }
}

