using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.UnitTests
{

    [TestFixture]
    public class EquationTests
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
        public void Calculate_ItemsHaveCorrectFormat_ReturnsCorrectResult(List<object> items, double expectedResult)
        {
            var eq = new Equation(items);

            var result = eq.Calculate();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //calculate method::
        //insert correct list of items -> returns correct number
        //insert empty list of items -> throws argument exception "Incorrect format!" 
        //insert list with incorrect item. i.e. type that it cannot work with, or incorrect string like "abc" -> throws argument exception "Incorrect format!"
        //insert list with correct items but with wrong syntax. i.e. 5**4, *5, 4*5*, 5*)(4+4) -> throws argument exception "Incorrect format!"
        //insert null list -> throws argument null exception "Something went wrong!"

    }
}