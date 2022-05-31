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
    public partial class AddVideocardForm : Form
    {
        public AddVideocardForm()
        {
            InitializeComponent();
        }

        private void AddVideocardForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.File.AppendAllText("Videocards.txt",
                Environment.NewLine +
                NameTB.Text + ", " +
                PriceTB.Text + ", " +
                ModelTB.Text + ", ");

                if (fileName != "")
                System.IO.File.Copy(fileName, "../../Pictures/Видеокарты/" + NameTB.Text + ".jpg");
            System.IO.File.AppendAllText("../../Pictures/Видеокарты/" + NameTB.Text + ".txt", 


            Environment.NewLine + textBox1.Text);

            MessageBox.Show("Сохранено");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                pictureBox1.Load(fileName);
            }
        }

        string fileName = "";
       



    }
}


