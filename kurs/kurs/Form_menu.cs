using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    public partial class Form_menu : Form
    {
        public int max_number_of_horses = 10;

        public Form_menu()
        {
            InitializeComponent();

            for (int i = 2; i <= max_number_of_horses; i++)
                comboBox_number_horses.Items.Add(i);

            comboBox_number_horses.SelectedIndex = 0;

            _Form_menu = this;
        }

        public static Form_menu _Form_menu;

        //Нажатие кнопки "На ипподром"
        private void button_start_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(_Form_menu);
            f1.Show();
            this.Hide();
        }
    }
}
