using HonoursProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HonoursProject
{
    public class Problem
    {
        public Location depot;
        public List<Location> customers = new List<Location>();


        public Problem(string filename)
        {

            int id = 0;
            double x = 0;
            double y = 0;

            foreach (string line in System.IO.File.ReadLines(filename))
            {
                Regex rgx = new Regex("\\s+");
                string[] words = rgx.Split(line);
                //string[] words = line.Split(' ', '\t', '\n');

                if (words.Length == 3)
                {
                    id = Int32.Parse(words[0]);
                    x = Convert.ToDouble(words[1]);
                    y = Convert.ToDouble(words[2]);

                    if (id == 1)
                    {
                        depot = new Location(id, x, y);
                    }
                    else
                    {
                        Location loc = new Location(id, x, y);
                        customers.Add(loc);
                    }
                }
            }
        }


        public String toString()
        {
            String str = depot.toString() + "\r\n";
            foreach (Location l in customers)
            {
                str += l.toString() + "\r\n";
            }
            return str;
        }
    }
}
