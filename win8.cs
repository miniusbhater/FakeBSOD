using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace silly
{
    public partial class win8 : Form
    {
        public win8()
        {
            InitializeComponent();
        }

        private async void win8_Load(object sender, EventArgs e)
        {
            float height = Screen.PrimaryScreen.Bounds.Width / 1920f;
            float wipth = Screen.PrimaryScreen.Bounds.Height / 1080f;
            DontFuck(this, height, wipth);
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            Random rand = new Random();
            int progress = 10;
            int taken = 0;
            int max = 20000;
            label4.Text = $"({progress}% complete)";
            while (progress < 100)
            {
                int delay = rand.Next(200, 1000);
                if (taken + delay > max)
                    delay = max - taken;
                await Task.Delay(delay);
                taken += delay;
                progress += rand.Next(1, 10);
                if (progress > 100) progress = 100;
                label4.Text = $"({progress}% complete)";
            }
        }
        private void DontFuck(Control control, float height, float wipth)
        {
            foreach (Control con in control.Controls)
            {
                con.Left = (int)(con.Left * height);
                con.Top = (int)(con.Top * wipth);
                con.Width = (int)(con.Width * height);
                con.Height = (int)(con.Height * wipth);
                con.Font = new Font(con.Font.FontFamily, con.Font.Size * height);

                if (con.Controls.Count > 0)
                    DontFuck(con, height, wipth);
            }
        }
    }
}
