using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public class Speelveld : UserControl
    {
        int xvakjes = 10, yvakjes = 10;
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

            Stapmogelijkcontrole();
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

        void Stapmogelijkcontrole()
            {
            for (int x = 0; x < xvakjes; x++)
                for (int y = 0; y < yvakjes; y++)
                {
                    if (roodbeurt == true && vakjes[x, y].gevuld == true && vakjes[x, y].rood == true)
                    {
                        if (vakjes[x + 1, y].rood == false && vakjes[x + 1, y].gevuld == true)
                            for (int z = 2; x + z < xvakjes; z++)
                                if (vakjes[x + z, y].gevuld == false)
                                {
                                    vakjes[x + z, y].stapmogelijk = true;
                                    z = xvakjes;
                                }
                                else if (vakjes[x + z, y].gevuld == true && vakjes[x + z, y].rood == true)
                                    z = xvakjes;

                        if (vakjes[x - 1, y].rood == false && vakjes[x - 1, y].gevuld == true)
                            for (int z = 2; x - z < 0; z++)
                                if (vakjes[x - z, y].gevuld == false)
                                {
                                    vakjes[x - z, y].stapmogelijk = true;
                                    z = x;
                                }
                                else if (vakjes[x - z, y].gevuld == true && vakjes[x - z, y].rood == true)
                                    z = x;

                        if (vakjes[x, y + 1].rood == false && vakjes[x, y + 1].gevuld == true)
                            for (int z = 2; y + z < yvakjes; z++)
                                if (vakjes[x, y + z].gevuld == false)
                                {
                                    vakjes[x, y + z].stapmogelijk = true;
                                    z = yvakjes;
                                }
                                else if (vakjes[x, y + z].gevuld == true && vakjes[x, y + z].rood == true)
                                    z = yvakjes;

                        if (vakjes[x, y - 1].rood == false && vakjes[x, y - 1].gevuld == true)
                            for (int z = 2; y - z < 0; z++)
                                if (vakjes[x, y - z].gevuld == false)
                                {
                                    vakjes[x, y - z].stapmogelijk = true;
                                    z = y;
                                }
                                else if (vakjes[x, y - z].gevuld == true && vakjes[x, y - z].rood == true)
                                    z = y;

                        if (vakjes[x + 1, y + 1].rood == false && vakjes[x + 1, y + 1].gevuld == true)
                            for (int z = 2; x + z < xvakjes && y + z < yvakjes; z++)
                                if (vakjes[x + z, y + z].gevuld == false)
                                {
                                    vakjes[x + z, y + z].stapmogelijk = true;
                                    z = xvakjes = yvakjes;
                                }
                                else if (vakjes[x + z, y + z].gevuld == true && vakjes[x + z, y + z].rood)
                                    z = xvakjes + yvakjes;
                        if (vakjes[x - 1, y - 1].rood == false && vakjes[x - 1, y - 1].gevuld == true)
                            for (int z = 2; x - z < 0 && y - z < 0; z++)
                                if (vakjes[x - z, y - z].gevuld == false)
                                {
                                    vakjes[x - z, y - z].stapmogelijk = true;
                                    z = x;
                                }
                                else if (vakjes[x - z, y - z].gevuld == true && vakjes[x - z, y - z].rood == true)
                                    z = x;
                        if (vakjes[x - 1, y + 1].rood == false && vakjes[x - 1, y + 1].gevuld == true)
                            for (int z = 2; x - z < 0 && y + z < yvakjes; z++)
                                if (vakjes[x - z, y + z].gevuld == false)
                                {
                                    vakjes[x - z, y + z].stapmogelijk = true;
                                    z = x;
                                }
                                else if (vakjes[x - z, y + z].gevuld == true && vakjes[x - z, y + z].rood == true)
                                    z = x;
                        if (vakjes[x + 1, y - 1].rood == false && vakjes[x + 1, y - 1].gevuld == true)
                            for (int z = 2; x + z < xvakjes && y - z < 1 && vakjes[x + z, y - z].rood; z++)
                                if (vakjes[x + z, y - z].gevuld == false)
                                {
                                    vakjes[x + z, y - z].stapmogelijk = true;
                                    z = y;
                                }
                                else if (vakjes[x + z, y - z].gevuld == true && vakjes[x + z, y - z].rood == true)
                                    z = y;
                    }

                    else if (roodbeurt == false && vakjes[x, y].gevuld == true && vakjes[x, y].rood == false)
                    {
                        if (vakjes[x + 1, y].rood == true && vakjes[x + 1, y].gevuld == true)
                            for (int z = 2; x + z < xvakjes; z++)
                                if (vakjes[x + z, y].gevuld == false)
                                {
                                    vakjes[x + z, y].stapmogelijk = true;
                                    z = xvakjes;
                                }
                                else if (vakjes[x + z, y].gevuld == true && vakjes[x + z, y].rood == false)
                                    z = xvakjes;

                        if (vakjes[x - 1, y].rood == true && vakjes[x - 1, y].gevuld == true)
                            for (int z = 2; x - z < 0; z++)
                                if (vakjes[x - z, y].gevuld == false)
                                {
                                    vakjes[x - z, y].stapmogelijk = true;
                                    z = x;
                                }
                                else if (vakjes[x - z, y].gevuld == true && vakjes[x - z, y].rood == false)
                                    z = x;

                        if (vakjes[x, y + 1].rood == true && vakjes[x, y + 1].gevuld == true)
                            for (int z = 2; y + z < yvakjes; z++)
                                if (vakjes[x, y + z].gevuld == false)
                                {
                                    vakjes[x, y + z].stapmogelijk = true;
                                    z = yvakjes;
                                }
                                else if (vakjes[x, y + z].gevuld == true && vakjes[x, y + z].rood == false)
                                    z = yvakjes;

                        if (vakjes[x, y - 1].rood == true && vakjes[x, y - 1].gevuld == true)
                            for (int z = 2; y - z < 0; z++)
                                if (vakjes[x, y - z].gevuld == false)
                                {
                                    vakjes[x, y - z].stapmogelijk = true;
                                    z = y;
                                }
                                else if (vakjes[x, y - z].gevuld == true && vakjes[x, y - z].rood == false)
                                    z = y;

                        if (vakjes[x + 1, y + 1].rood == true && vakjes[x + 1, y + 1].gevuld == true)
                            for (int z = 2; x + z < xvakjes && y + z < yvakjes; z++)
                                if (vakjes[x + z, y + z].gevuld == false)
                                {
                                    vakjes[x + z, y + z].stapmogelijk = true;
                                    z = xvakjes + yvakjes;
                                }
                                else if (vakjes[x + z, y + z].gevuld == true && vakjes[x + z, y + z].rood == false)
                                    z = xvakjes + yvakjes;

                        if (vakjes[x - 1, y - 1].rood == true && vakjes[x - 1, y - 1].gevuld == true)
                            for (int z = 2; x - z < 0 && y - z < 0; z++)
                                if (vakjes[x - z, y - z].gevuld == false)
                                {
                                    vakjes[x - z, y - z].stapmogelijk = true;
                                    z = x;
                                }
                                else if (vakjes[x - z, y - z].gevuld == true && vakjes[x - z, y - z].rood == false)
                                    z = x;

                        if (vakjes[x - 1, y + 1].rood == true && vakjes[x - 1, y + 1].gevuld == true)
                            for (int z = 2; x - z < 0 && y + z < yvakjes; z++)
                                if (vakjes[x - z, y + z].gevuld == false)
                                {
                                    vakjes[x - z, y + z].stapmogelijk = true;
                                    z = x;
                                }
                                else if (vakjes[x - z, y + z].gevuld == true && vakjes[x - z, y + z].rood == false)
                                    z = x;
                        if (vakjes[x + 1, y - 1].rood == true && vakjes[x + 1, y - 1].gevuld == true)
                            for (int z = 2; x + z < xvakjes && y - z < 1; z++)
                                if (vakjes[x + z, y - z].gevuld == false)
                                {
                                    vakjes[x + z, y - z].stapmogelijk = true;
                                    z = y;
                                }
                                else if (vakjes[x + z, y - z].gevuld == true && vakjes[x + z, y - z].rood == false)
                                    z = y;
                    }
                }
                        
                        

                    
                        
            }

        void Handle_MouseClick(object sender, MouseEventArgs e)
        {
            Vakje klikvakje = vakjes[(e.X-2) / vakjesformaat , (e.Y-2) / vakjesformaat ];

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

            for (int x = 1; x < xvakjes; x++)
                for (int y = 1; y < yvakjes; y++)
                    vakjes[x, y].stapmogelijk = false;

                    Stapmogelijkcontrole();
        }
    }
}
