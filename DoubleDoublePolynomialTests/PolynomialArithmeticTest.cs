using DoubleDoublePolynomial;

namespace DoubleDoublePolynomialTests {
    [TestClass]
    public sealed class PolynomialArithmeticTest {

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
        }
    }
}
