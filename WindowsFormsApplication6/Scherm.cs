using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public class Scherm : Form
    {
        public Speelveld speelveld;
        Scorebord scorebord;
        Button reset, help, pas;

        public Scherm()
        {
            speelveld = new Speelveld();
            this.ClientSize = new Size(speelveld.Width + 100, 
                                       speelveld.Height + 300);
            speelveld.Location = new Point(50, ClientSize.Height - 
                                           speelveld.Height - 50);
            scorebord = new Scorebord(this.ClientSize, speelveld);

            reset = new Button();
            reset.Location = new Point(50, 20);
            reset.Text = "Nieuw Spel";
            reset.BackColor = Color.LightGray;
            reset.Click += (sender, e) =>
            {
                speelveld.Leeg();
                speelveld.pasknop = false;
                scorebord.Invalidate();
                speelveld.Invalidate();
            };

            help = new Button();
            help.Location = new Point(150, 20);
            help.Text = "Help";
            help.BackColor = Color.LightGray;
            help.Click += (sender, e) =>
            {
                speelveld.help = !speelveld.help;
                speelveld.Invalidate();
            };

            pas = new Button();
            pas.Location = new Point(250, 20);
            pas.Text = "Overslaan";
            pas.BackColor = Color.LightGray;
            pas.Click += (sender, e) =>
            {
                speelveld.roodbeurt = !speelveld.roodbeurt;
                Controls.Remove(pas);
                scorebord.Invalidate();
            };

            speelveld.MouseClick += (sender, e) =>
            {
                Invalidate();
                scorebord.Invalidate();

                if (speelveld.pasknop)
                    Controls.Add(pas);
                else Controls.Remove(pas);

                if (speelveld.Gameover())
                    Controls.Remove(pas);
            };

            Controls.Add(speelveld);
            Controls.Add(scorebord);
            Controls.Add(reset);
            Controls.Add(help);
        }
    }
}