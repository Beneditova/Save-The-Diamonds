using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсова_GUI
{
    class Bullets
    {
        public string diretion;
        public int speed = 20, bulletLeft, bulletTop;
        PictureBox bullet = new PictureBox();
        Timer tm = new Timer();
        public void makeBullet(Form form)
        {
           
            if (Globals.BulletMode==2)
            {
                bullet.Size = new Size(20, 5);
                bullet.BackColor = System.Drawing.Color.LimeGreen;
            }
            if (Globals.BulletMode == 1)
            {
                bullet.Size = new Size(5, 5);
                bullet.BackColor = System.Drawing.Color.LightCoral;
            }
           
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.Tag = "bullet";
            bullet.BringToFront();
            form.Controls.Add(bullet);

            tm.Interval = speed;
            tm.Tick += new EventHandler(Tm_Tick);
            tm.Start();
        }
        public void Tm_Tick(object sender, EventArgs e)
        {
            if (diretion == "left")
            {
                bullet.Left -= speed;

            }
            if (diretion == "right")
            {
                bullet.Left += speed;

            }
            if (diretion == "up")
            {
                bullet.Top -= speed;

            }
            if (diretion == "down")
            {
                bullet.Top += speed;

            }
            if(Globals.BulletMode==1)
            {
                if (bullet.Left < 20 || bullet.Left > 1000 || bullet.Top < 20 || bullet.Top > 1206)
                {
                    tm.Stop();
                    tm.Dispose();
                    bullet.Dispose();
                    tm = null;
                    bullet = null;
                }
            }
            if (Globals.BulletMode == 3)
            {
                if (bullet.Left < 16 || bullet.Left > 1300 || bullet.Top < 10 || bullet.Top > 616)
                {
                    tm.Stop();
                    tm.Dispose();
                    bullet.Dispose();
                    tm = null;
                    bullet = null;
                }
            }

        }
    }
}
