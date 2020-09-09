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

//        var outputStream = new MemoryStream();
//            using (var inputStream = File.Open(@"c:\temp\SpecialPrimeOddBitArray3.dat", FileMode.Open, FileAccess.Read, FileShare.Read))
//            using (var gzip = new GZipStream(inputStream, CompressionMode.Decompress))
//            {
//                gzip.CopyTo(outputStream);

//                gzip.Close();
//                inputStream.Close();

//                // After writing to the MemoryStream, the position will be the size
//                // of the decompressed file, we should reset it back to zero before returning.
//                outputStream.Position = 0;
//            }
//var boe2 = formatter.Deserialize(outputStream) as OddBitArray;



private static List<int> _result = new List<int>();
        private static OddBitArray _obaBig;

        public static List<int> Solve(int lower, int upper)
        {
            //List<int> _result;
            _result.Clear();
            if (lower % 2 == 0)
                lower = lower + 1;
            var oba = obaBig;
            for (int i = lower; i <= upper && i > 0; i = i + 2)
            {
                if (oba[i])
                    _result.Add(i);
            }
            return _result;
        }
    }
}
