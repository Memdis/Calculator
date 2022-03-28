using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.UnitTests
{
    public class PowFunctionTests
    {
        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 2, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 1)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 4)]
        [TestCase(3, 3, 27)]
        [TestCase(1, -1, 1)]
        [TestCase(1, -2, 1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, 2, 1)]
        [TestCase(-1, 3, -1)]
        [TestCase(-1, -1, -1)]
        [TestCase(-1, 3, -1)]
        [TestCase(-2, 1, -2)]
        [TestCase(-2, 2, 4)]
        [TestCase(-2, 3, -8)]
        [TestCase(-2, -1, -0.5)]
        [TestCase(-2, -2, 0.25)]
        [TestCase(-3, 3, -27)]
        [TestCase(-3, -3, -0.037037037037037037)]
        [TestCase(1.1, 1.1, 1.11053424105457573)]
        [TestCase(1.1, -1.1, 0.900467507467747075)]
        [TestCase(-1.1, 2, 1.21)]
        [TestCase(-1.1, 3, -1.331)]
        [TestCase(-1.1, 1.1, double.NaN)]
        [TestCase(5, 21, 476837158203125)]
        public void Execute_ValidInput_ReturnsCorrectResult(double baseInput, double powerInput, double expectedResult)
        {
            Settings.SaveSettings((int)AngleUnits.Rad, ",", 13);
            var pow = new PowFunction(FunctionType.Function);
            pow.Index = 1;

            var items = new List<object>() { baseInput, pow, powerInput };

            Assert.That(pow.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}