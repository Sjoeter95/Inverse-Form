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

        public void Tekenvakje(Graphics g, int grootte)
        {
            if (gevuld)
            {
                if (rood)
                    g.FillEllipse(Brushes.Red, x * grootte + 1, y * grootte + 1,
                                  grootte - 2, grootte - 2);
                else
                    g.FillEllipse(Brushes.Blue, x * grootte + 1, y * grootte + 1,
                                  grootte - 2, grootte - 2);
            }
        }
    }
}
