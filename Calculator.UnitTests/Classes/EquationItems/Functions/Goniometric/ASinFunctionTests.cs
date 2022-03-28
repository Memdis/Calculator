using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Calculator.UnitTests
{
    public class ASinFunctionTests
    {
        [Test]
        [TestCase(0, AngleUnits.Deg, 0)]
        [TestCase(0.5, AngleUnits.Deg, 30)]
        [TestCase(-0.5, AngleUnits.Deg, -30)]
        [TestCase(1, AngleUnits.Deg, 90)]
        [TestCase(-1, AngleUnits.Deg, -90)]
        [TestCase(0, AngleUnits.Rad, 0)]
        [TestCase(1.1, AngleUnits.Deg, double.NaN)]
        [TestCase(-1.1, AngleUnits.Deg, double.NaN)]
        [TestCase(0.5, AngleUnits.Rad, Math.PI/6)]
        [TestCase(-0.5, AngleUnits.Rad, -Math.PI/6)]
        [TestCase(1, AngleUnits.Rad, Math.PI/2)]
        [TestCase(-1, AngleUnits.Rad, -Math.PI/2)]
        [TestCase(1.1, AngleUnits.Rad, double.NaN)]
        [TestCase(-1.1, AngleUnits.Rad, double.NaN)]
        [TestCase(0.1, AngleUnits.Deg, 5.7391704772667863)]
        [TestCase(0.1, AngleUnits.Rad, 0.100167421161559796)]
        public void Execute_ValidInput_ReturnsCorrectResult(double ratio, AngleUnits angleUnits, double expectedResult)
        {
            Settings.SaveSettings((int)angleUnits, ",", 13);
            var asin = new ASinFunction(FunctionType.Function);
            asin.Index = 0;

            var items = new List<object>() { asin, ratio };

            Assert.That(asin.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}