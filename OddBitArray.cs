using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SpecialPrimes
{
    public class OddBitArray
    {
        private readonly BitArray bitArray;
        public OddBitArray(int highestIndex)
        {
            bitArray = new BitArray(OddIndex(highestIndex));
        }

        public OddBitArray(BitArray bitArray)
        {
            this.bitArray = bitArray;
        }

        private int OddIndex(int index)
        {
            return (index - 1)/2;
        }

        public bool this[int index]
        {
            get => bitArray[OddIndex(index)];
            set => bitArray[OddIndex(index)] = value;
        }
        public BitArray rawBitArray
        {
            get => bitArray;
        }

    }
}
