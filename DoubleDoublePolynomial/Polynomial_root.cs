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
        public Vector RealRoots =>
            new(Roots.Where(c => ddouble.Ldexp(ddouble.Abs(c.val.R), -80) >= ddouble.Abs(c.val.I) || ddouble.Abs(c.val.I) < 1e-250)
                     .Select(c => c.val.R).OrderBy(r => r)
            );
    }
}
