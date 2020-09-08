using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SuperfastSpecialPrimes
{
    [Serializable]
    public class OddBitArray : ISerializable
    {
        private readonly BitArray _bitArray;
        private readonly int _startIndex;
        public OddBitArray(int startIndex, int highestIndex)
        {
            if (startIndex % 2 == 0)
                throw new Exception("OddBitArray is meant to store odd numbers, idiot!");
            _startIndex = startIndex;
            _bitArray = new BitArray(OddIndex(highestIndex));
        }

        protected OddBitArray(SerializationInfo info, StreamingContext context)
        {
            _startIndex = (int)info.GetValue("start", typeof(int));
            _bitArray = (BitArray)info.GetValue("data", typeof(BitArray));
        }

        private int OddIndex(int index)
        {
            return (index - _startIndex) /2;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("start", _startIndex);
            info.AddValue("data", _bitArray);
        }

        public bool this[int index]
        {
            get => _bitArray[OddIndex(index - _startIndex)];
            set => _bitArray[OddIndex(index - _startIndex)] = value;
        }

    }
}
