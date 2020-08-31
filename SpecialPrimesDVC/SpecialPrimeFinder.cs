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

        public List<int> GetSpecialPrimes(int lowerParam, int upper)
        {
            int lower = lowerParam >> 1;
            if (lower % 2 == 0)
                lower = lower + 1;
            primeFinder.Init(0, upper);
            int previousPrime = 0;
            bool loopInitialized = false;
            var result = new List<int>();
            int candidate = 0;
            for (int i = lower; i <= upper && i > 0; i = i + 2)
            {
                if (primeFinder.IsPrime(i))
                {
                    if (loopInitialized)
                    {
                        if (previousPrime > 0)
                        {
                            candidate = i + previousPrime + 1;
                            if (candidate > upper || candidate < 0)
                            {
                                break;
                            }
                            if (candidate >= lowerParam && primeFinder.IsPrime(candidate))
                            {
                                result.Add(candidate);
                            }
                        }
                        previousPrime = i;
                    }
                    else
                    {
                        i = lower - Math.Max(i - lower, 1); // restart loop to catch up with lagging primes
                        if (i % 2 == 0)
                            i = i + 1;
                        loopInitialized = true;
                    }
                }
            }
            return result;
        }
    }
}
