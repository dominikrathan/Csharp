using System;

namespace Cuni.Arithmetics.FixedPoint
{
    internal static class Singleton<T> where T : Q32Format, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }

    }

    public abstract class Q32Format
    {
        public abstract int ScalingFactorBase { get; }
        public int GetScalingFactor() => (int) Math.Pow(2, ScalingFactorBase);
    }

    public sealed class Q8_24 : Q32Format
    {
        public override int ScalingFactorBase { get; } = 24;
    }

    public sealed class Q16_16 : Q32Format
    {
        public override int ScalingFactorBase { get; } = 16;

    }

    public sealed class Q24_8 : Q32Format
    {
        public override int ScalingFactorBase { get; } = 8;
    }

    public interface IFixedArithmetics<T> where T: Q32Format, new()
    {
        Fixed<T> Add(Fixed<T> t2);
        Fixed<T> Subtract(Fixed<T> t2);
        Fixed<T> Multiply(Fixed<T> t2);
        Fixed<T> Divide(Fixed<T> t2);
        
    }
    public struct Fixed<T> : IFixedArithmetics<T> where T : Q32Format, new()
    {
        private int Representation { get; set; }
        private T QFormat;

        public Fixed(int numberToStore)
        {
            QFormat = Singleton<T>.Instance;
            Representation = numberToStore * QFormat.GetScalingFactor();
        }

        public double GetRepresentedNumber()
        {
            return (double) Representation / QFormat.GetScalingFactor();
        }

        public override string ToString()
        {
            return GetRepresentedNumber().ToString();
        }

        private static Fixed<T> WithRepresentation(int representation)
        {
            var fixedWith = new Fixed<T>(representation);
            fixedWith.Representation = representation;
            return fixedWith;
        }

        public Fixed<T> Add(Fixed<T> t2)
        {
            return WithRepresentation(Representation + t2.Representation);
        }

        public Fixed<T> Subtract(Fixed<T> t2)
        {
            return WithRepresentation(Representation - t2.Representation);
        }

        public Fixed<T> Multiply(Fixed<T> t2)
        {
            return WithRepresentation( (int)(((Int64) Representation * (Int64) t2.Representation) / (1 << QFormat.ScalingFactorBase)));
            
        }

        public Fixed<T> Divide(Fixed<T> t2)
        {
            return WithRepresentation((int) (((Int64) Representation * (1 << QFormat.ScalingFactorBase)) / t2.Representation));
            
        }
    }
}