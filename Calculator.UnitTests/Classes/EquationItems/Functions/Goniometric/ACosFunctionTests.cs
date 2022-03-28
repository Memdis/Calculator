using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Calculator.UnitTests
{
    public class ACosFunctionTests
    {
        [Test]
        [TestCase(1, AngleUnits.Deg, 0)]
        [TestCase(0, AngleUnits.Deg, 90)]
        [TestCase(-1, AngleUnits.Deg, 180)]
        [TestCase(0.5, AngleUnits.Deg, 60)]
        [TestCase(-0.5, AngleUnits.Deg, 120)]
        [TestCase(0.9, AngleUnits.Deg, 25.8419327631671287)]
        [TestCase(1.1, AngleUnits.Deg, double.NaN)]
        [TestCase(-1.1, AngleUnits.Deg, double.NaN)]
        [TestCase(1, AngleUnits.Rad, 0)]
        [TestCase(0, AngleUnits.Rad, Math.PI / 2)]
        [TestCase(-1, AngleUnits.Rad, Math.PI)]
        [TestCase(0.5, AngleUnits.Rad, Math.PI / 3)]
        [TestCase(-0.5, AngleUnits.Rad, Math.PI / 3 * 2)]
        [TestCase(0.9, AngleUnits.Rad, 0.451026811796262433)]
        [TestCase(1.1, AngleUnits.Rad, double.NaN)]
        [TestCase(-1.1, AngleUnits.Rad, double.NaN)]

        public void Execute_ValidInput_ReturnsCorrectResult(double ratio, AngleUnits angleUnits, double expectedResult)
        {
            Settings.SaveSettings((int)angleUnits, ",", 13);
            var acos = new ACosFunction(FunctionType.Function);
            acos.Index = 0;

            var items = new List<object>() { acos, ratio };

            Assert.That(acos.Execute(items), Is.EqualTo(expectedResult).Within(TestSettings.GetPrecision()));
        }
    }
}