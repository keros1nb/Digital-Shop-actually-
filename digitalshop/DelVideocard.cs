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
    public partial class DelVideocard : Form
    {
        public DelVideocard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DelVideocard_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Filter.videocard_list.Count; i++)
            {
                comboBox1.Items.Add(Filter.videocard_list[i].name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete("Видеокарты.txt");
            for (int i = 0; i < Filter.videocard_list.Count; i++)
            {
                if (textBox1.Text == Filter.videocard_list[i].name)
                { }
                else
                {
                    System.IO.File.AppendAllText("Videocards.txt",
                                                Filter.videocard_list[i].name + ", " +
                                                Filter.videocard_list[i].price + ", " +
                                                Filter.videocard_list[i].model + ", " +
                                                Filter.videocard_list[i].website + ", " +
                                                 Environment.NewLine);
                }           
               
            }
            MessageBox.Show("Удаление прошло успешно.");
            Close();
        }
    }
}
