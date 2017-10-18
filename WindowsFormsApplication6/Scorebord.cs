using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication6
{
    public class Scorebord : UserControl
    {
        int bolgrootte = 50;
        Speelveld s;
        
        public Scorebord(Size schermformaat, Speelveld speelveld)
        {
            int schermbreedte = schermformaat.Width;
            s = speelveld;
            this.Size = new Size(300, 175);
            this.Location = new Point(50, schermformaat.Height - 
                                      speelveld.Height - 225);
            this.Invalidate();
            this.Paint += Handle_Paint;
        }

        public void Handle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            string rood, blauw, beurt;
            Brush beurtkleur;

            if (s.Scoreteller()[0] == 1)
                rood = " Rode steen";
            else rood = " Rode stenen";

            if (s.Scoreteller()[1] == 1)
                blauw = " Blauwe steen";
            else blauw = " Blauwe stenen";

            if (s.roodbeurt)
            {
                beurt = "Rood is aan de beurt";
                beurtkleur = Brushes.Red;
            }
            else
            {
                beurt = "Blauw is aan de beurt";
                beurtkleur = Brushes.Blue;
            }

            if (!s.Gameover())
            {
                g.FillEllipse(Brushes.Red, 0, 0, bolgrootte, bolgrootte);
                g.FillEllipse(Brushes.Blue, 0, bolgrootte + 10, 
                              bolgrootte, bolgrootte);
                g.DrawString(s.Scoreteller()[0] + rood,
                             new Font("Tahoma", 12), Brushes.Red,
                             new PointF(bolgrootte + 5, (bolgrootte - 16) / 2));
                g.DrawString(s.Scoreteller()[1] + blauw,
                             new Font("Tahoma", 12), Brushes.Blue,
                             new PointF(bolgrootte + 5, bolgrootte + 10 +
                                        (bolgrootte - 16) / 2));
                g.DrawString(beurt, new Font("Tahoma", 12, FontStyle.Bold), 
                             beurtkleur, new PointF(bolgrootte + 5, 2 * 
                                                    bolgrootte + 10 + 
                                                    (bolgrootte - 16) / 2));
            }

            else if (s.Gameover())
            {
                string winnaar;
                Brush winnaarkleur;

                if (s.Scoreteller()[0] > s.Scoreteller()[1])
                {
                    winnaar = "Rood wint!";
                    winnaarkleur = Brushes.Red;
                }
                else if (s.Scoreteller()[0] == s.Scoreteller()[1])
                {
                    winnaar = "Remise!";
                    winnaarkleur = Brushes.Black;
                }
                else
                {
                    winnaar = "Blauw wint!";
                    winnaarkleur = Brushes.Blue;
                }

                g.DrawString(s.Scoreteller()[0] + rood,
                             new Font("Tahoma", 12), Brushes.Red,
                             new PointF(bolgrootte + 5, 50));
                g.DrawString(s.Scoreteller()[1] + blauw,
                             new Font("Tahoma", 12), Brushes.Blue,
                             new PointF(bolgrootte + 5, 75));

                g.DrawString("Game Over!", new Font("Tahoma", 20, 
                                                    FontStyle.Bold), 
                             winnaarkleur,new PointF(50,0));
                g.DrawString(winnaar, new Font("Tahoma", 12, FontStyle.Bold), 
                             winnaarkleur, new PointF(bolgrootte + 5, 125));
            }
        }
    }
}