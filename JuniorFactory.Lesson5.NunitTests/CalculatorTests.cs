using NUnit.Framework;

namespace JuniorFactory.Lesson5.NunitTests
{
    public class Tests
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calculator = new Calculator();
        }

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // )
            _calculator = null;
        }

        [Test]
        public void SumTest()
        {
            var result = _calculator.Sum(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test()]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 4)]
        [TestCase(2, -2, -4)]
        [TestCase(2, 0, 0)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 10)]
        public void MultTest(int a, int b, int expected)
        {
            var result = _calculator.Mult(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}