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
    public partial class DikeyAynalama : Form
    {
        string filename;
        public DikeyAynalama()
        {
            InitializeComponent();
        }

        private void DikeyAynalama_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

            Bitmap yimg = new Bitmap(filename);


            int width = yimg.Width;
            int height = yimg.Height;


            pictureBox1.Image = Image.FromFile(filename);

            //aynalanmış resim
            Bitmap mimg = new Bitmap(width, height * 2);

            for (int z = 0; z < width; z++)
            {

                for (int lx = 0, rx = height * 2 - 1; lx < height; lx++, rx--)
                {

                    //get source pixel value
                    Color p = yimg.GetPixel(z, lx);

                    //set mirror pixel value
                    mimg.SetPixel(z, lx, p);
                    mimg.SetPixel(z, rx, p);

                }
            }
            //load mirror image in box2
            pictureBox2.Image = mimg;

            //save (write) mirror image
            mimg.Save("C:\\Users\\MehmetCan\\Desktop\\MirrorImage5.png");
        }
    }
}
