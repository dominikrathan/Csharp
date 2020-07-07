using System.Collections.Generic;
using System.IO;

namespace Huffman
{
    public class Forest
    {
        private const int MAX_BUFFER_SIZE = 4096;

        public Dictionary<byte, ulong> treesList;

        public Forest(string path)
        {
            this.treesList = LoadForest(path);
        }

        private Dictionary<byte, ulong> LoadForest(string path)
        {
            BinaryReader inputBinaryReader = new BinaryReader(File.OpenRead(path));

            Dictionary<byte, ulong> forest = new Dictionary<byte, ulong>();

            using (inputBinaryReader)
            {
                while (inputBinaryReader.BaseStream.Position != inputBinaryReader.BaseStream.Length)
                {
                    byte[] buffer = inputBinaryReader.GetBuffer(MAX_BUFFER_SIZE);

                    foreach (var item in buffer)
                    {
                        if (forest.TryGetValue(item, out ulong currentValue))
                            forest[item] = ++currentValue;
                        else forest.Add(item, 1);
                    }
                }
                inputBinaryReader.Close();
            }

            return forest;
        }
    }
}