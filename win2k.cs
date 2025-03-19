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
    public partial class win2k : Form
    {
        public win2k()
        {
            InitializeComponent();
        }

        private void win2k_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 0, 170);
            float height = Screen.PrimaryScreen.Bounds.Width / 640f;
            float wipth = Screen.PrimaryScreen.Bounds.Height / 480f;
            DontFuck(this, height, wipth);
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Paint += new PaintEventHandler(DoTheShit);
        }
        public void DoTheShit(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            string text = $"*** STOP: 0x0000001E (0xC0000005, 0x80467BF4, 0x00000000, 0x00000018)\r\nKMODE_EXCEPTION_NOT_HANDLED\r\n\r\n*** Address 80467BF4 base at 80400000, DateStamp 384d9b17 - ntoskrnl.exe\r\n\r\nIf this is the first time you've seen this Stop error screen,\r\nrestart your computer. If this screen appears again, follow\r\nthese steps:\r\n\r\nCheck to make sure any new hardware or software is properly installed.\r\nIf this is a new installation, ask your hardware or software manufacturer\r\nfor any Windows updates you might need.\r\n\r\nIf problems continue, disable or remove any newly installed hardware\r\nor software. Disable BIOS memory options such as caching or shadowing.\r\nIf you need to use Safe Mode to remove or disable components, restart\r\nyour computer, press F8 to select Advanced Startup Options, and then\r\nselect Safe Mode.\r\n\r\nBeginning dump of physical memory\r\nPhysical memory dump complete.\r\nContact your system administrator or technical support group for further assistance.\r\n";
            Font font = new Font("Lucida Console", 26, FontStyle.Regular);
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
