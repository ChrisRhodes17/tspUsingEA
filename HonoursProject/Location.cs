using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonoursProject
{
    public class Location
    {
        public int idx;
        public double x;
        public double y;


        public Location(int idx, double x, double y)
        {

            this.idx = idx;
            this.x = x;
            this.y = y;
        }

        public String toString()
        {
            return "" + idx + " " + x + " " + y;
        }

        public Location copy()
        {
            Location location = new Location(this.idx, this.x, this.y);
            return location;
        }
    }
}
