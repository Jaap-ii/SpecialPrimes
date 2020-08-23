using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialPrimes
{
    public class SieveOfAtkin : IEnumerable<ulong>
    {
        private const bool HUH = true;
        private readonly List<ulong> primes;
        private readonly ulong upperlimit;
        private readonly ulong lowerlimit;

        public SieveOfAtkin(ulong lowerlimit, ulong upperlimit)
        {
            this.upperlimit = upperlimit;
            this.lowerlimit = lowerlimit;
            primes = new List<ulong>();
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            if (!primes.Any())
                FindPrimes();

            foreach (var p in primes)
                yield return p;
        }

        private void FindPrimes()
        {
            var isPrime = new BitArray((int)upperlimit + 1);
            var sqrt = Math.Sqrt(upperlimit);

            for (ulong x = 1; x <= sqrt; x++)
                for (ulong y = 1; y <= sqrt; y++)
                {
                    var n = 4 * x * x + y * y;
                    if (n>= lowerlimit && n <= upperlimit && (n % 12 == 1 || n % 12 == 5))
                        isPrime[(int)n] ^= true;

                    n = 3 * x * x + y * y;
                    if (n >= lowerlimit && n <= upperlimit && n % 12 == 7)
                        isPrime[(int)n] ^= true;

                    n = 3 * x * x - y * y;
                    if (n >= lowerlimit && x > y && n <= upperlimit && n % 12 == 11)
                        isPrime[(int)n] ^= true;
                }

            for (ulong n = 5; n <= sqrt; n++)
                if (isPrime[(int)n])
                {
                    var s = n * n;
                    for (ulong k = s; k <= upperlimit; k += s)
                        isPrime[(int)k] = false;
                }

            primes.Add(2);
            primes.Add(3);
            for (ulong n = 5; n <= upperlimit; n += 2)
                if (isPrime[(int)n])
                    primes.Add(n);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
