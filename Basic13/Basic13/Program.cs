using System.Collections.Generic;
using System.Linq;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Basic13.PrintOddTo255();
            Basic13.PrintOddTo255();
            Basic13.PrintSum();
            Basic13.PrintArray(1,5,7,9,13);
            Basic13.FindMax(-3,-5,-7);
            Basic13.GetAvg(2,3,10);
            Basic13.OddArray();
            Basic13.GtY(6, 1,5,5,7);
            Basic13.SquareVals(1,5,10,-2);
            Basic13.NoNegs(1,5,10,-2);
            Basic13.MinMaxAvg(1,5,10,-2);
            Basic13.ShiftArray(new List<int> {1,5,10,7,-2});
            Basic13.NegToString(new List<object> {-1,-3,2});
        }
    }
}
