using Algebra;
using ComplexAlgebra;
using DoubleDouble;
using DoubleDoubleComplex;

namespace DoubleDoublePolynomial {
    public partial class Polynomial {
        public ddouble Value(ddouble x) {
            if (coefs.Count < 1) {
                return 0d;
            }

            ddouble s = coefs_reversed[0];

            for (int i = 1; i < coefs_reversed.Count; i++) {
                s = s * x + coefs_reversed[i];
            }

            return s;
        }

        public Complex Value(Complex z) {
            if (coefs.Count < 1) {
                return 0d;
            }

            Complex s = coefs_reversed[0];

            for (int i = 1; i < coefs_reversed.Count; i++) {
                s = s * z + coefs_reversed[i];
            }

            return s;
        }

        public Vector Value(Vector x) {
            if (coefs.Count < 1) {
                return Vector.Zero(x.Dim);
            }

            Vector s = Vector.Fill(x.Dim, coefs_reversed[0]);

            for (int i = 1; i < coefs_reversed.Count; i++) {
                s = s * x + coefs_reversed[i];
            }

            return s;
        }

        public ComplexVector Value(ComplexVector z) {
            if (coefs.Count < 1) {
                return ComplexVector.Zero(z.Dim);
            }

            ComplexVector s = ComplexVector.Fill(z.Dim, coefs_reversed[0]);

            for (int i = 1; i < coefs_reversed.Count; i++) {
                s = s * z + coefs_reversed[i];
            }

            return s;
        }

        public IEnumerable<ddouble> Value(IEnumerable<ddouble> xs) {
            foreach (ddouble x in xs) {
                yield return Value(x);
            }
        }

        public IEnumerable<Complex> Value(IEnumerable<Complex> zs) {
            foreach (Complex z in zs) {
                yield return Value(z);
            }
        }
    }
}
