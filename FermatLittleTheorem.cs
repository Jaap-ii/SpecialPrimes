using System;

namespace SpecialPrimes
{
    public class FermatLittleTheorem
    {

        private static long power(long a, long n, long p)
        {
            // Initialize result 
            long res = 1;
            // Update 'a' if 'a' >= p 
            a = a % p;

            while (n > 0)
            {
                // If n is odd, multiply 'a' with result 
                if ((n & 1) == 1)
                    res = (res * a) % p;

                // n must be even now 
                n = n >> 1; // n = n/2 

                a = (a * a) % p;
            }
            return res;
        }

        public static bool CouldBePrime(int n)
        {
            // Corner cases 
            if (n <= 1 || n == 4 ) return false;

            if (n <= 3 || n==5) return true;

            foreach (int a in new int[] { 2,3,5})
            {
                // Fermat's little theorem 

                if (power(a, n - 1, n) != 1)
                    return false;
            }
            return true;
        }
    }
}