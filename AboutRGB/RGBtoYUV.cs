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
    public partial class RGBtoYUV : Form
    {
        string filename;
        public RGBtoYUV()
        {
            InitializeComponent();
        }

        private void addresBox_TextChanged(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(filename);
            int width = bmp.Width;
            int height = bmp.Height;


            for (int a = 0; a < height; a++)
            {
                for (int x = 0; x < width; x++)
                {
                    //pikselleri al
                    Color m = bmp.GetPixel(x, a);

                    int r = m.R;
                    int g = m.G;
                    int b = m.B;

                    double y = r * .299000 + g * .587000 + b * .114000;
                    double u = r * -.168736 + g * -.331264 + b * .500000 + 128;
                    double v = r * .500000 + g * -.418688 + b * -.081312 + 128;




                }
            }

            //Form'a eklenmesi
            //pictureBox1.Image = red;

            //Dosya olarak kayıt edilmesi
            // red.Save("C:\\Users\\MehmetCan\\Desktop\\resimler\\Kırmızı.png");



        }
    }
}
