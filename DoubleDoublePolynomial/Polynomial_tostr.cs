using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace DoubleDoublePolynomial {

    [DebuggerDisplay("{ToString(),nq}")]
    public partial class Polynomial : IFormattable {
        public override string ToString() {
            IEnumerable<string> terms = coefs.Select((c, i) => c != 0d ? i switch {
                0 => $"{c}",
                1 => $"{c} x",
                _ => $"{c} x^{i}"
            } : string.Empty).Where(s => s.Length > 0);

            string s = string.Join(" + ", Order == Order.Less ? terms : terms.Reverse()).Replace(" + -", " - ").Replace(" 1 x", " x");

            if (s.StartsWith("1 x")) {
                s = s[2..];
            }
            else if (s.StartsWith("-1 x")) {
                s = $"-{s[3..]}";
            }

            if (s.Length == 0) {
                s = "0";
            }

            return s;
        }

        public string ToString([AllowNull] string format, [AllowNull] IFormatProvider formatProvider) {
            if (string.IsNullOrWhiteSpace(format)) {
                return ToString();
            }

            format = format.Trim();

            IEnumerable<string> terms = coefs.Select((c, i) => c != 0d ? i switch {
                0 => $"{c.ToString(format)}",
                1 => $"{c.ToString(format)} x",
                _ => $"{c.ToString(format)} x^{i}"
            } : string.Empty).Where(s => s.Length > 0);

            string s = string.Join(" + ", Order == Order.Less ? terms : terms.Reverse()).Replace(" + -", " - ").Replace(" 1 x", " x");

            if (s.StartsWith("1 x")) {
                s = s[2..];
            }
            else if (s.StartsWith("-1 x")) {
                s = $"-{s[3..]}";
            }

            if (s.Length == 0) {
                s = "0";
            }

            return s;
        }

        public string ToString(string format) {
            return ToString(format, null);
        }
    }
}
