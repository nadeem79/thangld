using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beans;

namespace BussinessLayer
{
    public class Map
    {
        public static Beans.Village checkCoord(int x, int y)
        {
            return new Beans.Village();
        }

        public static double range(Beans.Village v1, Beans.Village v2)
        {
            return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
        }

        public static Beans.Village createNewVillage()
        {
            return new Beans.Village();
        }
    }
}
