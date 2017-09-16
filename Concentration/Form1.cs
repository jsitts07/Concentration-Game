using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentration
{
    public partial class Form1 : Form
    {
        const int NUM_CARDS = 14;
        const int NOT_SELECTED = -1;
        Card[] cards = new Card[NUM_CARDS];
        int firstPos = NOT_SELECTED;
        int secondPos = NOT_SELECTED;
        int matches; 

        public Form1()
        {
            InitializeComponent();
            CreateCards();
            ShuffleCards();
            AssignPictureBoxes();

        }
        void AssignPictureBoxes()
        {
            /*
            cards[0].Pb = pictureBox1;
            cards[1].Pb = pictureBox2;
            cards[2].Pb = pictureBox3;
            cards[3].Pb = pictureBox4;
            cards[4].Pb = pictureBox5;
            cards[5].Pb = pictureBox6;
            cards[6].Pb = pictureBox7;
            cards[7].Pb = pictureBox8;
            cards[8].Pb = pictureBox9;
            cards[9].Pb = pictureBox10;
            cards[10].Pb = pictureBox11;
            cards[11].Pb = pictureBox12;
            cards[12].Pb = pictureBox13;
            cards[13].Pb = pictureBox14;
            */
            for (int i = 0; i < NUM_CARDS; i++)
            {
                Control[] c = this.Controls.Find("pictureBox" + (i+1), false);
                cards[i].Pb = (PictureBox)c[0]; 
            }
        }

        void ShuffleCards()
        {
            Random r = new Random();

            int temp; 

            for (int i = 0; i < 100; i++)
            {
                int index1 = r.Next(0, NUM_CARDS);
                int index2 = r.Next(0, NUM_CARDS);

                temp = cards[index1].Type; //save card 1
                cards[index1].Type = cards[index2].Type; //cards2 -> card1
                cards[index2].Type = temp; 
            }

        }

        void CreateCards()
        {
           
            //allocates cards
            for (int i = 0; i < NUM_CARDS; i++)
            {
                cards[i] = new Card(); 
            }
            //tell each card what type it is 
            for (int i = 0; i < NUM_CARDS / 2; i++)
            {
                cards[i].Type = i;
                cards[i + NUM_CARDS / 2].Type = i;
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();


           // box = null;      //Force garbage collector to run --> NOT GOOD 
           // GC.Collect();    //RECOMENDED THAT YOU DO NOT DO IT
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
        //index of card flip
        void FlipCard(int card)
        {
            if (!cards[card].Matched)
            {
                if (firstPos == NOT_SELECTED)
                {
                    cards[card].Show();
                    firstPos = card;
                }
                else if (secondPos == NOT_SELECTED)
                {
                    if (card == firstPos)
                    {
                        MessageBox.Show("No cheating!");
                    }
                    else
                    {
                        cards[card].Show();
                        secondPos = card;
                        timer1.Interval = 2000;
                        timer1.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Stop trying to mess up the program");
                }
            }
        }

        void HideCards()
        {
            if(cards[firstPos].Type == cards[secondPos].Type)
            {
                cards[firstPos].Matched = true;
                cards[secondPos].Matched = true;
                matches++;

                if(matches == 7)
                {
                    MessageBox.Show("YOU WON!!"); 
                }
            }
                        
                cards[firstPos].Hide();
                cards[secondPos].Hide();
                firstPos = NOT_SELECTED;
                secondPos = NOT_SELECTED;
                timer1.Stop(); 
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FlipCard(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FlipCard(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FlipCard(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FlipCard(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FlipCard(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FlipCard(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FlipCard(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FlipCard(7);
        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FlipCard(8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FlipCard(9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FlipCard(10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FlipCard(11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            FlipCard(12);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            FlipCard(13);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HideCards();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShuffleCards();
            for (int i = 0; i < NUM_CARDS; i++)
            {
                cards[i].Matched = false;
                cards[i].Hide();
            }
            matches = 0;
        }
    }
}
