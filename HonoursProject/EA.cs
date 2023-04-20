using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonoursProject
{
    internal class EA
    {
        
        static void main(string filename)
        {
            string filename;

            Problem problem = new Problem(filename);

            Random random = new Random();

            List<Individual> population = new List<Individual>();
            Individual best;
            int popSize = 500;
            int tournamentSize = 10;
            int maxGenerations = 500000;
            int generation;
            double mutationRate = 0.5;


            // initialise population. The Individual constructor generates a random
            // permutation of customers (Locations)
            for (int i = 0; i < popSize; i++)
            {
                Individual individual = new Individual(problem);
                population.Add(individual);
            }


        }

        



        


    }
}
