using System;
using Xunit;
using Cuni.Arithmetics.FixedPoint;

namespace FixedTest
{
   public class UnitTest1
    {

        public int GetOverflownInt(int x, int powerOfTwo)
        {
            int power = (int) Math.Pow(2, powerOfTwo);
            
            if (x > power/2)
            {
                while (x > power/2)
                    x -= power;
            }

            if (x < -(power/2-1))
            {
                while (x < -(power/2-1))
                    x += power;
            }

            return x;
        }
        
        # region Q8_24
        
        [Theory]
        [InlineData(2,5)]
        [InlineData(52,30)]
        [InlineData(120,30)]

        public void AddTestQ8_24(int x, int y)
        {
            var expected = GetOverflownInt(x+y,8);

            var f1 = new Fixed<Q8_24>(x);
            var f2 = new Fixed<Q8_24>(y);
            var actual = f1.Add(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(2,5)]
        [InlineData(-52,30)]
        [InlineData(180,2656)]
        public void SubTestQ8_24(int x, int y)
        {
            var expected = GetOverflownInt(x - y,8);

            var f1 = new Fixed<Q8_24>(x);
            var f2 = new Fixed<Q8_24>(y);
            var actual = f1.Subtract(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(655,5)]
        [InlineData(-52,30)]
        [InlineData(56,4)]
        public void MultTestQ8_24(int x, int y)
        {
            var expected = GetOverflownInt(x* y,8);
            
            var f1 = new Fixed<Q8_24>(x);
            var f2 = new Fixed<Q8_24>(y);
            
            var actual = f1.Multiply(f2).GetRepresentedNumber();
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(655,5)]
        [InlineData(248,10)]
        [InlineData(56,4)]
        public void DivTestQ8_24(int x, int y)
        {
            var expected = GetOverflownInt(x,8) / (double)GetOverflownInt(y,8);

            var f1 = new Fixed<Q8_24>(x);
            var f2 = new Fixed<Q8_24>(y);
            var actual = Math.Round(f1.Divide(f2).GetRepresentedNumber(),1);
            
            Assert.Equal(expected,actual);
        }
        
        
        #endregion

        #region Q16_16

        [Theory]
        [InlineData(135455,255)]
        [InlineData(-1200,156)]
        public void AddTestQ16_16(int x, int y)
        {
            var expected = GetOverflownInt(x + y,16);
            
            var f1 = new Fixed<Q16_16>(x);
            var f2 = new Fixed<Q16_16>(y);
            var actual = f1.Add(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(45642,255)]
        [InlineData(-1200,156)]
        [InlineData(564,52)]
        public void SubTestQ16_16(int x, int y)
        {
            var expected = GetOverflownInt(x - y,16);
            
            var f1 = new Fixed<Q16_16>(x);
            var f2 = new Fixed<Q16_16>(y);
            var actual = f1.Subtract(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(563,26655)]
        [InlineData(-600,1556)]
        [InlineData(5654,5277)]
        public void MultTestQ16_16(int x, int y)
        {
            var expected = GetOverflownInt(x* y,16);
            
            var f1 = new Fixed<Q16_16>(x);
            var f2 = new Fixed<Q16_16>(y);
            var actual = f1.Multiply(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(1655,5)]
        [InlineData(2488,10)]
        [InlineData(5624,4)]
        public void DivTestQ16_16(int x, int y)
        {
            var expected = GetOverflownInt(x,16) / (double)GetOverflownInt(y,16);

            var f1 = new Fixed<Q16_16>(x);
            var f2 = new Fixed<Q16_16>(y);
            var actual = Math.Round(f1.Divide(f2).GetRepresentedNumber(),1);
            
            Assert.Equal(expected,actual);
        }
        
        #endregion

        #region Q24_8
        
        [Theory]
        [InlineData(569,0)]
        [InlineData(25632,-156)]
        public void AddTestQ24_8(int x, int y)
        {
            var expected = GetOverflownInt(x+y,24);
            
            var f1 = new Fixed<Q24_8>(x);
            var f2 = new Fixed<Q24_8>(y);
            var actual = f1.Add(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(569,56440)]
        [InlineData(2563562,-1556)]
        public void SubTestQ24_8(int x, int y)
        {
            var expected = GetOverflownInt(x-y,24);
            
            var f1 = new Fixed<Q24_8>(x);
            var f2 = new Fixed<Q24_8>(y);
            var actual = f1.Subtract(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(569,565440)]
        [InlineData(2,3)]
        [InlineData(5565592,-1556)]
        public void MultTestQ24_8(int x, int y)
        {
            var expected = GetOverflownInt(x*y,24);
            
            var f1 = new Fixed<Q24_8>(x);
            var f2 = new Fixed<Q24_8>(y);
            var actual = f1.Multiply(f2).GetRepresentedNumber();
            
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(16545,5)]
        [InlineData(245588,10)]
        [InlineData(524,4)]
        public void DivTestQ24_8(int x, int y)
        {
            var expected = GetOverflownInt(x,24) / (double)GetOverflownInt(y,24);

            var f1 = new Fixed<Q24_8>(x);
            var f2 = new Fixed<Q24_8>(y);
            var actual = Math.Round(f1.Divide(f2).GetRepresentedNumber(),1);
            
            Assert.Equal(expected,actual);
        }
        
        #endregion
    }
}