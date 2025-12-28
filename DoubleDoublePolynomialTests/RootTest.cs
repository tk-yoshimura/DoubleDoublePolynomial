using Algebra;
using DoubleDouble;
using DoubleDoublePolynomial;

namespace DoubleDoublePolynomialTests {
    [TestClass]
    public sealed class RootTest {

        [TestMethod]
        public void RealRootTest() {
            Polynomial p0 = Polynomial.OrderLess();
            Polynomial p1 = Polynomial.OrderLess(0);
            Polynomial p2 = Polynomial.OrderLess(1, 1);
            Polynomial p3 = Polynomial.OrderLess(1, -2, 1);
            Polynomial p4 = Polynomial.OrderLess(2, -4, 2);
            Polynomial p5 = Polynomial.OrderLess(-1, 1) * Polynomial.OrderLess(-10000000, 1);
            Polynomial p6 = Polynomial.OrderLess(-1, 1) * Polynomial.OrderLess(10000000, 1);

            Assert.AreEqual(new Vector(Array.Empty<ddouble>()), p0.RealRoots);
            Assert.AreEqual(new Vector(Array.Empty<ddouble>()), p1.RealRoots);
            Assert.AreEqual(new Vector(-1), p2.RealRoots);
            Assert.AreEqual(new Vector(1, 1), p3.RealRoots);
            Assert.AreEqual(new Vector(1, 1), p4.RealRoots);
            Assert.AreEqual(new Vector(1, 10000000), p5.RealRoots);
            Assert.AreEqual(new Vector(-10000000, 1), p6.RealRoots);
        }

        [TestMethod]
        public void RootsTest() {
            Polynomial p = Polynomial.OrderLess(-180, -156, -29, 4, 1);

            Vector roots = p.RealRoots;

            Console.Write(roots);

            p.Order = Order.Greater;

            Console.WriteLine(p);
        }
    }
}
