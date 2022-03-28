using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Calculator.UnitTests
{
    public class CosFunctionTests
    {
        [Test]
        [TestCase(0, AngleUnits.Deg, 1)]
        [TestCase(90, AngleUnits.Deg, 0)]
        [TestCase(180, AngleUnits.Deg, -1)]
        [TestCase(270, AngleUnits.Deg, 0)]
        [TestCase(0, AngleUnits.Rad, 1)]
        [TestCase(Math.PI / 2, AngleUnits.Rad, 0)]
        [TestCase(Math.PI, AngleUnits.Rad, -1)]
        [TestCase(Math.PI * 3 / 2, AngleUnits.Rad, 0)]
        [TestCase(Math.PI * 2, AngleUnits.Rad, 1)]
        [TestCase(90, AngleUnits.Rad, -0.448073616129170152)]
        [TestCase(Math.PI, AngleUnits.Deg, 0.998497149863863834)]
        public void Execute_ValidInput_ReturnsCorrectResult(double angle, AngleUnits angleUnits, double expectedResult)
        {
            Settings.SaveSettings((int)angleUnits, ",", 13);
            var cos = new CosFunction(FunctionType.Function);
            cos.Index = 0;

            var items = new List<object>() { cos, angle };

            Assert.That(cos.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}