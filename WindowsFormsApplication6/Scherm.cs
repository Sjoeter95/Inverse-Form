using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication6
{
    public class Scherm : Form
    {
        public Speelveld speelveld;

        public Scherm()
        {
            speelveld = new Speelveld();
            this.ClientSize = new Size(speelveld.Width + 100, 
                                       speelveld.Height + 200);
            Controls.Add(speelveld);

        }
    }

    public class Speelveld : UserControl
    {
        int xvakjes = 6, yvakjes = 6;
        int vakjesformaat = 50;
        bool roodbeurt = true;
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
        }

        void Handle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int t = 0; t <= xvakjes; t++)
                g.DrawLine(Pens.Black, t * vakjesformaat, 0, t * vakjesformaat, 
                           yvakjes * vakjesformaat);
            for (int t = 0; t <= yvakjes; t++)
                g.DrawLine(Pens.Black, 0, t * vakjesformaat, 
                           xvakjes * vakjesformaat, t * vakjesformaat);
        }

        void Handle_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.Invalidate();
            if (roodbeurt)
                roodbeurt = false;
            else
                roodbeurt = true;
            Console.WriteLine(roodbeurt);
        }
    }
}
