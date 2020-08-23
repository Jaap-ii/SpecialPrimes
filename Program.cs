
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

namespace SpecialPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //var boe = assembly.GetManifestResourceNames();
            //var sw = new Stopwatch();
            //sw.Start();
            //using (Stream stream = assembly.GetManifestResourceStream("SpecialPrimes.DataFile2.dat"))
            //sw.Stop();
            var atkin = new SieveOfAtkin(0, int.MaxValue-1);
            var boe5 = atkin.ToList();

            var primeTool = new PrimeTool();
            var oddBits = new OddBitArray(1, 1000);
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 1 ; i < 1000; i = i + 2)
            {
                if (FermatLittleTheorem.IsPrime(i) && primeTool.IsPrime(i))
                        oddBits[i] ^= true;
                if ((i % 100000) < 2)
                    Console.Write(".");
                if ((i % 10000000) < 2)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{i} of {int.MaxValue}, took {sw.ElapsedMilliseconds} ms");
                    sw.Restart();
                }
            }
            sw.Stop();
            BinaryFormatter formatter = new BinaryFormatter();
             FileStream fs2 = new FileStream(@"c:\temp\OddBits2.dat", FileMode.Create);
            formatter.Serialize(fs2, oddBits);

        }

    }


}
