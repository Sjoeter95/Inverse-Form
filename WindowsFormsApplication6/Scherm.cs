using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public class Scherm : Form
    {
        public Speelveld speelveld;
        Label beurt;

        public Scherm()
        {
            speelveld = new Speelveld();
            this.ClientSize = new Size(speelveld.Width + 100, 
                                       speelveld.Height + 200);
            
            beurt = new Label();
            speelveld.MouseClick += (sender, e) => {
                if (speelveld.roodbeurt)
                    beurt.Text = "Rood is aan de beurt.";
                else
                    beurt.Text = "Blauw is aan de beurt."; 
                beurt.Invalidate();
            };
            Controls.Add(beurt);
            Controls.Add(speelveld);

        }
    }


}
