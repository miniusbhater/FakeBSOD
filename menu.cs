using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace silly
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            win8 win8 = new win8();
            win8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            win7 win7 = new win7();
            win7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            win7 win7 = new win7();
            win7.Show(); //the BSOD is practically identical so this will do >:3
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WinXP winXP = new WinXP();
            winXP.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            win2k Win2k = new win2k();
            Win2k.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            winME WinME = new winME();
            WinME.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }
    }
}
