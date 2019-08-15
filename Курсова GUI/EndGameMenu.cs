using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсова_GUI
{
    public partial class EndGameMenu : Form
    {
        public EndGameMenu()
        {
            InitializeComponent();
            string check1, check2, check3;
            int score1,score2,score3;
            string file = $"{Globals.Username} HighScores.txt";
            label1.Text = $"Hello  {Globals.Username}";

            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader($"{Globals.Username} HighScores.txt"))
                {
                    
                    while (!sr.EndOfStream)
                    {
                        check1 = sr.ReadLine();
                        Int32.TryParse(check1, out score1);
                        if (Globals.FirstGame < score1)
                        {
                            Globals.FirstGame = score1;
                        }
                        check2 = sr.ReadLine();
                         Int32.TryParse(check2, out score2);
                        if (Globals.FirstGame < score2)
                        {
                            Globals.FirstGame = score2;
                        }
                        check3 = sr.ReadLine();
                        Int32.TryParse(check3, out score3);
                        if (Globals.FirstGame < score3)
                        {
                            Globals.FirstGame = score3;
                        }
                    }
                }

            }
           
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            using (StreamWriter sv = new StreamWriter(fs))
            {
                sv.WriteLine(Globals.FirstGame);
                sv.WriteLine(Globals.SecondGame);
                sv.WriteLine(Globals.ThirdGame);
            }
            using (StreamReader sr = new StreamReader($"{Globals.Username} HighScores.txt"))
            {

                while (!sr.EndOfStream)
                {
                   listBox1.Items.Add((sr.ReadLine()));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
