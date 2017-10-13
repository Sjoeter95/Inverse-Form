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
        Speelveld speelveld;

        public Scherm()
        {
            speelveld = new Speelveld();
            this.ClientSize = new Size(speelveld.Width + 200, 
                                       speelveld.Height + 200);
            Controls.Add(speelveld);

        }
    }

    public class Speelveld : UserControl
    {
        int xvakjes = 6, yvakjes = 6;

        public Speelveld()
        {
            this.Size = new Size(xvakjes * 50, yvakjes * 50);
            this.Location = new Point(100, 100);
            this.BackColor = Color.White;
        }
    }
}
