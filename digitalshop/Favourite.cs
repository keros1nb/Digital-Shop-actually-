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
    public partial class Favourite : Form
    {


        // public static List<Videocards> favouriteVideocards = new List<Videocards>();
        public static Dictionary<Videocards, int> favouriteVideocards = new Dictionary<Videocards, int>();



        public static int totalPrice = 0;
        public static void Calculate()
        
        {
            totalPrice = 0;
            foreach(KeyValuePair<Videocards, int> Fav_Videocards in favouriteVideocards)
            {
                totalPrice += Fav_Videocards.Value * Fav_Videocards.Key.price;
            }
        }



        public Favourite()
        {
            InitializeComponent();
            Text = "Избранное";
            Draw();
        }

        void Draw()
        {
            Controls.Clear();
            Controls.Add(label1);

            Controls.Add(button1);



            int x = 10;
            int y = 20;

            foreach (KeyValuePair<Videocards, int> Fav_Videocards in favouriteVideocards)
            {
                Videocards videocard = Fav_Videocards.Key;
                //  Fav_Videocards.Value


                #region 1 столбец
                PictureBox picture = new PictureBox();
                picture.Location = new Point(x, y + AutoScrollPosition.Y);
                picture.Size = new Size(300, 200);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.Image = videocard.picture.Image;
                Controls.Add(picture);
                #endregion

                #region 2 столбец
                Label label1 = new Label();
                label1.Font = new Font("Times New Roman", 12);
                label1.Text = "Навзание: " + videocard.name;
                label1.Location = new Point(x + 310, y + 20 + AutoScrollPosition.Y);
                label1.Size = new Size(200, 40);
                Controls.Add(label1);

                Label label3 = new Label();
                label3.Font = new Font("Times New Roman", 12);
                label3.Text = "Модель: " + videocard.model;
                label3.Location = new Point(x + 310, y + 60 + AutoScrollPosition.Y);
                label3.Size = new Size(200, 40);
                Controls.Add(label3);
                #endregion

                #region 3 столбец
                Label label2 = new Label();
                label2.Font = new Font("Times New Roman", 12);
                label2.Text = "Стоимость(руб.) - " + videocard.price;
                label2.Location = new Point(x + 550, y + 20 + AutoScrollPosition.Y);
                label2.Size = new Size(200, 40);
                Controls.Add(label2);

                NumericUpDown numericUpDown1 = new NumericUpDown();
                numericUpDown1.Font = new Font("Times New Roman", 16);
                numericUpDown1.Location = new Point(x + 550, y + 60 + AutoScrollPosition.Y);
                numericUpDown1.Size = new Size(100, 40);
                numericUpDown1.Value = Fav_Videocards.Value;
                numericUpDown1.Click += new EventHandler(CountChanged);
                Controls.Add(numericUpDown1);


                Label label4 = new Label();
                label4.Font = new Font("Times New Roman", 12);
                label4.Text = "Кол-во:  " + Fav_Videocards.Value.ToString() + " шт.";
                label4.Location = new Point(x + 550, y + 100 + AutoScrollPosition.Y);
                label4.Size = new Size(200, 40);
                Controls.Add(label4);

                Label label5 = new Label();
                label5.Font = new Font("Times New Roman", 12);
                label5.Text = "Итого(руб.) :  " + (Fav_Videocards.Value * videocard.price).ToString() + " руб.";
                label5.Location = new Point(x + 550, y + 140 + AutoScrollPosition.Y);
                label5.Size = new Size(200, 40);
                Controls.Add(label5);
                #endregion

                #region 4 столбец 
                Button btn_del = new Button();
                btn_del.Font = new Font("Times New Roman", 12);
                btn_del.Text = "Удалить";
                btn_del.Location = new Point(x + 750, y + 20 + AutoScrollPosition.Y);
                btn_del.Size = new Size(100, 50);
                btn_del.Click += new EventHandler(Del);
                Controls.Add(btn_del);
                #endregion






                /*
                 videocard.btn.Location = new Point(x, y);
                 videocard.btn.Size = new Size(300, 40);
                 Controls.Add(videocard.btn);
                                                                */

                {
                    y = y + 220;

                }
            }


            Calculate();
            label1.Text = "Общая стоимость (руб.)  -  " + totalPrice.ToString();
        }

        void Del(object sender, EventArgs e)
        {
            int i = 0;
            Button b = new Button();
            b = (Button)sender;
            Dictionary<Videocards, int> favouriteVideocards1 = new Dictionary<Videocards, int>();
            foreach (KeyValuePair<Videocards, int> Fav_Videocards in favouriteVideocards)
            {
                if (b.Location == new Point(760, 40 + i * 220 + AutoScrollPosition.Y))
                { }
                else
                {
                    favouriteVideocards1[Fav_Videocards.Key] = Fav_Videocards.Value;
                }
                i++;
            }
            favouriteVideocards = favouriteVideocards1;
            Draw();
        }



        private void Favourite_Load(object sender, EventArgs e)
        {

        }

        private void CountChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;

            for (int i = 0; i < favouriteVideocards.Count; i++)
            {
                int price = 0;
                Image image = null;
                if (nud.Location == new Point(560, 80 + i * 220 + AutoScrollPosition.Y))
                {
                    foreach (Control ctrl in Controls)
                    {
                        if (ctrl is PictureBox && ctrl.Location == new Point(10, 20 + i * 220 + AutoScrollPosition.Y))
                        {
                            image = ((PictureBox)ctrl).Image;
                        }
                    }            
                    foreach(Videocards videocard in Filter.videocard_list)
                    {
                       if(videocard.picture.Image == image )
                        {
                            favouriteVideocards[videocard] = Convert.ToInt32(nud.Value);
                        }
                    }
                foreach (Control ctrl in Controls)
                {
                    if (ctrl is Label && ctrl.Location == new Point(560, 40 + i * 220 + AutoScrollPosition.Y))
                    {
                        price = Convert.ToInt32(ctrl.Text.Replace("Стоимость(руб.) - ", ""));
                    }
                }
                foreach (Control ctrl in Controls)
                {
                    if (ctrl is Label && ctrl.Location == new Point(560, 160 + i * 220 + AutoScrollPosition.Y))
                    {
                        ctrl.Text = "Итого(руб.) :  " + (price * nud.Value).ToString();
                    }
                }
            }
                Calculate();
                label1.Text = "Общая стоимость (руб.)  -  " + totalPrice.ToString();
        }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMail send = new SendMail();
            send.ShowDialog();
        }
    }
}
