using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three Basic Arrays
            int[] zeroThruNine = new int[10];
            for (int i = 0; i < 10; i++)
            {
                zeroThruNine[i] = i;
            }

            string[] names = {"Tim", "Martin", "Nikki", "Sara"};

            bool[] altTf = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    altTf[i] = true;
                }
                else
                {
                    altTf[i] = false;
                }
            }

            //MULTIPLICATION TABLE
            int[,] multTable = new int[10, 10];
            for (int i = 1; i < 10; i++)
                {
                for (int j = 1; j < 10; j++)
                {
                    multTable[i,j] = i*j;
                    Console.Write(multTable[i,j]+ " ");
                }
                Console.WriteLine();
            }

            //LIST OF FLAVORS
            List<string> flavors = new List<string>
            {
                "Mint Cookies",
                "Rum Raisin",
                "Pralines and Pecan",
                "Cookie Dough",
                "Cookies n' Cream"
            };
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            // USER INFO DICTIONARY
            Dictionary<string,string> nameKeys = new Dictionary<string, string>();
            foreach (var name in names)
            {
                nameKeys.Add(name, null);
            }
            Random rand = new Random();
            foreach (var name in names)
            {
                int randInx = rand.Next(flavors.Count - 1);
                nameKeys[name] = flavors[randInx];
                flavors.RemoveAt(randInx);
            }

            foreach (var entry in nameKeys)
            {
                Console.WriteLine("{0}'s favorite flavor is {1}", entry.Key, entry.Value);
            }
        }
    }
}
