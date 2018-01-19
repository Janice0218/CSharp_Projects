using System;
using System.Runtime.InteropServices;

namespace WhichMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            new Worker().WhoAmI();
            new Farmer().WhoAmI();
            (new Farmer() as Worker).WhoAmI();
            var Bob = new Farmer();
            Worker Wbob = (Worker) Bob;
            Bob.WhoAmI();
            Wbob.WhoAmI();
            new Baker().WhoAmI();
        }
    }
}
