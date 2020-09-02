using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace SpecialPrimes
{
    public class SimplePrimeTool : IPrimeFinder
    {
        private BitArray primes;
        private BitArray primesCalculated;
        private int lowerbound;
        private int upperbound;
        private Func<int, bool> probe;
        public SimplePrimeTool(Func<int, bool> probe)
        {
            this.probe = probe;
        }
        public SimplePrimeTool()
        {
        }

        public void Init(int lowerbound, int upperbound)
        {
            this.upperbound = upperbound;
            this.lowerbound = lowerbound;
            primes = new BitArray(upperbound - lowerbound);
            primesCalculated = new BitArray(upperbound - lowerbound);
        }

        public bool IsPrime(int n)
        {
            int index = (n - 1) - lowerbound;
            if (primesCalculated[index])
                return primes[index];
            bool result;
            if (probe == null)
                result = CalculateIsPrime(n);
            else
                result = probe(n) && CalculateIsPrime(n);
            primesCalculated[index] = true;
            primes[index] = result;
            return result;
        }

        private bool CalculateIsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }

    }
}
