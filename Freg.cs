using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flowers_Ermoshina
{
    public partial class Freg : Form
    {
        public Freg()
        {
            InitializeComponent();
        }

        private void cb_woker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_woker.SelectedIndex == 0)
            {
                if (textBox1.Text == "123")
                {
                    woker f = new woker();
                    f.Text = "Добро пожаловать Сотрудник!";
                    f.ShowDialog();
                }
                else MessageBox.Show("Для пользователя " + cb_woker.Text + " пароль неверный!");
            }

            if (cb_woker.SelectedIndex == 1)
            {
                if (textBox1.Text == "222")
                {
                    director f = new director();
                    f.Text = "Добро пожаловать Директор!";
                    f.ShowDialog();
                }
                else MessageBox.Show("Для пользователя " + cb_woker.Text + " пароль неверный!");
            }

        }
    }
}
