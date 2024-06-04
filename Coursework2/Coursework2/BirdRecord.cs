using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coursework2
{
    class BirdRecord
    {
        private string coordinates;
        private Image image;
        private string sound;
        public string Coordinates { get { return coordinates; } set { coordinates = value; } }
        public Image Image { get { return image; } set { image = value; } }
        public string Sound { get { return sound; } set { sound = value; } }
        public BirdRecord(string coordinates, Image imagePath, string sound) { 
            this.coordinates = coordinates;
            this.image = imagePath;
            this.sound = sound;
        }
        public BirdRecord(string coordinates, string imagePath, string sound)
        {
            this.coordinates = coordinates;
            if (!string.IsNullOrEmpty(imagePath))
            {
                this.image = System.Drawing.Image.FromFile(imagePath);
            }
            this.sound = sound;
        }
        public void Play_Sound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = this.Sound;
            player.Play();
        }
    }
}
