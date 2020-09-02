using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialPrimes
{
    public class SpecialPrimeFinder
    {
        IPrimeFinder primeFinder;

        public SpecialPrimeFinder(IPrimeFinder primeFinder)
        {
            this.primeFinder = primeFinder;
        }

        public IEnumerable<int> GetSpecialPrimes(int lowerParam, int upper)
        {
            primeFinder.Init(0, upper);
            int previousPrime = 0;
            bool loopInitialized = false;
            //var result = new List<int>();
            int lower = lowerParam >> 1;
            if (lower % 2 == 0)
                lower = lower - 1;
            int halfWayOffset = 0;

            for (int i = lower; i <= upper && i > 0; i = i + 2)
            {
                if (primeFinder.IsPrime(i))
                {
                    halfWayOffset = (i - lower);
                }
            }
            lower = lower - halfWayOffset - 1;
            if (lower < 5)
                lower = 5;

           int candidate = 0;
           for (int i = lower; i <= upper && i > 0; i = i + 2)
            {
                if (primeFinder.IsPrime(i))
                {
                    if (loopInitialized)
                    {
                        candidate = i + previousPrime + 1;
                        if (candidate > upper || candidate < 0)
                        {
                            break;
                        }
                        if (candidate >= lowerParam && primeFinder.IsPrime(candidate))
                        {
                            yield return candidate;
                        }
                    }
                    else
                    {
                        loopInitialized = true;
                    }
                    previousPrime = i;
                }
            }
        }
    }
}