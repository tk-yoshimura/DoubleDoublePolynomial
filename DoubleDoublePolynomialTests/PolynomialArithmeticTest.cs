using DoubleDoublePolynomial;

namespace DoubleDoublePolynomialTests {
    [TestClass]
    public sealed class PolynomialArithmeticTest {

        [TestMethod]
        public void AddOrderLessTest() {
            Polynomial p1 = Polynomial.OrderLess(0);
            Polynomial p2 = Polynomial.OrderLess(3, 1);
            Polynomial p3 = Polynomial.OrderLess(5, 1);
            Polynomial p4 = Polynomial.OrderLess(-2, 1);
            Polynomial p5 = Polynomial.OrderLess(-1, -1);
            Polynomial p6 = Polynomial.OrderLess(2);
            Polynomial p7 = Polynomial.OrderLess(1, -2, 3);
            Polynomial p8 = Polynomial.OrderLess(-4, 5, -6);
            Polynomial p9 = Polynomial.OrderLess(2, 0, -1, 4);
            Polynomial p10 = Polynomial.OrderLess(-2, 1, 1, -3);

            Assert.AreEqual("8 + 2 x", (p2 + p3).ToString());
            Assert.AreEqual("8 + 2 x", (+(p2 + p3)).ToString());
            Assert.AreEqual("6 + 3 x", (p2 + p3 + p4).ToString());
            Assert.AreEqual("5 + 2 x", ((p2 + p3 + p4) + p5).ToString());
            Assert.AreEqual("0", (p1 + p1).ToString());
            Assert.AreEqual("0", (Polynomial.Zero + p1).ToString());
            Assert.AreEqual("5 + x", (p2 + p6).ToString());
            Assert.AreEqual("5 + x", (p6 + p2).ToString());
            Assert.AreEqual("-3 + 3 x - 3 x^2", (p7 + p8).ToString());
            Assert.AreEqual("3 - 2 x + 2 x^2 + 4 x^3", (p7 + p9).ToString());
            Assert.AreEqual("x + x^3", (p9 + p10).ToString());
            Assert.AreEqual("5 - 2 x + 3 x^2", (p7 + 4).ToString());
            Assert.AreEqual("5 - 2 x + 3 x^2", (4 + p7).ToString());
            Assert.AreEqual("4", (Polynomial.Zero + 4).ToString());
            Assert.AreEqual("4", (4 + Polynomial.Zero).ToString());
        }

        [TestMethod]
        public void AddOrderGreaterTest() {
            Polynomial p1 = Polynomial.OrderGreater(0);
            Polynomial p2 = Polynomial.OrderGreater(1, 3);
            Polynomial p3 = Polynomial.OrderGreater(1, 5);
            Polynomial p4 = Polynomial.OrderGreater(1, -2);
            Polynomial p5 = Polynomial.OrderGreater(-1, -1);
            Polynomial p6 = Polynomial.OrderGreater(2);
            Polynomial p7 = Polynomial.OrderGreater(3, -2, 1);
            Polynomial p8 = Polynomial.OrderGreater(-6, 5, -4);
            Polynomial p9 = Polynomial.OrderGreater(4, -1, 0, 2);
            Polynomial p10 = Polynomial.OrderGreater(-3, 1, 1, -2);

            Assert.AreEqual("2 x + 8", (p2 + p3).ToString());
            Assert.AreEqual("2 x + 8", (+(p2 + p3)).ToString());
            Assert.AreEqual("3 x + 6", (p2 + p3 + p4).ToString());
            Assert.AreEqual("2 x + 5", ((p2 + p3 + p4) + p5).ToString());
            Assert.AreEqual("0", (p1 + p1).ToString());
            Assert.AreEqual("0", (Polynomial.Zero + p1).ToString());
            Assert.AreEqual("x + 5", (p2 + p6).ToString());
            Assert.AreEqual("x + 5", (p6 + p2).ToString());
            Assert.AreEqual("-3 x^2 + 3 x - 3", (p7 + p8).ToString());
            Assert.AreEqual("4 x^3 + 2 x^2 - 2 x + 3", (p7 + p9).ToString());
            Assert.AreEqual("x^3 + x", (p9 + p10).ToString());
            Assert.AreEqual("3 x^2 - 2 x + 5", (p7 + 4).ToString());
            Assert.AreEqual("3 x^2 - 2 x + 5", (4 + p7).ToString());
            Assert.AreEqual("4", (Polynomial.Zero + 4).ToString());
            Assert.AreEqual("4", (4 + Polynomial.Zero).ToString());
        }

        [TestMethod]
        public void SubOrderLessTest() {
            Polynomial p1 = Polynomial.OrderLess(0);
            Polynomial p2 = Polynomial.OrderLess(3, 1);
            Polynomial p3 = Polynomial.OrderLess(5, 1);
            Polynomial p4 = Polynomial.OrderLess(-2, 1);
            Polynomial p5 = Polynomial.OrderLess(-1, -1);
            Polynomial p6 = Polynomial.OrderLess(2);
            Polynomial p7 = Polynomial.OrderLess(1, -2, 3);
            Polynomial p8 = Polynomial.OrderLess(-4, 5, -6);
            Polynomial p9 = Polynomial.OrderLess(2, 0, -1, 4);
            Polynomial p10 = Polynomial.OrderLess(-2, 1, 1, -3);

            Assert.AreEqual("-2", (p2 - p3).ToString());
            Assert.AreEqual("2", (p3 - p2).ToString());
            Assert.AreEqual("-8 - 2 x", (-(p2 + p3)).ToString());
            Assert.AreEqual("5", (p2 - p4).ToString());
            Assert.AreEqual("7", (p3 - p4).ToString());
            Assert.AreEqual("4 + 2 x", (p2 - p5).ToString());
            Assert.AreEqual("-1 - x", (p6 - p2).ToString());
            Assert.AreEqual("0", (p1 - p1).ToString());
            Assert.AreEqual("0", (Polynomial.Zero - p1).ToString());
            Assert.AreEqual("5 - 7 x + 9 x^2", (p7 - p8).ToString());
            Assert.AreEqual("-1 - 2 x + 4 x^2 - 4 x^3", (p7 - p9).ToString());
            Assert.AreEqual("4 - x - 2 x^2 + 7 x^3", (p9 - p10).ToString());
            Assert.AreEqual("-3 - 2 x + 3 x^2", (p7 - 4).ToString());
            Assert.AreEqual("3 + 2 x - 3 x^2", (4 - p7).ToString());
            Assert.AreEqual("-4", (Polynomial.Zero - 4).ToString());
            Assert.AreEqual("4", (4 - Polynomial.Zero).ToString());
        }

        [TestMethod]
        public void SubOrderGreaterTest() {
            Polynomial p1 = Polynomial.OrderGreater(0);
            Polynomial p2 = Polynomial.OrderGreater(1, 3);
            Polynomial p3 = Polynomial.OrderGreater(1, 5);
            Polynomial p4 = Polynomial.OrderGreater(1, -2);
            Polynomial p5 = Polynomial.OrderGreater(-1, -1);
            Polynomial p6 = Polynomial.OrderGreater(2);
            Polynomial p7 = Polynomial.OrderGreater(3, -2, 1);
            Polynomial p8 = Polynomial.OrderGreater(-6, 5, -4);
            Polynomial p9 = Polynomial.OrderGreater(4, -1, 0, 2);
            Polynomial p10 = Polynomial.OrderGreater(-3, 1, 1, -2);

            Assert.AreEqual("-2", (p2 - p3).ToString());
            Assert.AreEqual("2", (p3 - p2).ToString());
            Assert.AreEqual("-2 x - 8", (-(p2 + p3)).ToString());
            Assert.AreEqual("5", (p2 - p4).ToString());
            Assert.AreEqual("7", (p3 - p4).ToString());
            Assert.AreEqual("2 x + 4", (p2 - p5).ToString());
            Assert.AreEqual("-x - 1", (p6 - p2).ToString());
            Assert.AreEqual("0", (p1 - p1).ToString());
            Assert.AreEqual("0", (Polynomial.Zero - p1).ToString());
            Assert.AreEqual("9 x^2 - 7 x + 5", (p7 - p8).ToString());
            Assert.AreEqual("-4 x^3 + 4 x^2 - 2 x - 1", (p7 - p9).ToString());
            Assert.AreEqual("7 x^3 - 2 x^2 - x + 4", (p9 - p10).ToString());
            Assert.AreEqual("3 x^2 - 2 x - 3", (p7 - 4).ToString());
            Assert.AreEqual("-3 x^2 + 2 x + 3", (4 - p7).ToString());
            Assert.AreEqual("-4", (Polynomial.Zero - 4).ToString());
            Assert.AreEqual("4", (4 - Polynomial.Zero).ToString());
        }

        [TestMethod]
        public void MulOrderLessTest() {
            Polynomial p1 = Polynomial.OrderLess(0);
            Polynomial p2 = Polynomial.OrderLess(3, 1);
            Polynomial p3 = Polynomial.OrderLess(5, 1);
            Polynomial p4 = Polynomial.OrderLess(-2, 1);
            Polynomial p5 = Polynomial.OrderLess(-1, -1);
            Polynomial p6 = Polynomial.OrderLess(2);

            Assert.AreEqual("15 + 8 x + x^2", (p2 * p3).ToString());
            Assert.AreEqual("-30 - x + 6 x^2 + x^3", (p2 * p3 * p4).ToString());
            Assert.AreEqual("30 + 31 x - 5 x^2 - 7 x^3 - x^4", ((p2 * p3) * (p4 * p5)).ToString());
            Assert.AreEqual("0", (p1 * ((p2 * p3) * (p4 * p5))).ToString());
            Assert.AreEqual("0", (Polynomial.Zero * ((p2 * p3) * (p4 * p5))).ToString());
            Assert.AreEqual("60 + 62 x - 10 x^2 - 14 x^3 - 2 x^4", (2 * ((p2 * p3) * (p4 * p5))).ToString());
            Assert.AreEqual("60 + 62 x - 10 x^2 - 14 x^3 - 2 x^4", (((p2 * p3) * (p4 * p5)) * 2).ToString());
            Assert.AreEqual("60 + 62 x - 10 x^2 - 14 x^3 - 2 x^4", (((p2 * p3) * (p4 * p5)) * p6).ToString());
        }

        [TestMethod]
        public void MulOrderGreaterTest() {
            Polynomial p1 = Polynomial.OrderGreater(0);
            Polynomial p2 = Polynomial.OrderGreater(1, 3);
            Polynomial p3 = Polynomial.OrderGreater(1, 5);
            Polynomial p4 = Polynomial.OrderGreater(1, -2);
            Polynomial p5 = Polynomial.OrderGreater(-1, -1);
            Polynomial p6 = Polynomial.OrderGreater(2);

            Assert.AreEqual("x^2 + 8 x + 15", (p2 * p3).ToString());
            Assert.AreEqual("x^3 + 6 x^2 - x - 30", (p2 * p3 * p4).ToString());
            Assert.AreEqual("-x^4 - 7 x^3 - 5 x^2 + 31 x + 30", ((p2 * p3) * (p4 * p5)).ToString());
            Assert.AreEqual("0", (p1 * ((p2 * p3) * (p4 * p5))).ToString());
            Assert.AreEqual("0", (Polynomial.Zero * ((p2 * p3) * (p4 * p5))).ToString());
            Assert.AreEqual("-2 x^4 - 14 x^3 - 10 x^2 + 62 x + 60", (2 * ((p2 * p3) * (p4 * p5))).ToString());
            Assert.AreEqual("-2 x^4 - 14 x^3 - 10 x^2 + 62 x + 60", (((p2 * p3) * (p4 * p5)) * 2).ToString());
            Assert.AreEqual("-2 x^4 - 14 x^3 - 10 x^2 + 62 x + 60", (((p2 * p3) * (p4 * p5)) * p6).ToString());
        }

        [TestMethod]
        public void DivRemOrderLessTest() {
            Polynomial p1 = Polynomial.OrderLess(2);
            Polynomial p2 = Polynomial.OrderLess(3, 1);
            Polynomial p3 = Polynomial.OrderLess(5, 1);
            Polynomial p4 = Polynomial.OrderLess(-2, 1);
            Polynomial p5 = Polynomial.OrderLess(-1, -1);

            Assert.AreEqual(p2.ToString(), ((p2 * p3) / p3).ToString());
            Assert.AreEqual("1", (p2 / p2).ToString());
            Assert.AreEqual((p2 * p3).ToString(), ((p2 * p3 * p4) / p4).ToString());
            Assert.AreEqual((p2 * p3).ToString(), (((p2 * p3) * (p4 * p5)) / (p4 * p5)).ToString());
            Assert.AreEqual((p2 * p3 * p1).ToString(), (((p2 * p3) * (p4 * p5) * p1) / (p4 * p5)).ToString());
            Assert.AreEqual("1", (p1 / p1).ToString());
            Assert.AreEqual("1.5 + 0.5 x", (p2 / p1).ToString());
            Assert.AreEqual("1.5 + 0.5 x", (p2 / 2).ToString());

            Assert.AreEqual("0", ((p2 * p3) % p3).ToString());
            Assert.AreEqual("0", (p2 % p2).ToString());
            Assert.AreEqual("0", ((p2 * p3 * p4) % p4).ToString());
            Assert.AreEqual("0", (((p2 * p3) * (p4 * p5)) % (p4 * p5)).ToString());
            Assert.AreEqual("0", (((p2 * p3) * (p4 * p5) * p1) % (p4 * p5)).ToString());
            Assert.AreEqual("0", (p1 % p1).ToString());
            Assert.AreEqual("0", (p2 % p1).ToString());

            foreach ((Polynomial a, Polynomial b) in new (Polynomial a, Polynomial b)[] {
                ((p2 * p3 + "1"), p3),
                ((p2 + "1"), p2),
                ((p2 * p3 * p4 + p2 * p3), p4),
                ((p2 * p3) * (p4 * p5) + p2 + p3, (p4 * p5))
                }) {

                Assert.AreEqual(a.ToString(), ((a / b) * b + a % b).ToString());
            }
        }

        [TestMethod]
        public void DivRemOrderGreaterTest() {
            Polynomial p1 = Polynomial.OrderGreater(2);
            Polynomial p2 = Polynomial.OrderGreater(1, 3);
            Polynomial p3 = Polynomial.OrderGreater(1, 5);
            Polynomial p4 = Polynomial.OrderGreater(1, -2);
            Polynomial p5 = Polynomial.OrderGreater(-1, -1);

            Assert.AreEqual(p2.ToString(), ((p2 * p3) / p3).ToString());
            Assert.AreEqual("1", (p2 / p2).ToString());
            Assert.AreEqual((p2 * p3).ToString(), ((p2 * p3 * p4) / p4).ToString());
            Assert.AreEqual((p2 * p3).ToString(), (((p2 * p3) * (p4 * p5)) / (p4 * p5)).ToString());
            Assert.AreEqual((p2 * p3 * p1).ToString(), (((p2 * p3) * (p4 * p5) * p1) / (p4 * p5)).ToString());
            Assert.AreEqual("1", (p1 / p1).ToString());
            Assert.AreEqual("0.5 x + 1.5", (p2 / p1).ToString());
            Assert.AreEqual("0.5 x + 1.5", (p2 / 2).ToString());
        }

        [TestMethod]
        public void XShiftTest() {
            Polynomial p0 = Polynomial.OrderGreater(1);
            Polynomial p1 = Polynomial.OrderGreater(1, 3);
            Polynomial p2 = p1 * p1;
            Polynomial p3 = p2 * p1;
            Polynomial p4 = p3 * p1;

            Assert.AreEqual("1", Polynomial.XShift(p0, 3).ToString());
            Assert.AreEqual(Polynomial.OrderGreater(1, 0).ToString(), Polynomial.XShift(p1, 3).ToString());
            Assert.AreEqual(Polynomial.OrderGreater(1, 0, 0).ToString(), Polynomial.XShift(p2, 3).ToString());
            Assert.AreEqual(Polynomial.OrderGreater(1, 0, 0, 0).ToString(), Polynomial.XShift(p3, 3).ToString());
            Assert.AreEqual(Polynomial.OrderGreater(1, 0, 0, 0, 0).ToString(), Polynomial.XShift(p4, 3).ToString());
        }

        [TestMethod]
        public void DifferentiateTest() {
            Polynomial p0 = Polynomial.OrderGreater(5, 7, 3, 6);
            Polynomial p1 = Polynomial.OrderGreater(15, 14, 3);

            Assert.AreEqual(p1.ToString(), Polynomial.Differentiate(p0).ToString());
            Assert.AreEqual(p0.ToString(), Polynomial.Integrate(p1, 6).ToString());
            Assert.AreEqual((p0 - 6).ToString(), Polynomial.Integrate(p1).ToString());
        }
    }
}
