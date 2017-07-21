using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardShuffleGame
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateButton();
        }

        private void CreateButton()
        {
            int fatherCard = rand.Next(0, 5);


            for (int i = 0; i < 5; i++)
            {

                Button buttonCard = new Button();
                buttonCard.TabStop = false;
                buttonCard.Size = new Size(60, 100);
                buttonCard.Location = new Point(i * 100 + 20);
                buttonCard.Name = i.ToString();
                buttonCard.BackgroundImage = Image.FromFile("..\\..\\CardPictures\\BackendCard.jpg");
                buttonCard.BackgroundImageLayout = ImageLayout.Stretch;
                if (i == fatherCard)
                {
                    buttonCard.Tag = "FindtheCard";
                }
                else
                {
                    buttonCard.Tag = "FrontendCard";
                }
                buttonCard.Click += buttonCard_Click;
                this.Controls.Add(buttonCard);

            }
        }

        void buttonCard_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            senderButton.BackgroundImage = Image.FromFile("..\\..\\CardPictures\\" + senderButton.Tag.ToString() + ".jpg");
            senderButton.BackgroundImageLayout = ImageLayout.Stretch;

            if (senderButton.Tag.ToString() == "FindtheCard")
            {
                MessageBox.Show("Tebrikler Buldunuz !!!");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Maalesef Bulamadınız,Tekrar Dene!!!", "Dikkat", MessageBoxButtons.OK);
            }

        }
    }
}
