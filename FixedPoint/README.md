# Fixed Point Library
Fixed point arithmetic library
## Supported formats
### Q32Format\<T\>
Represents the format of 32bit signed fixed point number.


      public abstract class Q32Format<T> where T : Q32Format<T>

For now only 32bit signed fixed point numbers are supported.

**Inheretors**:
 - `Q8_24` - 32bit signed fixed point number, 8bit real part and 24bit fractional part
 - `Q16_16` - 32bit signed fixed point number, 16bit real part and 16bit fractional part
 - `Q24_8` - 32bit signed fixed point number, 24 real part and 8bit fractional part

## Usage
 ### Fixed\<T\> struct
 Represents fixed point number where `T` specifies one of the Q type above.

    Fixed<T> : IFixedArithmetics<T>, IComparable<Fixed<T>>, IEquatable<Fixed<T>> where T : Q32Format<T>

**Inheretance**: Object -> Fixed\<T\>
**Implements**: IFixedArithmetics\<T\>, IComparable<Fixed\<T\>>, IEquatable<Fixed\<T\>>

### Initialization
 You have to options for initializing your new fixed point number:
 - using the constructor that takes an `int` as the only argument:
 -- `var f = new Fixed<Q8_24>(5);`
 - using the implicit conversion from `int`:
 -- `Fixed<Q8_24> f = 5;`

 ### Methods

 - `Fixed<T> Add(Fixed<T> t2)`
 - `Fixed<T> Subtract(Fixed<T> t2)`
 - `Fixed<T> Divide(Fixed<T> t2)`
 - `Fixed<T> Multiply(Fixed<T> t2)`
 - `public Fixed<TargetQ> ConvertTo<TargetQ>() where TargetQ : Q32Format<TargetQ>`
 -- converts the fixed point to another Q format
 - `int CompareTo(Fixed<T> other)`
 - `string ToString()`
 - `int GetHashCode()`
 - `bool Equals(object obj)`
 -  `bool Equals(Fixed<T> other)`
 - `double ToDouble()`

#### Overriden operators
In order to make the API more fluent following operators are overridden, however they are equivalent to corresponding methods above:

 - \+
 - \-
 - \/
 - \*
 - ==
 - !=
 - \>
 - \<
 - \>=
 - \<=
#### Implicit conversions
- `int` -> `Fixed<T>`
- '`Fixed<T>`-> `double`
### Example

The following code demonstrates usage of the fixed point library on Gaussian elimination:



    public class Matrix {  
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


## Remarks
### Implementation details

 1. The Q format is defined as `public abstract class Q32Format<T> where T : Q32Format<T>`just so we can simulate having an 'abstract static' property `ScalingFactorBase`.
 2. The static constructor of `Fixed<T>` forces calling  the `Q32Format<T>` inheretors constructors using the `.NET`'s `RuntimeHelpers` class. This is because the QFormats are never instantiated but we need to access their static properties.
 3. The private constructor `Fixed(int fixedPointValue, bool withFixedPint = true)` is present just so that we can distinguish if the parameter passed is already the representation or number to represent.

### Performace
The performance of the library was tested with `BenchmarkDotNet` library on the example above. As you can see down below the performance is a bit worse than on `.NET`'s `System.Single` (`float`). I also tried running tests on all of the operations and the biggest difference is on multiplication and division (probably since they both include two operations of multiplication and division) - cca 1.5 times slower.

Small optimization can be made by removing casting to `Int64` before division/multiplication, however we loose half of the precision - the result of the operation can overflow even if the result is still representable by our Q format.

**With casting to 64bit integer:**
|                Method | dimension | maxValueInMatrix |       Mean |    Error |    StdDev | Ratio | RatioSD |
|---------------------- |---------- |----------------- |-----------:|---------:|----------:|------:|--------:|
| EliminateQ16_16Matrix |         5 |              100 |   600.3 ns | 11.38 ns |  10.08 ns |  3.79 |    0.09 |
|  EliminateFloatMatrix |         5 |              100 |   158.3 ns |  3.02 ns |   2.68 ns |  1.00 |    0.00 |
|                       |           |                  |            |          |           |       |         |
| EliminateQ16_16Matrix |        10 |              100 | 3,866.3 ns | 69.17 ns |  57.76 ns |  3.10 |    0.12 |
|  EliminateFloatMatrix |        10 |              100 | 1,238.1 ns | 22.48 ns |  41.11 ns |  1.00 |    0.00 |


**Without casting to 64bit integer:**

|                Method | dimension | maxValueInMatrix |       Mean |    Error |   StdDev | Ratio | RatioSD |
|---------------------- |---------- |----------------- |-----------:|---------:|---------:|------:|--------:|
| EliminateQ16_16Matrix |         5 |              100 |   297.8 ns |  5.60 ns | 11.18 ns |  1.93 |    0.06 |
|  EliminateFloatMatrix |         5 |              100 |   155.3 ns |  2.19 ns |  2.05 ns |  1.00 |    0.00 |
|                       |           |                  |            |          |          |       |         |
| EliminateQ16_16Matrix |        10 |              100 | 2,427.5 ns | 48.41 ns | 79.54 ns |  1.97 |    0.09 |
|  EliminateFloatMatrix |        10 |              100 | 1,234.5 ns | 24.05 ns | 28.63 ns |  1.00 |    0.00 |
