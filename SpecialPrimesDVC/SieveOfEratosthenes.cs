using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialPrimes
{
    public class SieveOfEratosthenes
    {
        public static bool Sieve(int n, bool[] isPrime)
        {
            // Initialize all entries of boolean 
            // array as true. A value in isPrime[i]  
            // will finally be false if i is Not a  
            // prime, else true bool isPrime[n+1]; 
            isPrime[0] = isPrime[1] = false;
            for (int i = 2; i <= n; i++)
                isPrime[i] = true;

            for (int p = 2; p * p <= n; p++)
            {
                // If isPrime[p] is not changed,  
                // then it is a prime 
                if (isPrime[p] == true)
                {
                    // Update all multiples of p 
                    for (int i = p * p; i <= n; i += p)
                        isPrime[i] = false;
                }
            }
            return false;
        }

        // Prints a prime pair with given sum 
        public static void findPrimePair(int n)
        {
            // Generating primes using Sieve 
            bool[] isPrime = new bool[n + 1];
            Sieve(n, isPrime);

            // Traversing all numbers to find first 
            // pair 
            for (int i = 0; i < n; i++)
            {
                if (isPrime[i] && isPrime[n - i])
                {
                    Console.Write(i + " " + (n - i));
                    return;
                }
            }
        }
    }
}
