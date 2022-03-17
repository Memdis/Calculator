namespace Calculator
{
    public static class Settings
    {
        public static AngleUnits AngleUnits { get; private set; }
        public static string DecimalSeparator { get; private set; }

        public static void LoadSettings()
        {
            AngleUnits = (AngleUnits)Properties.Settings.Default.AngleUnits;
            DecimalSeparator = Properties.Settings.Default.DecimalSeparator;
        }

        public static void SaveSettings(int angleUnits, string decimalSeparator)
        {
            AngleUnits = (AngleUnits)angleUnits;
            DecimalSeparator = decimalSeparator;

            Properties.Settings.Default.AngleUnits = (int)AngleUnits;
            Properties.Settings.Default.DecimalSeparator = DecimalSeparator;
            Properties.Settings.Default.Save();
        }
    }
}
