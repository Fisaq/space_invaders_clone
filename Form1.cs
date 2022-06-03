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
        int miliSegundo = 0;

        int pos_x = 0;
        int pos_y = 300;
        int ePos_x = 10;

        int Flag = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pos_x,pos_y);
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
            }
            pictureBox1.Location = new Point(pos_x,pos_y);
        }

        //enemy movement
        private void timer1_Tick(object sender, EventArgs e)
        {
            miliSegundo++;

            if(miliSegundo % 1 == 0)
            {
                if (Flag == 0)
                    ePos_x = ePos_x + 15;
                else
                    ePos_x = ePos_x - 15;

                if (ePos_x < 10)
                    Flag = 0;

                if (ePos_x > 690)
                    Flag = 1;
            }
             pictureBox2.Location = new Point(ePos_x);
        }
    }
}
