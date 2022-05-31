using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace digitalshop
{
    public partial class VideocardForm : Form
    {
        Videocards videocard;

        public VideocardForm(Videocards _videocard)
        {
            InitializeComponent();
            videocard = _videocard;
            Text = videocard.name;
            try
            {
                textBox1.Text = videocard.name + Environment.NewLine + "" + File.ReadAllText("../../Pictures/Видеокарты/" + videocard.name + ".txt");
            }
            catch (Exception) { }
            try
            {

                pictureBox1.Load("../../Pictures/Видеокарты/" + videocard.name + ".jpg");
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Favourite.favouriteVideocards.ContainsKey(videocard))
            {
                Favourite.favouriteVideocards[videocard]++;
            }
            else
            Favourite.favouriteVideocards.Add(videocard, 1);
        }

        private void VideocardForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(videocard.website);
        }
    }
}
