using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Huffman
{
    public static class Huffman
    {
        private static HuffmanTree huffmanTree;
        private static BinaryReader readerIn;
        public static BinaryWriter writerOut;


        private const int MAX_BUFFER_SIZE = 4096; // 4KiB

        public static void SetReader(string pathIn)
        {
            readerIn = new BinaryReader(File.OpenRead(pathIn));
            huffmanTree = new HuffmanTree(pathIn);
        }

        public static void SetWriter(string pathOut)
        {
            writerOut = new BinaryWriter(File.OpenWrite(pathOut));
        }
        
        public static void PrintTree(StreamWriter sw)
        {
            if (!huffmanTree.IsNull())
                PrintRec(huffmanTree.root);
        }
        private static void PrintRec(Node root)
        {
            if (!root.IsLeaf())
            {
                Console.Write(root.Value + " ");
                if (root.left != null) PrintRec(root.left);
                if (root.right != null) PrintRec(root.right);
            }
            else
            {
                Console.Write("*" + (int) root.Key + ":" + root.Value + " ");
            }
        }
        public static void PrintHeader()
        {
            byte[] header = {0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66};
            writerOut.Write(header);
        }
        private static Node DecodeRoot() 
        {
            
            Stack<Node> nodeStack = new Stack<Node>();
            Node root = null;
            byte[] sequence;
            
            while (!(sequence = readerIn.ReadBytes(8)).IsZero())
            {

                if (root != null) return null;
                
                BitArray nodeArray = new BitArray(sequence);
                Node decodedNode = nodeArray.Decode();
               
                if (decodedNode.innerNode) nodeStack.Push(decodedNode);
                else
                {
                    while (nodeStack.Count > 0)
                    {
                        Node inner = nodeStack.Peek();
                        if (inner.AddChildren(decodedNode))
                        {
                            nodeStack.Pop();
                            decodedNode = inner;
                        }
                        else
                        {
                            decodedNode = null;
                            break;
                        }

                    }
                    
                    if (decodedNode != null)
                    {
                        root = decodedNode;
                    }
                }
            }

            if (nodeStack.Count != 0) root = null;
            
            return root;

        }
        private static void DecodeAndPrintTree(HuffmanTree huffmanTree)
        {
            
            Node current = huffmanTree.root;
            
            while (readerIn.BaseStream.Position != readerIn.BaseStream.Length)
            {
                byte[] bufferOfBytes = readerIn.ReadBytes(MAX_BUFFER_SIZE / 8);
                BitArray bitArray = new BitArray(bufferOfBytes);
                
                for (int i = 0; i < bitArray.Length; i++)
                {
                    if (bitArray[i] == false)
                    {
                        if (current.left == null) Exit();
                        current = current.left;
                    }
                    else
                    {
                        if (current.right == null) Exit();
                        current = current.right;
                    }

                    if (current.IsLeaf())
                    {
                      
                        if (current.Value != 0)
                        {
                            writerOut.Write(current.Key);
                            current.Value--;
                        }

                        current = huffmanTree.root;
                    }

                }

            }

        }
        private static bool TryReadHeader()
        {
            if (readerIn.BaseStream.Position != 0) return false;
           
            byte[] header = readerIn.ReadBytes(8);
            if (header.IsEqualTo(new byte[] {0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66})) return true;
           
            return false;
        }
        private static void PrintEncodedNode(Node root)
        {
            byte[] encodedNode = root.Encode().GetByteArray();

            if (!root.IsLeaf())
            {
                writerOut.Write(encodedNode);
                if (root.left != null) PrintEncodedNode(root.left);
                if (root.right != null) PrintEncodedNode(root.right);
            }
            else
            {
                writerOut.Write(encodedNode);
            }
        }
        public static void PrintEncodedPrefix()
        {
            if (huffmanTree.IsNull()) return;
            PrintEncodedNode(huffmanTree.root);
            writerOut.Write(0);
            writerOut.Write(0);
        }
        public static void PrintEncodedTree()
        {
            huffmanTree.GenerateNodesEncoding();
            using (readerIn)
            {
                BitArray bufferEncodedTree = new BitArray(MAX_BUFFER_SIZE * 8);
                BitArray leftover;
                int currentpos = 0;

                while (readerIn.BaseStream.Position != readerIn.BaseStream.Length) // proc ze je tohle nebezpecny?
                {
                    byte[] bufferOfReadBytes = readerIn.GetBuffer(MAX_BUFFER_SIZE);
                    foreach (var item in bufferOfReadBytes)
                    {
                        BitArray itemCode = huffmanTree.codes[item];
                        if (itemCode.Count + currentpos >= bufferEncodedTree.Length)
                        {
                            bufferEncodedTree.CopyTo(currentpos, bufferEncodedTree.Length - currentpos, itemCode);
                            writerOut.Write(bufferEncodedTree.GetByteArray());
                            currentpos = (itemCode.Count + currentpos) - bufferEncodedTree.Length;

                            if (currentpos != 0)
                            {
                                bufferEncodedTree = new BitArray(MAX_BUFFER_SIZE * 8);
                                leftover = itemCode.GetRange(itemCode.Count - currentpos, itemCode.Count - 1);
                                bufferEncodedTree.CopyTo(0, leftover.Length, leftover);
                            }
                        }
                        else
                        {
                            bufferEncodedTree.CopyTo(currentpos, itemCode.Count, itemCode);
                            currentpos += itemCode.Count;
                        }
                    }
                }

                if (currentpos != 0)
                {
                    while (currentpos % 8 != 0) currentpos++;
                    leftover = bufferEncodedTree.GetRange(0, currentpos - 1);
                    writerOut.Write(leftover.GetByteArray());
                }
            }
        }
        public static void PrintDecodedTree(string pathOut)
        {
            using (readerIn)
            {
                if (!TryReadHeader()) 
                    Exit();
                HuffmanTree huffmanTree = new HuffmanTree();
                huffmanTree.root = DecodeRoot();
                if (huffmanTree.root == null) 
                    Exit();
                SetWriter(pathOut);
                DecodeAndPrintTree(huffmanTree);
                readerIn.Close();
            }
        }

        public static void Exit()
        {
            Console.WriteLine("File Error");
            Environment.Exit(1);
        }
    }
}