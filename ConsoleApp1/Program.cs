
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using SpecialPrimesDVC;

namespace SpecialPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int upper = int.MaxValue;
            int lower = upper - 25000000; // 1000000;
            var sw = new Stopwatch();
            sw.Start();
            var boe = JaapHisSolver.Solve(lower, upper);
            sw.Stop();
            Console.WriteLine($"found {boe.Count} took {sw.ElapsedMilliseconds} ms");
            sw.Reset();
        }
    }


}
