# DoubleDoublePolynomial
 Double-Double Polynomial Implements 

## Requirement
.NET 10.0  
[DoubleDouble](https://github.com/tk-yoshimura/DoubleDouble)  
[DoubleDoubleComplex](https://github.com/tk-yoshimura/DoubleDoubleComplex)  
[Algebra](https://github.com/tk-yoshimura/Algebra)  
[ComplexAlgebra](https://github.com/tk-yoshimura/ComplexAlgebra)  
[MultiPrecision](https://github.com/tk-yoshimura/MultiPrecision)  
[MultiPrecisionComplex](https://github.com/tk-yoshimura/MultiPrecisionComplex)  
[MultiPrecisionAlgebra](https://github.com/tk-yoshimura/MultiPrecisionAlgebra)  
[MultiPrecisionComplexAlgebra](https://github.com/tk-yoshimura/MultiPrecisionComplexAlgebra)  

## Install

[Download DLL](https://github.com/tk-yoshimura/DoubleDoublePolynomial/releases)  
[Download Nuget](https://www.nuget.org/packages/tyoshimura.doubledouble.polynomial/)

## Usage
```csharp
Polynomial p1 = Polynomial.OrderLess(5, 1); // 5 + x
Polynomial p2 = Polynomial.OrderGreater(-1, -2); // -x - 2

Polynomial p3 = p1 * p2; // operator +, -, *, /, %

Vector roots = p3.RealRoots;

Polynomial p4 = Polynomial.Differentiate(p3);
Polynomial p5 = Polynomial.Integrate(p3);

Polynomial p6 = Polynomial.Parse("3 - 4.2 x + 8 x^2 + 1.0e-6 x^4");
```

## Licence
[MIT](https://github.com/tk-yoshimura/DoubleDoublePolynomial/blob/main/LICENSE)

## Author

[T.Yoshimura](https://github.com/tk-yoshimura)
