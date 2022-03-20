using NUnit.Framework;

namespace Calculator.UnitTests
{
    /*[TestFixture]
    public class SettingsTests
    {
        [Test]
        public void LoadSettings_
    }*/


    public class EquationHelperTests
    {
        private TestSetupAndTearDown _testSetupAndTearDown = new TestSetupAndTearDown();

        [Test]
        [TestCase("1,1+1", "2,1", AngleUnits.Rad, ",")]
        [TestCase("1.1+1", "2.1", AngleUnits.Rad, ".")]
        [TestCase("sin(1)", "0,8414709848078965", AngleUnits.Rad, ",")] //TODO use pi/2 when constants are implemented
        [TestCase("sin(90.0)", "1", AngleUnits.Deg, ".")]
        public void GetStringResult_SettingsAreChanged_ReturnCorrectString(string input, string correctResult, AngleUnits angleUnits, string decimalSeparator)
        {
            Settings.SaveSettings((int)angleUnits, decimalSeparator);
            var eq = EquationHelper.ExtractItems(input);

            var result = EquationHelper.GetStringResult(eq);
            
            Assert.That(result, Is.EqualTo(correctResult));
        }

        [SetUp]
        public void SetUp()
        {
            _testSetupAndTearDown.SetUp(AngleUnits.Rad, ",");
        }

        [TearDown]
        public void TearDown()
        {
            _testSetupAndTearDown.TearDown();
        }
    }
}