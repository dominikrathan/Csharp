using System;
using System.Collections;
using System.Collections.Generic;

namespace Huffman
{
    public class HuffmanTree
    {
        public Node root;
       
        public BitArray[] codes = new BitArray[256];

        public HuffmanTree(string path)
        {
            Forest forest = new Forest(path);
            List<Node> treesList = new List<Node>();
            foreach (var item in forest.treesList) treesList.Add(new Node(item.Key, item.Value));
            Heap<Node> heapedForest = new Heap<Node>(treesList);

            while (heapedForest.HeapCount() > 1)
            {
                Node firstSmallest = heapedForest.GetMinAndRemove();
                Node secondSmallest = heapedForest.GetMinAndRemove();
                Node merged = null;

                if (firstSmallest.CompareTo(secondSmallest) < 1) merged = Node.Merge(firstSmallest, secondSmallest);
                else merged = Node.Merge(secondSmallest, firstSmallest);

                heapedForest.Add(merged);
                if (heapedForest.HeapCount() == 1) this.root = merged;
            }
        }
        public HuffmanTree()
        {
            
        }
        public bool IsNull()
        {
            return (this.root == null);
        }
        public void GenerateNodesEncoding()
        {
            GenerateBitSequence(root);
        }
        private void GenerateBitSequence(Node node)
        {
            if (node == null) throw new NullReferenceException();
            if (node == root) node.code = new List<bool>();

            if (node.left != null)
            {
                node.left.code = new List<bool>(node.code);
                node.left.code.Add(false);
                GenerateBitSequence(node.left);
            }

            if (node.right != null)
            {
                node.right.code = new List<bool>(node.code);
                node.right.code.Add(true);
                GenerateBitSequence(node.right);
            }

            if (node.IsLeaf())
                codes[node.Key] = node.code.ToBitArray();
        }
    }
}