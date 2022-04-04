using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public static Point Up = new Point(0, -1);
        public static Point Down = new Point(0, 1);
        public static Point Left = new Point(-1, 0);
        public static Point Right = new Point(1, 0);

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
