using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSpaceGame
{
    public class Node
    {
        bool visited = false;
        bool current = false;
        bool initial = false;
        bool end = false;
        double distance = 99999;
        int x;
        int y;
        List<Node> neighbors = new List<Node>();

        Node(int setx, int sety)
        {
            x = setx;
            y = sety;
        }

        void CheckDistance(double newDistance)
        {
            distance = (distance < newDistance) ? distance : newDistance;
        }
        public double DistanceToNode(Node n)
        {
            return CommonMath.Distance(this.x, this.y, n.x, n.y);
        }
    }
    class NodeList
    {
        List<Node> nlst = new List<Node>();

    }
}
