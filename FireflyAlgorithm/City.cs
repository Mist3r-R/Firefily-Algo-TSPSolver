using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireflyAlgorithm
{
    public class City
    {
        public int x;
        public int y;

        public int index;

        public City(int x, int y, int index)
        {
            this.x = x;
            this.y = y;

            this.index = index;
        }

        public static int getDestination(City a, City b)
        {
            return (int)(Math.Sqrt((a.x - b.x)* (a.x - b.x) + (a.y - b.y)* (a.y - b.y)) + 0.5);
        }
    }
}
