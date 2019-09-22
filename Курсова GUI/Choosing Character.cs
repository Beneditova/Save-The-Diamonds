using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсова_GUI
{
    public partial class Choosing_Character : Form
    {
        string file = $"{Globals.Username} Heroes.txt";

        private bool button1_clicked = false;

        public Choosing_Character()
        {
            InitializeComponent();
            username.Text = $"Hello  {Globals.Username}";

            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        heroesList.Items.Add((sr.ReadLine()));
                    }

                }
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            customHeroButton.PerformClick();

            if (customHeroButton.Checked)
            {
                if (customHeroButton.Checked)
                {
                    picturePath.Visible = true;
                    label6.Visible = true;

                    Globals.Upload = 1;

                    try
                    {
                        OpenFileDialog dialog = new OpenFileDialog();

                        dialog.InitialDirectory = @"C:\Users\PC\Desktop";
                        dialog.Filter = "Image Files(*.png;*.jpg; *.jpeg; *.gif;  *.bmp;)|*.png;*.jpg; *.jpeg; *.gif; *.bmp;";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            picturePath.Text = dialog.SafeFileName;
                            File.Copy(dialog.FileName, "NewClass\\" + dialog.SafeFileName);
                            customPicture.ImageLocation = "NewClass\\" + dialog.SafeFileName;
                            FileStream fs = new FileStream($"{Globals.Username} Upload.txt", FileMode.OpenOrCreate);
                            using (StreamWriter sv = new StreamWriter(fs))
                            {
                                sv.WriteLine(dialog.SafeFileName);
                            }
                            MessageBox.Show($"Dont forget to click [save] after uploading the picture {Globals.Username} :)");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong with the picture!");
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            button1_clicked = true;

            heroesList.Items.Clear();

            if (tankButton.Checked)
            {
                Globals.UsersHeroPicture = "Tank";
            }

            if (healerButton.Checked)
            {
                Globals.UsersHeroPicture = "Healer";
            }

            if (mageButton.Checked)
            {
                Globals.UsersHeroPicture = "Mage";
            }

            if (thirdRabbitButton.Checked)
            {
                Globals.UsersHeroPicture = "Big Yargus";
            }

            if (firstRabbitButton.Checked)
            {
                Globals.UsersHeroPicture = "Big Flagus";
            }

            if (secondRabbitButton.Checked)
            {
                Globals.UsersHeroPicture = "Big Chunguschu";
            }

            if (customHeroButton.Checked)
            {
                Globals.UsersHeroPicture = picturePath.Text;
            }

            Globals.UsersHeroName = userHeroName.Text;

            FileStream fs = new FileStream(file, FileMode.Append);
            using (StreamWriter sv = new StreamWriter(fs))
            {
                sv.WriteLine("Hero name: " +userHeroName.Text + "," + Globals.UsersHeroPicture);
            }
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                   heroesList.Items.Add((sr.ReadLine()));
                }
            }
        }
        private void heroesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1_clicked = true;

            if (heroesList.SelectedIndex != -1)
            {
                int itemAtPostion = heroesList.SelectedIndex;

                if (heroesList.Items[itemAtPostion].ToString().Contains("Tank"))
                {
                    Globals.UsersHeroPicture = "Tank";
                  
                }

                if (heroesList.Items[itemAtPostion].ToString().Contains("Healer"))
                {
                    Globals.UsersHeroPicture = "Healer";
                    
                }

                if (heroesList.Items[itemAtPostion].ToString().Contains("Mage"))
                {
                    Globals.UsersHeroPicture = "Mage";
                   

                }

                if (heroesList.Items[itemAtPostion].ToString().Contains("Big Yargus"))
                {
                    Globals.UsersHeroPicture = "Big Yargus";
                   
                }

                if (heroesList.Items[itemAtPostion].ToString().Contains("Big Flagus"))
                {
                    Globals.UsersHeroPicture = "Big Flagus";
                    
                }

                if (heroesList.Items[itemAtPostion].ToString().Contains("Big Chunguschu"))
                {
                    Globals.UsersHeroPicture = "Big Chunguschu";
                   
                }
                else
                {
                    Globals.Upload = 2;
                    Globals.NewHero = heroesList.Items[itemAtPostion].ToString().Split(',');
                    customPicture.ImageLocation = "NewClass\\" + Globals.NewHero[1];
                   
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1_clicked)
            {
                if (heroesList.SelectedIndex != -1)
                {
                    int itemAtPostion = heroesList.SelectedIndex;
                    if (heroesList.Items[itemAtPostion].ToString().Contains("Tank"))
                    {
                        Globals.UsersHeroPicture = "Tank";
                    }
                    if (heroesList.Items[itemAtPostion].ToString().Contains("Healer"))
                    {
                        Globals.UsersHeroPicture = "Healer";
                    }
                    if (heroesList.Items[itemAtPostion].ToString().Contains("Mage"))
                    {
                        Globals.UsersHeroPicture = "Mage";

                    }
                    if (heroesList.Items[itemAtPostion].ToString().Contains("Big Yargus"))
                    {
                        Globals.UsersHeroPicture = "Big Yargus";
                       
                    }
                    if (heroesList.Items[itemAtPostion].ToString().Contains("Big Flagus"))
                    {
                        Globals.UsersHeroPicture = "Big Flagus";
                       
                    }
                    if (heroesList.Items[itemAtPostion].ToString().Contains("Big Chunguschu"))
                    {
                        Globals.UsersHeroPicture = "Big Chunguschu";
                       
                    }
                    else
                    {
                        Globals.Upload = 2;

                        Globals.NewHero = heroesList.Items[itemAtPostion].ToString().Split(',');

                        customPicture.ImageLocation = "NewClass\\" + Globals.NewHero[1];
                    }
                }

                this.Hide();

                var firstStory = new FirstStory();
                firstStory.Closed += (s, args) => this.Close();
                firstStory.Show();
            }
            else
            {
                MessageBox.Show("Please [save] or click on a Hero(in the litsbox).");
            }
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            firstRabbitButton.PerformClick();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            secondRabbitButton.PerformClick();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            thirdRabbitButton.PerformClick();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tankButton.PerformClick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            healerButton.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mageButton.PerformClick();
        }
    }
}
