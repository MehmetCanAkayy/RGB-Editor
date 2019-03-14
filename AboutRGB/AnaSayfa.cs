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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RenklerineAyırma f1 = new RenklerineAyırma();
            f1.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YatayAynalama f2 = new YatayAynalama();
            f2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DikeyAynalama f3 = new DikeyAynalama();
            f3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KenarBulma f3 = new KenarBulma();
            f3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GaussianBlur f3 = new GaussianBlur();
            f3.Visible = true;
        }
    }
}
