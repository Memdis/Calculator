namespace Calculator
{
    public static class Settings
    {
        public static AngleUnits AngleUnits { get; private set; }
        public static string DecimalSeparator { get; private set; }
        public static int PrecisionPoints { get; private set; }

        private const int _maxPrecisionPoints = 13;
        private const int _minPrecisionPoints = 1;

        public static void LoadSettings()
        {
            AngleUnits = (AngleUnits)Properties.Settings.Default.AngleUnits;
            DecimalSeparator = Properties.Settings.Default.DecimalSeparator;
            PrecisionPoints = Properties.Settings.Default.PrecisionPoints;
        }

        public static void SaveSettings(int angleUnits, string decimalSeparator, int precisionPoints)
        {
            AngleUnits = (AngleUnits)angleUnits;
            DecimalSeparator = decimalSeparator;
            PrecisionPoints = precisionPoints <= _maxPrecisionPoints ? precisionPoints : _maxPrecisionPoints;
            PrecisionPoints = precisionPoints >= _minPrecisionPoints ? precisionPoints : _minPrecisionPoints;

            Properties.Settings.Default.AngleUnits = (int)AngleUnits;
            Properties.Settings.Default.DecimalSeparator = DecimalSeparator;
            Properties.Settings.Default.PrecisionPoints = PrecisionPoints;
            Properties.Settings.Default.Save();
        }
    }
}
