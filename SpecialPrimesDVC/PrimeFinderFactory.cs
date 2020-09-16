using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialPrimes
{
    public class PrimeFinderFactory
    {
        public static IPrimeFinder CreatePrimeFinder(int lower, int upper)
        {
            int range = upper - lower;
            double deel = (range / (double)lower);
            if ((lower < 10000000 && deel < 0.5) || (lower > 10000000 && lower < 100000000 && deel < 0.3))
            {
                //Console.WriteLine("Using Simple");
                return new SimplePrimeTool();
            }
            if ((lower <= 1000000000 && lower >= 100000000 && range < 50000001) || (lower >= 1000000000 && range < 30000001))
            {
                //Console.WriteLine("Using Simple + probe");
                return new SimplePrimeTool(FermatLittleTheorem.CouldBePrime);
            }
            //Console.WriteLine("Using Atkin");
            return new SieveOfAtkin();
        }
    }
}
