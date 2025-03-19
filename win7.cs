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
    public partial class win7 : Form
    {
        private int progress = 5;
        private System.Windows.Forms.Timer refresh;
        public win7()
        {
            InitializeComponent();
        }

  
        
        public async void win7_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 0, 170);
            float height = Screen.PrimaryScreen.Bounds.Width / 1920f;
            float wipth = Screen.PrimaryScreen.Bounds.Height / 1080f;
            DontFuck(this, height, wipth);
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Paint += new PaintEventHandler(DoTheShit);
            refresh = new System.Windows.Forms.Timer();
            refresh.Interval = 500;
            refresh.Tick += (s, ev) => this.Invalidate();
            refresh.Start();
            Random rand = new Random();
            int taken = 5;
            int max = 20000;
            while (progress < 100)
            {
                int delay = rand.Next(200, 1000);
                if (taken + delay > max)
                    delay = max - taken;
                await Task.Delay(delay);
                taken += delay;
                progress += rand.Next(5, 5);
                if (progress > 100) progress = 100;
            }
            progress = 100;
            this.Invalidate();
            refresh.Stop();
        }

        public void DoTheShit(object sender, PaintEventArgs e)
        {           
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            string text = $"A problem has been detected and Windows has been shut down to prevent damage \nto your computer.\n\n\nIf this is the first time you've seen this Stop error screen,\nrestart your computer. If this screen appears again, follow\nthese steps:\n\n\nCheck to make sure any new hardware or software is properly installed.\nIf this is a new installation, ask your hardware or software manufacture\nfor any windows updates you might need.\n\n\nIf problems continue disable or remove any newwly installed hardware\nor software. Disable BIOS memory options such as caching or shadowing.\nIf you need to use Safe Mode to remove or disable components, restart\nyour computer, press F8 to select Advanced Startup Options, and then\nselect Safe Mode.\n\n\nTechnical information:\n\n\n*** STOP: 0x0000007B (0xFFFFF880009A9928, 0xFFFFFFFFC0000034, 0x0000000000000000, 0x0000000000000000)\n\n\n\n\nCollecting data for crash dump...\nInitializing disk for crash dump...\nBeginning dump of physical memory.\nDumping physical memory to disk: {progress}\nPhysical memory dump complete.\nContact your system admin or technical support group for further assistance.";
            Font font = new Font("Lucida Console", 28, FontStyle.Regular);
            SizeF size = g.MeasureString(text, font);
            float scale = this.ClientSize.Width / size.Width;
            g.ScaleTransform(scale, 1.0f);
            g.DrawString(text, font, Brushes.White, new PointF(0, 100));
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
