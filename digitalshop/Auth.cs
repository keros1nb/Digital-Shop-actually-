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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Auth_Load(object sender, EventArgs e)
        { 
        
        }
            public static string Login = "";
    
        private void button1_Click(object sender, EventArgs e)
        {
            string[] line = System.IO.File.ReadAllLines("Users.txt");

            foreach (string str in line)
            {
                
                string[] parts = str.Split(new string[] { ", " }, StringSplitOptions.None);
                if (textBox1.Text == parts[0] && textBox2.Text == parts[1])
                {
                    Login = textBox1.Text;
                    Close();
                    return;
                }
            }
            MessageBox.Show("Веден неверный логин или пароль");
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register RegForm = new Register();
            RegForm.ShowDialog();
        }
    } 
}
