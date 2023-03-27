using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace SpaceInvaders
{
    public partial class Invaders : Form
    {
        //To move the ship from left to right
        bool DirLeft, DirRight;
        int RickSpeed = 12;
        int CromulonSpeed = 5;
        int GameScore = 0;
        int CromulonLaserTmr = 300;

        PictureBox[] CromulonsArray;

        bool lasershoot;
        bool GameFinished;

        public Invaders()
        {
            InitializeComponent();
            GameCode();
        }
        private void GameTimer(object sender, EventArgs e)
        {
            lblscore.Text = "Puntaje: " + GameScore;
            if (DirLeft)
            {
                picrick.Left -= RickSpeed;
            }
            if (DirRight)
            {
                picrick.Left += RickSpeed;
            }

            CromulonLaserTmr -= 10;

            if (CromulonLaserTmr < 1)
            {
                CromulonLaserTmr = 300;
                LaserMaker("LaserCromulon");
            }
            foreach (Control x in this.Controls)
            {
                //this defines the positions of the enemies
                if (x is PictureBox && (string)x.Tag == "Cromulons")
                {
                    x.Left += CromulonSpeed;

                    if (x.Left > 730)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(picrick.Bounds))
                    {
                        GameOver("Perdiste!");
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "laserrick")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                GameScore += 1;
                                lasershoot = false;
                            }
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "laserrick")
                {
                    x.Top -= 20;

                    if (x.Top < 15)
                    {
                        this.Controls.Remove(x);
                        lasershoot = false;
                    }
                }
                //this defines the position of the enemy laser
                if (x is PictureBox && (string)x.Tag == "LaserCromulon")
                {

                    x.Top += 20;

                    if (x.Top > 620)
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(picrick.Bounds))
                    {
                        this.Controls.Remove(x);
                        
                    }

                }
            }

            if (GameScore > 8)
            {
                CromulonSpeed = 12;
            }

            if (GameScore == CromulonsArray.Length)
            {
                GameOver("Ganaste!");
            }
        }

        private void KDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                DirLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                DirRight = true;
            }
        }
        //both for the movement of the ship, from left to right with the keys
        private void KUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                DirLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                DirRight = false;
            }
            if (e.KeyCode == Keys.Space && lasershoot == false)
            {
                lasershoot = true;
                LaserMaker("laserrick");
            }
            if (e.KeyCode == Keys.Enter && GameFinished == true)
            {
                Clear();
                GameCode();
            }
        }
        private void MakeCromulons()
        {
            CromulonsArray = new PictureBox[15];

            int left = 0;
            //this makes the cromulons, with the array previosly defined, can be modified easily
            for (int i = 0; i < CromulonsArray.Length; i++)
            {
                CromulonsArray[i] = new PictureBox();
                CromulonsArray[i].Size = new Size(40, 50);
                CromulonsArray[i].Image = Properties.Resources.Cromulon;
                CromulonsArray[i].Top = 5;
                CromulonsArray[i].Tag = "Cromulons";
                CromulonsArray[i].Left = left;
                CromulonsArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(CromulonsArray[i]);
                left = left - 80;
            }
        }

        private void GameCode()
        {
            //this stores the speed, score and some of the ticks
            lblscore.Text = "Puntuación: 0";
            GameScore = 0;
            GameFinished = false;

            CromulonLaserTmr = 300;
            CromulonSpeed = 5;  
            lasershoot = false;

            MakeCromulons();
            TmrGame.Start();
        }

        private void GameOver(string msg)
        {
            //this defines the score at the end of the game
            GameFinished = true;
            TmrGame.Stop();
            lblscore.Text = "Score: " + GameScore + " " + msg;
        }

        private void Clear()
        {
            foreach (PictureBox i in CromulonsArray)
            {
                this.Controls.Remove(i);
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "laserrick" || (string)x.Tag == "LaserCromulon")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

        private void picrick_Click(object sender, EventArgs e)
        {

        }

        private void LaserMaker(string LaserTag)    
        {
            //this creates the laser picturebox, and defines it's starting point 
            PictureBox laser = new PictureBox();
            laser.Image = Properties.Resources.laserr;
            laser.Size = new Size(10, 20);
            laser.Tag = LaserTag ;
            laser.Left = picrick.Left + picrick.Width / 2;
            if ((string)laser.Tag == "laserrick")
            {
                laser.Top = picrick.Top - 20;
            }
            else if ((string)laser.Tag == "LaserCromulon")
            {
                laser.Top = -100;
            }
            this.Controls.Add(laser);
            laser.BringToFront();
        }
                    
    }

}
