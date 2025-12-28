using DoubleDouble;

namespace DoubleDoublePolynomial {
    public partial class Polynomial {
        public static Polynomial operator +(Polynomial p) {
            return p;
        }

        public static Polynomial operator +(Polynomial p, ddouble c) {
            if (p.coefs.Count > 0) {
                ddouble[] coefs = p.Coefs;
                coefs[0] += c;

                Polynomial ret = OrderLess(coefs);
                ret.Order = p.Order;

                return ret;
            }
            else { 
                Polynomial ret = OrderLess(c);
                ret.Order = p.Order;

                return ret;
            }
        }

        public static Polynomial operator +(ddouble c, Polynomial p) {
            return p + c;
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2) {
            ddouble[] coefs = new ddouble[int.Max(p1.coefs.Count, p2.coefs.Count)];

            for (int i = 0; i < p1.coefs.Count; i++) {
                coefs[i] = p1.coefs[i];
            }

            for (int i = 0; i < p2.coefs.Count; i++) {
                coefs[i] += p2.coefs[i];
            }

            Polynomial ret = OrderLess(coefs);
            ret.Order = p1.Order;

            return ret;
        }

        public static Polynomial operator -(Polynomial p) {
            Polynomial ret = OrderLess(p.coefs.Select(p => -p));
            ret.Order = p.Order;

            return ret;
        }

        public static Polynomial operator -(Polynomial p, ddouble c) {
            if (p.coefs.Count > 0) {
                ddouble[] coefs = p.Coefs;
                coefs[0] -= c;

                Polynomial ret = OrderLess(coefs);
                ret.Order = p.Order;

                return ret;
            }
            else { 
                Polynomial ret = OrderLess(-c);
                ret.Order = p.Order;

                return ret;
            }
        }

        public static Polynomial operator -(ddouble c, Polynomial p) {
            return c + (-p);
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2) {
            ddouble[] coefs = new ddouble[int.Max(p1.coefs.Count, p2.coefs.Count)];

            for (int i = 0; i < p1.coefs.Count; i++) {
                coefs[i] = p1.coefs[i];
            }

            for (int i = 0; i < p2.coefs.Count; i++) {
                coefs[i] -= p2.coefs[i];
            }

            Polynomial ret = OrderLess(coefs);
            ret.Order = p1.Order;

            return ret;
        }

        public static Polynomial operator *(Polynomial p, ddouble c) {
            Polynomial ret = OrderLess(p.coefs.Select(p => p * c));
            ret.Order = p.Order;

            return ret;
        }

        public static Polynomial operator *(ddouble c, Polynomial p) {
            return p * c;
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2) {
            ddouble[] coefs = new ddouble[checked(p1.Degree + p2.Degree + 1)];

            for (int j = 0; j < p2.coefs.Count; j++) {
                for (int i = 0; i < p1.coefs.Count; i++) {
                    coefs[i + j] += p1.coefs[i] * p2.coefs[j];
                }
            }

            Polynomial ret = OrderLess(coefs);
            ret.Order = p1.Order;

            return ret;
        }

        public static Polynomial operator /(Polynomial p, ddouble c) {
            Polynomial ret = OrderLess(p.coefs.Select(p => p / c));
            ret.Order = p.Order;

            return ret;
        }

        public static (Polynomial quotient, Polynomial remainder) DivRem(Polynomial p1, Polynomial p2) {
            if (p1.Degree < p2.Degree) {
                return (Zero, p2);
            }
            if (p2.coefs.Count < 1) {
                return (Invalid, Invalid);
            }

            ddouble d = p2.coefs[^1];
            ddouble[] quotient = new ddouble[checked(p1.Degree - p2.Degree + 1)];
            ddouble[] remainer = [.. p1.coefs];

            for (int i = quotient.Length - 1; i >= 0; i--) {
                ddouble r = remainer[i + p2.coefs.Count - 1] / d;

                quotient[i] = r;

                remainer[i + p2.coefs.Count - 1] = 0d;
                for (int j = p2.coefs.Count - 2; j >= 0; j--) {
                    remainer[i + j] -= r * p2.coefs[j];
                }
            }

            Polynomial pq = OrderLess(quotient), pr = OrderLess(remainer);
            pq.Order = pr.Order = p1.Order;

            return (pq, pr);
        }

        public static Polynomial operator /(Polynomial p1, Polynomial p2) {
            return DivRem(p1, p2).quotient;
        }

        public static Polynomial operator %(Polynomial p1, Polynomial p2) {
            return DivRem(p1, p2).remainder;
        }

        public static Polynomial XShift(Polynomial p, ddouble mx) {
            int n = p.coefs.Count;
            
            ddouble[] coefs = new ddouble[n], v = new ddouble[checked(n + 1)];

            for (int j = 0; j < n; j++) {
                v[j] = 1d;

                for (int i = 0; i <= j; i++) {
                    coefs[i] += p.coefs[j] * v[i];
                }

                if (j < n - 1) {
                    ddouble[] w = new ddouble[n + 1];
                    w[0] = -mx * v[0];

                    for (int i = 1; i <= j; i++) {
                        w[i] = v[i - 1] - mx * v[i];
                    }

                    v = w;
                }
            }

            Polynomial ret = OrderLess(coefs);
            ret.Order = p.Order;

            return ret;
        }
    }
}
