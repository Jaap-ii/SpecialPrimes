using SpecialPrimes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialPrimesDVC
{
    public class JaapHisSolver
    {
        public static List<int> Solve(int lower, int upper)
        {

            if (lower < 0)
                throw new Exception("Fuzzy input exception1");
            if (lower > upper)
                throw new Exception("Fuzzy input exception2.5");
            List<int> result = new List<int>();
            var sp = new SpecialPrimeFinder(PrimeFinderFactory.CreatePrimeFinder(lower, upper));
            result = sp.GetSpecialPrimes(lower, upper).ToList();
            return result;
        }
    }
}
