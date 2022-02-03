using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        static private readonly List<IOperation> _allowedSigns = new List<IOperation>() { new PlusOperation(), new MinusOperation(), new MultOperation(), new DivOperation() };
        static private readonly List<IFunction> _allowedFunctions = new List<IFunction>() { new Log10Function(), new SqrtFunction() };
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var calculator = new BasicCalculator(_allowedSigns, _allowedFunctions);
            Application.Run(new MainForm(calculator));
        }
    }
}
