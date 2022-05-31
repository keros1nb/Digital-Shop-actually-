using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace digitalshop
{
    public partial class Form1 : Form
    {
       Videocard[] videocards_list = new Videocard[13];
        


        public Form1()
        {
            InitializeComponent();
        }

        private void CardClick(object sender, EventArgs e)
        {
            Filter.CardClick(sender, e);             
        }



       

        private void Form1_Load(object sender, EventArgs e)
        {
            Filter.videocard_list.Clear();
            string[] line = System.IO.File.ReadAllLines("Videocards.txt");

            foreach (string str in line)
            {
                string[] parts = str.Split(new string[] { ", " }, StringSplitOptions.None);
               Videocards videocards = new Videocards(parts[0], Convert.ToInt32(parts[1]), parts[2], parts[3]);
                Filter.videocard_list.Add(videocards);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Filter filterForm = new Filter();
            filterForm.ShowDialog(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Favourite favourite = new Favourite();
            favourite.ShowDialog();
        }

        private void AddVideocard_Opening(object sender, CancelEventArgs e)
        {
            AddVideocardForm addVideocard = new AddVideocardForm();
            addVideocard.ShowDialog();
            Form1_Load(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FeedBack feedback = new FeedBack();
           feedback.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Auth.Login == "")
            {

                Auth auth = new Auth();
                auth.ShowDialog();
            }
            else
            {
                Auth.Login = "";
            }

            if (Auth.Login == "")
            {
                button8.Text = "Войти";
                label2.Text = "";
            }
            else
            {
                button8.Text = "Выйти";
                label2.Text = "Привет, пользователь " + Auth.Login;
            }



        }

        private void DelVideocardToolStripMenuItem_Click(object  sender, EventArgs e)
        {
            DelVideocard delvideocard = new DelVideocard();
            delvideocard.ShowDialog();
            Form1_Load(sender, e);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DelVideocard delvideocard = new DelVideocard();
            delvideocard.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddVideocardForm addVideocard = new AddVideocardForm();
            addVideocard.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
