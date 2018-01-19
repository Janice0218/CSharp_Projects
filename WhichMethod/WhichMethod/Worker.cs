using System;

namespace WhichMethod
{
    class Worker
    {
        public virtual void WhoAmI()
        {
            Console.WriteLine("I am a worker");
        }
    }

    class Farmer : Worker
    {   //override will write over Parent Method for either object
        //new will just hid Parent Method but can still access when cast

        //public override void WhoAmI()
        public new void WhoAmI()
        {

            Console.WriteLine("I am a Farmer");
        }
    }

    class Baker : Worker
    {
        
    }
}