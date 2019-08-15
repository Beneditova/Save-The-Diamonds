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
    public partial class LogInSystem : Form
    {
        string passCheck;
        List<string> usernames = new List<string>();
        List<string> passwords = new List<string>();
        readonly string filePath = "Acc.txt";
        public LogInSystem()
        {
            InitializeComponent();
            passTxt.PasswordChar = '*';
            Globals.StartMenuSound();
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);

            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string lineUser = sr.ReadLine();
                usernames.Add(lineUser);
                string linePass = sr.ReadLine();
                passwords.Add(linePass);
            }

            sr.Close();
        }
        private void userTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void LogIn_Click(object sender, EventArgs e)
        {
            string currentPassword = passTxt.Text;
          
            Globals.Username = userTxt.Text;
            
            using (StreamReader sr = new StreamReader("Acc.txt"))
            {
                string inputUsername = userTxt.Text;
                string inputPass = passTxt.Text;
                bool isFound = false;
                for (int i = 0; i < usernames.Count; i++)
                {
                    if (usernames[i] == inputUsername
                        && passwords[i] == inputPass)
                    {
                        isFound = true;
                        if (MessageBox.Show($"Hello user {userTxt.Text} ,Click OK to start the game! ", "Game On: ")
                              == DialogResult.OK)
                        {
                            this.Hide();
                            var log = new Choosing_Character();
                            log.Closed += (s, args) => this.Close();
                            log.Show();
                        }
                    }
                }

                if (!isFound)
                {
                    MessageBox.Show("Wrong username or password!Try Again!", "Something went wrong!",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Globals.Username = userTxt.Text.Trim();
            passCheck = passTxt.Text.Trim();
            if (Globals.Username=="")
            {
                MessageBox.Show("Username is empty");
                return;
            }
            if (passCheck == "")
            {
                MessageBox.Show("Password is empty");
                return;
            }

            if (File.Exists("Acc.txt"))
            {
                foreach (string line in File.ReadLines("Acc.txt"))
                {
                    if (line.Contains(Globals.Username))
                    {
                        MessageBox.Show($"Username {Globals.Username} is taken!", "Sorry",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            FileStream fs = new FileStream("Acc.txt", FileMode.Append);
            using (StreamWriter sv = new StreamWriter(fs))
            {
                sv.WriteLine(Globals.Username);
                sv.WriteLine(passTxt.Text);
            }
            usernames.Add(Globals.Username);
            passwords.Add(passTxt.Text);
            if (MessageBox.Show("Account has been created!" , "Congratulations")==DialogResult.OK)
            {
                this.Hide();
                var log = new Choosing_Character();
                log.Closed += (s, args) => this.Close();
                log.Show();
            }
        }

       
    }
}
