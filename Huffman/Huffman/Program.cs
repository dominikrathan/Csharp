using System;
using System.IO;

namespace Huffman
{
    public class Program
    {
        public static void Encode(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Argument Error");
            }
            else
            {
                try
                {
                    Huffman.SetReader(args[1]);
                    Huffman.SetWriter(args[1] + ".huff");
                    using (Huffman.writerOut)
                    {
                        Huffman.PrintHeader();
                        Huffman.PrintEncodedPrefix();
                        Huffman.PrintEncodedTree();
                        Huffman.writerOut.Close();
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    Console.WriteLine("File Error");
                }
            }
        }
        public static void Decode(string[] args)
        {
            if (args.Length != 2 || !args[1].EndsWith(".huff") || args[1].Length <= ".huff".Length)
                Console.WriteLine("Argument Error");
            else
            {
                try
                {
                    Huffman.SetReader(args[1]);
                    using (Huffman.writerOut)
                    {
                        Huffman.PrintDecodedTree(args[1].Substring(0, args[1].Length - ".huff".Length));
                        Huffman.writerOut.Close();
                    }
                    
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("File Error");
                }
            }
        }

        /// <summary>
        /// Program.exe [Options] file_to_encode/decode
        /// Options: -e for encode, -d for decode
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Program.exe [Options] file_to_encode/decode");
                Console.WriteLine("Options: -e for encode, -d for decode");
                Environment.Exit(1);
            }

            if (args[0] == "-d")
            {
                Decode(args);
            }
            else if (args[0] == "-e")
            {
                Encode(args);
            }
            
        }
    }
}