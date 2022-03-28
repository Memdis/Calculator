using System;

namespace Calculator.UnitTests
{
    public static class TestSettings
    {
        public static double GetPrecision()
        {
            return 1.0 / Math.Pow(10.0, Settings.PrecisionPoints);
        }
    }

}