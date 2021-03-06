﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace HyperfastSpecialPrimes
{
    public class Primer
    {
        private static int[] _specialPrimes;
        private static int[] specialPrimes
        {
            get
            {
                if (_specialPrimes == null)
                {
                    var ass = Assembly.GetExecutingAssembly();
                    var formatter = new BinaryFormatter();
                    using (var stream = ass.GetManifestResourceStream("HyperfastSpecialPrimes.SpecialPrimeList.dat"))
                    {
                        _specialPrimes = formatter.Deserialize(stream) as int[];
                    }
                }
                return _specialPrimes;
            }
        }
        public static List<int> Solve(int lower, int upper)
        {
            List<int> result = new List<int>();
            if (lower % 2 == 0)
                lower = lower + 1;
            var arr = specialPrimes;
            var index = Array.BinarySearch(arr, lower);
            index = Math.Abs(index);
            if (index == 0)
                index=1;
            int val = arr[index - 1];
            if (val < lower)
                index = index + 1;
            for (int i = index; i <= arr.Length; i++)
            {
                val = arr[i - 1];
                if (val > upper)
                    break;
                result.Add(val);
            }
            return result;
        }

    }
}
