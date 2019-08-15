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
    public partial class FirstGame : Form
    {
        
        public FirstGame()
        {
            InitializeComponent();
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

        private void FirstGame_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.PaleTurquoise;
        }

        bool goUp, goDown, goLeft, goRight, gameOver;
        double playerHeath = 100;
        Random rnd = new Random();
        string facing = "up",pathFile;
        int speed = 10, ammo = 10, enemySpeed = 3, score = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var gameSecond = new SecondStory();
            gameSecond.Closed += (s, args) => this.Close();
            gameSecond.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            goUp = false; goDown = false; goLeft = false; goRight = false; gameOver = false;
            playerHeath = 100; score = 0; ammo = 10;
            this.Controls.Clear();
            InitializeComponent();
            GameTimer(e, e);
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
            label4.Visible = false;
            if (gameOver) return;
            if (e.KeyCode == Keys.Left)
            {
                
                   goLeft = true;
                facing = "left";
                if (Globals.UsersHeroPicture=="Tank")
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
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                if (Globals.UsersHeroPicture == "Tank")
                {
                    player.Image = Properties.Resources.TankUp;
                }
                if (Globals.UsersHeroPicture == "Healer")
                {
                    player.Image = Properties.Resources.HealerUp;
                }
                if (Globals.UsersHeroPicture == "Mage")
                {
                    player.Image = Properties.Resources.MageUp;
                }
                if (Globals.UsersHeroPicture == "Big Yargus")
                {
                    player.Image = Properties.Resources.YareUp;
                }
                if (Globals.UsersHeroPicture == "Big Flagus")
                {
                    player.Image = Properties.Resources.FlambinoUp;
                }
                if (Globals.UsersHeroPicture == "Big Chunguschu")
                {
                    player.Image = Properties.Resources.PikaUp;
                }

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
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
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                if (Globals.UsersHeroPicture == "Tank")
                {
                    player.Image = Properties.Resources.TankDown;
                }
                if (Globals.UsersHeroPicture == "Healer")
                {
                    player.Image = Properties.Resources.HealerDown;
                }
                if (Globals.UsersHeroPicture == "Mage")
                {
                    player.Image = Properties.Resources.MageDown;
                }
                if (Globals.UsersHeroPicture == "Big Yargus")
                {
                    player.Image = Properties.Resources.YareDown;
                }
                if (Globals.UsersHeroPicture == "Big Flagus")
                {
                    player.Image = Properties.Resources.FlambinoDown;
                }
                if (Globals.UsersHeroPicture == "Big Chunguschu")
                {
                    player.Image = Properties.Resources.PikaDown;
                }
            }
        }
        private void GameTimer(object sender, EventArgs e)
        {
            Globals.BulletMode = 1;

            

            if (playerHeath > 1)
            {
                progressBar1.Value = Convert.ToInt32(playerHeath);
            }
            else
            {
                if (score>Globals.FirstGame)
                {
                    Globals.FirstGame = score;
                }
                
                
                Ded();
                timer1.Stop();
                gameOver = true; button1.Visible = true;score = 0;
                button2.Visible = true; button1.BringToFront();
                button2.BringToFront();
            }
            label3.Text = "Ammo: " + ammo;
            label2.Text = "Score: " + score;
            
            if (playerHeath < 60)
            {
                ModifyProgressBarColor.SetState(progressBar1, 3);
            }
            if (playerHeath < 30)
            {
                ModifyProgressBarColor.SetState(progressBar1, 2);
            }
            if (goLeft && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight && player.Left + player.Width < 805)
            {
                player.Left += speed;
            }
            if (goUp && player.Top > 80)
            {
                player.Top -= speed;
            }
            if (goDown && player.Top + player.Height < 610)
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
                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 800 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 650)
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
                        ((PictureBox)x).Image = Properties.Resources.aleft;
                    }

                    if (((PictureBox)x).Top > player.Top)
                    {
                        ((PictureBox)x).Top -= enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.aright;
                    }
                    if (((PictureBox)x).Left < player.Left)
                    {
                        ((PictureBox)x).Left += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.aup;
                    }
                    if (((PictureBox)x).Top < player.Top)
                    {
                        ((PictureBox)x).Top += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.adown;
                    }
                }
                
                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "alien1"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            Globals.CoinSound();
                            score++;
                            this.Controls.Remove(j); j.Dispose();
                            this.Controls.Remove(x); x.Dispose();
                            MakeAliens();

                        }
                    }
                }
            }
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(10, 550);
            ammo.Top = rnd.Next(50, 500);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void Shoot(string direct)
        {
            Bullets shoot = new Bullets();
            shoot.diretion = direct;
            shoot.bulletLeft = player.Left + (player.Width / 2);
            shoot.bulletTop = player.Top + (player.Height / 2);
            shoot.makeBullet(this);

           
            if (Globals.UsersHeroPicture=="Tank")
            {
                Globals.TankSound();
            }
            if (Globals.UsersHeroPicture == "Healer")
            {
                Globals.HealerSound();
            }
            if (Globals.UsersHeroPicture == "Mage")
            {
                Globals.MageSound();
            }
            if (Globals.UsersHeroPicture == "Big Yargus")
            {
                Globals.YareSound();
            }
            if (Globals.UsersHeroPicture == "Big Flagus")
            {
                Globals.YareSound();
            }
            if (Globals.UsersHeroPicture == "Big Chunguschu")
            {
                Globals.PikaSound();
            }
            else
            {
                Globals.ShootSound();
            }
        }
        private void MakeAliens()
        {
            PictureBox alien = new PictureBox();
            alien.Tag = "alien1";
            alien.Image = Properties.Resources.aleft;
            alien.Left = rnd.Next(0, 900);
            alien.Top = rnd.Next(0, 800);
            alien.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(alien);
            player.BringToFront();
        }
        public static void Ded()
        {
            SoundPlayer dedSound = new SoundPlayer(@"ded.wav");
            dedSound.Play();
        }


    }
}
