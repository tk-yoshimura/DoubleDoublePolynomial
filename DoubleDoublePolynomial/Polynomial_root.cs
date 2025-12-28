using Algebra;
using ComplexAlgebra;
using DoubleDouble;
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ComplexVector Roots => ComplexMatrix.EigenValues(CompanionMatrix);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Vector RealRoots => Degree <= 2 ? RootsLessDegree() :
            new(Roots.Where(c => ddouble.Ldexp(ddouble.Abs(c.val.R), -80) >= ddouble.Abs(c.val.I) || ddouble.Abs(c.val.I) < 1e-250)
                     .Select(c => c.val.R).OrderBy(r => r)
            );

        private Vector RootsLessDegree() {
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
