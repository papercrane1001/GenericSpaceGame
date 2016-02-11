using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GenericSpaceGame
{
    public class GameGrid
    {
        public Bitmap initialGrid = null;
        private Graphics initGraph = null;
        public Bitmap currentGrid = null;
        private Graphics currGraph = null;

        public GameGrid()
        {
            //Creating the initial grid
            initialGrid = new Bitmap(5000, 5000);
            initGraph = Graphics.FromImage(initialGrid);
            initGraph.FillRectangle(Brushes.AliceBlue, 0, 0, initialGrid.Width, initialGrid.Height);
            for (int i = 1; i < 100; i++)
            {
                initGraph.DrawLine(Pens.Black, (int)(initialGrid.Width / 100 * i), 0, (int)(initialGrid.Width / 100 * i), 4999);
                initGraph.DrawLine(Pens.Black, 0, (int)(initialGrid.Height / 100 * i), 4999, (int)(initialGrid.Height / 100 * i));
            }

            currentGrid = (Bitmap)initialGrid.Clone();
            currGraph = Graphics.FromImage(currentGrid);
        }
        public void DrawShip(ShipArt ship)
        {
            currGraph.DrawImage(ship.activeShip, ship.x, ship.y);
        }
    }

    public class ShipArt
    {
        public int x = 0;
        public int y = 0;
        public double theta = 0;

        public Bitmap initialShip = null;
        public Graphics initGr = null;
        public Bitmap activeShip = null;
        public Graphics actGr = null;

        public GraphicsContainer gC = null;

        public void Move(int newX,int newY)
        {
            x = newX;
            y = newY;
        }
        public void Rotate(double newTh)
        {
            theta = (newTh/180*Math.PI);
            gC = actGr.BeginContainer();
            actGr.RotateTransform(CommonMath.ToDeg(theta));
            int xh = (int)(activeShip.Width / 2);
            int yh = (int)(activeShip.Height / 2);
            int a = (int)(activeShip.Width / 2 - initialShip.Width / 2);
            int b = (int)(activeShip.Height / 2 - initialShip.Height / 2);
            //double test1 = a * Math.Cos(theta);
            //double test2 = -b * Math.Sin(theta);
            //double test3 = activeShip.Width / 2;
            //double test4 = a * Math.Cos(theta) - b * Math.Sin(theta) + activeShip.Width / 2;

            //TODO: need to add initial angle.
            double ja = CommonMath.JointAngle(CommonMath.ToVector(xh, yh, a, b), CommonMath.ToVector(xh, yh, 1, 0));
            int ja2 = (int)ja;
            int apr = (int)(a * Math.Cos(theta+ja2) - b * Math.Sin(theta+ja2) + initialShip.Width / 2);
            int bpr = (int)(a * Math.Sin(theta+ja2) + b * Math.Cos(theta+ja2) + initialShip.Height / 2);

            actGr.FillRectangle(Brushes.Red, x, y, x + 10, y + 10);
            actGr.DrawImage(initialShip, apr, bpr);
            actGr.EndContainer(gC);
        }
    }

    public class PlayerShipArt : ShipArt
    {
                
        public PlayerShipArt()
        {
            initialShip = new Bitmap(50, 25);
            initGr = Graphics.FromImage(initialShip);
            Point[] pts = new Point[3];
            pts[0] = new Point(0, 0);pts[1] = new Point(0, 24);pts[2] = new Point(49, 12);
            initGr.FillPolygon(Brushes.Green, pts);



            activeShip = new Bitmap(100, 100);
            actGr = Graphics.FromImage(activeShip);
        }
    }

    class ArtAssets
    {
    }
}
