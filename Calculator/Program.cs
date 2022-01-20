using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        static private readonly List<char> _allowedNums = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static private readonly List<char> _allowedSigns = new List<char>() { '+' };
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var calculator = new BasicCalculator(_allowedNums, _allowedSigns);
            Application.Run(new MainForm(calculator));
        }
    }
}
