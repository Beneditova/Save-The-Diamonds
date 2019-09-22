using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Курсова_GUI
{
    class Globals
    {
        public static string Username;
        public static string UsersHeroName;
        public static string UsersHeroPicture;

        public static string[] NewHero;

        public static int Upload=0;

        public static int FirstGame;
        public static int SecondGame;
        public static int ThirdGame;

        public static int BulletMode;
       
        public static void StartMenuSound()
        {
            SoundPlayer start = new SoundPlayer(@"start.wav");
            start.Play();
        }

        public static void StoryMenuSound()
        {
            SoundPlayer story = new SoundPlayer(@"story.wav");
            story.Play();
        }

        public static void LaserSound()
        {
            SoundPlayer laserSound = new SoundPlayer(@"laser.wav");
            laserSound.Play();
        }

        public static void ReloadSound()
        {
            SoundPlayer reloadSound = new SoundPlayer(@"reload.wav");
            reloadSound.Play();
        }

        public static void CoinSound()
        {
            SoundPlayer coinSound = new SoundPlayer(@"coin.wav");
            coinSound.Play();
        }

        public static void ShootSound()
        {
            SoundPlayer shootSound = new SoundPlayer(@"gun.wav");
            shootSound.Play();
        }

        public static void DeathSound()
        {
            SoundPlayer deathSound = new SoundPlayer(@"death.wav");
            deathSound.Play();
        }

        public static void JumpSound()
        {
            SoundPlayer jumpSound = new SoundPlayer(@"jump.wav");
            jumpSound.Play();
        }

        public static void TankSound()
        {
            SoundPlayer tankSound = new SoundPlayer(@"heavy.wav");
            tankSound.Play();
        }

        public static void HealerSound()
        {
            SoundPlayer healerSound = new SoundPlayer(@"fiddle.wav");
            healerSound.Play();
        }

        public static void MageSound()
        {
            SoundPlayer mageSound = new SoundPlayer(@"foxy.wav");
            mageSound.Play();
        }

        public static void YareSound()
        {
            SoundPlayer yareSound = new SoundPlayer(@"yare.wav");
            yareSound.Play();
        }

        public static void PikaSound()
        {
            SoundPlayer pikaSound = new SoundPlayer(@"pika.wav");
            pikaSound.Play();
        }

    }
}
