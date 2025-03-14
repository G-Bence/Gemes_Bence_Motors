using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors
{
    internal class Statistics
    {
        private List<Motor> motors = new List<Motor>();

        internal List<Motor> Motors { get => motors; set => motors = value; }



        /*
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡉⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⢻⣿⣿⣿⣿⣿⣿⣿⡿⠁⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠸⣿⣿⣿⣿⣿⣿⡟⠁⢀⠀⢻⣿⣿⣿⣿⣿⣿⡇⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⢻⣿⣿⣿⣿⡟⠁⣰⣿⣆⠀⢹⣿⣿⣿⣿⡿⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠘⣿⣿⣿⡟⠀⣰⣿⣿⣿⣆⠀⠹⣿⣿⣿⡇⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⢻⣿⡟⠀⣰⣿⣿⡿⣿⣿⣧⠀⠹⣿⡿⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠘⡟⠀⣰⣿⣿⡟⠀⠹⣿⣿⣧⠀⠹⠇⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⣰⣿⣿⠏⠀⣠⠀⠹⣿⣿⣧⡀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠘⣿⣿⠏⠀⣴⣿⣧⡀⠹⣿⣿⠇⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⣴⠀⢹⠏⠀⣼⣿⣿⣿⣷⡀⠘⡿⠀⢰⡀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣀⣼⣿⡄⠀⠀⣼⣿⣿⣿⣿⣿⣷⡀⠀⠀⣿⣷⡀⠘⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⢀⣼⣿⣿⣿⣿⣿⣿⣿⣷⡄⢸⣿⣿⣷⡄⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⣨⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
         */




        public void ReadFromFiles(string FileName)
        {
            Console.WriteLine("Reading from file: " + FileName + "\n----------------------------------------");
            StreamReader sr = new StreamReader(FileName);
            sr.ReadLine();

            do
            {
                string line = sr.ReadLine() ?? ""; // null-coalescing operator
                if (line != null)
                {
                    string[] words = line.Split(';');
                    motors.Add(new Motor(words[0], words[1], int.Parse(words[2]), double.Parse(words[3], CultureInfo.InvariantCulture), double.Parse(words[4], CultureInfo.InvariantCulture)));
                }
                else
                {
                    Console.WriteLine("File is empty");
                    sr.Close();
                    break;
                }
            } while (!sr.EndOfStream);
        }

        public int SumPrices()
        {
            double sum = 0;

            for (int i = 0; i < motors.Count; i++)
            {
                sum += motors[i].PriceInEur;
            }

            return (int)(sum);
        }

        public bool Contains(string Brand)
        {
            bool contains = false;
            for (int i = 0; i < motors.Count; i++)
            {
                if (motors[i].Brand == Brand)
                {
                    contains = true;
                }
            }

            return contains;
        }

        public Motor Oldest()
        {
            Motor oldest = motors[0];

            for (int i = 0; i < motors.Count; i++)
            {
                if (oldest.RelaseYear > motors[i].RelaseYear)
                {
                    oldest = motors[i];
                }
            }

            return oldest;
        }

        public int SumPricesBasedOnBrand(string brandName)
        {
            double sum = 0;

            for (int i = 0; i < motors.Count; i++)
            {
                if (motors[i].Brand == brandName)
                {
                    sum += motors[i].PriceInEur;
                }
            }

            return (int)sum;

        }

        public void Sort()
        {
            for (int i = motors.Count; i > 0; i--)
            {
                for (int j = 0; j < motors.Count - 1; j++)
                {
                    if (motors[j].Performance > motors[j + 1].Performance)
                    {
                        Motor temp = motors[j];
                        motors[j] = motors[j + 1];
                        motors[j + 1] = temp;
                    }
                }
            }
        }




    }
}
