using HonoursProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonoursProject
{
    public class NearestNeighbour
    {
        public static Random random = new Random();
        public List<Individual> population = new List<Individual>();
        public Individual best;

        public string filename = "";

        public NearestNeighbour(string filename)
        {
            Problem problem = new Problem(filename);

            List<Location> solution = new List<Location>();

            double best = 0;
            double lenth = 0;
            int loc = 0;

            solution.Add(problem.depot);

            int solLenth = problem.customers.Count - 1;

            for (int i = 0; i < solLenth; i++)
            {
                best = 0;
                for (int j = 0; j < problem.customers.Count; j++)
                {
                    double temp = calcDistance(solution[solution.Count - 1], problem.customers[j]);
                    if (temp > best)
                    {
                        best = temp;
                        loc = j;
                    }
                }
                solution.Add(problem.customers[loc]);
                problem.customers.RemoveAt(loc);
                lenth += best;
            }

            solution.Add(problem.customers[0]);

            string text = solution[0].idx.ToString();

            for (int i = 1; i < solution.Count; i++)
            {
                text += " " + solution[i].idx;
            }

            Globals.frm1.PrintResults(text);
            Globals.frm1.PrintResults(lenth.ToString());
            Globals.frm1.PrintBest(lenth.ToString());
        }

        public int calcDistance(Location loc1, Location loc2)
        {
            double euclideanDistance = Math.Sqrt(Math.Pow(loc1.x - loc2.x, 2) + Math.Pow(loc1.y - loc2.y, 2));
            return (int)Math.Round(euclideanDistance);
        }

    }
}
