using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Set_Desktop_Background
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x01;

        public Form1()
        {
            InitializeComponent();
            setImageButton.Hide();
        }

        private void choosePictureButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Height = 800;
            pictureBox1.Width = 800;

            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                slika = openFileDialog1.FileName;
            }
            setImageButton.Show();
            setImageButton.Location = new Point(15, 900);
        }

        private string slika = "";

        private void setImageButton_Click(object sender, EventArgs e)
        {
            SetDWallpaper(slika);
        }

        public void SetDWallpaper(string path)
        {
            //setting the wallpaper to the path
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE);
        }
    }
}