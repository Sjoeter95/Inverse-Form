using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public class Speelveld : UserControl
    {
        int xvakjes = 6, yvakjes = 6;
        public int vakjesformaat = 75;
        public bool roodbeurt = true;
        Vakje[,] vakjes;

        public Speelveld()
        {
            this.Size = new Size(xvakjes * vakjesformaat + 1,
                                 yvakjes * vakjesformaat + 1);
            this.Location = new Point(50, 150);
            this.BackColor = Color.White;
            this.Paint += Handle_Paint;
            this.MouseClick += Handle_MouseClick;
            vakjes = new Vakje[xvakjes, yvakjes];
            for (int t = 0; t < xvakjes; t++)
            {
                for (int u = 0; u < yvakjes; u++)
                {
                    vakjes[t, u] = new Vakje(t, u);
                }
            }
            vakjes[(xvakjes - 1) / 2, (yvakjes - 1) / 2].gevuld = true;
            vakjes[(xvakjes - 1) / 2 + 1, (yvakjes - 1) / 2 + 1].gevuld = true;
            vakjes[(xvakjes - 1) / 2, (yvakjes - 1) / 2 + 1].gevuld = true;
            vakjes[(xvakjes - 1) / 2 + 1, (yvakjes - 1) / 2].gevuld = true;
            vakjes[(xvakjes - 1) / 2, (yvakjes - 1) / 2 + 1].rood = true;
            vakjes[(xvakjes - 1) / 2 + 1, (yvakjes - 1) / 2].rood = true;
        }

        void Handle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Brushes.Black, 2);
            for (int t = 0; t <= xvakjes; t++)
            {
                g.DrawLine(pen, t * vakjesformaat, 0, t * vakjesformaat,
                           yvakjes * vakjesformaat);
            }

            for (int t = 0; t <= yvakjes; t++)
                g.DrawLine(pen, 0, t * vakjesformaat,
                           xvakjes * vakjesformaat, t * vakjesformaat);

            for (int a = 0; a < xvakjes; a++)
            {
                for (int b = 0; b < yvakjes; b++)
                {
                    vakjes[a, b].Tekenvakje(g, vakjesformaat);
                }
            }

        }

        void Handle_MouseClick(object sender, MouseEventArgs e)
        {
            Vakje klikvakje = vakjes[(e.X-2) / vakjesformaat, (e.Y-2) / vakjesformaat];

            if (klikvakje.Legaal(vakjes))
            {
                klikvakje.gevuld = true;
                if (roodbeurt)
                    klikvakje.rood = true;
                else
                    klikvakje.rood = false;
                this.Invalidate();
                if (roodbeurt)
                    roodbeurt = false;
                else
                    roodbeurt = true;
            }
        }
    }
}
