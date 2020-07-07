using System;
using System.Collections.Generic;

namespace Huffman
{
    public class Heap<T> where T : IComparable
    {
        private List<T> heap = new List<T>();

        public Heap(List<T> list)
        {
            foreach (var item in list)
            {
                this.Add(item);
            }
        }

        public T GetMinAndRemove()
        {
            T min;
            if (this.HeapCount() < 0) return default(T);
            if (this.HeapCount() == 1)
            {
                min = this.heap[0];
                this.heap.RemoveAt(0);
                return min;
            }

            min = this.heap[0];
            this.heap[0] = this.heap[this.HeapCount() - 1];
            this.heap.RemoveAt(this.HeapCount() - 1);
            this.Heapify(0);
            return min;
        }

        private int GetParentIndex(int of)
        {
            if ((of - 1) / 2 >= 0) return (of - 1) / 2;
            else return -1;
        }

        public int HeapCount()
        {
            return this.heap.Count;
        }

        public void Add(T newelement)
        {
            heap.Add(newelement);
            int i = this.HeapCount() - 1;


            while (i != 0 && heap[GetParentIndex(i)].CompareTo(heap[i]) > 0)
            {
                T temp = heap[GetParentIndex(i)];
                heap[GetParentIndex(i)] = heap[i];
                heap[i] = temp;
                i = GetParentIndex(i);
            }
        }

        private void Heapify(int index)
        {
            int leftIndex = 2 * index + 1;
            int rightIndex = 2 * index + 2;
            int smallest = index;

            if (leftIndex < this.HeapCount() && heap[leftIndex].CompareTo(heap[smallest]) < 0) smallest = leftIndex;
            if (rightIndex < this.HeapCount() && heap[rightIndex].CompareTo(heap[smallest]) < 0) smallest = rightIndex;
            if (smallest != index)
            {
                T temp = heap[smallest];
                heap[smallest] = heap[index];
                heap[index] = temp;
                Heapify(smallest);
            }
        }
    }
}