using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.UnitTests
{
    public class SqrtFunctionTests
    {
        [Test]
        [TestCase(4, 2)]
        [TestCase(1, 1)]
        [TestCase(0, 0)]
        [TestCase(-1, double.NaN)]
        [TestCase(2, 1.41421356237309505)]
        [TestCase(10, 3.16227766016837933)]
        public void Execute_ValidInput_ReturnsCorrectResult(double input, double expectedResult)
        {
            Settings.SaveSettings((int)AngleUnits.Rad, ",", 13);
            var sqrt = new SqrtFunction(FunctionType.Function);
            sqrt.Index = 0;

            var items = new List<object>() { sqrt, input };

            Assert.That(sqrt.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}