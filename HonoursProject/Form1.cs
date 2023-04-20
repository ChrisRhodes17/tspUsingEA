using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HonoursProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Globals.frm1 = this;
        }

        string name = "";
        string filename;

        private void btnRun_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            int popSize;
            int tournamentSize;
            int maxGenerations;
            double mutationRate;

            if (regex.IsMatch(comboBoxPopulation.Text))
            {
                popSize = Int32.Parse(comboBoxPopulation.Text);
            }
            else
            {
                MessageBox.Show("Population size must be a number. \n\n" +
                                "Please enter a new population size.");
                return;
                
            }

            if (regex.IsMatch(comboBoxTounamentSize.Text))
            {
                tournamentSize = Int32.Parse(comboBoxTounamentSize.Text);
            }
            else
            {
                MessageBox.Show("Tounament size must be a number. \n\n" +
                                "Please enter a new tounament size.");
                return;

            }

            if (regex.IsMatch(comboBoxGenerations.Text))
            {
                maxGenerations = Int32.Parse(comboBoxGenerations.Text);
            }
            else
            {
                MessageBox.Show("The number of generations must be a number. \n\n" +
                                "Please enter a new number of generations.");
                return;

            }

            if (double.TryParse(comboBoxMutationRate.Text, out double d) && !Double.IsNaN(d) && !Double.IsInfinity(d) && Convert.ToDouble(comboBoxMutationRate.Text) < 1)
            {
                mutationRate = Convert.ToDouble(comboBoxMutationRate.Text);
            }
            else
            {
                MessageBox.Show("Mutation rate must be a decimal less than 1. \n\n" +
                                "such as 0.1 \n\n" +
                                "Please enter a new mutation rate.");
                return;

            }

            string method = comboBoxMethod.Text;
            string mutation = comboBoxMutation.Text;
            string crossover = comboBoxCrossover.Text;

            int numRuns = Int32.Parse(comboBoxNumRuns.Text);

            if (filename == null)
            {
                MessageBox.Show("No file selected. \n\n" +
                                "Please select a file.");
            }
            else
            {
                if (method == "Heuristic (Nearest Neighbour)")
                {
                    name = "Heuristic";
                }
                else
                {
                    name = "Results";
                }

                if (method == "Heuristic (Nearest Neighbour)")
                {
                    NearestNeighbour nn = new NearestNeighbour(filename);
                }
                else
                {
                    for (int i = 0; i < numRuns; i++)
                    {
                        EvolutionaryAlgorithm ea = new EvolutionaryAlgorithm(filename, popSize, tournamentSize, maxGenerations, mutationRate, mutation, crossover);
                    }
                }                
            }
        }


        public void PrintBest(string best)
        {
            textBoxBest.AppendText(best + Environment.NewLine);
        }

        public void PrintResults(string result)
        {
            textBoxResult.AppendText(result + Environment.NewLine);
        }

  
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxBest.Text = "";
            textBoxResult.Text = "";
        }

        private void btnInfoPop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The population size is the number of children you have in each generation.");
        }

        private void btnInfoGen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The number of generations is the amount of times the evolutionary algorithm " +
                            "will try to evolve the route to find a shorter one.");
        }

        private void btnInfoTourSize_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the number of children that will be compared to select the which 2 should be crossed.");
        }

        private void btnInfoCross_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the method that that will be used to mix the two selected children to " +
                            "create two new children");
        }

        private void btnInfoMuteOp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" ");
        }

        private void btnInfoMuteRate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This determins how many children in your population will be mutated, a higher " +
                            "mutaion rate means more of the population is muatated.");
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = fdlg.FileName;
                filename = fdlg.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Enter the name you want to save your results as", "File Name", "");

            string currentLoc = Directory.GetCurrentDirectory();

            if (input != "")
            {
                name = input;
            }

            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                currentLoc = fdlg.SelectedPath;
            }



            string fullPathFit = currentLoc+ "\\" + name + "Fitness" + ".csv";

            TextReader readFit = new System.IO.StringReader(textBoxBest.Text);

            string[] linesFit = new string[textBoxBest.Lines.Length];

            for(int i = 0; i < textBoxBest.Lines.Length; i++)
            {
                linesFit[i] = readFit.ReadLine();
            }

            using (StreamWriter file = new StreamWriter(fullPathFit))
            {
                file.WriteLine("Best Fitness Found In Run");
                foreach (string line in linesFit)
                {
                    file.WriteLine(line);
                }
            }


            string fullPathFull = currentLoc + "\\" + name + "Full" + ".csv";

            TextReader readFull = new System.IO.StringReader(textBoxBest.Text);

            string[] linesFull = new string[textBoxBest.Lines.Length];

            for (int i = 0; i < textBoxBest.Lines.Length; i++)
            {
                linesFull[i] = readFull.ReadLine();
            }

            using (StreamWriter file = new StreamWriter(fullPathFull))
            {
                file.WriteLine("Best Fitness Found In Run");
                foreach (string line in linesFull)
                {
                    file.WriteLine(line);
                }
            }
        }

        
    }
}
