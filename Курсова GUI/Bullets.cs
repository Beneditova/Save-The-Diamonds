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
            switch (Globals.BulletMode)
            {
                case 2:
                    {
                        bullet.Size = new Size(20, 5);
                        bullet.BackColor = System.Drawing.Color.LimeGreen;
                    }break;

                case 1:
                    {
                        bullet.Size = new Size(5, 5);
                        bullet.BackColor = System.Drawing.Color.LightCoral;
                    }break;
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
            switch (diretion)
            {
                case "left": bullet.Left -= speed; break;
                case "right": bullet.Left += speed; break;
                case "up": bullet.Top -= speed; break;
                case "down": bullet.Top += speed; break;

            }

            switch (Globals.BulletMode)
            {
                case 1:
                    {
                        if (bullet.Left < 20 || bullet.Left > 1000 || bullet.Top < 20 || bullet.Top > 1206)
                        {
                            tm.Stop();
                            tm.Dispose();
                            bullet.Dispose();
                            tm = null;
                            bullet = null;
                        }
                    } break;

                case 3:
                    {
                        if (bullet.Left < 16 || bullet.Left > 1300 || bullet.Top < 10 || bullet.Top > 616)
                        {
                            tm.Stop();
                            tm.Dispose();
                            bullet.Dispose();
                            tm = null;
                            bullet = null;
                        }
                    } break;
            }
        }
    }
}
