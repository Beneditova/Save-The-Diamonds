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
            label2.Text = $"Hello  {Globals.Username}";
            if(File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        listBox1.Items.Add((sr.ReadLine()));
                    }

                }
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
           
            radioButton4.PerformClick();
            if (radioButton4.Checked)
            {
                if (radioButton4.Checked)
                {
                    textBox1.Visible = true;
                    label6.Visible = true;
                    Globals.Upload = 1;
                    try
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.InitialDirectory = @"C:\Users\PC\Desktop";
                        dialog.Filter = "Image Files(*.png;*.jpg; *.jpeg; *.gif;  *.bmp;)|*.png;*.jpg; *.jpeg; *.gif; *.bmp;";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            textBox1.Text = dialog.SafeFileName;
                            File.Copy(dialog.FileName, "NewClass\\" + dialog.SafeFileName);
                            pictureBox4.ImageLocation = "NewClass\\" + dialog.SafeFileName;
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
            listBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                Globals.UsersHeroPicture = "Tank";
            }
            if (radioButton2.Checked)
            {
                Globals.UsersHeroPicture = "Healer";
            }
            if (radioButton3.Checked)
            {
                Globals.UsersHeroPicture = "Mage";
            }
            if (radioButton7.Checked)
            {
                Globals.UsersHeroPicture = "Big Yargus";
            }
            if (radioButton5.Checked)
            {
                Globals.UsersHeroPicture = "Big Flagus";
            }
            if (radioButton6.Checked)
            {
                Globals.UsersHeroPicture = "Big Chunguschu";
             
            }
            if (radioButton4.Checked)
            {
                Globals.UsersHeroPicture = textBox1.Text;
              

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
                   listBox1.Items.Add((sr.ReadLine()));
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1_clicked = true;
            if (listBox1.SelectedIndex != -1)
            {
                int itemAtPostion = listBox1.SelectedIndex;
                if (listBox1.Items[itemAtPostion].ToString().Contains("Tank"))
                {
                    Globals.UsersHeroPicture = "Tank";
                  
                }
                if (listBox1.Items[itemAtPostion].ToString().Contains("Healer"))
                {
                    Globals.UsersHeroPicture = "Healer";
                    
                }
                if (listBox1.Items[itemAtPostion].ToString().Contains("Mage"))
                {
                    Globals.UsersHeroPicture = "Mage";
                   

                }
                if (listBox1.Items[itemAtPostion].ToString().Contains("Big Yargus"))
                {
                    Globals.UsersHeroPicture = "Big Yargus";
                   
                }
                if (listBox1.Items[itemAtPostion].ToString().Contains("Big Flagus"))
                {
                    Globals.UsersHeroPicture = "Big Flagus";
                    
                }
                if (listBox1.Items[itemAtPostion].ToString().Contains("Big Chunguschu"))
                {
                    Globals.UsersHeroPicture = "Big Chunguschu";
                   
                }
                else
                {
                    Globals.Upload = 2;
                    Globals.NewHero = listBox1.Items[itemAtPostion].ToString().Split(',');
                    pictureBox4.ImageLocation = "NewClass\\" + Globals.NewHero[1];
                   
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1_clicked)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    int itemAtPostion = listBox1.SelectedIndex;
                    if (listBox1.Items[itemAtPostion].ToString().Contains("Tank"))
                    {
                        Globals.UsersHeroPicture = "Tank";
                    }
                    if (listBox1.Items[itemAtPostion].ToString().Contains("Healer"))
                    {
                        Globals.UsersHeroPicture = "Healer";
                    }
                    if (listBox1.Items[itemAtPostion].ToString().Contains("Mage"))
                    {
                        Globals.UsersHeroPicture = "Mage";

                    }
                    if (listBox1.Items[itemAtPostion].ToString().Contains("Big Yargus"))
                    {
                        Globals.UsersHeroPicture = "Big Yargus";
                       
                    }
                    if (listBox1.Items[itemAtPostion].ToString().Contains("Big Flagus"))
                    {
                        Globals.UsersHeroPicture = "Big Flagus";
                       
                    }
                    if (listBox1.Items[itemAtPostion].ToString().Contains("Big Chunguschu"))
                    {
                        Globals.UsersHeroPicture = "Big Chunguschu";
                       
                    }
                    else
                    {
                        Globals.Upload = 2;
                        Globals.NewHero = listBox1.Items[itemAtPostion].ToString().Split(',');
                        pictureBox4.ImageLocation = "NewClass\\" + Globals.NewHero[1];
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
            radioButton5.PerformClick();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            radioButton6.PerformClick();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            radioButton7.PerformClick();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton1.PerformClick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            radioButton2.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            radioButton3.PerformClick();
        }

       
        

        
    }
}
