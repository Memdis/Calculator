namespace Calculator
{
    public static class Settings
    {
        public static AngleUnit AngleUnits = AngleUnit.Rad;

        public static void LoadSettings ()
        {
            AngleUnits = (AngleUnit)Properties.Settings.Default.AngleUnits;
        }
    }

}
