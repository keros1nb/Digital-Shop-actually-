using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace digitalshop
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Невведен логин или пароли не совпадают.");
            }
            else
            {
                System.IO.File.AppendAllText("Users.txt", textBox1.Text + ", " + textBox2.Text +
                                                        Environment.NewLine);
                Close();
            }

           
        }
    }
}
