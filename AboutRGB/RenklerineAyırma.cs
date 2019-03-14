using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AboutRGB
{
    public partial class RenklerineAyırma : Form
    {
        string filename;
        public RenklerineAyırma()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //read image
            Bitmap bmp = new Bitmap(filename);

            //load original image  in picturebox1
            pictureBox1.Image = Image.FromFile(filename);

            //image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //Tek tek RGB değerlerini için
            Bitmap red = new Bitmap(bmp);
            Bitmap green = new Bitmap(bmp);
            Bitmap blue = new Bitmap(bmp);


            //kırmızı,yeşil,mavi resimler
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //pikselleri al
                    Color m = bmp.GetPixel(x, y);

                    int a = m.A;
                    int r = m.R;
                    int g = m.G;
                    int b = m.B;

                    //kırmızı
                    red.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));

                    //yeşil
                    green.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));

                    //mavi
                    blue.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));


                }
            }

            //Form'a eklenmesi
            pictureBox2.Image = red;
            pictureBox3.Image = green;
            pictureBox4.Image = blue;

            //Dosya olarak kayıt edilmesi
            red.Save("C:\\Users\\MehmetCan\\Desktop\\resimler\\Kırmızı.png");
            green.Save("C:\\Users\\MehmetCan\\Desktop\\resimler\\Yesil.png");
            blue.Save("C:\\Users\\MehmetCan\\Desktop\\resimler\\Mavi.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                addresBox.Text = openFileDialog1.FileName;
                filename = addresBox.Text;
            }
        }
    }
}
