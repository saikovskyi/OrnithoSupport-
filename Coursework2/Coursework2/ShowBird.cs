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
using static System.Net.Mime.MediaTypeNames;

namespace Coursework2
{
    public partial class ShowBird : Form
    {
        Bird bird_;
        public List<object> records;

        private BindingSource bindingSource;

        public ShowBird(int bird_id,string bird_name, System.Drawing.Image bird_image, string bird_sound_path)
        {
            InitializeComponent();
            СreateDataGridView();AddButtons(); 
            records = new List<object>();
            bird_ = new Bird(bird_id, bird_name, bird_image, bird_sound_path);
            records.Add(new BirdRecord("33.44 33.44","",""));
            dataGridView1.CellClick += dataGridViewSoftware_CellClick;
            FillForm(); FillData(); 
        }

        private void AddButtons()
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "button";
                button.HeaderText = "Дії";
                button.Text = "Переглянути";
                button.FlatStyle = FlatStyle.Popup;
                button.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                button.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(button);
            }

            DataGridViewButtonColumn buttonPlaySound = new DataGridViewButtonColumn();
            {
                buttonPlaySound.Name = "buttonPlaySound";
                buttonPlaySound.HeaderText = "Дії";
                buttonPlaySound.Text = "Прослухати";
                buttonPlaySound.FlatStyle = FlatStyle.Popup;
                buttonPlaySound.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                buttonPlaySound.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonPlaySound);
            }
        }
        private void СreateDataGridView()
        {
            dataGridView1.DataSource = records;
        }
        public void FillData()
        {
            bindingSource = new BindingSource();
            dataGridView1.DataSource = bindingSource;
            bindingSource.DataSource = records;
        }
        private void PlaySound(int bird_index)
        {
            BirdRecord record = (BirdRecord)records[bird_index];
            record.Play_Sound();
        }
        private void ShowRecords_(int bird_index)
        {
            BirdRecord record = (BirdRecord)records[bird_index];
            ShowRecords f2 = new ShowRecords(record.Coordinates, record.Image, record.Sound);
            f2.ShowDialog();
        }
        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["button"].Index) ShowRecords_(e.RowIndex);
            if (e.ColumnIndex == dataGridView1.Columns["buttonPlaySound"].Index) PlaySound(e.RowIndex);
        }
        public void FillForm() {
            label1.Text = bird_.Name;
            pictureBox1.Image = new Bitmap(bird_.ImagePath);
        }

        public string Coordinates;

        public System.Drawing.Image ImagePath;
        
        public string SoundPath;

        private void button1_Click(object sender, EventArgs e)
        {
            records.Add(new BirdRecord(Coordinates, ImagePath, SoundPath));
            bindingSource.ResetBindings(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Coordinates = textBox1.Text;
        }
        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = new Bitmap(ofd.FileName);

                    if (!string.IsNullOrEmpty(ofd.FileName))
                    {
                        ImagePath = System.Drawing.Image.FromFile(ofd.FileName);
                    }
                }
                catch
                {
                    MessageBox.Show("Неможливо відкрити файл", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Sound Files(*.MP3;*.WAV)|*.MP3;*.WAV|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SoundPath = ofd.FileName;
                }
                catch
                {
                    MessageBox.Show("Неможливо відкрити файл", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
