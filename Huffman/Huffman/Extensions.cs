using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Huffman
{
    public static class ListExtension
    {
        public static BitArray ToBitArray(this List<bool> list)
        {
            int i = 0;
            BitArray ba = new BitArray(list.Count);

            while (i < ba.Length) ba[i] = list[i++];

            return ba;
        }
    }

    public static class BitArrayExtension
    {
        public static void CopyTo(this BitArray b, int position, int length, BitArray toCopy)
        {
            int j = 0;
            for (int i = position; i < (position + length); i++)
            {
                b[i] = toCopy[j++];
            }
        }

        public static void Print(this BitArray b)
        {
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i]) Console.Write("1");
                else Console.Write("0");
            }

            Console.WriteLine();
        }
        public static void Copy(this BitArray outputArray, BitArray from, int startIndex, int endIndex)
        {
            if (endIndex > from.Length) throw new ArgumentException("Ending index is higher than the length of the original array");
            if (endIndex-startIndex+1 > outputArray.Length) throw new ArgumentException("The size of output array is lesser than the size of data to copy");
            int j = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                outputArray[j++] = from[i];
            }
        }
        public static byte[] GetByteArray(this BitArray b)
        {
            int size = (b.Length - 1) / 8 + 1;
            byte[] bytearray = new byte[size];
            b.CopyTo(bytearray, 0);

            return bytearray;
        }

        public static BitArray GetRange(this BitArray b, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex) throw new Exception("Starting index must be lesser than ending index");

            BitArray cut = new BitArray(endIndex - startIndex + 1);
            int j = 0;
            for (int i = startIndex; i <= endIndex; i++)
                cut[j++] = b[i];

            return cut;
        }

        public static Node Decode(this BitArray b) 
        {
            bool innerNode = !b[0];

            BitArray weight = new BitArray(55);
            weight.Copy(b,1, 55);
            ulong value = weight.ToUlong();

            BitArray character = new BitArray(8);
            character.Copy(b,56,63);
            byte key = character.GetByteArray()[0];

            return new Node(key, value, innerNode);
            
        }
        public static ulong ToUlong(this BitArray b) 
        {
            int[] value = new int[2];
            b.CopyTo(value,0);
            return (uint) value[0] + ((ulong) (uint) value[1] << 32);
        }
    }

    public static class BinaryReaderExtension
    {
        public static byte[] GetBuffer(this BinaryReader br, int buffersize)
        {
            byte[] buffer;
            if (br.BaseStream.Length - br.BaseStream.Position < buffersize)
                buffer = br.ReadBytes((int) (br.BaseStream.Length - br.BaseStream.Position));
            else buffer = br.ReadBytes(buffersize);

            return buffer;
        }
        
    }

    public static class ByteArrayExtension
    {
        public static bool IsEqualTo(this byte[] array1, byte[] array2)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) break;
                if (i == array1.Length-1) return true;
            }

            return false;
        }

        public static byte[] SubArray(this byte[] array, int startPosition, int length)
        {
            if (startPosition+length > array.Length) throw new IndexOutOfRangeException();
            
            byte[] newarray = new byte[length]; 
            Array.Copy(array, startPosition, newarray, 0, length);

            return newarray;
        }
        public static bool IsZero(this byte[] array)
        {
            return array.IsEqualTo(new byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00});
        }
        
    }
}