using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsDevisibleBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDevisibleBy3Only_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputIsDevisibleBy5Only_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputNotDevisibleBy3Or5_ReturnTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(1);
            Assert.That(result, Is.EqualTo("1"));
        }
    }
}
