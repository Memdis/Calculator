using System.Globalization;


namespace Calculator
{
    public class Calculation : ICalculation
    {
        public string CalculateResult(string inputString)
        {
            var eq = CalculationHelper.GetEquationFromString(inputString);
            var result = eq.Calculate();

            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberDecimalSeparator = Settings.DecimalSeparator;

            return result.ToString(nfi);
        }
    }
}
