using NUnit.Framework;
using System;

namespace Calculator.UnitTests
{
    public class EquationTests
    {
        [Test]
        [TestCaseSource(nameof(correctFormat))]
        public void CalculateResult_InitStringIsCorrect_ReturnCorrectResult(string inputString, double expectedNum)
        {
            var eq = CalculationHelper.GetEquationFromString(inputString);
            var result = eq.Calculate();

            // Log10(100) = 2, so to get the manitude we add 1.
            var temp = Math.Floor(Math.Log10(Math.Abs(result)));
            int magnitude = 1 + (result == 0.0 ? -1 : Convert.ToInt32(double.IsInfinity(temp) ? 0.0 : temp));
            int precision = 13 - magnitude;
            double tolerance = 1.0 / Math.Pow(10, precision);

            Assert.That(result, Is.EqualTo(expectedNum).Within(tolerance));
        }

        private static object[] correctFormat =
        {//results computed by online calculator https://keisan.casio.com/calculator
            new object[] { "1", 1.0 },
            new object[] { "-1", -1.0 },
            new object[] { "sin(1)", 0.841470984807896507 },
            new object[] { "-sin(1)", -0.841470984807896507 },
            new object[] { "1-sin(1)", 0.158529015192103493 },
            new object[] { "sin(-2)", -0.909297426825681695 },
            new object[] { "cos(1)", 0.540302305868139717 },
            new object[] { "cos(-2)", -0.416146836547142387 },
            new object[] { "tan(1)", 1.55740772465490223 },
            new object[] { "tan(-2)", 2.18503986326151899 },
            new object[] { "log(2)", 0.301029995663981195 },
            new object[] { "(2)^(3)", 8.0},
            new object[] { "(-2)^(4)", 16.0},
            new object[] { "(-2)^(3)", -8.0},
            new object[] { "-2^(3)", -8.0},
            new object[] { "-2^3*2", -16.0},
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
            new object[] { "sin0,055*(10^2*sin1-99,6566*8485,2)", -46480.2698616434054 },

            new object[] { "99999999999999,9999999999115515851454512/89595623*0,000000000000001+9999999999999999,9999999/0,22*9595", 4.36136363636363636E+20 },
            new object[] { "(sqrt(tan((0,235652/sin(0,15)-9,623)))+(-0,25*98,5*(0,99)^(12,1)))-(cos(12,151/956/7*4+1*(-332,5)))", -20.4075765495815081 },
            new object[] { "(sqrt(tan((0,235652/sin0,15-9,623)))+(-0,25*98,5*0,99^12,1))-(cos(12,151/956/7*4+1*(-332,5)))", -20.4075765495815081 },
            new object[] { "(cos(12,151/956/7*4+1*(-332,5)))", 0.8697581645804889 },
            new object[] { "12,151/956/7*4+1*(-332,5)", -332.492736999402271 },
            new object[] { "cos(-332,492736999402271)", 0.869758164580488722 },

            new object[] { "pi", 3.141592653589793238 },
            new object[] { "-pi", -3.141592653589793238 },
            new object[] { "(pi-pi)", 0},
            new object[] { "-pi+pi", 0 },
            new object[] { "-pi*(-1)", 3.141592653589793238 },
            new object[] { "0,5529999654*cos(pi/551-(545*(-2,11)))-458,22*tan(42*pi*(-pi))", -76.6211771915088692 },
        };

        [SetUp]
        public void SetUp()
        {
            Settings.SaveSettings((int)AngleUnits.Rad, ",");
        }
    }
}