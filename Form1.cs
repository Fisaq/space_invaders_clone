using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navinha
{
    public partial class Form1 : Form
    {
        //global variables 
        int timerMS = 0;
        int pos_x = 0;
        int pos_y = 300;
        int ePos_x = 10;
        int Flag = 0;
        int flagShot = 0;
        int posX_shot = 0;
        int posY_shot = 0;

        PictureBox[] movimentacaoInimigo = new PictureBox[5];

        public Form1()
        {
            InitializeComponent();

            movimentacaoInimigo[0] = pictureBox2;
            movimentacaoInimigo[1] = pictureBox3;
            movimentacaoInimigo[2] = pictureBox4;
            movimentacaoInimigo[3] = pictureBox5;
            movimentacaoInimigo[4] = pictureBox6;

            pictureBox7.Location = new Point(21, 248); //player shot's location
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pos_x, pos_y);
            pictureBox1.BringToFront();
        }

        //player movement
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (pos_x < 690)
                        pos_x = pos_x + 10;
                    break;
                case Keys.Left:
                    if(pos_x > 10)
                        pos_x = pos_x - 10;
                    break;
                case Keys.Space:
                    if (flagShot == 0)
                        posX_shot = pos_x + 30;
                    flagShot = 1;
                    break ;
            }
            pictureBox1.Location = new Point(pos_x,pos_y);
        }

        //enemy movement timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerMS++;

            if (flagShot == 1)
            {
                pictureBox7.Location = new Point(posX_shot, 248 - posY_shot);
                posY_shot = posY_shot + 10;

                if (posY_shot > 690)
                {
                    posY_shot = 0;
                    flagShot = 0;
                }
            }
            else
                pictureBox7.Location = new Point(pos_x + 31, 248);

            for(int i = 0; i<5;i++)
            {

              if (Flag == 0)
                  ePos_x = ePos_x + 2;
              else
                  ePos_x = ePos_x - 2;

              if (ePos_x < 10)
                  Flag = 0;

              if (ePos_x > 248)
                  Flag = 1;

                movimentacaoInimigo[i].Location = new Point(ePos_x + 100 * i, 10);
            }

        }
    }
}
