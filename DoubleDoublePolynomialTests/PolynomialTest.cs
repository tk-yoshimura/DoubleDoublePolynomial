using Algebra;
using DoubleDoublePolynomial;

namespace DoubleDoublePolynomialTests {
    [TestClass]
    public sealed class PolynomialTest {

        [TestMethod]
        public void OrderLessToStringTest() {
            Polynomial p00 = Polynomial.OrderLess();
            Polynomial p01 = Polynomial.OrderLess(0);
            Polynomial p02 = Polynomial.OrderLess(1);
            Polynomial p03 = Polynomial.OrderLess(-1);
            Polynomial p04 = Polynomial.OrderLess(1, 1);
            Polynomial p05 = Polynomial.OrderLess(-1, -1);
            Polynomial p06 = Polynomial.OrderLess(1, -6);
            Polynomial p07 = Polynomial.OrderLess(-1, 6);
            Polynomial p08 = Polynomial.OrderLess(0, -6);
            Polynomial p09 = Polynomial.OrderLess(0, 6);
            Polynomial p10 = Polynomial.OrderLess(2, 1, 3);
            Polynomial p11 = Polynomial.OrderLess(3, 2, 1, 1);
            Polynomial p12 = Polynomial.OrderLess(3, 2, 1, -1);
            Polynomial p13 = Polynomial.OrderLess(3, 0, 1, -1);
            Polynomial p14 = Polynomial.OrderLess(0, -1, 1, -1);
            Polynomial p15 = Polynomial.OrderLess(0, 1, -1, 1);
            Polynomial p16 = Polynomial.OrderLess(3, 2, 1, 0);
            Polynomial p17 = Polynomial.OrderLess(0, 2, 1, 0);
            Polynomial p18 = Polynomial.OrderLess(0, 0, 0, 0);

            Assert.AreEqual("0", p00.ToString());
            Assert.AreEqual("0", p01.ToString());
            Assert.AreEqual("1", p02.ToString());
            Assert.AreEqual("-1", p03.ToString());
            Assert.AreEqual("1 + x", p04.ToString());
            Assert.AreEqual("-1 - x", p05.ToString());
            Assert.AreEqual("1 - 6 x", p06.ToString());
            Assert.AreEqual("-1 + 6 x", p07.ToString());
            Assert.AreEqual("-6 x", p08.ToString());
            Assert.AreEqual("6 x", p09.ToString());
            Assert.AreEqual("2 + x + 3 x^2", p10.ToString());
            Assert.AreEqual("3 + 2 x + x^2 + x^3", p11.ToString());
            Assert.AreEqual("3 + 2 x + x^2 - x^3", p12.ToString());
            Assert.AreEqual("3 + x^2 - x^3", p13.ToString());
            Assert.AreEqual("-x + x^2 - x^3", p14.ToString());
            Assert.AreEqual("x - x^2 + x^3", p15.ToString());
            Assert.AreEqual("3 + 2 x + x^2", p16.ToString());
            Assert.AreEqual("2 x + x^2", p17.ToString());
            Assert.AreEqual("0", p18.ToString());
        }

        [TestMethod]
        public void OrderGreaterToStringTest() {
            Polynomial p00 = Polynomial.OrderGreater();
            Polynomial p01 = Polynomial.OrderGreater(0);
            Polynomial p02 = Polynomial.OrderGreater(1);
            Polynomial p03 = Polynomial.OrderGreater(-1);
            Polynomial p04 = Polynomial.OrderGreater(1, 1);
            Polynomial p05 = Polynomial.OrderGreater(-1, -1);
            Polynomial p06 = Polynomial.OrderGreater(-6, 1);
            Polynomial p07 = Polynomial.OrderGreater(6, -1);
            Polynomial p08 = Polynomial.OrderGreater(-6, 0);
            Polynomial p09 = Polynomial.OrderGreater(6, 0);
            Polynomial p10 = Polynomial.OrderGreater(3, 1, 2);
            Polynomial p11 = Polynomial.OrderGreater(1, 1, 2, 3);
            Polynomial p12 = Polynomial.OrderGreater(-1, 1, 2, 3);
            Polynomial p13 = Polynomial.OrderGreater(-1, 1, 0, 3);
            Polynomial p14 = Polynomial.OrderGreater(-1, 1, -1, 0);
            Polynomial p15 = Polynomial.OrderGreater(1, -1, 1, 0);
            Polynomial p16 = Polynomial.OrderGreater(0, 1, 2, 3);
            Polynomial p17 = Polynomial.OrderGreater(0, 1, 2, 0);
            Polynomial p18 = Polynomial.OrderGreater(0, 0, 0, 0);

            Assert.AreEqual("0", p00.ToString());
            Assert.AreEqual("0", p01.ToString());
            Assert.AreEqual("1", p02.ToString());
            Assert.AreEqual("-1", p03.ToString());
            Assert.AreEqual("x + 1", p04.ToString());
            Assert.AreEqual("-x - 1", p05.ToString());
            Assert.AreEqual("-6 x + 1", p06.ToString());
            Assert.AreEqual("6 x - 1", p07.ToString());
            Assert.AreEqual("-6 x", p08.ToString());
            Assert.AreEqual("6 x", p09.ToString());
            Assert.AreEqual("3 x^2 + x + 2", p10.ToString());
            Assert.AreEqual("x^3 + x^2 + 2 x + 3", p11.ToString());
            Assert.AreEqual("-x^3 + x^2 + 2 x + 3", p12.ToString());
            Assert.AreEqual("-x^3 + x^2 + 3", p13.ToString());
            Assert.AreEqual("-x^3 + x^2 - x", p14.ToString());
            Assert.AreEqual("x^3 - x^2 + x", p15.ToString());
            Assert.AreEqual("x^2 + 2 x + 3", p16.ToString());
            Assert.AreEqual("x^2 + 2 x", p17.ToString());
            Assert.AreEqual("0", p18.ToString());
        }

        [TestMethod]
        public void RootsTest() {
            Polynomial p = Polynomial.OrderLess(-180, -156, -29, 4, 1);

            Vector roots = p.RealRoots;

            Console.Write(roots);

            p.Order = Order.Greater;

            Console.WriteLine(p);
        }

        [TestMethod]
        public void ParseOrderLessTest() {
            string s0 = "3-4.2x+8x^2+1.0e-6x^4";
            string s1 = "3 - 4.2x + 8x^2 + 1.0e-6x^4";
            string s2 = "+3 - 4.2 x + 8 x^2 + 1.0e-6 x^4";
            string s3 = "0";
            string s4 = "-0";
            string s5 = "1+x";
            string s6 = "1+x+1+2x";
            string s7 = "+3 + 8 x^2 - 4.2 x + 1.0e-6 x^4";

            Polynomial p0 = Polynomial.Parse(s0);
            Polynomial p1 = Polynomial.Parse(s1);
            Polynomial p2 = Polynomial.Parse(s2);
            Polynomial p3 = Polynomial.Parse(s3);
            Polynomial p4 = Polynomial.Parse(s4);
            Polynomial p5 = Polynomial.Parse(s5);
            Polynomial p6 = Polynomial.Parse(s6);
            Polynomial p7 = Polynomial.Parse(s7);

            Assert.AreEqual("3 - 4.2 x + 8 x^2 + 1e-6 x^4", p0.ToString());
            Assert.AreEqual("3 - 4.2 x + 8 x^2 + 1e-6 x^4", p1.ToString());
            Assert.AreEqual("3 - 4.2 x + 8 x^2 + 1e-6 x^4", p2.ToString());
            Assert.AreEqual("0", p3.ToString());
            Assert.AreEqual("0", p4.ToString());
            Assert.AreEqual("1 + x", p5.ToString());
            Assert.AreEqual("2 + 3 x", p6.ToString());
            Assert.AreEqual("3 - 4.2 x + 8 x^2 + 1e-6 x^4", p7.ToString());
        }

        [TestMethod]
        public void ParseOrderGreaterTest() {
            string s0 = "1.0e-6x^4+8x^2-4.2x+3";
            string s1 = "1.0e-6x^4 + 8x^2 - 4.2x + 3";
            string s2 = "1.0e-6 x^4 + 8 x^2 - 4.2 x + 3";
            string s3 = "x+1";
            string s4 = "x+1+2x+1";
            string s5 = "1.0e-6 x^4 - 4.2 x + 8 x^2 + 3";

            Polynomial p0 = Polynomial.Parse(s0);
            Polynomial p1 = Polynomial.Parse(s1);
            Polynomial p2 = Polynomial.Parse(s2);
            Polynomial p3 = Polynomial.Parse(s3);
            Polynomial p4 = Polynomial.Parse(s4);
            Polynomial p5 = Polynomial.Parse(s5);

            Assert.AreEqual("1e-6 x^4 + 8 x^2 - 4.2 x + 3", p0.ToString());
            Assert.AreEqual("1e-6 x^4 + 8 x^2 - 4.2 x + 3", p1.ToString());
            Assert.AreEqual("1e-6 x^4 + 8 x^2 - 4.2 x + 3", p2.ToString());
            Assert.AreEqual("x + 1", p3.ToString());
            Assert.AreEqual("3 x + 2", p4.ToString());
            Assert.AreEqual("1e-6 x^4 + 8 x^2 - 4.2 x + 3", p5.ToString());
        }

        [TestMethod]
        public void InvalidParseTest() {
            string[] strs = [
                "",
                "x^^2",
                "2xx",
                "x^",
                "+*3",
                "3+",
                "e10x",
                "x^1.5",
                "1+y",
                "1+2y",
            ];

            foreach (string s in strs) {
                Assert.ThrowsExactly<FormatException>(() => Polynomial.Parse(s));
            }
        }
    }
}
