using System;
using System.Collections;
using System.Collections.Generic;

namespace PL
{
    public class BitArray : IPLType, IEnumerable<bool>, ICloneable
    {
        private byte[] byteArray;
        private int length;
        public BitArray(int length)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException("Length BitArray must be > 0");
            this.length = length;
            byteArray = new byte[(length + 7) / 8];
        }
        public bool this[int index]
        {
            get
            {
                if ((index < 0) || (index >= length))
                    throw new ArgumentOutOfRangeException("Out of range BitArray");
                else
                    return (byteArray[index / 8] & (1 << (index % 8))) != 0;
            }
            set
            {
                if ((index < 0) || (index >= length))
                    throw new ArgumentOutOfRangeException("Out of range BitArray");
                if (value)
                {
                    byteArray[index / 8] = (Byte)(byteArray[index / 8] | (1 << (index % 8)));
                }
                else
                {
                    byteArray[index / 8] = (Byte)(byteArray[index / 8] & ~(1 << (index % 8)));
                }
            }
        }

        public object Clone()
        {
            BitArray copy = new BitArray(length);
            for (int i = 0; i < byteArray.Length; i++)
                copy.byteArray[i] = byteArray[i];
            return copy;
        }

        public IEnumerator<bool> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
