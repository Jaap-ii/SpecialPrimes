using System;
namespace SpecialPrimes
{public static class MillerRabin
{
    public static bool IsPrime(int n)
    {
        if ((n < 2) || (n % 2 == 0)) return (n == 2);
 
        int s = n - 1;
        while (s % 2 == 0)  s >>= 1;
 
        foreach (int a in trymees(n))
        {
            int temp = s;
            long mod = 1;
            for (int j = 0; j < temp; ++j)  mod = (mod * a) % n;
            while (temp != n - 1 && mod != 1 && mod != n - 1)
            {
                mod = (mod * mod) % n;
                temp *= 2;
            }
            if (mod != n - 1 && temp % 2 == 0) return false;
        }
        return true;
    }
private static int[] trymees(int i)
{
/*
 * if n < 1,373,653, it is enough to test a = 2 and 3;
 * if n < 9,080,191, it is enough to test a = 31 and 73;
 * if n < 4,759,123,141, it is enough to test a = 2, 7, and 61;
 * if n < 1,122,004,669,633, it is enough to test a = 2, 13, 23, and 1662803;
 * if n < 2,152,302,898,747, it is enough to test a = 2, 3, 5, 7, and 11;
 * if n < 3,474,749,660,383, it is enough to test a = 2, 3, 5, 7, 11, and 13;
 * if n < 341,550,071,728,321, it is enough to test a = 2, 3, 5, 7, 11, 13, and 17.
 */

if (i < 2047) return new int[]{2};          
              if (i < 1373653) return new int[]  {2, 3};
              if (i < 9090191) return new int[]  {31, 73};
              if (i < 25326001) return new int[]  {2, 3, 5};
            return new int[]  {2, 3, 5, 7};
            //   if (i < 3215031751) return new int[]  {2, 3, 5, 7};
            //   if (i < 1122004669633) return new int[]  {2, 13, 23, 1662803};
            //   if (i < 2152302898747) return new int[]  {2, 3, 5, 7, 11};
            //   if (i < 3474749660383) return new int[]  {2, 3, 5, 7, 11, 13};
            //   if (i < 341550071728321) return new int[]  {2, 3, 5, 7, 11, 13, 17};
            //   if (i < 3825123056546413051) return new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23};
 }
}

}