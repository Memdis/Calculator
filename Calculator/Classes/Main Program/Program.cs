using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        private static List<IOperation> _allowedSigns;
        private static List<IFunction> _allowedFunctions;
        private static string _filePath;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppSetUp();

            //var calculator = new BasicCalculator(_allowedSigns, _allowedFunctions);
            var fileLogger = new FileLogger(_filePath);

            Application.Run(new MainForm(fileLogger));
        }

        private static void AppSetUp()
        {
            _allowedSigns = new List<IOperation>() { new PlusOperation(), new MinusOperation(), new MultOperation(), new DivOperation() };
            _allowedFunctions = new List<IFunction>() { new Log10Function(), new SqrtFunction(), new PowFunction(), new SinFunction(), new CosFunction(), new TanFunction() };

            string pathToExecutable = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string nameOfFile = "History.txt";
            _filePath = pathToExecutable + "\\" + nameOfFile;



            List<ExecutableEquationItem> allExeEqItems = new List<ExecutableEquationItem>();
            List<string> allExeEqItemsRepresentation = new List<string>();

            foreach (var sign in _allowedSigns)
            {
                allExeEqItems.Add((ExecutableEquationItem)sign);
                allExeEqItemsRepresentation.Add(sign.GetStringRepresentation());
            }
            foreach (var function in _allowedFunctions)
            {
                allExeEqItems.Add((ExecutableEquationItem)function);
                allExeEqItemsRepresentation.Add(function.GetStringRepresentation());
            }

            ExecutableFunctions.AllExeEqItems.AddRange(allExeEqItems);
            ExecutableFunctions.AllExeEqItemsRepresentation.AddRange(allExeEqItemsRepresentation);
        }
    }
}
