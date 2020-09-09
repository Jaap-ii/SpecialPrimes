using SevenZip.Compression.LZMA;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace SuperfastSpecialPrimes
{
    public class Primer
    {
        private static OddBitArray _obaSmall;
        private static OddBitArray obaSmall
        {
            get
            {
                if (_obaSmall == null)
                {
                    var ass = Assembly.GetExecutingAssembly();
                    var formatter = new BinaryFormatter();
                    using (var stream = ass.GetManifestResourceStream("SuperfastSpecialPrimes.SpecialPrimeOddBitArraySmall.dat"))
                    {
                        _obaSmall = formatter.Deserialize(stream) as OddBitArray;
                    }
                }
                return _obaSmall;
            }
        }

        public static List<int> Solve(int lower, int upper)
        {
            List<int> result = new List<int>();
            if (lower % 2 == 0)
                lower = lower + 1;
            var oba = obaSmall;
            for (int i = lower; i <= upper && i > 0; i = i + 2)
            {
                if (oba[i])
                    result.Add(i);
            }
            return result;
        }
    }
}
