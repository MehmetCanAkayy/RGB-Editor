using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AboutRGB
{
    public partial class KenarBulma : Form
    {
        Bitmap bmp;
        String filename;
        public KenarBulma()
        {
            InitializeComponent();
        }
        private Bitmap cbmp
        {
            get
            {
                if (bmp == null)
                {
                    bmp = new Bitmap(1, 1);
                }
                return bmp;
            }
            set
            {
                bmp = value;
            }
        }


        //Sobel Dikey konvolüsyonu
        private static double[,] xSobel
        {
            get
            {
                return new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };
            }
        }

        //Sobel Yatay konvolüsyonu
        private static double[,] ySobel
        {
            get
            {
                return new double[,]
                {
                    {  1,  2,  1 },
                    {  0,  0,  0 },
                    { -1, -2, -1 }
                };
            }
        }

        private static Bitmap ConvolutionFilter(Bitmap sourceImage, double[,] xkernel, double[,] ykernel, double factor = 1, int bias = 0, bool grayscale = false)
        {

            //Değişkenlerde saklanan görüntü boyutları
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            //Kaynak görüntü bitlerini kayıt eder
            BitmapData srcData = sourceImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            //Görüntüdeki toplam byte hesabı
            int bytes = srcData.Stride * srcData.Height;

            //Resimdeki pikselleri saklamak için dizi
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            //İlk pikselin adresi
            IntPtr srcScan0 = srcData.Scan0;

            //resmin ilk adresini kopyalama diziye
            Marshal.Copy(srcScan0, pixelBuffer, 0, bytes);

            sourceImage.UnlockBits(srcData);

            //Resmi Griye çevirme
            if (grayscale == true)
            {
                float rgb = 0;
                for (int i = 0; i < pixelBuffer.Length; i += 4)
                {
                    rgb = pixelBuffer[i] * .21f;
                    rgb += pixelBuffer[i + 1] * .71f;
                    rgb += pixelBuffer[i + 2] * .071f;
                    pixelBuffer[i] = (byte)rgb;
                    pixelBuffer[i + 1] = pixelBuffer[i];
                    pixelBuffer[i + 2] = pixelBuffer[i];
                    pixelBuffer[i + 3] = 255;
                }
            }

            
            double xr = 0.0;
            double xg = 0.0;
            double xb = 0.0;
            double yr = 0.0;
            double yg = 0.0;
            double yb = 0.0;
            double rt = 0.0;
            double gt = 0.0;
            double bt = 0.0;

           
            int filterOffset = 1;
            int calcOffset = 0;
            int byteOffset = 0;

            
            for (int OffsetY = filterOffset; OffsetY < height - filterOffset; OffsetY++)
            {
                for (int OffsetX = filterOffset; OffsetX < width - filterOffset; OffsetX++)
                {
                   
                    xr = xg = xb = yr = yg = yb = 0;
                    rt = gt = bt = 0.0;

                    
                    byteOffset = OffsetY * srcData.Stride + OffsetX * 4;
                    
                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + filterX * 4 + filterY * srcData.Stride;
                            xb += (double)(pixelBuffer[calcOffset]) * xkernel[filterY + filterOffset, filterX + filterOffset];
                            xg += (double)(pixelBuffer[calcOffset + 1]) * xkernel[filterY + filterOffset, filterX + filterOffset];
                            xr += (double)(pixelBuffer[calcOffset + 2]) * xkernel[filterY + filterOffset, filterX + filterOffset];
                            yb += (double)(pixelBuffer[calcOffset]) * ykernel[filterY + filterOffset, filterX + filterOffset];
                            yg += (double)(pixelBuffer[calcOffset + 1]) * ykernel[filterY + filterOffset, filterX + filterOffset];
                            yr += (double)(pixelBuffer[calcOffset + 2]) * ykernel[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    
                    bt = Math.Sqrt((xb * xb) + (yb * yb));
                    gt = Math.Sqrt((xg * xg) + (yg * yg));
                    rt = Math.Sqrt((xr * xr) + (yr * yr));

                    
                    if (bt > 255) bt = 255;
                    else if (bt < 0) bt = 0;
                    if (gt > 255) gt = 255;
                    else if (gt < 0) gt = 0;
                    if (rt > 255) rt = 255;
                    else if (rt < 0) rt = 0;

                   
                    resultBuffer[byteOffset] = (byte)(bt);
                    resultBuffer[byteOffset + 1] = (byte)(gt);
                    resultBuffer[byteOffset + 2] = (byte)(rt);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

           
            Bitmap resultImage = new Bitmap(width, height);

            BitmapData resultData = resultImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

           
            resultImage.UnlockBits(resultData);

            
            return resultImage;
        }


        private void KenarBulma_Load(object sender, EventArgs e)
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
            bmp = ConvolutionFilter(yimg, xSobel, ySobel, 1.0, 0, true);
            Invalidate();

            pictureBox2.Image = bmp;
            pictureBox1.Image = yimg;
           
        }
    }
}
