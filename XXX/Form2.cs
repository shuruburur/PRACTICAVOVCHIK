using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XXX
{
    public partial class Form2 : Form
    {
        private const string correctUsername = "111";
        private const string correctPassword = "111";
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем введенные пользователем данные
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Проверка логина и пароля
            if (username == correctUsername && password == correctPassword)
            {
                MessageBox.Show("Вход выполнен успешно!");
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
              
            }
            else
            {
                MessageBox.Show ("Неправильный логин или пароль. Попробуйте снова.");
               
            }
        }
    }
}
        
    

