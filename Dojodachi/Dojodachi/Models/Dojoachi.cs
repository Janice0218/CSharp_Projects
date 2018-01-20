using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dojodachi.Models
{
    public  static class Dojoachi
    {
        private static Random rand = new Random();
        public static int Happiness { get; set; } = 20;
        public static int Fullness { get; set; } = 20;
        public static int Energy { get; set; } = 50;
        public static int Meals { get; set; } = 3;
        public static string Message { get; set; } = "Click a button to perform an activity";
        public static string Photo { get; set; } = @"/Images/default.jpg";

        public static void Feed()
        {
            Meals -= 1;
            if (rand.Next(1, 5) != 1)
            {
                Fullness += rand.Next(5, 11);
            }

            Photo = @"/Images/eat.jpg";

        }
        public static void Play()
        {
            Energy -= 5;
            if (rand.Next(1, 5) != 1)
            {
                Happiness += rand.Next(5, 11);
            }
            Photo = @"/Images/play.jpg";
        }
        public static void Work()
        {
            Energy -= 5;
            Meals += rand.Next(1, 4);
            Photo = @"/Images/work.jpg";
        }
        public static void Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            Photo = @"/Images/sleep.jpg";
        }
    }
 

}

