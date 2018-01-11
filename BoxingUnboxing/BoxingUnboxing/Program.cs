using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            var objList = new List<object>
            {
                7,
                28,
                -1,
                true,
                "chair"
            };

            foreach (var o in objList)
            {
                Console.WriteLine(o);
            }

             int sum = 0;
            foreach (var o in objList)
            {
                if (o is int)
                {
                    sum += (int)o;
                }


            }
                Console.WriteLine(sum);

        }
    }
}
