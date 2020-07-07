using System;
using System.Collections;
using System.Collections.Generic;

namespace Huffman
{
    public class Node : IComparable
    {
        public byte Key;
        public ulong Value;
        public Node left;
        public Node right;
        public bool innerNode;
        private static ulong count = 0;
        private ulong index;
        public List<bool> code;

        public Node(byte key, ulong value)
        {
            Key = key;
            Value = value;
            left = null;
            right = null;
        }

        public Node(byte key, ulong value, bool innerNode)
        {
            Key = key;
            Value = value;
            this.innerNode = innerNode;
        }

        public bool AddChildren(Node children)
        {
            if (left == null)
            {
                left = children;
                return false;
            } 
            if (right == null)
            {
                right = children;
            }

            return true;

        }
        public Node(byte key, ulong value, Node left, Node right)
        {
            this.Key = key;
            this.Value = value;
            this.left = left;
            this.right = right;
        }

        public int CompareTo(Object obj)
        {
            if (this.Value < ((Node) obj).Value) return -1;
            else if (this.Value > ((Node) obj).Value) return 1;
            else
            {
                if (this.IsLeaf() && !((Node) obj).IsLeaf()) return -1;
                else if (!this.IsLeaf() && ((Node) obj).IsLeaf()) return 1;
                else if (this.IsLeaf() && ((Node) obj).IsLeaf())
                {
                    if (this.Key < ((Node) obj).Key) return -1;
                    else return 1;
                }
                else if (!this.IsLeaf() && !((Node) obj).IsLeaf())
                {
                    if (this.index < ((Node) obj).index) return -1;
                    else return 1;
                }
                else return 0;
            }
        }

        public bool IsLeaf()
        {
            if (this.left == null && this.right == null) return true;
            else return false;
        }

        public static Node Merge(Node lighter, Node heavier)
        {
            Node node = new Node(
                (byte) (lighter.Key << 8 | heavier.Key),
                lighter.Value + heavier.Value,
                lighter,
                heavier);
            node.index = count++;
            return node;
        }
        
        public BitArray Encode()
        {
            BitArray encoded = new BitArray(64, false);
            BitArray value = new BitArray(BitConverter.GetBytes(this.Value));
            encoded.CopyTo(1, 55, value);

            if (IsLeaf())
            {
                encoded[0] = true;
                BitArray key = new BitArray(BitConverter.GetBytes(this.Key)); // tady se to pak uklada lsb-msb
                encoded.CopyTo(56, 8, key);
            }

            return encoded;
        }

    }
}