using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Cuni.Arithmetics.FixedPoint;

namespace FixedPointApiTest
{
    
    public class FixedTest
    {
        private int[,] _testMatrix;
        private Matrix Q16_16Matrix;
        private FloatMatrix FloatMatrix;

        [Params(5,10)]
        public int dimension;

        [Params(100)] 
        public int maxValueInMatrix;

        [GlobalSetup]
        public void SetUp()
        {
            _testMatrix = RandomArray.GetRandomMatrixArray(dimension, maxValueInMatrix);
            Q16_16Matrix = new Matrix(_testMatrix, dimension);
            FloatMatrix = new FloatMatrix(_testMatrix, dimension);
        }

        [Benchmark]
        public void EliminateQ16_16Matrix() => Q16_16Matrix.EliminateRows();

        [Benchmark(Baseline = true)]
        public void EliminateFloatMatrix() => FloatMatrix.EliminateRows();
        
    }
}