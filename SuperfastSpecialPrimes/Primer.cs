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
        private static OddBitArray _obaSmallDummy = new OddBitArray(1, 3);
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
        private static OddBitArray obaBig
        {
            get
            {
                if (_obaBig == null)
                {
                    var ass = Assembly.GetExecutingAssembly();
                    var formatter = new BinaryFormatter();
                    var outputStream = new MemoryStream();
                    using (var inputStream = ass.GetManifestResourceStream("SuperfastSpecialPrimes.SpecialPrimeOddBitArrayBig.dat.gz"))
                    using (var gzip = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(outputStream);
                        gzip.Close();
                        inputStream.Close();
                        outputStream.Position = 0;
                    }
                    _obaBig = formatter.Deserialize(outputStream) as OddBitArray;
                }
                return _obaBig;
            }
        }

        private static int[] spArray
        {
            get
            {
                if (_spArray == null)
                {
                    _spArray = Solve(0, int.MaxValue - 1).ToArray();
                }
                return _spArray;
            }
        }

        private static int[] _spArray;

        private static OddBitArray _obaBig;

        public static List<int> Solve(int lower, int upper)
        {
            List<int> result = new List<int>();
            if (lower % 2 == 0)
                lower = lower + 1;
            var oba = obaBig;
            for (int i = lower; i <= upper && i > 0; i = i + 2)
            {
                if (oba[i])
                    result.Add(i);
            }
            return result;
        }


    }
}
