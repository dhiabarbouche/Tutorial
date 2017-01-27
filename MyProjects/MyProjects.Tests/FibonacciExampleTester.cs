using NUnit.Framework;

namespace MyProjects.Tests
{
    [TestFixture]
    public class FibonacciExampleTester
    {
        [Test]
        public void DefaultValues()
        {
            FibonacciExample math = new FibonacciExample();

            int result = math.Calculate(0);
            Assert.AreEqual(1, result);

            result = math.Calculate(1);
            Assert.AreEqual(1, result);
        }

        [TestCase(5, 8)]
        [TestCase(10, 89)]
        [TestCase(15, 987)]
        public void SpecificValues(int n, int expected)
        {
            FibonacciExample math = new FibonacciExample();
            
            int result = math.Calculate(n);

            Assert.AreEqual(expected, result);
        }
    }
}
