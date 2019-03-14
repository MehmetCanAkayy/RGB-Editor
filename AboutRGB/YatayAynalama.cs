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
    public partial class YatayAynalama : Form
    {
        string filename;
        public YatayAynalama()
        {
            InitializeComponent();
        }

        private void Aynalama_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                addresBox.Text = openFileDialog1.FileName;
                filename = addresBox.Text;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Bitmap yimg = new Bitmap(filename);


            int width = yimg.Width;
            int height = yimg.Height;


            pictureBox1.Image = Image.FromFile(filename);

            //aynalanmış resim
            Bitmap mimg = new Bitmap(width * 2, height);

            for (int z = 0; z < height; z++)
            {

                for (int lx = 0, rx = width * 2 - 1; lx < width; lx++, rx--)
                {

                    //get source pixel value
                    Color p = yimg.GetPixel(lx, z);

                    //set mirror pixel value
                    mimg.SetPixel(lx, z, p);
                    mimg.SetPixel(rx, z, p);

                }
            }


            //load mirror image in box2
            pictureBox2.Image = mimg;
            pictureBox1.Image = yimg;

            //save (write) mirror image
            mimg.Save("C:\\Users\\MehmetCan\\Desktop\\MirrorImage3.png");
        }
    }
}

