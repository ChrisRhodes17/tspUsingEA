using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonoursProject
{
    internal class EvolutionaryAlgorithm
    {
        public static Random random = new Random();

        List<Individual> population = new List<Individual>();
        Individual best;
        int popSize = 500;
        int tournamentSize = 10;
        int maxGenerations = 10;
        int generation;
        double mutationRate = 0.5;

        
        public EvolutionaryAlgorithm(string filename, int formPopSize, int formTournamentSize, int formMaxGenerations, double formMutationRate, string mutationOp, string crossoverOp)
        {
            Problem problem = new Problem(filename);

            popSize = formPopSize;
            tournamentSize = formTournamentSize;
            maxGenerations = formMaxGenerations;
            mutationRate = formMutationRate;

            // initialise population. The Individual constructor generates a random
            // permutation of customers (Locations)
            for (int i = 0; i < popSize; i++)
            {
                Individual individual = new Individual(problem);
                population.Add(individual);
            }

            best = getBest();
            generation = 0;
            while (generation < maxGenerations)
            {
                generation++;
                Individual parent1 = select();  
                Individual parent2 = select();
                List<Individual> children = null;

                //random.Next(2) == 1
                if (crossoverOp == "OXcrossover")
                {
                    children = OXcrossover(parent1, parent2);
                }
                else if (crossoverOp == "PmxCrossover")
                {
                    children = pmxCrossover(parent1, parent2);
                }
                else
                {
                    children = crossover(parent1, parent2, problem);
                }

                if (random.NextDouble() < mutationRate)
                {
                    //random.Next(2) == 1
                    if (mutationOp == "Mutate2Opt")
                    {
                        children = mutate2Opt(children);
                    }
                    else if (mutationOp == "Scramble Mutation")
                    {
                        children = scrambleMutation(children);
                    }
                    else 
                    {
                        children = mutate(children);
                    }
                    
                }

                foreach (Individual child in children)
                {
                    child.evaluate();
                    replace(child);
                }

                printStats(generation);
                //setChanged();
                //notifyObservers(best);

            }
                        
            Globals.frm1.PrintResults(best.toString());
            Globals.frm1.PrintBest(best.fitness.ToString());
        }


        private List<Individual> mutate2Opt(List<Individual> children)
        {
            List<Individual> result = new List<Individual>();

            foreach (Individual child in children)
            {
                int cut1 = random.Next(child.chromosome.Count() - 1);
                int cut2 = cut1 + random.Next(child.chromosome.Count() - cut1);
                Individual individual = new Individual();
                int i = 0;
                for (i = 0; i < cut1; i++)
                {
                    individual.chromosome.Add(child.chromosome[i]);
                }
                for (int k = cut2; k >= cut1; k--)
                {
                    individual.chromosome.Add(child.chromosome[k]);
                    i++;
                }
                for (i = cut2 + 1; i < child.chromosome.Count(); i++)
                {
                    individual.chromosome.Add(child.chromosome[i]);
                }
                individual.depot = child.depot;
                result.Add(individual);
            }
            return result;
        }

        private void printStats(int generation)
        {
            string stats = generation + "\t" + best.fitness;

            Globals.frm1.PrintResults(stats);
        }

        private Individual getBest()
        {
            Individual bestInPop = null;
            foreach (Individual individual in population)
            {
                if (bestInPop == null || individual.fitness < bestInPop.fitness)
                {
                    bestInPop = individual;
                }
            }
            return bestInPop.copy();
        }

        private Individual getWorst()
        {
            Individual worstInPop = null;
            foreach (Individual individual in population)
            {
                if (worstInPop == null || individual.fitness > worstInPop.fitness)
                {
                    worstInPop = individual;
                }
            }
            return worstInPop;
        }

        private void replace(Individual child)
        {
            Individual worst = getWorst();
            if (child.fitness < worst.fitness)
            {
                population[population.IndexOf(worst)] = child;
                if (child.fitness < best.fitness)
                {
                    best = child.copy();
                }
            }
        }

        // swap two locations
        private List<Individual> mutate(List<Individual> children)
        {

            foreach (Individual child in children)
            {
                Location temp;
                int idx1 = random.Next(child.chromosome.Count());
                int idx2 = random.Next(child.chromosome.Count());

                temp = child.chromosome[idx1];
                child.chromosome[idx1] = child.chromosome[idx2];
                child.chromosome[idx2] = temp;
            }
            return children;
        }

        private List<Individual> pmxCrossover(Individual parent1, Individual parent2)
        {
            int xPoint1 = random.Next(parent1.chromosome.Count());
            int xPoint2 = random.Next(parent1.chromosome.Count());
            if (xPoint1 > xPoint2)
            {
                int temp = xPoint1;
                xPoint1 = xPoint2;
                xPoint2 = temp;
            }

            Individual child1 = new Individual();
            child1.depot = parent1.depot;
            child1.chromosome = new List<Location>();
            Individual child2 = new Individual();
            child2.depot = parent1.depot;
            child2.chromosome = new List<Location>();
            for (int i = 0; i < parent1.chromosome.Count(); i++)
            {
                child1.chromosome.Add(null);
                child2.chromosome.Add(null);
            }

            // crossover between cut points
            for (int i = xPoint1; i <= xPoint2; i++)
            {
                child1.chromosome[i] = parent2.chromosome[i];
                child2.chromosome[i] = parent1.chromosome[i];
            }

            // fill up to xpoint1 from original parent if possible
            for (int i = 0; i < xPoint1; i++)
            {
                if (!child1.contains(parent1.chromosome[i]))
                {
                    child1.chromosome[i] = parent1.chromosome[i];
                }
                if (!child2.contains(parent2.chromosome[i]))
                {
                    child2.chromosome[i] = parent2.chromosome[i];
                }
            }

            // fill from after xpoint2 from original parent if possible
            for (int i = xPoint2 + 1; i < parent1.chromosome.Count(); i++)
            {
                if (!child1.contains(parent1.chromosome[i]))
                {
                    child1.chromosome[i] = parent1.chromosome[i];
                }
                if (!child2.contains(parent2.chromosome[i]))
                {
                    child2.chromosome[i] = parent2.chromosome[i];
                }
            }

            // fill in remainder of child1 based on map;
            for (int i = 0; i < parent1.chromosome.Count(); i++)
            {
                if (child1.chromosome[i] == null)
                {
                    Boolean filled = false;
                    // this value is already in the child as it wasnt set in previous steps
                    Location locFromParent = parent1.chromosome[i];
                    while (!filled)
                    {
                        // look up the corresponding mapped value (the value at the same position in the
                        // other child where valFromParent exists)
                        Location locFromOtherChild = getMappedVal(child1, child2, locFromParent);
                        if (!child1.contains(locFromOtherChild))
                        {
                            child1.chromosome[i] = locFromOtherChild;
                            filled = true;
                        }
                        else
                        {
                            // continue while loop until we find a value not in the child
                            locFromParent = locFromOtherChild;
                        }
                    }

                }
            }

            // do the same for child2
            for (int i = 0; i < parent1.chromosome.Count(); i++)
            {
                if (child2.chromosome[i] == null)
                {
                    Boolean filled = false;
                    // this value is already in the child as it wasnt set in previous steps
                    Location locFromParent = parent2.chromosome[i];
                    while (!filled)
                    {
                        // look up the corresponding mapped value (the value at the same position in the
                        // other child where valFromParent exists)
                        Location locFromOtherChild = getMappedVal(child2, child1, locFromParent);
                        if (!child2.contains(locFromOtherChild))
                        {
                            child2.chromosome[i] = locFromOtherChild;
                            filled = true;
                        }
                        else
                        {
                            // continue while loop until we find a value not in the child
                            locFromParent = locFromOtherChild;
                        }
                    }

                }
            }
            foreach (Location l in child1.chromosome)
            {
                if (l == null)
                {
                    //System.err.println();
                    Console.Error.WriteLine();
                }
            }
            foreach (Location l in child2.chromosome)
            {
                if (l == null)
                {
                    //System.err.println();
                    Console.Error.WriteLine();
                }
            }
            List<Individual> children = new List<Individual>();
            children.Add(child1);
            children.Add(child2);
            return children;
        }

        /**
         * Return the customer in the same position in child2 as the customer defined by
         * locFromParent is in child1
         * 
         * @param child1
         * @param child2
         * @param locFromParent
         * @return
         */

        private Location getMappedVal(Individual child1, Individual child2, Location locFromParent)
        {

            for (int i = 0; i < child1.chromosome.Count(); i++)
            {
                if (child1.chromosome[i] != null)
                {
                    if (child1.chromosome[i].idx == locFromParent.idx)
                    {
                        return child2.chromosome[i];
                    }
                }
            }

            return null;

        }

        // simple crossover. Probably not very good. Long winded with customer indices
        private List<Individual> crossover(Individual parent1, Individual parent2, Problem problem)
        {
            Individual child = new Individual();
            child.depot = parent1.depot.copy();
            child.chromosome = new List<Location>();
            int cutPoint = random.Next(parent1.chromosome.Count());

            // add from parent1 up to cutpoint
            for (int i = 0; i < cutPoint; i++)
            {
                child.chromosome.Add(parent1.chromosome[i].copy());
            }

            // 1 is depot. Add all location indices
            List<int> locationIndexesNotUsed = new List<int>();
            for (int i = 2; i < problem.customers.Count() + 2; i++)
            {
                locationIndexesNotUsed.Add(i);
            }

            // remove indices copied from parent1
            for (int i = 0; i < child.chromosome.Count(); i++)
            {
                int idx = child.chromosome[i].idx;
                int usedIdx = locationIndexesNotUsed.IndexOf(idx);
                locationIndexesNotUsed.RemoveAt(usedIdx);
            }

            // add locations not used from cutpoint to end of parent2
            for (int i = cutPoint; i < parent2.chromosome.Count(); i++)
            {
                Location loc = parent2.chromosome[i];
                if (locationIndexesNotUsed.Contains(loc.idx))
                {
                    child.chromosome.Add(loc.copy());
                    int usedIdx = locationIndexesNotUsed.IndexOf(loc.idx);
                    locationIndexesNotUsed.RemoveAt(usedIdx);
                }
            }

            // add remaining locations not in child
            foreach (int i in locationIndexesNotUsed)
            {
                // Problem has locations in order starting with location 2
                Location loc = problem.customers[i - 2].copy();
                child.chromosome.Add(loc);
            }

            // check 1
            if (child.chromosome.Count() != parent1.chromosome.Count())
            {
                Console.Error.WriteLine("Error in crossover wrong size " + child.chromosome.Count());
                System.Environment.Exit(-1);
            }

            // check 2. All indices from 2 .. end should be included
            List<int> indexCheck = new List<int>();
            for (int i = 2; i < problem.customers.Count() + 2; i++)
            {
                indexCheck.Add(i);
            }
            foreach (Location loc in child.chromosome)
            {
                int usedIdx = indexCheck.IndexOf(loc.idx);
                indexCheck.RemoveAt(usedIdx);
            }
            if (indexCheck.Count() != 0)
            {
                Console.Error.WriteLine("Unused indices " + child);
                System.Environment.Exit(-1);
            }
            List<Individual> children = new List<Individual>();
            children.Add(child);
            return children;
        }

        private Individual select()
        {
            Individual winner = population[random.Next(popSize)];
            for (int i = 1; i < tournamentSize; i++)
            {
                Individual candidate2 = population[random.Next(popSize)];
                if (candidate2.fitness < winner.fitness)
                {
                    winner = candidate2;
                }
            }
            return winner.copy();
        }


        private List<Individual> scrambleMutation(List<Individual> children)
        {
            Individual scrambeling = new Individual();

            foreach (Individual child in children)
            {
                int loc2 = random.Next(child.chromosome.Count());
                int loc1 = random.Next(loc2);

                for (int i = loc1; i < loc2; i++)
                {
                    scrambeling.chromosome.Add(child.chromosome[i]);
                }

                string finChromosome = "";
                for (int i = 0; i < child.chromosome.Count; i++)
                {
                    finChromosome += child.chromosome[i].idx + " ";
                }

                for (int i = loc1; i < loc2; i++)
                {
                    int next = random.Next(scrambeling.chromosome.Count());
                    child.chromosome[i] = scrambeling.chromosome[next];
                    scrambeling.chromosome.RemoveAt(next);
                }
            }
            return children;
        }

        private List<Individual> OXcrossover(Individual parent1, Individual parent2)
        {
            Individual child1 = new Individual();
            child1.depot = parent1.depot;
            child1.chromosome = new List<Location>();
            Individual child2 = new Individual();
            child2.depot = parent1.depot;
            child2.chromosome = new List<Location>();

            for (int i = 0; i < parent1.chromosome.Count(); i++)
            {
                child1.chromosome.Add(null);
                child2.chromosome.Add(null);
            }

            //selects two random locations in the child
            int loc2 = random.Next(child1.chromosome.Count());
            int loc1 = random.Next(loc2);

            //fills in between the two locations with the opposit parent from the child
            for (int i = loc1; i < loc2; i++)
            {
                child1.chromosome[i] = parent2.chromosome[i];
                child2.chromosome[i] = parent1.chromosome[i];
            }


            for (int i = parent1.chromosome.Count() - 1; i > loc2 - 1; i--)
            {
                if (!child1.contains(parent1.chromosome[i]))
                {
                    child1.chromosome[i] = parent1.chromosome[i];
                }
                if (!child2.contains(parent2.chromosome[i]))
                {
                    child2.chromosome[i] = parent2.chromosome[i];
                }
            }

            for (int i = loc1 - 1; i > 0 - 1; i--)
            {
                if (!child1.contains(parent1.chromosome[i]))
                {
                    child1.chromosome[i] = parent1.chromosome[i];
                }
                if (!child2.contains(parent2.chromosome[i]))
                {
                    child2.chromosome[i] = parent2.chromosome[i];
                }
            }


            // fill in remainder of child1 based on map;
            for (int i = 0; i < parent1.chromosome.Count(); i++)
            {
                if (child1.chromosome[i] == null)
                {
                    Boolean filled = false;
                    // this value is already in the child as it wasnt set in previous steps
                    Location locFromParent = parent1.chromosome[i];
                    while (!filled)
                    {
                        // look up the corresponding mapped value (the value at the same position in the
                        // other child where valFromParent exists)
                        Location locFromOtherChild = getMappedVal(child1, child2, locFromParent);
                        if (!child1.contains(locFromOtherChild))
                        {
                            child1.chromosome[i] = locFromOtherChild;
                            filled = true;
                        }
                        else
                        {
                            // continue while loop until we find a value not in the child
                            locFromParent = locFromOtherChild;
                        }
                    }

                }
            }

            // do the same for child2
            for (int i = 0; i < parent1.chromosome.Count(); i++)
            {
                if (child2.chromosome[i] == null)
                {
                    Boolean filled = false;
                    // this value is already in the child as it wasnt set in previous steps
                    Location locFromParent = parent2.chromosome[i];
                    while (!filled)
                    {
                        // look up the corresponding mapped value (the value at the same position in the
                        // other child where valFromParent exists)
                        Location locFromOtherChild = getMappedVal(child2, child1, locFromParent);
                        if (!child2.contains(locFromOtherChild))
                        {
                            child2.chromosome[i] = locFromOtherChild;
                            filled = true;
                        }
                        else
                        {
                            // continue while loop until we find a value not in the child
                            locFromParent = locFromOtherChild;
                        }
                    }

                }
            }

            List<Individual> children = new List<Individual>();
            children.Add(child1);
            children.Add(child2);
            return children;
        }

    }
}