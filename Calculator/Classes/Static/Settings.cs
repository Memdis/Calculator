namespace Calculator
{
    public static class Settings
    {
        public static AngleUnits AngleUnits { get; private set; }
        public static DecimalSeparator DecimalSeparator { get; private set; }

        public static void LoadSettings()
        {
            AngleUnits = (AngleUnits)Properties.Settings.Default.AngleUnits;
            DecimalSeparator = (DecimalSeparator)Properties.Settings.Default.DecimalSeparator;
        }

        public static void SaveSettings(int angleUnits, int decimalSeparator)
        {
            AngleUnits = (AngleUnits)angleUnits;
            DecimalSeparator = (DecimalSeparator)decimalSeparator;

            Properties.Settings.Default.AngleUnits = (int)AngleUnits;
            Properties.Settings.Default.DecimalSeparator = (int)DecimalSeparator;
            Properties.Settings.Default.Save();
        }
    }
}
