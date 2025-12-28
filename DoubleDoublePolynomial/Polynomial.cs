using DoubleDouble;
using System.Collections.ObjectModel;

namespace DoubleDoublePolynomial {
    public partial class Polynomial {
        private readonly ReadOnlyCollection<ddouble> coefs, coefs_reversed;

        public int Degree => int.Max(0, coefs.Count - 1);

        public Order Order { set; get; }

        public ddouble this[int index] => coefs[index];

        public ddouble[] Coefs => [.. coefs];

        protected Polynomial(ddouble[] coefs, bool orderless = true) {
            if (orderless) {
                coefs = coefs[..(Array.FindLastIndex(coefs, value => value != 0d) + 1)];

                this.coefs = new(coefs);
                this.coefs_reversed = new([.. coefs.Reverse()]);
            }
            else {
                int index = Array.FindIndex(coefs, value => value != 0d);
                if (index < 0) {
                    index = coefs.Length;
                }

                coefs = coefs[index..];

                this.coefs = new([.. coefs.Reverse()]);
                this.coefs_reversed = new(coefs);
            }

            Order = orderless ? Order.Less : Order.Greater;
        }

        public static Polynomial OrderLess(params ddouble[] coefs) => new(coefs, orderless: true);

        public static Polynomial OrderLess(IEnumerable<ddouble> coefs) => new([.. coefs], orderless: true);

        public static Polynomial OrderGreater(params ddouble[] coefs) => new(coefs, orderless: false);

        public static Polynomial OrderGreater(IEnumerable<ddouble> coefs) => new([.. coefs], orderless: false);

        public static Polynomial Zero => new([]);

        public static Polynomial Invalid => new([double.NaN]);
    }
}
