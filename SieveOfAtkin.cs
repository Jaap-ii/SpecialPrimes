using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialPrimes
{
    public class SieveOfAtkin : IPrimeFinder
    {
        private const bool HUH = true;
        private  ulong upperlimit;
        private  ulong lowerlimit;
        private BitArray isPrime;

        public void Init(int lowerbound, int upperbound)
        {
            this.upperlimit = (ulong)Math.Max(upperbound, 1);
            this.lowerlimit = (ulong)Math.Min(lowerbound, int.MaxValue);
            FindPrimes();
        }

        public bool IsPrime(int n)
        {
            return isPrime[n - 1];
        }

        private void FindPrimes()
        {
            isPrime = new BitArray((int)upperlimit);
            isPrime[2] = true;
            isPrime[3] = true;
            var sqrt = Math.Sqrt(upperlimit);

            for (ulong x = 1; x <= sqrt; x++)
                for (ulong y = 1; y <= sqrt; y++)
                {
                    var n = 4 * x * x + y * y;
                    if (n >= lowerlimit && n <= upperlimit && (n % 12 == 1 || n % 12 == 5))
                        isPrime[(int)n - 1] ^= true;

                    n = 3 * x * x + y * y;
                    if (n >= lowerlimit && n <= upperlimit && n % 12 == 7)
                        isPrime[(int)n - 1] ^= true;

                    n = 3 * x * x - y * y;
                    if (n >= lowerlimit && x > y && n <= upperlimit && n % 12 == 11)
                        isPrime[(int)n - 1] ^= true;
                }

            for (ulong n = 5; n <= sqrt; n++)
                if (isPrime[(int)n - 1])
                {
                    var s = n * n;
                    for (ulong k = s; k <= upperlimit; k += s)
                        isPrime[(int)k - 1] = false;
                }
        }


    }
}
