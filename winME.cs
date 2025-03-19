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
    public partial class winME : Form
    {
        public winME()
        {
            InitializeComponent();
        }

        private void winME_Load(object sender, EventArgs e)
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
            string text = $"*** STOP: 0x0000000A (0xFA473388, 0x00000002, 0x00000000, 0xFA473388)\r\nIRQL_NOT_LESS_OR_EQUAL\r\n*** Address FA473388 has base at FA470000 - sndblst.SYS\r\n\r\np4-0200 irq1:1f DPC SYSVER 0x0000030e\r\n\r\nDll Base    DateStmp    - Name                      Dll Base    DateStmp    - Name\r\n80400000    2f3e5b38    - ntoskrnl.exe              804d8000    2e593b88    - hal.dll\r\nf9a00000    46a2b45f    - PartMgr.sys               f99d8000    2c7bc6e6    - SCSIDISK.SYS\r\nf9a40000    42065513    - Floppy.SYS                f9a38000    2d3a7b5c    - FastFat.SYS\r\nf9a60000    420656a1    - FS_Rec.SYS                f9a70000    42065655    - Null.SYS\r\nf9a80000    42065422    - Beep.SYS                  f9a90000    42065411    - Kbdclass.SYS\r\nf9aa0000    42065410    - Mouclass.SYS              f9ab0000    42065532    - VIDEOPRT.SYS\r\nf9ac0000    41791a79    - NPFS.SYS                  f9ad0000    41791b20    - NDIS.SYS\r\nf9ae0000    41791c91    - NetBIOS.SYS               f9af0000    41791d77    - TCPIP.SYS\r\nf9b00000    41791f2d    - Srv.sys                   fa400000    41792088    - afd.sys\r\nfa410000    41792211    - Smb.sys                   fa420000    41792345    - Parport.SYS\r\nfa430000    41792467    - ParVdm.SYS                fa440000    41792551    - rdbss.sys\r\n\r\nAddress dworq dump - Build 17821\r\n\r\nfcb1e2a8    00000000    00000000    00000000    00000000    FA473388    00000000\r\nfcb1e2ac    00000000    00000000    00000000    00000000    00000000    00000000\r\nfcb1e2b0    00000000    00000000    00000000    00000000    00000000    00000000\r\nfcb1e2b4    804d8a6c    804d8a48    804d8a48    804d8a6c    804d8a48    804d8a6c\r\nfcb1e2b8    804d8a6c    804d8a48    804d8a6c    804d8a48    804d8a6c    804d8a48\r\nfcb1e2bc    804d8a6c    804d8a48    804d8a6c    804d8a48    804d8a6c    804d8a48\r\nfcb1e2c0    804d8a6c    804d8a48    804d8a6c    804d8a48    804d8a6c    804d8a48\r\n\r\nRestart and set the recovery options in the system control panel\r\nor the /CRASHDEBUG system start option. If this message reappears,\r\ncontact your system administrator or technical support group.\r\n";
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
