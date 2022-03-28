using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Calculator.UnitTests
{
    public class SinFunctionTests
    {
        [Test]
        [TestCase(0, AngleUnits.Deg, 0)]
        [TestCase(90.0, AngleUnits.Deg, 1.0)]
        [TestCase(180.0, AngleUnits.Deg, 0)]
        [TestCase(270.0, AngleUnits.Deg, -1.0)]
        [TestCase(360, AngleUnits.Deg, 0)]
        [TestCase(0, AngleUnits.Rad, 0)]
        [TestCase(Math.PI / 2, AngleUnits.Rad, 1.0)]
        [TestCase(Math.PI, AngleUnits.Rad, 0)]
        [TestCase(Math.PI * 3 /2, AngleUnits.Rad, -1.0)]
        [TestCase(Math.PI * 2, AngleUnits.Rad, 0)]
        [TestCase(90.0, AngleUnits.Rad, 0.893996663600557891)]
        [TestCase(Math.PI, AngleUnits.Deg, 0.0548036651487895309)]
        public void Execute_ValidInput_ReturnsCorrecResult(double angle, AngleUnits angleUnits, double expectedResult)
        {
            Settings.SaveSettings((int)angleUnits, ",", 13);
            var sin = new SinFunction(FunctionType.Function);
            sin.Index = 0;

            var items = new List<object>() { sin, angle };

            Assert.That(sin.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}