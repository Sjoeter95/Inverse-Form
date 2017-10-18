using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public class Speelveld : UserControl
    {
        public int xvakjes = 6, yvakjes = 6;
        public int vakjesformaat = 75;
        public bool roodbeurt = true;
        public bool help = false;
        public bool pasknop = false;
        public Vakje[,] vakjes;

        public Speelveld()
        {
            this.Size = new Size(xvakjes * vakjesformaat + 1,
                                 yvakjes * vakjesformaat + 1);
            this.BackColor = Color.White;
            this.Paint += Handle_Paint;
            this.MouseClick += Handle_MouseClick;
            vakjes = new Vakje[xvakjes , yvakjes ]; 
           
            for (int t = 0; t < xvakjes ; t++) 
            {
                for (int u = 0; u < yvakjes ; u++)
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

        public int[] Scoreteller()
        {
            int[] result = new int[2];
            for (int a = 0; a < xvakjes; a++)
            {
                for (int b = 0; b < yvakjes; b++)
                {
                    if (vakjes[a, b].gevuld && vakjes[a, b].rood)
                        result[0]++;
                    if (vakjes[a, b].gevuld && vakjes[a, b].rood == false)
                        result[1]++;
                }
            }
            return result;
        }

        public void Leeg()
        {
            for (int x = 0; x < xvakjes; x++)
                for (int y = 0; y < yvakjes; y++)
            {
                vakjes[x, y].gevuld = false;
                vakjes[x, y].rood = false;
            }
            

            roodbeurt = true;

            vakjes[(xvakjes - 1) / 2, (yvakjes - 1) / 2].gevuld = true;
            vakjes[(xvakjes - 1) / 2 + 1, (yvakjes - 1) / 2 + 1].gevuld = true;
            vakjes[(xvakjes - 1) / 2, (yvakjes - 1) / 2 + 1].gevuld = true;
            vakjes[(xvakjes - 1) / 2 + 1, (yvakjes - 1) / 2].gevuld = true;
            vakjes[(xvakjes - 1) / 2, (yvakjes - 1) / 2 + 1].rood = true;
            vakjes[(xvakjes - 1) / 2 + 1, (yvakjes - 1) / 2].rood = true;
        }

        private bool Beurtmogelijk(bool beurt)
        {
            for (int x = 0; x < xvakjes; x++)
                for (int y = 0; y < yvakjes; y++)
                    if (vakjes[x, y].Legaal(this, beurt))
                        return true;
            return false;
        }

        public bool Gameover()
        {
            if (!Beurtmogelijk(roodbeurt))
            {
                if (!Beurtmogelijk(!roodbeurt))
                {
                    return true;
                }
            }
            return false;
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
                    vakjes[a, b].Tekenvakje(g, vakjesformaat, this);
                }
            }
        }

        void Handle_MouseClick(object sender, MouseEventArgs e)
        {
            Vakje klikvakje = vakjes[(e.X - 2) / vakjesformaat,
                                     (e.Y - 2) / vakjesformaat];

            if (klikvakje.Legaal(this, roodbeurt))
            {
                klikvakje.gevuld = true;
                if (roodbeurt)
                    klikvakje.rood = true;
                else
                    klikvakje.rood = false;

                klikvakje.Insluiten(this);
                help = false;

                this.Invalidate();

                if (roodbeurt)
                    roodbeurt = false;
                else
                    roodbeurt = true;

                pasknop = !Beurtmogelijk(roodbeurt);  
            }
        }
    }
}