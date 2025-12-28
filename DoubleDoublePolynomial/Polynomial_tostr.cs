using DoubleDouble;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace DoubleDoublePolynomial {

    [DebuggerDisplay("{ToString(),nq}")]
    public partial class Polynomial {
        public override string ToString() {
            IEnumerable<string> terms = coefs.Select((c, i) =>
                c != 0d ? i switch {
                    0 => $"{c}",
                    1 => (c != 1d && c != -1d) ? $"{c} x" : ddouble.IsNegative(c) ? "-x" : "x",
                    _ => (c != 1d && c != -1d) ? $"{c} x^{i}" : ddouble.IsNegative(c) ? $"-x^{i}" : $"x^{i}"
                }
                : string.Empty).Where(s => s.Length > 0);

            string s = string.Join(" + ", Order == Order.Less ? terms : terms.Reverse()).Replace(" + -", " - ");

            if (s.Length == 0) {
                s = "0";
            }

            return s;
        }
    }
}
