using Microsimulation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsimulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        Random rng = new Random(1234);
        List<int> male = new List<int>();
        List<int> female = new List<int>();
        int[] male2= new int[100];
        int[] female2 = new int[100];
        public Form1()
        {
            
            InitializeComponent();
            numericUpDown1.Minimum = 2005;
            numericUpDown1.Maximum = 2105;
            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");
            BirthProbabilities = GetBirthProbabilites(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilites(@"C:\Temp\halál.csv");
            
            
        }

        private void SimStep(int year, Person person)
        {
            if(!person.IsAlive) return;
            int personAge = year - person.BirthYear;
            double deathProb = (from x in DeathProbabilities
                                   where x.Gender == person.Gender && x.Age == personAge
                                   select x.ProbabilityOfDeath).FirstOrDefault();
            if (rng.NextDouble() <= deathProb)
            {
                person.IsAlive = false;
            }
            if (person.IsAlive == true && person.Gender == Gender.Female)
            {
                double birthProb = (from x in BirthProbabilities
                                    where x.Age == personAge && x.NumberOfChildren == person.NumberOfChildren
                                    select x.ProbabilityOfBirth).FirstOrDefault();
                if (rng.NextDouble() <= birthProb)
                {
                    //person.NumberOfChildren++;
                    Person newperson = new Person();
                    newperson.BirthYear = year;
                    newperson.Gender = (Gender)rng.Next(1,3);
                    newperson.NumberOfChildren = 0;
                    newperson.IsAlive = true;
                    Population.Add(newperson);
                }
            }
            

        }

        public List<DeathProbability> GetDeathProbabilites(string csvpath)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathProbabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender),line[0]),
                        Age = int.Parse(line[1]),
                        ProbabilityOfDeath = double.Parse(line[2])
                    });
                }
            }
            return deathProbabilities;
        }

        public List<BirthProbability> GetBirthProbabilites(string csvpath)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();
            using (StreamReader sr = new StreamReader(csvpath,Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NumberOfChildren = int.Parse(line[1]),
                        ProbabilityOfBirth = double.Parse(line[2])
                    }) ;
                }
            }

            return birthProbabilities;
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NumberOfChildren = int.Parse(line[2])
                    });

                }
            }
            return population;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            male.Clear();
            female.Clear();
            Simulation();
            DisplayResults();
        }

        private void DisplayResults()
        {
            for (int year = 2005; year <= numericUpDown1.Value; year++)
            {
                richTextBox1.Text += string.Format("Szimulációs év: {0}\n\tFiúk: {1}\n\tLányok: {2}\n\n", year,male2[year-2005],female2[year-2005]);
            }
        }

        private void Simulation()
        {
            Population = GetPopulation(textBox1.Text);
            for (int year = 2005; year <= numericUpDown1.Value; year++)
            {
                
                for (int i = 0; i < Population.Count; i++)
                {
                    
                    SimStep(year, Population[i]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                male2[year-2005]= nbrOfMales;
                female2[year-2005] = nbrOfFemales;
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = ofd.FileName.ToString();
        }
    }
}
