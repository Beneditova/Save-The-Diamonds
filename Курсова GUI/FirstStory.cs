using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсова_GUI
{
    public partial class FirstStory : Form
    {
        public FirstStory()
        {
            InitializeComponent();
        }


        int count = 0;

        private void KeyIsPressed(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Enter&&count==0)
            {
                    pictureBox1.Image = Properties.Resources._2;
                    count++;
                    
                    return;
            }
            if (e.KeyChar == (char)Keys.Enter && count == 1)
            {
                pictureBox1.Image = Properties.Resources.controls1;
                count++;
                return;
            }

            if (e.KeyChar == (char)Keys.Enter&& count==2)
            {
                this.Hide();
                var gameOne = new FirstGame();
                gameOne.Closed += (s, args) => this.Close();
                gameOne.Show();
            }

        }
    }
}
