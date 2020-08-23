
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
            var assembly = Assembly.GetExecutingAssembly();
            var boe = assembly.GetManifestResourceNames();
            var sw = new Stopwatch();
            sw.Start();
            using (Stream stream = assembly.GetManifestResourceStream("SpecialPrimes.DataFile2.dat"))
            {
                BinaryFormatter formatter2 = new BinaryFormatter();
                BitArray boe3 = formatter2.Deserialize(stream) as BitArray;
            }
            sw.Stop();
            var primeTool = new PrimeTool();
            var oddBits = new OddBitArray(int.MaxValue);
            for (int i = 3; i < int.MaxValue; i = i + 2)
            {
                if (FermatLittleTheorem.IsPrime(i) && primeTool.IsPrime(i))
                    oddBits[i] ^= true;
                if ((i % 100000) < 2)
                    Console.Write(".");
                if ((i % 10000000) < 2)
                {
                    Console.WriteLine();
                    Console.WriteLine(i);
                    Console.WriteLine(int.MaxValue);
                }
            }
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(@"c:\temp\DataFile02.dat", FileMode.Create);
            formatter.Serialize(fs, oddBits.rawBitArray);
            //var b = new BitArray(int.MaxValue / 8);
            //FileStream fs2 = new FileStream(@"c:\temp\DataFile2.dat", FileMode.Create);
            //formatter.Serialize(fs2, b);

        }

    }


}
