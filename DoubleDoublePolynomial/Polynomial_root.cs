using Algebra;
using ComplexAlgebra;
using DoubleDouble;
using DoubleDoubleComplex;
using MultiPrecision;
using System.Diagnostics;

namespace DoubleDoublePolynomial {
    public partial class Polynomial {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Matrix CompanionMatrix {
            get {
                int n = Degree;

                if (n <= 0) {
                    return Matrix.Invalid(1);
                }

                Matrix m = Matrix.Zero(n);

                ddouble r = ddouble.Abs(coefs[^1]);

                for (int i = 0; i < n; i++) {
                    m[n - 1, i] = -coefs[i] / r;
                }

                for (int i = 0; i < n - 1; i++) {
                    m[i, i + 1] = 1d;
                }

                return m;
            }
        }

        protected MultiPrecisionAlgebra.Matrix<N> CompanionMatrixMultiPrecision<N>() where N : struct, IConstant {
            int n = Degree;

            if (n <= 0) {
                return MultiPrecisionAlgebra.Matrix<N>.Invalid(1);
            }

            MultiPrecisionAlgebra.Matrix<N> m = MultiPrecisionAlgebra.Matrix<N>.Zero(n);

            MultiPrecision<N> r = MultiPrecision<N>.Abs($"{coefs[^1]}");

            for (int i = 0; i < n; i++) {
                m[n - 1, i] = $"{coefs[i]}" / -r;
            }

            for (int i = 0; i < n - 1; i++) {
                m[i, i + 1] = MultiPrecision<N>.One;
            }

            return m;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ComplexVector Roots => Degree <= 2
            ? RootsLessDegree()
            : new ComplexVector(
                MultiPrecisionComplexAlgebra.ComplexMatrix<Pow2.N8>.EigenValues(CompanionMatrixMultiPrecision<Pow2.N8>())
                .Select((item) => (Complex)$"{item}")
            );

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Vector RealRoots => Degree <= 2 ? RealRootsLessDegree() :
            new(Roots.Where(c => ddouble.Ldexp(ddouble.Abs(c.val.R), -100) >= ddouble.Abs(c.val.I) || ddouble.Abs(c.val.I) < 1e-250)
                     .Select(c => c.val.R).OrderBy(r => r)
            );

        private ComplexVector RootsLessDegree() {
            Debug.Assert(Degree <= 2);

            if (Degree < 1) {
                return new Vector(Array.Empty<ddouble>());
            }
            if (Degree <= 1) {
                return new Vector(-coefs[0] / coefs[1]);
            }

            ddouble a = coefs[2], b = coefs[1] / a, c = coefs[0] / a;

            ddouble d = b * b - ddouble.Ldexp(c, 2);

            Complex e = Complex.Sqrt(d);

            Complex z1, z2;

            if (ddouble.IsPositive(b)) {
                Complex f = -e - b;

                z1 = Complex.Ldexp(f, -1);
                z2 = ddouble.Ldexp(c, 1) / f;
            }
            else {
                Complex f = e - b;

                z1 = ddouble.Ldexp(c, 1) / f;
                z2 = Complex.Ldexp(f, -1);
            }

            return new ComplexVector(z1, z2);
        }

        private Vector RealRootsLessDegree() {
            Debug.Assert(Degree <= 2);

            if (Degree < 1) {
                return new Vector(Array.Empty<ddouble>());
            }
            if (Degree <= 1) {
                return new Vector(-coefs[0] / coefs[1]);
            }

            ddouble a = coefs[2], b = coefs[1] / a, c = coefs[0] / a;

            ddouble d = b * b - ddouble.Ldexp(c, 2);

            if (d >= 0d) {
                ddouble e = ddouble.Sqrt(ddouble.Max(0d, d));

                ddouble x1, x2;

                if (ddouble.IsPositive(b)) {
                    ddouble f = -e - b;

                    x1 = ddouble.Ldexp(f, -1);
                    x2 = ddouble.Ldexp(c, 1) / f;
                }
                else {
                    ddouble f = e - b;

                    x1 = ddouble.Ldexp(c, 1) / f;
                    x2 = ddouble.Ldexp(f, -1);
                }

                if (x1 < x2) {
                    return new Vector(x1, x2);
                }
                else {
                    return new Vector(x2, x1);
                }
            }
            else {
                return new Vector(Array.Empty<ddouble>());
            }
        }
    }
}
