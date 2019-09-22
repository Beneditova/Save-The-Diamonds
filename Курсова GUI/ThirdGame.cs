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
    public partial class ThirdGame : Form
    {
        public ThirdGame()
        {
            InitializeComponent();
        }

        bool goUp, goDown, goLeft, goRight, gameOver;

        double playerHeath = 100;

        Random rnd = new Random();
        string facing = "right";

        int speed = 7, ammo = 10, enemySpeed = 3, score = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            goUp = false; goDown = false; goLeft = false;

            goRight = false; gameOver = false;

            playerHeath = 100; score = 0; ammo = 10;

            this.Controls.Clear();

            InitializeComponent();

            GmaeTimer(e, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var gameSecond = new EndGameMenu();

            gameSecond.Closed += (s, args) => this.Close();

            gameSecond.Show();
        }

        private void Scene(object sender, PaintEventArgs e)
        {
            this.Size = new Size(1100, 550);
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

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;

                Shoot(facing);

                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                Bitmap user = new Bitmap(Properties.Resources.finalship);
                player.Image = user;
                player.Size = new System.Drawing.Size(150, 70);

            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                Bitmap user = new Bitmap(Properties.Resources.finalship);
                player.Image = user;
                player.Size = new System.Drawing.Size(150, 70);

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                Bitmap user = new Bitmap(Properties.Resources.shipright);
                player.Image = user;
                player.Size = new System.Drawing.Size(150, 70);

            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                Bitmap user = new Bitmap(Properties.Resources.finalship);
                player.Image = user;
                player.Size = new System.Drawing.Size(150, 70);

            }
        }

        private void GmaeTimer(object sender, EventArgs e)
        {
            if (playerHeath > 1)
            {
                progressBar1.Value = Convert.ToInt32(playerHeath);
            }
            else
            {
                if (score > Globals.ThirdGame)
                {
                    Globals.ThirdGame = score;
                }
               
                Globals.DeathSound();
                timer1.Stop();
                gameOver = true; button1.Visible = true; button2.Visible = true;
                button1.BringToFront(); button2.BringToFront();
            }

            label1.Text = "Score; " + score;

            label2.Text = "Ammo; " + ammo;

            if (playerHeath < 60)
            {
                ModifyProgressBarColor.SetState(progressBar1, 3);
            }

            if (playerHeath < 30)
            {
                ModifyProgressBarColor.SetState(progressBar1, 2);
            }

            Globals.BulletMode = 2;

            if (goLeft && player.Left > 0)
            {
                player.Left -= speed;
            }

            if (goRight && player.Left + player.Width < 1100)
            {
                player.Left += speed;
            }

            if (goUp && player.Top > 50)
            {
                player.Top -= speed;
            }

            if (goDown && player.Top + player.Height < 500)
            {
                player.Top += speed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "ammo")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        Globals.ReloadSound();
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose(); ammo += 5;
                    }
                }

                if (x is PictureBox && x.Tag == "bullet")
                {
                    if (((PictureBox)x).Left > 1000 )
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                }

                if (x is PictureBox && x.Tag == "alien1")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHeath -= 1;
                    }
                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.nyan;
                    }

                    if (((PictureBox)x).Top > player.Top)
                    {
                        ((PictureBox)x).Top -= enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.nyan;
                    }

                    if (((PictureBox)x).Left < player.Left)
                    {
                        ((PictureBox)x).Left += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.nyan;
                    }

                    if (((PictureBox)x).Top < player.Top)
                    {
                        ((PictureBox)x).Top += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.nyan;
                    }
                }

                foreach (Control j in this.Controls)
                {
                  
                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "alien1"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            MeowSound();
                                score++;
                                this.Controls.Remove(j); j.Dispose();
                                this.Controls.Remove(x); x.Dispose();
                                MakeAliens();
                        }
                    }
                }
            }
        }
        private void Shoot(string direct)
        {
            Bullets shoot = new Bullets();
            shoot.diretion = direct;
            shoot.bulletLeft = player.Left + 15;
            shoot.bulletTop = player.Top + 25;

            Bullets more = new Bullets();
            more.diretion = direct;
            more.bulletLeft = player.Left + 20;
            more.bulletTop = player.Top + 50;
            shoot.makeBullet(this);
            more.makeBullet(this);

            Globals.LaserSound();
        }
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(100, 450);
            ammo.Top = rnd.Next(100, 450);
            ammo.Tag = "ammo";

            this.Controls.Add(ammo);

            ammo.BringToFront();
            player.BringToFront();
        }
        private void MakeAliens()
        {
            PictureBox alien = new PictureBox();
            alien.Tag = "alien1";
            alien.Image = Properties.Resources.aleft;
            alien.Left = rnd.Next(400, 1000);
            alien.Top = rnd.Next(400, 800);
            alien.SizeMode = PictureBoxSizeMode.StretchImage;
            alien.Size = new System.Drawing.Size(100, 69);

            this.Controls.Add(alien);
            player.BringToFront();
        }
        public static void MeowSound()
        {
            SoundPlayer meowSound = new SoundPlayer(@"meow.wav");
            meowSound.Play();
        }

    }
}
