using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Coursework2
{    
    abstract class Animal {
        int id;
        string name;
        System.Drawing.Image imagePath;
        string sound;
        abstract public void Play_Sound();
    }
    class Bird : Animal
    {
        private int id;
        private string name;
        private System.Drawing.Image imagePath;
        private string sound;
        private List<BirdRecord> bird_records;
        public int Id { get { return id; }set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public System.Drawing.Image ImagePath { get { return imagePath; } set { imagePath = value; } }
        public string Sound { get { return sound; } set { sound = value; } }
        public List<BirdRecord> Bird_records { get { return bird_records; } set { bird_records = value; } }
        public Bird() { 

        }
        public Bird(int id, string name, string image, string sound)
        {
            this.id = id;
            this.name = name;
            if (!string.IsNullOrEmpty(image))
            {
                this.imagePath = System.Drawing.Image.FromFile(image);
            }
            this.sound = sound;
        }
        public Bird(int id, string name, System.Drawing.Image image, string sound)
        {
            this.id = id;
            this.name = name;
            this.imagePath = image;
            this.sound = sound;
        }
        public override void Play_Sound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = this.Sound;
            player.Play();
        }
    }
}
