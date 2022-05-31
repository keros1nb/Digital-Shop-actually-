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
    public struct Videocards
    {
        public string name;
        public int price;
        public string model;
        public string website;
        public Button btn;
        public PictureBox picture;

        public Videocards(string _name, int _price, string _model, string _website)
        {
            name = _name;
            price = _price;
            model = _model;
            website = _website;
            btn = new Button();
            picture = new PictureBox();


            btn.Font = new Font("Times New Roman", 13.2F, FontStyle.Italic);
            btn.Text = name;

            picture.SizeMode = PictureBoxSizeMode.Zoom;
            try 
            { 
                picture.Load("../../Pictures/Видеокарты/" + name + ".jpg");
            }
            catch (Exception) { }
        }
    }



    public partial class Filter : Form
    {
        public static List<Videocards> videocard_list = new List<Videocards>();


        public Filter()
        {
            InitializeComponent();

          

            int x = 10;
            int y = 150;
            
            for (int i = 0; i < videocard_list.Count; i++)
            {
                videocard_list[i].btn.Location = new Point(x, y);
                videocard_list[i].btn.Size = new Size(300, 40);
                videocard_list[i].btn.Click += new EventHandler(CardClick);
                Controls.Add(videocard_list[i].btn);

                videocard_list[i].picture.Location = new Point(x, y+40);
                videocard_list[i].picture.Size = new Size(300, 200);
                Controls.Add(videocard_list[i].picture);

                x = x + 310;
                if(x + 310 > Width)
                {
                    y = y + 250;
                    x = 10;
                }

            }





        }

        public static void CardClick(object sender, EventArgs e)
        {
            for (int i = 0; i < videocard_list.Count; i++)
            {
                if (((Button)sender).Text == videocard_list[i].btn.Text)
                {
                    VideocardForm videocard = new VideocardForm(videocard_list[i]);
                    videocard.ShowDialog();
                }
            }
        }
        private void FilterButton_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 150;

            for (int i = 0; i < videocard_list.Count; i++)
            {
                
                

                videocard_list[i].btn.Visible = true;
                videocard_list[i].picture.Visible = true;

                if (ModelComboBox.Text != "" &&
                    videocard_list[i].model != ModelComboBox.Text)

                {
                    videocard_list[i].btn.Visible = false;
                    videocard_list[i].picture.Visible = false;
                }

                if (PriceTextBox.Text != "" &&
                    videocard_list[i].price > Convert.ToInt32(PriceTextBox.Text))

                {
                    videocard_list[i].btn.Visible = false;
                    videocard_list[i].picture.Visible = false;
                }

                if (videocard_list[i].btn.Visible  )
                {
                    videocard_list[i].btn.Location = new Point(x, y);
                    videocard_list[i].picture.Location = new Point(x, y + 40);

                    x = x + 310;    
                    if (x + 310 > Width)
                    {
                        y = y + 250;
                        x = 10;
                    }
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Favourite favourite = new Favourite();
            favourite.ShowDialog();
        }

        private void Filter_Load(object sender, EventArgs e)
        {

        }
    }
}
