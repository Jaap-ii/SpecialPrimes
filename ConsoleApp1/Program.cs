
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
using System.IO.Compression;
using SuperfastSpecialPrimes;

namespace SpecialPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Primer.boe();
            return;
            int upper = int.MaxValue;
            int lower = 1;
            var sw = new Stopwatch();
            sw.Start();
            //var sp = new SpecialPrimeFinder(PrimeFinderFactory.CreatePrimeFinder(lower, upper));
            //int boe = 0;
            //var oba = new OddBitArray(lower,upper);
            //foreach (int i in sp.GetSpecialPrimes(lower, upper))
            //{
            //    oba[i] = true;
            //    boe++;
            //};
            //sw.Stop();

            //Console.WriteLine($"found {boe} took {sw.ElapsedMilliseconds} ms");
            //sw.Reset();
            //var formatter = new BinaryFormatter();
            //var fs = new FileStream(@"c:\temp\SpecialPrimeOddBitArray.dat", FileMode.Create);
            //formatter.Serialize(fs, oba);
            // Assembly.GetExecutingAssembly()
            // GetManifestoResourceStream()
            OddBitArray boe;
            var formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(@"c:\temp\SpecialPrimeOddBitArray.dat", FileMode.Open))
            {
                boe = formatter.Deserialize(stream) as OddBitArray;
            };
            var oba1 = new SuperfastSpecialPrimes.OddBitArray(1,1000001);
            for (int i=1;i<=1000001;i=i+2)
            {
                oba1[i] = boe[i];
            }
            using (var fs = new FileStream(@"c:\temp\SpecialPrimeOddBitArraySmall.dat", FileMode.Create))
            {
                formatter.Serialize(fs, oba1);
            }
            return;
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, boe);
                ms.Position = 0;
                using (FileStream compressedFileStream = File.Create(@"c:\temp\SpecialPrimeOddBitArray3.dat"))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                    {
                        ms.CopyTo(compressionStream);
                        compressionStream.Close();
                    }
                }
            }

            var outputStream = new MemoryStream();
            using (var inputStream = File.Open(@"c:\temp\SpecialPrimeOddBitArray3.dat", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var gzip = new GZipStream(inputStream, CompressionMode.Decompress))
            {
                gzip.CopyTo(outputStream);

                gzip.Close();
                inputStream.Close();

                // After writing to the MemoryStream, the position will be the size
                // of the decompressed file, we should reset it back to zero before returning.
                outputStream.Position = 0;
            }
            var boe2 = formatter.Deserialize(outputStream) as OddBitArray;
        }
        static void Main2(string[] args)
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
