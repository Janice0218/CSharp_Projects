using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Linq;

namespace Puzzles
{
    class Program

    {
        //RANDOM ARRAY
        public static int[] RandomArray()
        {
            var rand = new Random();
            var randomArray = new int[10];
            for (int i = 0; i < 10; i++)
            {
                randomArray[i] = rand.Next(5, 25);
            }

            int min = randomArray[0];
            int max= randomArray[0];
            int sum = randomArray[0];
            for (int i = 1; i < 10; i++)

            {
                int temp = randomArray[i];
                if (temp < min)
                {
                    min = temp;
                }

                if (temp > max)
                {
                    max = temp;
                }

                sum += temp;
            }

            Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}", min, max, sum);
            return randomArray;
        }

        //COIN TOSS
        public static string TossCoin()
        {
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Tossing a Coin");
            int toss = rand.Next(1, 3);
            string outcome = (toss == 1) ? "heads" : "tails";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(outcome);
            return outcome;
        }

        public static double TossMultipleCoins(int num)
        {
            double heads = 0;
            double tails = 0;
            for (int i = 0; i < num; i++)
            {
                string outcome = TossCoin();
                if (outcome == "heads")
                {
                    heads += 1;
                }
                else
                {
                    tails += 1;
                }
            }

            double ratio = (heads / tails);
            Console.WriteLine($"Ratio of {heads} heads to {tails} tails in {num} tosses is {ratio}");
            return ratio;
        }
         //NAMES
        public static string[] Names()
        {
            string[] Names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            for (int i = 0; i < Names.Length; i++)
            {
                int idx = rand.Next(Names.Length);
                string temp = Names[idx];
                Names[idx] = Names[i];
                Names[i] = temp;
            }
            List<string> OverFive = new List<string>();
            foreach (var name in Names)
            {
                Console.WriteLine(name);
                if (name.Length > 5)
                {
                    OverFive.Add(name);
                }
            }

            foreach (var person in OverFive)
            {
                Console.WriteLine(person);
            }
            return OverFive.ToArray();
        }
        static void Main(string[] args)
        {
            RandomArray();
            TossMultipleCoins(10);
            Names();
        }
    }
}
