using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсова_GUI
{
    public partial class SecondGame : Form
    {
        public SecondGame()
        {
            InitializeComponent();

            heart1.Image = Properties.Resources.lifeu;
            heart2.Image = Properties.Resources.lifeu;
            heart3.Image = Properties.Resources.lifeu;

            player.BringToFront();
            if (Globals.Upload == 1)
            {
                using (StreamReader sr = new StreamReader($"{Globals.Username} Upload.txt"))
                {
                    pathFile = sr.ReadLine();
                }
                player.ImageLocation = "NewClass\\" + pathFile;
            }
            if (Globals.Upload == 2)
            {
                player.ImageLocation = "NewClass\\" + Globals.NewHero[1];
            }

        }
        bool goLeft, goRight, jumping, hasKey, gameOver;
        int jumpSpeed = 10, force = 8, score = 0,health=3;
        string pathFile;

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                if (Globals.UsersHeroPicture == "Tank")
                {
                    player.Image = Properties.Resources.TankLeft;
                }
                if (Globals.UsersHeroPicture == "Healer")
                {
                    player.Image = Properties.Resources.HealerLeft;
                }
                if (Globals.UsersHeroPicture == "Mage")
                {
                    player.Image = Properties.Resources.MageLeft;
                }
                if (Globals.UsersHeroPicture == "Big Yargus")
                {
                    player.Image = Properties.Resources.YareLeft;
                }
                if (Globals.UsersHeroPicture == "Big Flagus")
                {
                    player.Image = Properties.Resources.FlambinoLeft;
                }
                if (Globals.UsersHeroPicture == "Big Chunguschu")
                {
                    player.Image = Properties.Resources.PikaLeft;
                }

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                if (Globals.UsersHeroPicture == "Tank")
                {
                    player.Image = Properties.Resources.TankRight;
                }
                if (Globals.UsersHeroPicture == "Healer")
                {
                    player.Image = Properties.Resources.HealerRight;
                }
                if (Globals.UsersHeroPicture == "Mage")
                {
                    player.Image = Properties.Resources.MageRight;
                }
                if (Globals.UsersHeroPicture == "Big Yargus")
                {
                    player.Image = Properties.Resources.YareRight;
                }
                if (Globals.UsersHeroPicture == "Big Flagus")
                {
                    player.Image = Properties.Resources.FlambinoRIght;
                }
                if (Globals.UsersHeroPicture == "Big Chunguschu")
                {
                    player.Image = Properties.Resources.PikaRight;
                }
            }
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

       
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping)
            {
                jumping = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            player.Top += jumpSpeed;
            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (goLeft)
            {
                player.Left -= 5;
            }

            if (goRight && player.Left + player.Width < 1210)
            {
                player.Left += 5;
            }

            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (health==2)
            {
                heart3.Visible = false;
            }

            if (health == 1)
            {
                heart2.Visible = false;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8; player.Top = x.Top - player.Height;
                        jumpSpeed = 0;
                    }
                }
                if (x is PictureBox && x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x); score++;Globals.CoinSound();
                    }
                }
                if (x is PictureBox && x.Tag == "key")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x); hasKey = true;KeySound();
                    }
                }
                if (x is PictureBox && x.Tag == "door")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && hasKey)
                    {
                       
                        this.Controls.Remove(x); DoorSound();
                    }
                }
            }

            if (player.Bounds.IntersectsWith(Door.Bounds) && hasKey)
            {
                if (score > Globals.SecondGame)
                {
                    Globals.SecondGame = score;
                }
                timer1.Stop();
                this.Hide();
                var gameOne = new ThirdStory();
                gameOne.Closed += (s, args) => this.Close();
                gameOne.Show();
            }

            if (player.Bounds.IntersectsWith(Key.Bounds))
            {
                this.Controls.Remove(Key);
                hasKey = true;
            }

            if(health>0)
            {
                if (player.Top + player.Height > this.ClientSize.Height - 9)
                {
                    health--;
                    OofSound();
                    timer1.Stop();
                    MessageBox.Show("Wrong direction", "[Respawn]");
                    gameOver = false; goLeft = false; goRight = false; jumping = false;
                    player.Location = new Point(100, 427);
                    timer1.Start();
                    
                }
            }

            if (health==0)
            {
                heart1.Visible = false;
                timer1.Stop();
                MessageBox.Show("You died!", "[Respawn]");
                gameOver = false; goLeft = false; goRight = false; jumping = false;
                score = 0; health = 3;
                this.Controls.Clear();
                InitializeComponent();
                timer1.Start();
            }
            
        }

        
        private void BackgroundPaint(object sender, PaintEventArgs e)
        {
            Bitmap platform = new Bitmap(Properties.Resources.platform);
            Bitmap background = new Bitmap(Properties.Resources.background1);
            Bitmap key = new Bitmap(Properties.Resources.key);
            Bitmap door = new Bitmap(Properties.Resources.door);
            Bitmap diamond = new Bitmap(Properties.Resources.diamond);

            foreach (PictureBox x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    x.Image = platform;
                }
                if (x is PictureBox && x.Tag == "coin")
                {
                    x.Image = diamond;
                }
            }
            BackImg.Image = background; Door.Image = door;Key.Image = key;
        
        }
       
        private void DoorSound()
        {
            SoundPlayer door = new SoundPlayer(@"door.wav");
            door.Play();
        }

        private void KeySound()
        {
            SoundPlayer key = new SoundPlayer(@"key.wav");
            key.Play();
        }

        private void OofSound()
        {
            SoundPlayer oof = new SoundPlayer(@"oof.wav");
            oof.Play();
        }

    }
}
