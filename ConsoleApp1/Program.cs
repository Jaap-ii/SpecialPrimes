
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
        static void Main2(string[] args)
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
        static void Main(string[] args)
        { //SpecialPrime.FindSpecialPrimes(1,10).ForEach(i => Console.Write("{0} ,", i));
            var testSet = BuildTests();
            var sw = new Stopwatch();
            Console.WriteLine("Press any key to start tests.");
            Console.ReadKey();

            foreach (var test in testSet)
            {
                try
                {
                    sw.Start();
                    var answer = JaapHisSolver.Solve(test.from, test.to);
                    sw.Stop();
                    Console.WriteLine($"Result for {test.from} - {test.to} is correct: {test.VerifyResults(answer)}. Answer given in {sw.ElapsedTicks} ticks");
                    sw.Reset();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("All done. Press key to exit.");
            Console.ReadKey();
        }

        private static List<Test> BuildTests()
        {
            List<Test> output = new List<Test>();
            output.Add(new Test { from = 1, to = 10 });
            output.Add(new Test { from = 20, to = 100, results = new List<int> { 31, 37, 43, 53, 61, 79 } });
            output.Add(new Test { from = 500, to = 1000, results = new List<int> { 509, 521, 541, 577, 601, 619, 631, 727, 773, 787, 811, 829, 853, 883, 907, 919, 947, 967, 991 } });
            output.Add(new Test { from = 1, to = 100, results = new List<int> { 13, 19, 31, 37, 43, 53, 61, 79 } });
            output.Add(new Test { from = 100, to = 800, results = new List<int> { 101, 113, 139, 163, 173, 199, 211, 223, 241, 269, 277, 331, 353, 373, 397, 457, 463, 509, 521, 541, 577, 601, 619, 631, 727, 773, 787 } });
            output.Add(new Test { from = 12, to = 12 });
            output.Add(new Test { from = 14, to = 18 });
            output.Add(new Test { from = 13, to = 13, results = new List<int> { 13 } });
            output.Add(new Test { from = 13, to = 19, results = new List<int> { 13, 19 } });
            output.Add(new Test { from = 1, to = 1000, results = new List<int> { 13, 19, 31, 37, 43, 53, 61, 79, 101, 113, 139, 163, 173, 199, 211, 223, 241, 269, 277, 331, 353, 373, 397, 457, 463, 509, 521, 541, 577, 601, 619, 631, 727, 773, 787, 811, 829, 853, 883, 907, 919, 947, 967, 991 } });
            return output;
        }
    }


}
