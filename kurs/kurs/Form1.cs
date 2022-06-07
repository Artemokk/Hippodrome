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

namespace kurs
{
    public partial class Form1 : Form
    {
        public int number_of_horses; //количество лошадей, учавствующих в гонке
        int max_number_of_horses; //макимально возможное количество лошадей
        public int ind_selected_horse; //выбранная лошадь
        int ind_previous_horse; //индекс предыдущей выбр. лошади (для возвращения дефолтной картинки дорожки)
        int number_of_finishers; //счетчик лошадей пришедших к финишу

        int number_of_stages; //количество этапов
        public List<int> list_stages = new List<int>(); //список этапов (для графика)


        int finish_line = 640; //число пикселей до финиша

        List<PictureBox> list_pictureBoxes = new List<PictureBox>(); //коллекция picturebox-ов лошадей
        List<Panel> list_road = new List<Panel>(); //коллекция дорожек

        List<double> list_average_speed = new List<double>(); //список средней скорости каждой лошади
        public List<List<int>> list_of_speeds_horses = new List<List<int>>(); //двумерный список скоростей каждой лошади на каждом этапе

        int place_select_horse; //место выбранной лошади
        int index_win_horse; //индекс лошади-победителя

        List<FileMode> list_filemode = new List<FileMode>() { FileMode.Create, FileMode.Append };//список способов открытия файла
        public int ind_select_filemode;//индекс выбранной лошади

        Random rnd = new Random();

        public Form1(Form_menu form_menu)
        {
            InitializeComponent();
            this.form_menu = form_menu;

            
            number_of_horses = Convert.ToInt32(form_menu.comboBox_number_horses.Text);
            max_number_of_horses = form_menu.max_number_of_horses;
        }

        Form_menu form_menu; //форма меню
        public static Form1 _Form1;
        public Form_chart form_chart; //форма с графиком

        //нажатие на кнопку "Старт"
        private void button_start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
            Start_position();
            Close_chartForm();

            File_ToolStripMenuItem.Enabled = false;
            button_pause.Visible = true;
            button_start.Enabled = false;
            comboBox_select_horse.Enabled = false;
            comboBox_record.Enabled = false;
        }

        //метод, срабатывающий при каждом тике таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            int stage_speed; //скорость на этапе 

            double average_speed; //средняя скорость

            number_of_stages += 1; //увеличиваем количество этапов
            list_stages.Add(number_of_stages); //добавляем номер этапа в список (для графика)

            for (int i = 0; i < number_of_horses; i++)
            {
                //передвижение лошадей и запись скорости каждой лошади на каждом этапе в списки
                stage_speed = rnd.Next(5, 20);
                list_pictureBoxes[i].Left += stage_speed;
                list_of_speeds_horses[i].Add(stage_speed);
                

                //блок, срабатывающий когда лошадь финиширует
                if ((list_pictureBoxes[i].Left > finish_line) && ((int)list_pictureBoxes[i].Tag == 0))
                {
                    number_of_finishers += 1; //увелииваем число финиширующих лошадей
                    list_pictureBoxes[i].Tag = number_of_finishers;
                    average_speed = (double)list_pictureBoxes[i].Left / (double)number_of_stages; //определяем среднюю скорость лошади
                    list_average_speed[i] = average_speed; //добавляем среднюю скорость в список
                }

            }


            //блок, срабаатывающий после того, как все лошади пересекут финишную черту
            if (number_of_finishers == number_of_horses)
            {
                timer1.Enabled = false;
                richTextBox_result.Visible = true;
                button_pause.Visible = false;
                File_ToolStripMenuItem.Enabled = true;
                //блок, который определяет место лошади в гонке
                for (int i = 0; i < number_of_horses; i++)
                {
                    //индекс максимального элемента в списке средних скоростей
                    int index_max_speed = list_average_speed.IndexOf(list_average_speed.Max());

                    //переменные для вывода лошади и места
                    int horse = index_max_speed + 1;
                    int place = i + 1;

                    //вывод результата гонки
                    richTextBox_result.Text += horse + "-я лошадь - " + place + " место - V(ср) = " + Math.Round(list_average_speed.Max(), 4) + "\n";

                    if (index_max_speed == ind_selected_horse)
                        place_select_horse = place;
                    
                    //сохраняем индекс лошади с максимальной скоростью
                    if (i == 0)
                        index_win_horse = index_max_speed;

                    list_average_speed[index_max_speed] = 0; //обнуление максимального элемента в списке средних скоростей
                }


                //блок, определяющий нашу победу или поражение в ставке
                if (ind_selected_horse == index_win_horse)
                    Win();
                else
                    Loose();

                //вызываем метод, записывающий историю матча
                Record_game();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _Form1 = this;

            //вызываем метод отрисовки ипподрома
            Load_arena(number_of_horses);

            comboBox_select_horse.SelectedIndex = 0;
            comboBox_record.SelectedIndex = 0;


            ind_select_filemode = comboBox_record.SelectedIndex;

            form_chart = new Form_chart(_Form1);
        }


        //метод, который приводит ипподром в исходное состояние
        public void Start_position()
        {

            number_of_finishers = 0; //обнуление числа финиширующих лошадей
            number_of_stages = 0; //обнуление количества этапов

            //обнуление и возвращение начальных значений списка мест и средней скорости
            for (int i = 0; i < number_of_horses; i++)
            {
                //возвращаем лошадей на исходные позиции
                list_pictureBoxes[i].Location = new Point(0, 0);
                list_pictureBoxes[i].Tag = 0;
                list_average_speed[i] = 0;
                list_of_speeds_horses[i].Clear();
            }

            list_stages.Clear();

            //обнуление табла результатов
            richTextBox_result.Text = "";

            label_result.Text = "Ждем результата гонки";
            label_result.ForeColor = Color.Black;

        }

        //метод генерирующий арену ипподрома в зависимости от выбранного количества лошадей
        public void Load_arena(int number_of_horses)
        {
            //размер дорожки
            int width_road = 974;
            int height_road = 65;

            //размер картинки лошади
            int width_horse = 115;
            int heigh_horse = 60;

            //настройка формы
            int heigh_form = panel1.Height + height_road * max_number_of_horses + 30;
            ClientSize = new Size(1000, heigh_form);

            //координаты дорожек относительно формы
            int x_road = (this.Width - width_road) / 2;
            int y_road = panel1.Height + (this.Height - panel1.Height) / number_of_horses - height_road;

            for (int i = 0; i < number_of_horses; i++)
            {
                //заполняем комбобокс числом лошадей
                comboBox_select_horse.Items.Add(i + 1);

                //создаем элементы управления
                PictureBox pic_horse = new PictureBox();
                Panel panel_road = new Panel();

                //устанавливаем размеры
                pic_horse.Size = new Size(width_horse, heigh_horse);
                panel_road.Size = new Size(width_road, height_road);

                //загружаем картинки лошадей и дорожек
                pic_horse.Load("..\\picture\\horse" + i + ".png");
                panel_road.BackgroundImage = new Bitmap("..\\picture\\road_defolt.png");
                panel_road.Anchor = AnchorStyles.Top;

                //указываем способ отображения 
                panel_road.BackgroundImageLayout = ImageLayout.Center;
                pic_horse.SizeMode = PictureBoxSizeMode.Zoom;


                Controls.Add(panel_road);
                panel_road.Controls.Add(pic_horse); //устанавливаем родительский элемент (дорожка) для картинок лошадей

                pic_horse.BackColor = Color.Transparent;

                //картинки лошадей на передний план
                pic_horse.BringToFront();

                //устанавливаем расположение дорожек
                panel_road.Location = new Point(x_road, y_road);
                y_road = panel1.Height + (this.Height - panel1.Height) / number_of_horses + (i * height_road);

                //добавляем картинку лошади в коллекцию
                list_pictureBoxes.Add(pic_horse);
                list_road.Add(panel_road);
                list_average_speed.Add(0);
                list_of_speeds_horses.Add(new List<int>());
            }
        }

        //метод, срабатывающий в случае, если наша ставка была верной
        public void Win()
        {
            label_result.Text = "Ваша лошадь победила!";
            label_result.ForeColor = Color.Green;
            button_start.Enabled = true;
            comboBox_select_horse.Enabled = true;
            comboBox_record.Enabled = true;

        }

        //метод, срабатывающий в случае, если наша ставка прогорела
        public void Loose()
        {
            label_result.ForeColor = Color.Red;
            label_result.Text = "Ваша лошадь заняла:\n" + place_select_horse + " место";
            button_start.Enabled = true;
            comboBox_select_horse.Enabled = true;
            comboBox_record.Enabled = true;

        }

        //возврат в главное меню по кнопке "Вернуться в меню" или при закрытии окна ипподрома
        private void button_main_menu_Click(object sender, EventArgs e)
        {
            //закрытие графика
            Close_chartForm();

            Form menu = Application.OpenForms[0];
            this.Close();
            menu.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //закрытие графика
            Close_chartForm();

            Form menu = Application.OpenForms[0];
            menu.Show();
        }

        //"Подсвечивание" выбранной дорожки, при выборе лошади
        private void comboBox_select_horse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ind_selected_horse = comboBox_select_horse.SelectedIndex; //выбранная лошадь
                //возвращаем картинку по умолчанию для предыдущей выбранной лошади
                list_road[ind_previous_horse].BackgroundImage = new Bitmap("..\\picture\\road_defolt.png"); 
                //загружаем "подсвеченную" дорожку для выбранной лошади
                list_road[ind_selected_horse].BackgroundImage = new Bitmap("..\\picture\\road_select.png");
                //запоминаем индекс измененной дорожки
                ind_previous_horse = ind_selected_horse;
            }
            catch 
            {
                list_road[ind_selected_horse].BackgroundImage = new Bitmap("..\\picture\\road_select.png");
                ind_previous_horse = ind_selected_horse; 
            }
        }

        //нажатие на кнопку "График"
        private void button_chart_Click(object sender, EventArgs e)
        {

            Form fc = Application.OpenForms["Form_chart"];

            //проверяем - открыта ли форма с графиком
            if (fc == null)
            {
                form_chart = new Form_chart(_Form1);
                form_chart.Show();
            }
            else
            {
                fc.Refresh();
                fc.Show();
                fc.BringToFront();
            }
        }

        //нажатие на кнопку "Пауза"
        private void button_pause_Click(object sender, EventArgs e)
        {
            bool check = timer1.Enabled;

            //проверяем - включен ли таймер
            if (check)
                button_pause.Text = "Продолжить";
            else
            {
                Close_chartForm();
                button_pause.Text = "Пауза";
            }

            timer1.Enabled = !check;
        }

        //метод, записывающий историю игр
        public void Record_game()
        {
            string text = $"Игра: {DateTime.Now}" +
                $"\nКоличество лошадей: {number_of_horses}" +
                $"\nВыбранная лошадь: {ind_selected_horse + 1}" +
                $"\nРезультат: {place_select_horse} место" +
                "\nИтоги гонки:\n" +
                $"{richTextBox_result.Text}\n\n";

            //в зависимости от выбора пользователя выполняется "Запись" или "Перезапись" файла
            try
            {
                using (FileStream filestream = new FileStream("Record.txt", list_filemode[ind_select_filemode]))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    filestream.Write(array, 0, array.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        public List<int> list_location_settings = new List<int>(); //список расположения настроек в файле (для произвольного доступа)
        string text_save_settings; //сохраненные настройки
            
        //нажатие кнопки "Сохранить пользовательские настройки"
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                list_location_settings.Clear();
                text_save_settings = "";
                
                //вызываем метод, преобразующий входные данные к строковому формату и запоминающий их расположение в файле
                Record_text_settings(number_of_horses, ind_selected_horse, ind_select_filemode);
                int type_line;
                int width;
                string color_line;

                Form fc = Application.OpenForms["Form_chart"];

                if (fc == null)
                    form_chart = new Form_chart(_Form1);

                //получаем данные из элементов форматирования графика
                for (int i = 0; i < number_of_horses; i++)
                {
                    type_line = form_chart.list_combobox[i].SelectedIndex;
                    width = (int)form_chart.list_numericUpDOwn[i].Value;
                    color_line = ColorTranslator.ToHtml(form_chart.chart1.Series[$"Series{i}"].Color);

                    Record_text_settings(type_line, width, color_line);
                }

                //Записываем полученные настройки в файл 
                using (FileStream filestream = new FileStream("Settings.txt", FileMode.Create))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text_save_settings);
                    filestream.Write(array, 0, array.Length);

                }


                string text = "";

                //преобразуем информацию о расположении настроек в файле к строковому виду
                foreach (int el in list_location_settings)
                {
                    text += $"{el};";
                }

                //записываем расположения в отдельный файл
                using (FileStream filestream = new FileStream("Location_for_settings.txt", FileMode.Create))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    filestream.Write(array, 0, array.Length);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        //метод, преобразующий входные данные к строковому формату и запоминающий их расположение в файле
        private void Record_text_settings(params object[] value)
        {
            foreach (var item in value)
            {
                text_save_settings += $"{item}";
                list_location_settings.Add(text_save_settings.Length);
            }
        }

        //метод, закрывающий форму с графиком
        private void Close_chartForm()
        {
            Form fc = Application.OpenForms["Form_chart"];

            if (fc != null)
                fc.Close();
        }

        public List<List<string>> list_formatting; //набор настроек элементов форматирования для каждой лошади

        public bool download_check = false; //индикатор нажатия кнопки "Загрузить пользовательские настройки"

        //нажатие кнопки "Загрузить пользовательские настройки"
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text;

                //открываем "Маршрутную карту" с данными о расположении настроек в файле
                using (FileStream fstream = File.OpenRead("Location_for_settings.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    text = System.Text.Encoding.Default.GetString(array);
                }

                string[] splited = text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                list_location_settings.Clear();

                //записываем данные о расположении в список
                for (int i = 0; i < splited.Length; i++)
                {
                    list_location_settings.Add(int.Parse(splited[i]));
                }

                list_formatting = new List<List<string>>();

                //открываем для чтения файл с пользовательскими настройками
                using (FileStream fstream = File.OpenRead("Settings.txt"))
                {

                    number_of_horses = int.Parse(Get_setting(fstream, list_location_settings[0], 0));

                    int j = 0; //счетчик элементов форматирования

                    List<string> list_for_one_horse = new List<string>(); //набор настроек для одной лошади

                    for (int i = 1; i < list_location_settings.Count; i++)
                    {
                        //длина настройки
                        int length = list_location_settings[i] - list_location_settings[i-1];
                        //число символов от начала файла
                        int location_from_start = list_location_settings[i-1];

                        //вызываем метод, который находит настройку в файле
                        string text_settings = Get_setting(fstream, length, location_from_start);

                        //распределяем полученные настройки
                        if (i == 1)
                            ind_selected_horse = int.Parse(text_settings);
                        else if (i == 2)
                            ind_select_filemode = int.Parse(text_settings);
                        else
                        {
                            list_for_one_horse.Add(text_settings);
                            j++;

                            //ограничение числа элементов форматирования для каждой лошади
                            if (j == 3)
                            {
                                list_formatting.Add(list_for_one_horse);
                                list_for_one_horse = new List<string>();
                                j = 0;
                            }
                        }
                    }
                }

                
                download_check = true;

                //очищаем форму
                foreach(Panel road in list_road)
                {
                    road.Controls.Clear();
                    Controls.Remove(road);
                }

                list_pictureBoxes.Clear();
                list_road.Clear();
                comboBox_select_horse.Items.Clear();

                //генерируем загруженный ипподром
                Load_arena(number_of_horses);

                //передаем элементам формы полученные настройки
                form_menu.comboBox_number_horses.SelectedIndex = number_of_horses - 2;
                comboBox_select_horse.SelectedIndex = ind_selected_horse;
                comboBox_record.SelectedIndex = ind_select_filemode;

                Start_position();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }

        }

        //метод, который отыскивает настройки в файле произвольного доступа
        private string Get_setting (FileStream fstream, int length, int location_from_start)
        {
            //перемещение указателя
            fstream.Seek(location_from_start, SeekOrigin.Begin);

            byte[] array = new byte[length];
            fstream.Read(array, 0, array.Length);

            return System.Text.Encoding.Default.GetString(array);

        }

        //выбор способа записи истории игр
        private void comboBox_record_SelectedIndexChanged(object sender, EventArgs e)
        {
            ind_select_filemode = comboBox_record.SelectedIndex;
        }
    }
}
