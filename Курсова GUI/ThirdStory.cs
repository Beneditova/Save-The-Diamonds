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
    public partial class ThirdStory : Form
    {
        public ThirdStory()
        {
            InitializeComponent();
            Globals.StoryMenuSound();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var log = new ThirdGame();
            log.Closed += (s, args) => this.Close();
            log.Show();
        }
        int count = 0;
        private void KeyIsPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && count == 0)
            {
                pictureBox1.Image = Properties.Resources._6;
                count++;

                return;
            }
            if (e.KeyChar == (char)Keys.Enter && count == 1)
            {
                pictureBox1.Image = Properties.Resources._7;
                count++;

                return;
            }
            if (e.KeyChar == (char)Keys.Enter && count == 2)
            {
                pictureBox1.Image = Properties.Resources._8;
                count++;

                return;
            }
            if (e.KeyChar == (char)Keys.Enter && count == 3)
            {
                pictureBox1.Image = Properties.Resources.controls1;
                count++;

                return;
            }


            if (e.KeyChar == (char)Keys.Enter && count == 4)
            {
                this.Hide();
                var gameOne = new ThirdGame();
                gameOne.Closed += (s, args) => this.Close();
                gameOne.Show();
            }
        }
    }
}
