using DoubleDouble;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DoubleDoublePolynomial {

    [DebuggerDisplay("{ToString(),nq}")]
    public partial class Polynomial {
        public override string ToString() {
            if (!IsValid(this)) {
                return "invalid";
            }

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

        public static bool TryParse(string s, out Polynomial polynomial) {
            if (!IsValidPolynomial(s)) {
                polynomial = Invalid;
                return false;
            }

            (Dictionary<int, ddouble> coefs, Order order) = ParsePolynomial(s);

            polynomial = FromTable(coefs, order);
            return true;
        }

        public static Polynomial Parse(string s) {
            if (!TryParse(s, out Polynomial p)) {
                throw new FormatException(nameof(s));
            }

            return p;
        }

        protected static bool IsValidPolynomial(string s) {
            Regex regex = PolynomialValidationRegex();

            return regex.IsMatch(s.Replace(" ", string.Empty));
        }

        protected static (Dictionary<int, ddouble> coefs, Order order) ParsePolynomial(string s) {
            Dictionary<int, ddouble> result = [];
            List<int> degrees = [];

            Regex regex = PolynomialRegex();

            foreach (Match match in regex.Matches(s)) {
                if (string.IsNullOrWhiteSpace(match.Value)) {
                    continue;
                }

                string str = match.Groups[1].Value.Replace(" ", string.Empty);
                ddouble coef;

                if (string.IsNullOrEmpty(str) || str == "+" || str == "-") {
                    coef = str == "-" ? -1d : 1d;
                }
                else {
                    coef = ddouble.Parse(str, CultureInfo.InvariantCulture);
                }

                int degree;
                if (match.Groups[2].Success) {
                    degree = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : 1;
                }
                else {
                    degree = 0;
                }

                if (result.ContainsKey(degree)) {
                    result[degree] += coef;
                }
                else {
                    result[degree] = coef;
                }

                degrees.Add(degree);
            }

            Order order = (degrees.Count < 1 || degrees[0] <= degrees[^1]) ? Order.Less : Order.Greater;

            return (result, order);
        }

        [GeneratedRegex(@"([+-]?\s*(?:\d+(?:\.\d+)?(?:e[+-]?\d+)?)?)\s*(x)?(?:\^(\d+))?", RegexOptions.IgnoreCase, "en-EN")]
        private static partial Regex PolynomialRegex();


        [GeneratedRegex(@"^[+-]?((\d+(\.\d+)?([eE][+-]?\d+)?)?x(\^\d+)?|\d+(\.\d+)?([eE][+-]?\d+)?)([+-]((\d+(\.\d+)?([eE][+-]?\d+)?)?x(\^\d+)?|\d+(\.\d+)?([eE][+-]?\d+)?))*$")]
        private static partial Regex PolynomialValidationRegex();
    }
}