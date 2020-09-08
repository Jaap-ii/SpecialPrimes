using SevenZip.Compression.LZMA;
using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace SuperfastSpecialPrimes
{
    public class Primer
    {
        private static OddBitArray obaSmall { get; set; }
        public static void boe()
        {
            var ass = Assembly.GetExecutingAssembly();
            var formatter = new BinaryFormatter();
            using (var stream = ass.GetManifestResourceStream("SuperfastSpecialPrimes.SpecialPrimeOddBitArraySmall.dat"))
            {
                obaSmall = formatter.Deserialize(stream) as OddBitArray;
            }
        }
    }
}
