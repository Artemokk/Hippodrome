using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace kurs
{
    public partial class Form_chart : Form
    {
        int number_of_horses; //количество лошадей, учавствующих в гонке
        List<List<string>> list_formatting = new List<List<string>>(); //набор настроек элементов форматирования для каждой лошади

        Form1 fm1;

        public List<ComboBox> list_combobox = new List<ComboBox>(); //коллекция combobox-ов для типа линии
        public List<NumericUpDown> list_numericUpDOwn = new List<NumericUpDown>(); //коллекция numUpDown для толщины линий
        public List<Button> list_button = new List<Button>(); //коллекция кнопок цвета
        List<ChartDashStyle> list_type_line = new List<ChartDashStyle>() { ChartDashStyle.NotSet, ChartDashStyle.Solid, ChartDashStyle.Dash, ChartDashStyle.Dot }; //список типов линий

        public Form_chart(Form1 form1)
        {
            InitializeComponent();
            fm1 = form1;

            number_of_horses = fm1.number_of_horses;

            Chart(number_of_horses, fm1.list_stages, fm1.list_of_speeds_horses);

            //Если нажата кнопка "Загрузить пользовательские настройки"
            if (fm1.download_check)
            {
                list_formatting = fm1.list_formatting;
                Download_formatting();
            }
            else
                Restart();

                    

        }

        //Отрисовка графиков и генерация элементов управления
        private void Chart(int number_of_horses, List<int> list_stages, List<List<int>> list_of_speeds_horses)
        {
            chart1.Titles.Add("Диаграмма скоростей");
            chart1.ChartAreas[0].AxisX.Title = "Этап";
            chart1.ChartAreas[0].AxisY.Title = "Скорость";

            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;

            chart1.ChartAreas[0].AxisX.Interval = 3;
            chart1.ChartAreas[0].AxisY.Interval = 2;

            int y_start_location = 52;
            int y_location = y_start_location;

            string[] type_line = new string[] { "Без линии", "Сплошная", "Пунктирная", "Точечная" };

            for (int i = 0; i < number_of_horses; i++)
            {
                string name_horse = $"Лошадь {i+1}";

                chart1.Series.Add($"Series{i}");
                chart1.Series[$"Series{i}"].LegendText = name_horse;
                chart1.Series[$"Series{i}"].ChartType = SeriesChartType.Spline;
                chart1.Series[$"Series{i}"].MarkerStyle = MarkerStyle.Circle;

                chart1.Series[i].Points.DataBindXY(list_stages, list_of_speeds_horses[i]);

                Label label_name_horse = new Label();
                ComboBox comboBox_type_line = new ComboBox();
                NumericUpDown numericUp_width = new NumericUpDown();
                Button button_color = new Button();

                
                //размещение и настройка элементов управления
                int x_location = 23;
                label_name_horse.Location = new Point(x_location, y_location);

                label_name_horse.Text = name_horse;
                label_name_horse.Size = new Size(70, 17);

                comboBox_type_line.Size = new Size(108, 24);

                x_location = label_type_line.Location.X;
                comboBox_type_line.Location = new Point(x_location, y_location);

                comboBox_type_line.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox_type_line.Items.AddRange(type_line);
                comboBox_type_line.Tag = i;
                comboBox_type_line.SelectedIndexChanged += new EventHandler(comboBox_type_lineSelectedIndexChanged);

                x_location = label_width_line.Location.X;
                numericUp_width.Location = new Point(x_location, y_location);

                numericUp_width.Size = new Size(48, 22);
                numericUp_width.Tag = i;
                numericUp_width.ValueChanged += new EventHandler(numericUpDown_ValueChanged);

                x_location = label_width_line.Location.X + 85;
                button_color.Location = new Point(x_location, y_location);

                button_color.Text = "Цвет";
                button_color.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
                button_color.BackColor = chart1.Series[$"Series{i}"].Color;
                button_color.ForeColor = Color.White;
                button_color.Size = new Size(73, 24);
                button_color.Tag = i;
                button_color.Click += new EventHandler(btn_color_Click);

                y_location = y_start_location * (i + 2);

                tabPage2.Controls.Add(label_name_horse);
                tabPage2.Controls.Add(comboBox_type_line);
                tabPage2.Controls.Add(numericUp_width);
                tabPage2.Controls.Add(button_color);

                list_combobox.Add(comboBox_type_line);
                list_numericUpDOwn.Add(numericUp_width);
                list_button.Add(button_color);


            }

        }

        private void Form_chart_FormClosing(object sender, FormClosingEventArgs e)
        {
            chart1.Series.Clear();
        }

        //нажатие на кнопку "Цвет"
        private void btn_color_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            //меняем цвет линий и кнопок
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                chart1.Series[$"Series{clickedButton.Tag}"].Color = colorDialog1.Color;
                clickedButton.BackColor = chart1.Series[$"Series{clickedButton.Tag}"].Color;
            }
        }

        //метод, срабатывающий при изменении значения комбобокса типов линий
        private void comboBox_type_lineSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            int select_ind = comboBox.SelectedIndex;

            chart1.Series[$"Series{comboBox.Tag}"].BorderDashStyle = list_type_line[select_ind];
        }

        //метод, срабатывающий при изменении значения ширины линии
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown upDown = (NumericUpDown)sender;
            
            chart1.Series[$"Series{upDown.Tag}"].BorderWidth = (int)upDown.Value;
        }

        //метод, возвращающий настройки по умолчанию
        private void Restart()
        {
            for (int i=0; i<number_of_horses;i++)
            {
                list_combobox[i].SelectedIndex = 1;
                list_numericUpDOwn[i].Value = 1;
                chart1.Series[$"Series{i}"].Color = default;
                list_button[i].BackColor = default;
            }
        }

        //метод, преобразующий текстовые данные форматирования - в настоящие 
        private void Download_formatting()
        {
            for (int i = 0; i < number_of_horses; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 2)
                    {
                        Color color = ColorTranslator.FromHtml(list_formatting[i][j]);

                        chart1.Series[$"Series{i}"].Color = color;
                        list_button[i].BackColor = color;
                    }
                    else
                    {
                        int value = int.Parse(list_formatting[i][j]);

                        if (j == 0)
                            list_combobox[i].SelectedIndex = value;
                        else
                            list_numericUpDOwn[i].Value = value;
                    }
                }
            }
        }

        //нажатие кнопки "Сбросить"
        private void button_restart_Click(object sender, EventArgs e)
        {
            Restart();
            fm1.download_check = false;
        }

        private void Form_chart_Load(object sender, EventArgs e)
        {
            tabControl1.Height = 600;
        }

    }
}
