using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.UnitTests
{
    public class Log10FunctionTests
    {
        [Test]
        [TestCase(0, double.NegativeInfinity)]
        [TestCase(0.1, -1)]
        [TestCase(1, 0)]
        [TestCase(10, 1)]
        [TestCase(100, 2)]
        [TestCase(2, 0.301029995663981195)]
        [TestCase(-1, double.NaN)]
        [TestCase(1.1, 0.0413926851582250408)]
        public void Execute_ValidInput_ReturnsCorrectResult(double input, double expectedResult)
        {
            Settings.SaveSettings((int)AngleUnits.Rad, ",", 13);
            var log10 = new Log10Function(FunctionType.Function);
            log10.Index = 0;

            var items = new List<object>() { log10, input };

            Assert.That(log10.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}