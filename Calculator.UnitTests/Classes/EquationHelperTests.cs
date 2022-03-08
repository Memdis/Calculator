using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class EquationHelperTests
    {
        private static object[] eqLists =
        {
            new object[] { new List<object>() { 1 }, (double)1 },
            new object[] { new List<object>() { new SinFunction() { Index = 0 }, new Equation(new List<object> { 1 }) }, 0.8414709848 },
            new object[] { new List<object>() { 1, new PlusOperation() { Index = 1 }, 1 }, (double)2 }
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(nameof(eqLists))]
        [Ignore("Equation class wont be tested")]
        public void ExtractItems_ItemsHaveCorrectFormat_ReturnsCorrectResult(List<object> items, double expectedResult)
        {
            var eq = new Equation(items);

            var result = eq.Calculate();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //extract items cases:
        //input string is null -> throws reference null exception
        //input string is not null and has correct format -> return correct eqaution
        //input string is not null and does not have correct format -> throws argument exception "Incorrect format!" 
        //input string is not null but is empty -> return empty string

    }
}