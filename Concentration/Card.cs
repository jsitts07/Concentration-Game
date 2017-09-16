using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media; 


namespace Concentration
{
    class Card
    {
        const int KNIGHT = 0;
        const int SWORD = 1;
        const int TORCH = 2;
        const int DYNAMITE = 3;
        const int COINS = 4;
        const int LAMP = 5;
        const int SHIELD = 6;
        const int BLANK = 7;

        public int Type { get; set; }
        private PictureBox pb;

        public PictureBox Pb
        {
            get
            {
                return pb;
            }

            set
            {
                pb = value;
                value.BackColor = Color.Transparent;
            }
        }

        public bool Matched { get; set; }

        SoundPlayer flipSound = new SoundPlayer(Properties.Resources.snd__flip);


        public Card()
        {
           // Pb.BackColor = Color.Transparent; 
        }

        public void Show()
        {
            if(!Matched)
            {
                flipSound.Play();
                switch (Type)
                {
                    case TORCH:
                        Pb.Image = Properties.Resources.img_torch;
                        break;
                    case KNIGHT:
                        Pb.Image = Properties.Resources.img_knight;
                        break;
                    case SWORD:
                        Pb.Image = Properties.Resources.img_sword;
                        break;
                    case DYNAMITE:
                        Pb.Image = Properties.Resources.img_dynamite;
                        break;
                    case COINS:
                        Pb.Image = Properties.Resources.img_coins;
                        break;
                    case LAMP:
                        Pb.Image = Properties.Resources.img_lamp;
                        break;
                    case SHIELD:
                        Pb.Image = Properties.Resources.img_shield;
                        break;
                    case BLANK:
                        Pb.Image = Properties.Resources.img_blank;
                        break;
                }

            }
           
        }//end show

        //Flip back over
        public void Hide()
        {
            if(Matched)
            {
                flipSound.Play(); 
                Pb.Image = Properties.Resources.img_blank;
            }
            else
            {        
                Pb.Image = Properties.Resources.img_card_back; 
            }
        }

    }//end card

}//end ns
