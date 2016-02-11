using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSpaceGame
{
    public static class CommonMath
    {
        public static double ToRad(int th)
        {
            return th * Math.PI / 180;
        }
        public static int ToDeg(double th)
        {
            return (int)(th * 180 / Math.PI);
        }
        public static double[] ToVector(int x1, int y1, int x2, int y2)
        {
            double[] retD = new double[2];
            retD[0] = (double)(x2 - x1);
            retD[1] = (double)(y2 - y1);
            return retD;
        }
        public static double Mag(double[] vect)
        {
            return Math.Sqrt(
                Math.Pow(vect[0], 2) +
                Math.Pow(vect[1], 2)
                );
        }
        public static double JointAngle(double[] v1,double[] v2)
        {
            return Math.Acos(
                (v1[0] * v2[0] + v1[1] * v2[1])
                / 
                (CommonMath.Mag(v1) * CommonMath.Mag(v2))
                );
        }
    }

    class StaticClasses
    {
    }
}
