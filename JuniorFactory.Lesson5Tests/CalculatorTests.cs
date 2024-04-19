using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JuniorFactory.Lesson5.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void SumTest()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(1, 2);
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        [DataRow(1, 2, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(2, -2, -4)]
        [DataRow(2, 0, 0)]
        [DataRow(10, 0, 0)]
        [DataRow(10, 1, 10)]
        public void MultTest(int a, int b, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Mult(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}