using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class CalculationTests
    {
        

        [Test]
        public void Calculation_InputStringIsNull_ThrowsNullReferenceException()
        {
            var eq = new Equation(null);

            Assert.Throws<NullReferenceException>(() => EquationHelper.ExtractItems(null));
            Assert.Throws<NullReferenceException>(() => eq.Calculate());
        }

        [Test]
        public void Calculation_InputStringIsEmpty_ReturnsZero()
        {
            var eq = EquationHelper.ExtractItems(string.Empty);
            var result = eq.Calculate();

            Assert.That(result, Is.EqualTo((double)0));
        }

        [Test]
        [TestCaseSource(nameof(wrongFormat))]
        public void Calculation_InputStringIsInWrongFormat_ThrowsFormatException(string inputString)
        {
            var eq = EquationHelper.ExtractItems(inputString);

            Assert.Throws<FormatException>(() => eq.Calculate());
        }

        [Test]
        [TestCaseSource(nameof(correctFormat))]
        public void Calculation_InitStringIsCorrect_ReturnCorrectResults(string inputString, double expectedNum)
        {
            var eq = EquationHelper.ExtractItems(inputString);

            var result = eq.Calculate();

            // Log10(100) = 2, so to get the manitude we add 1.
            var temp = Math.Floor(Math.Log10(Math.Abs(result)));
            int magnitude = 1 + (result == 0.0 ? -1 : Convert.ToInt32(double.IsInfinity(temp) ? 0.0 : temp));
            int precision = 14 - magnitude;
            double tolerance = 1.0 / Math.Pow(10, precision);

            Assert.That(result, Is.EqualTo(expectedNum).Within(tolerance));
        }

        //input string conains undefined parts, like "abc", wrognly typed functions like "sni()", "**" -> throws format exception "Incorrect format!"
        //delenie 0 a pod. sqrt(0) ainé nesprávne stavy

        private static string[] wrongFormat =
        {
            "+", "-", "*", "/", "++", "--", "**", "//", "*/", "-+", "*-", "1+1_", "§1+1",
            "*1", "/1", "1+", "1-", "1*", "1/", "1**", "1+*",
            "a", "aa", "a1", "a1+", "a1+1", "1a", "a+1",
            "sin", "cos", "tan", "sqrt", "^", "log",
            "2^(2)", "(2)^2", "^(2)", "(2)^", "sin(1)^(2)", "(2)^sin(1)", 
            "sin1", "1sin(1)", "sin(1+)", "sni(1)", "nsi(1)", "sin(1)cos(1)",
            "sqrt1", "1sqrt", "1sqrt(1)", "sqrt(1)1", "sqrt(1)-tan(1)cos(1)",
            "()1", "1()", "()sin(1)", "()sqrt(1)"

        };

        private static object[] correctFormat =
        {//results computed by online calculator https://keisan.casio.com/calculator
            new object[] { "1", 1.0 },
            new object[] { "-1", -1.0 },
            new object[] { "sin(1)", 0.841470984807896507 }, //0.841470984807896507 -> 0.8414709848078965; 
            new object[] { "sin(-2)", -0.909297426825681695 },
            new object[] { "cos(1)", 0.540302305868139717 },
            new object[] { "cos(-2)", -0.416146836547142387 },
            new object[] { "tan(1)", 1.55740772465490223 },
            new object[] { "tan(-2)", 2.18503986326151899 },
            new object[] { "log(2)", 0.301029995663981195 },
            new object[] { "(2)^(3)", 8.0},
            new object[] { "(-2)^(4)", 16.0},
            new object[] { "(-2)^(3)", -8.0},
            new object[] { "sqrt(2)", 1.41421356237309505},
            new object[] { "1+1", 2.0 },
            new object[] { "1+0", 1.0 },
            new object[] { "-1+1", 0 },
            new object[] { "-1-(-1)", 0 },
            new object[] { "1+1,111", 2.111 },
            new object[] { "1,111+1,111", 2.222 },
            new object[] { "2-1", 1.0 },
            new object[] { "2-0", 2.0 },
            new object[] { "0-1", -1.0 },
            new object[] { "-2-1,11", -3.11 },
            new object[] { "2,111-1", 1.111 },
            new object[] { "2,111-1,111", 1.0 },
            new object[] { "1*1", 1.0 },
            new object[] { "1*0", 0 },
            new object[] { "1*2", 2.0 },
            new object[] { "-1*2", -2.0 },
            new object[] { "-1*(-2)", 2.0 },
            new object[] { "1,111*2", 2.222 },
            new object[] { "1,111*2,111", 2.345321 },
            new object[] { "1/1", 1.0 },
            new object[] { "1/0", double.PositiveInfinity },
            new object[] { "1/2", 0.5 },
            new object[] { "-1/2", -0.5 },
            new object[] { "-1/(-2)", 0.5 },
            new object[] { "2,111/3", 0.703666666666666667 },
            new object[] { "2,111/3,111", 0.678559948569591771 },
            
            new object[] { "sin(0,055)*((10)^(2)*sin(1)-99,6566*8485,2)", -46480.2698616434054 },

            new object[] { "99999999999999,9999999999115515851454512/89595623*0,000000000000001+9999999999999999,9999999/0,22*9595", 4.36136363636363636E+20 },
            new object[] { "(sqrt(tan((0,235652/sin(0,15)-9,623)))+(-0,25*98,5*(0,99)^(12,1)))-(cos(12,151/956/7*4+1*(-332,5)))", -20.4075765495815081 },
            new object[] { "(cos(12,151/956/7*4+1*(-332,5)))", 0.8697581645804889 },
            new object[] { "12,151/956/7*4+1*(-332,5)", -332.492736999402271 },
            new object[] { "cos(-332,492736999402271)", 0.869758164580488722 },
        };

        [SetUp]
        public void SetUp()
        {
            List<IOperation> _allowedSigns;
            List<IFunction> _allowedFunctions;
            _allowedSigns = new List<IOperation>() { new PlusOperation(), new MinusOperation(), new MultOperation(), new DivOperation() };
            _allowedFunctions = new List<IFunction>() { new Log10Function(), new SqrtFunction(), new PowFunction(), new SinFunction(), new CosFunction(), new TanFunction() };

            List<ExecutableEquationItem> allExeEqItems = new List<ExecutableEquationItem>();
            List<string> allExeEqItemsRepresentation = new List<string>();

            foreach (var sign in _allowedSigns)
            {
                allExeEqItems.Add((ExecutableEquationItem)sign);
                allExeEqItemsRepresentation.Add(sign.GetStringRepresentation());
            }
            foreach (var function in _allowedFunctions)
            {
                allExeEqItems.Add((ExecutableEquationItem)function);
                allExeEqItemsRepresentation.Add(function.GetStringRepresentation());
            }

            ExecutableFunctions.AllExeEqItems.AddRange(allExeEqItems);
            ExecutableFunctions.AllExeEqItemsRepresentation.AddRange(allExeEqItemsRepresentation);
        }

        [TearDown]
        public void TearDown()
        {
            ExecutableFunctions.AllExeEqItems.Clear();
            ExecutableFunctions.AllExeEqItemsRepresentation.Clear();
        }
    }
}