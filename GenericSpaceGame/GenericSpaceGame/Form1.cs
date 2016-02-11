using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericSpaceGame
{
    public partial class Form1 : Form
    {
        GameGrid gg = new GameGrid();
        PlayerShipArt plShip = new PlayerShipArt();
        public Form1()
        {
            InitializeComponent();
            plShip.Move(500, 500);
            //gg.DrawShip(plShip);
            plShip.Rotate(0);
            gg.DrawShip(plShip);
            //I'm using pictureBox1 to test various drawing things.
            pbtest(gg.currentGrid);

            this.WindowState = FormWindowState.Maximized;
        }

        internal void pbtest(Bitmap testim)
        {
            pictureBox1.Width = testim.Width;
            pictureBox1.Height = testim.Height;
            pictureBox1.Image = testim;
        }
    }
}
