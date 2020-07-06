using System;
using System.Runtime.CompilerServices;

namespace Cuni.Arithmetics.FixedPoint
{
    public abstract class Q32Format<T> where T : Q32Format<T>
    {
        internal static int ScalingFactorBase;
        internal static int GetScalingFactor() => 1 << ScalingFactorBase;
    }

    public sealed class Q8_24 : Q32Format<Q8_24>
    {
        static Q8_24() => ScalingFactorBase = 24;
        
    }

    public sealed class Q16_16 : Q32Format<Q16_16>
    {
        static Q16_16() => ScalingFactorBase = 16;
    }

    public sealed class Q24_8 : Q32Format<Q24_8>
    {
        static Q24_8() => ScalingFactorBase = 8;
    }

    public interface IFixedArithmetics<T> where T: Q32Format<T>
    {
        Fixed<T> Add(Fixed<T> t2);
        Fixed<T> Subtract(Fixed<T> t2);
        Fixed<T> Multiply(Fixed<T> t2);
        Fixed<T> Divide(Fixed<T> t2);
        
    }
    public struct Fixed<T> : IFixedArithmetics<T>, IComparable<Fixed<T>>, IEquatable<Fixed<T>> where T : Q32Format<T>
    {
        private readonly int _representation;
        
        static Fixed()
        {
            RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        }
        public Fixed(int numberToStore)
        {
            _representation = numberToStore * Q32Format<T>.GetScalingFactor();
        }

        private Fixed(int fixedPointValue, bool withFixedPint = true)
        {
            _representation = fixedPointValue;
        }

        public double ToDouble()
        {
            return _representation / (double) (Q32Format<T>.GetScalingFactor());
        }
        public bool Equals(Fixed<T> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fixed<T>))
             return false;

            if (((Fixed<T>) obj)._representation == _representation)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return _representation;
        }

        public override string ToString()
        {
            return ToDouble().ToString();
        }
        
        public Fixed<T> Add(Fixed<T> t2)
        {
            return new Fixed<T>(fixedPointValue:_representation + t2._representation);
        }

        public Fixed<T> Subtract(Fixed<T> t2)
        {
            return new Fixed<T>(fixedPointValue:_representation - t2._representation);
        }

        public Fixed<T> Multiply(Fixed<T> t2)
        {
            return new Fixed<T>( fixedPointValue:
                (int)(_representation * (Int64) t2._representation) / Q32Format<T>.GetScalingFactor());
            
        }

        public Fixed<T> Divide(Fixed<T> t2)
        {
            return new Fixed<T>(fixedPointValue:
               (int) ( _representation * (Int64) Q32Format<T>.GetScalingFactor() / t2._representation));
            
        }

        public Fixed<TargetQ> ConvertTo<TargetQ>() where TargetQ : Q32Format<TargetQ> {
            
            int toShift = Q32Format<T>.ScalingFactorBase - Q32Format<TargetQ>.ScalingFactorBase;
            int shifted = (toShift > 0) ? _representation >> toShift : _representation << -toShift;
           
            return new Fixed<TargetQ>(fixedPointValue: shifted);
          
        }
        
        public int CompareTo(Fixed<T> other)
        {
            return _representation.CompareTo(other._representation);
        }
        
        public static implicit operator Fixed<T>(int numberToRepresent) => new Fixed<T>(numberToRepresent);
        public static implicit operator double(Fixed<T> f) => f.ToDouble();
     
        public static Fixed<T> operator +(Fixed<T> f1, Fixed<T> f2)
            => f1.Add(f2);

        public static Fixed<T> operator -(Fixed<T> f1, Fixed<T> f2)
            => f1.Subtract(f2);

        public static Fixed<T> operator /(Fixed<T> f1, Fixed<T> f2)
            => f1.Divide(f2);

        public static Fixed<T> operator *(Fixed<T> f1, Fixed<T> f2)
            => f1.Multiply(f2);
        
        public static bool operator ==(Fixed<T> f1, Fixed<T> f2)
            => f1.CompareTo(f2) == 0;
        
        public static bool operator !=(Fixed<T> f1, Fixed<T> f2)
            => f1.CompareTo(f2) != 0;
        
        public static bool operator >(Fixed<T> f1, Fixed<T> f2)
            => f1.CompareTo(f2) == 1;
        
        public static bool operator >=(Fixed<T> f1, Fixed<T> f2)
            => f1.CompareTo(f2) >= 0;
        
        public static bool operator <(Fixed<T> f1, Fixed<T> f2)
            => f1.CompareTo(f2) == -1;
        
        public static bool operator <=(Fixed<T> f1, Fixed<T> f2)
            => f1.CompareTo(f2) <= 0;
    }
}