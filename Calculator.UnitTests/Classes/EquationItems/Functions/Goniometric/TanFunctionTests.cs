using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Calculator.UnitTests
{
    public class TanFunctionTests
    {
        [Test]
        [TestCase(0, AngleUnits.Deg, 0)]
        [TestCase(45, AngleUnits.Deg, 1)]
        [TestCase(90, AngleUnits.Deg, double.NaN)]
        [TestCase(180, AngleUnits.Deg, 0)]
        [TestCase(270, AngleUnits.Deg, double.NaN)]
        [TestCase(360, AngleUnits.Deg, 0)]
        [TestCase(0, AngleUnits.Rad, 0)]
        [TestCase(Math.PI / 4, AngleUnits.Rad, 1)]
        [TestCase(Math.PI / 2, AngleUnits.Rad, double.NaN)]
        [TestCase(Math.PI, AngleUnits.Rad, 0)]
        [TestCase(Math.PI * 3 / 2, AngleUnits.Rad, double.NaN)]
        [TestCase(Math.PI * 2, AngleUnits.Rad, 0)]
        [TestCase(30, AngleUnits.Deg, 0.577350269189625765)]
        [TestCase(30, AngleUnits.Rad, -6.40533119664627578)]
        public void Execute_ValidInput_ReturnsCorrectResult(double angle, AngleUnits angleUnits, double expectedResult)
        {
            Settings.SaveSettings((int)angleUnits, ",", 13);
            var tan = new TanFunction(FunctionType.Function);
            tan.Index = 0;

            var items = new List<object>() { tan, angle };

            Assert.That(tan.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}