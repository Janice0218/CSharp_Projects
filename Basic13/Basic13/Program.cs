using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Sample = {12, 3, 5, -1, 32};
            PrintOddTo255();
            PrintOddTo255();
            PrintSum();
            PrintArray(Sample);
            FindMax(Sample);
            GetAvg(Sample);
            OddArray();
            GtY(6, Sample);
            SquareVals(Sample);
            NoNegs(Sample);
            MinMaxAvg(Sample);
            ShiftArray(new List<int> {5,4,16,12});
            NegToString(new List<object> {4,2,-5});
        }
        //==========================
        //ASSIGNMENT FUNCTIONS
        //==========================
        //PRINT 1-255
        public static void PrintTo255()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }
        //PRINT ODD NUMS BTW 1-255  
        public static void PrintOddTo255()
        {
            for (int i = 1; i < 256; i++)
            {
                if(i%2==1){Console.WriteLine(i);}

            }
        } 
        //PRINT SUM 
        public static void PrintSum()
        {
            int sum = 0;
            for (int i = 1; i < 256; i++)
            {
                sum += i;
                Console.WriteLine(sum);
            }
        }
        //ITERATING THRU ARRAY 
        public static void PrintArray(params int[] vals)
        {
            foreach (var val in vals)
            {
                Console.WriteLine(val);
            }
        }
        //FIND MAX 
        public static void FindMax(params int[] maxNums) 
        {
            int max = 0;
            foreach (var maxNum in maxNums)
            {
                if (maxNum > max)
                {
                    max = maxNum;
                }
            }
            Console.WriteLine("Max: " + max);
        }
        //GET AVERAGE 
        public static void GetAvg(params int[] nums)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }
            Console.WriteLine("avg: "+ (sum/(nums.Length)));
        }
        //ARRAY WITH ODD NUMS 
        public static void OddArray()
        {
            var y = new List<int>();
            for (int i = 1; i < 256; i++)
            {
                if (i % 2 == 1)
                {
                    y.Add(i);
                }
            }
        }
        //GREATER THAN Y
        public static void GtY(int y, params int[] compVals)
        {
            int count = 0;
            foreach (var compVal in compVals)
            {
                if (compVal > y)
                {
                    count++;        
                }
                Console.WriteLine(count);
            }
        }
        //SQUARE THE VALS 
        public static void SquareVals(params int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[i] * x[i];
            }

            foreach (var val in x) 
            {
                Console.WriteLine(val);
            }
        }
        //EMIMINATE NEGS 
        public static void NoNegs(params int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < 0)
                {
                    x[i] = 0;
                }
            }

            foreach (var i in x)
            {
                Console.WriteLine(x);
            }
        }
        //MIN, MAX AND AVG 
        public static void MinMaxAvg(params int[] x)
        {
            FindMax(x);
            GetAvg(x);
            int min = x[0];
            for(int i=1; i< x.Length-1; i++)
            {
                if (x[i] < min)
                {
                    min = x[i];
                }
            }
            Console.WriteLine("min:" + min);
        }
        //SHIFTING VALS OF ARRAY  
        public static void ShiftArray(List<int> shifties)
        {
            shifties.RemoveAt(0);
            shifties.Add(0);
            Console.Write("[");
            foreach (var shifty in shifties)
            {
                Console.Write(shifty+", ");
            }
            Console.Write("]");
        }

        //NUM TO STRING 
        public static void NegToString(List<object> junk)
        {
            for(int i = 0; i<junk.Count; i++)
            {
                if ((int)junk[i] < 0)
                {
                    junk[i] = "Dojo";
                }
            }
            foreach (var item in junk)
            {
                Console.WriteLine(item);
            }
        }

    }
}
