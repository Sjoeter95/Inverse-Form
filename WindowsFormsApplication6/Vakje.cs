using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public class Vakje
    {
        int x, y;
        public bool gevuld, rood;

        public Vakje(int a, int b)
        {
            x = a;
            y = b;
            gevuld = false;
            rood = false;
        }

        public void Tekenvakje(Graphics g, int grootte, Speelveld speelveld)
        {
            if (gevuld)
            {
                if (rood)
                    g.FillEllipse(Brushes.Red, x * grootte + 1, y * grootte + 1,
                                  grootte - 2, grootte - 2);
                else
                    g.FillEllipse(Brushes.Blue, x * grootte + 1, 
                                  y * grootte + 1, grootte - 2, grootte - 2);
            }
            else if (this.Legaal(speelveld, speelveld.roodbeurt) && 
                     speelveld.help)
                g.FillEllipse(Brushes.LightGray, x * grootte + 1, 
                              y * grootte + 1, grootte - 2, grootte - 2);
        }

        public bool Legaal(Speelveld speelveld, bool roodbeurt)
        {
            Vakje[,] vakjes = speelveld.vakjes;
            bool ingesloten;

            if (this.gevuld)
                return false;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int di = i, dj = j;
                    ingesloten = false;

                    while (x + di >= 0 && x + di < speelveld.xvakjes &&
                           y + dj >= 0 && y + dj < speelveld.yvakjes) //
                    {
                        if (vakjes[x + di, y + dj].gevuld &&
                            vakjes[x + di, y + dj].rood != roodbeurt)
                        {
                            ingesloten = true;
                        }

                        else if (vakjes[x + di, y + dj].gevuld &&
                                 vakjes[x + di, y + dj].rood == roodbeurt &&
                                 ingesloten)
                            return true;

                        else break;

                        di = di + i;
                        dj = dj + j;
                    }
                }
            }
            return false;
        }

        public void Insluiten(Speelveld speelveld)
        {
            Vakje[,] vakjes = speelveld.vakjes;
            bool ingesloten;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int di = i, dj = j;
                    ingesloten = false;
                    int ingeslotenn = 0;

                    while (x + di >= 0 && x + di < speelveld.xvakjes &&
                           y + dj >= 0 && y + dj < speelveld.yvakjes) //
                    {
                        if (vakjes[x + di, y + dj].gevuld &&
                            vakjes[x + di, y + dj].rood != speelveld.roodbeurt)
                        {
                            ingesloten = true;
                            ingeslotenn++;
                        }

                        else if (vakjes[x + di, y + dj].gevuld &&
                                 vakjes[x + di, y + dj].rood == 
                                 speelveld.roodbeurt && ingesloten)
                        {
                            for (int t = 1; t <= ingeslotenn; t++)
                            {
                                vakjes[x + i * t, y + j * t].rood = 
                                    speelveld.roodbeurt;
                            }
                            break;
                        }

                        else break;

                        di = di + i;
                        dj = dj + j;
                    }
                }
            }
        }
    }
}