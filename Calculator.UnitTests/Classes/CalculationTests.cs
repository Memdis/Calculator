using NUnit.Framework;
using System;

namespace Calculator.UnitTests
{
    public class CalculationTests
    {
        [Test]
        public void CalculateResult_InputStringIsNull_ThrowsNullExceptions()
        {
            var calculation = new Calculation();
            Assert.Throws<ArgumentNullException>(() => calculation.CalculateResult(null));
        }

        [Test]
        public void CalculateResult_InputStringIsEmpty_ReturnsZero()
        {
            var calculation = new Calculation();
            var result = calculation.CalculateResult(string.Empty);

            Assert.That(result, Is.EqualTo("0"));
        }

        [Test]
        [TestCaseSource(nameof(wrongFormat))]
        public void CalculateResult_InputStringIsInWrongFormat_ThrowsFormatException(string inputString)
        {
            var calculation = new Calculation();
            Assert.Throws<FormatException>(() => calculation.CalculateResult(inputString));
        }

        [Test]
        [TestCase("1,1+1", "2,1", AngleUnits.Rad, ",")]
        [TestCase("1.1+1", "2.1", AngleUnits.Rad, ".")]
        [TestCase("sin(1)", "0,8414709848078965", AngleUnits.Rad, ",")]
        [TestCase("sin(90.0)", "1", AngleUnits.Deg, ".")]
        public void CalculateResult_InitStringIsCorrectAndSettingsAreChanged_ReturnCorrectString(string input, string correctResult, AngleUnits angleUnits, string decimalSeparator)
        {
            Settings.SaveSettings((int)angleUnits, decimalSeparator);

            var calculation = new Calculation();
            var result = calculation.CalculateResult(input);

            Assert.That(result, Is.EqualTo(correctResult));
        }

        private static string[] wrongFormat =
        {
            "+", "-", "*", "/", "++", "--", "**", "//", "*/", "-+", "*-", "1+1_", "§1+1",
            "*1", "/1", "1+", "1-", "1*", "1/", "1**", "1+*",
            "a", "aa", "a1", "a1+", "a1+1", "1a", "a+1",
            "sin", "cos", "tan", "sqrt", "^", "log",
            "^(2)", "(2)^", "(2)^sin(1)",
            "1sin(1)", "sin(1+)", "sni(1)", "nsi(1)", "sin(1)cos(1)",
            "1sqrt", "1sqrt(1)", "sqrt(1)1", "sqrt(1)-tan(1)cos(1)",
            "()1", "1()", "()sin(1)", "()sqrt(1)"
        };

        [SetUp]
        public void SetUp()
        {
            Settings.SaveSettings((int)AngleUnits.Rad, ",");
        }
    }
}