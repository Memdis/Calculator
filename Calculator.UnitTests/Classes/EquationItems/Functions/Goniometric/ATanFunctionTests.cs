using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Calculator.UnitTests
{
    public class ATanFunctionTests
    {
        [Test]
        [TestCase(0, AngleUnits.Deg, 0)]
        [TestCase(1, AngleUnits.Deg, 45)]
        [TestCase(double.PositiveInfinity, AngleUnits.Deg, 90)]
        [TestCase(-1, AngleUnits.Deg, -45)]
        [TestCase(double.NegativeInfinity, AngleUnits.Deg, -90)]
        [TestCase(0.5, AngleUnits.Deg, 26.5650511770779894)]
        [TestCase(0, AngleUnits.Rad, 0)]
        [TestCase(1, AngleUnits.Rad, Math.PI / 4)]
        [TestCase(double.PositiveInfinity, AngleUnits.Rad, Math.PI / 2)]
        [TestCase(-1, AngleUnits.Rad, -Math.PI / 4)]
        [TestCase(double.NegativeInfinity, AngleUnits.Rad, -Math.PI / 2)]
        [TestCase(0.5, AngleUnits.Rad, 0.463647609000806116)]
        public void Execute_ValidInput_ReturnsCorrectResult(double ratio, AngleUnits angleUnits, double expectedResult)
        {
            Settings.SaveSettings((int)angleUnits, ",", 13);
            var atan = new ATanFunction(FunctionType.Function);
            atan.Index = 0;

            var items = new List<object>() { atan, ratio };

            Assert.That(atan.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}