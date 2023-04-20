using HonoursProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonoursProject
{
    public class Individual
    {
        public Location depot;
        public List<Location> chromosome = new List<Location>();
        public double fitness = -1;

        public Individual()
        {

        }

        public Individual(Problem problem)
        {

            depot = problem.depot;

            List<Location> chromoCopy = new List<Location>();
            for (int i = 0; i < problem.customers.Count(); i++)
            {
                Location l = problem.customers[i];
                Location locCopy = new Location(l.idx, l.x, l.y);
                chromoCopy.Add(locCopy);
            }
            while (chromoCopy.Count() > 0)
            {
                int idx = EvolutionaryAlgorithm.random.Next(chromoCopy.Count);
                chromosome.Add(chromoCopy[idx]);
                chromoCopy.RemoveAt(idx);
            }
            evaluate();
        }


        public void evaluate()
        {
            double distance = calcDistance(depot, chromosome[0]);
            for (int i = 0; i < chromosome.Count() - 1; i++)
            {
                distance += calcDistance(chromosome[i], chromosome[i + 1]);
            }
            distance += calcDistance(chromosome[chromosome.Count() - 1], depot);
            fitness = distance;
        }


        public int calcDistance(Location loc1, Location loc2)
        {
            double euclideanDistance = Math.Sqrt(Math.Pow(loc1.x - loc2.x, 2) + Math.Pow(loc1.y - loc2.y, 2));
            return (int)Math.Round(euclideanDistance);
        }


        public String toString()
        {
            String str = "" + depot.idx;
            foreach (Location l in chromosome)
            {
                str += ", " + l.idx ;
            }
            //str += fitness;
            return str;
        }


        public Individual copy()
        {
            Individual individual = new Individual();
            individual.depot = this.depot;
            individual.chromosome = new List<Location>();
            foreach (Location loc in this.chromosome)
            {
                Location locCopy = loc.copy();
                individual.chromosome.Add(locCopy);
            }
            individual.fitness = this.fitness;
            return individual;
        }



        public Boolean contains(Location location)
        {
            for (int i = 0; i < chromosome.Count(); i++)
            {
                if (chromosome[i] != null && location != null)
                {
                    try
                    {
                        if (chromosome[i].idx == location.idx)
                        {
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        // TODO Auto-generated catch block
                        //e.PrintStackTrace();
                    }
                }
            }
            return false;
        }
    }
}
