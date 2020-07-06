using System;
using BenchmarkDotNet.Attributes;
using Cuni.Arithmetics.FixedPoint;

namespace FixedPointApiTest
{

    public class Matrix  
    {
        public Fixed<Q16_16>[,] elements;
        private int dimension;

        public Matrix(int[,] elements, int dimension)
        {
            this.dimension = dimension;
            
            this.elements = new Fixed<Q16_16>[dimension,dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    this.elements[i, j] = elements[i, j];
                }
            }
        }

        public Fixed<Q16_16> this[int index1, int index2]
        {
            get => elements[index1, index2];
            set => elements[index1, index2] = value;
        }
        public void EliminateRows()
        {
            for (int i = 0; i < dimension-1 ; i++)
            {
                if (this[i,i] == 0)
                    continue;
                
                for (int j = i+1; j < dimension; j++)
                { 
                    var ratio = this[j, i] / this[i, i];
                    this[j,i] = 0;
                    
                    for (int k = i+1; k < dimension; k++)
                    {
                        this[j, k] = this[j, k] - ratio * this[i, k];
                    }
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(this[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
    
    public static class RandomArray
    {
        public static int[,] GetRandomMatrixArray(int dimension, int maxValue)
        {
            Random random = new Random();
            var elements = new int[dimension,dimension];
            
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    elements[i, j] = random.Next(maxValue);
                }
            }

            return elements;
        }   
        
    }

    public class FloatMatrix 
    {
        public float[,] elements;
        private int dimension;

        public FloatMatrix(int[,] elements, int dimension)
        {
            this.dimension = dimension;
            this.elements = new float[dimension,dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    this.elements[i, j] = elements[i, j];
                }
            }
        }

        public float this[int index1, int index2]
        {
            get => elements[index1, index2];
            set => elements[index1, index2] = value;
        }
        public void EliminateRows()
        {
            for (int i = 0; i < dimension-1 ; i++)
            {
                if (this[i,i] == 0)
                    continue;
                
                for (int j = i+1; j < dimension; j++)
                {
                    var ratio = this[j, i] / this[i, i];
                    this[j,i] = 0;
                    
                    for (int k = i+1; k < dimension; k++)
                    {
                        this[j, k] =this[j, k] - ratio * this[i, k];
                    }
                }
            }
        }
        
    }
    
}