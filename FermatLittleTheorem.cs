using System;

namespace SpecialPrimes
{
    public class FermatLittleTheorem
    {



        /* Iterative Function to calculate 

        // (a^n)%p in O(logy) */

        public static long power(long a, long n, long p)

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
        // If n is prime, then always returns true,  

        // If n is composite than returns false with  

        // high probability Higher value of k increases 

        //  probability of correct result. 

        public static bool IsPrime(int n)

        {

            // Corner cases 

            if (n <= 1 || n == 4) return false;

            if (n <= 3) return true;



            // Try k times 
            //          var rand = new Random();
            //            while (k > 0)

            foreach (int a in new int[] { 2,3,5})
            {
                //            var r = rand.NextDouble() * (n - 4);
                // Pick a random number in [2..n-2]      

                // Above corner cases make sure that n > 4 

                //          int a = 2 + (int)(r);



                // Fermat's little theorem 

                if (power(a, n - 1, n) != 1)

                    return false;



                //          k--;

            }



            return true;

        }
        private static int[] trymees(int i)
        {
            return new int[] { 3, 2, 13 };
            if (i < 1373653) return new int[] { 2, 3 };
            if (i < 9090191) return new int[] { 31, 73 };
            if (i < 25326001) return new int[] { 2, 3, 5 };
            if (i < 2047) return new int[] { 2 };
            if (i < 1373653) return new int[] { 2, 3 };
            if (i < 9090191) return new int[] { 31, 73 };
            if (i < 25326001) return new int[] { 2, 3, 5 };
            return new int[] { 2, 3, 5, 7 };
            //   if (i < 3215031751) return new int[]  {2, 3, 5, 7};
            //   if (i < 1122004669633) return new int[]  {2, 13, 23, 1662803};
            //   if (i < 2152302898747) return new int[]  {2, 3, 5, 7, 11};
            //   if (i < 3474749660383) return new int[]  {2, 3, 5, 7, 11, 13};
            //   if (i < 341550071728321) return new int[]  {2, 3, 5, 7, 11, 13, 17};
            //   if (i < 3825123056546413051) return new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23};
        }

    }
}