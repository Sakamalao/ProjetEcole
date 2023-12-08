using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_v2
{
    internal class Position
    {
        int x;
        int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string toString()
        {
            return "X: " + x + "\nY: " + y;
        }


    }
}
