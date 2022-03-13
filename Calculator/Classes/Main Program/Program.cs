using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
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

            var fileLogger = new FileLogger(_filePath);

            Application.Run(new MainForm(fileLogger));
        }

        private static void AppSetUp()
        {
            List<IOperation> _allowedOperations = new List<IOperation>() { new PlusOperation(), new MinusOperation(), new MultOperation(), new DivOperation() };
            List<IFunction> _allowedFunctions = new List<IFunction>() { new Log10Function(), new SqrtFunction(), new PowFunction(), new SinFunction(), new CosFunction(), new TanFunction() };

            List<ExecutableEquationItem> allExeEqItems = new List<ExecutableEquationItem>();
            List<string> allExeEqItemsRepresentation = new List<string>();

            foreach (var operation in _allowedOperations)
            {
                allExeEqItems.Add((ExecutableEquationItem)operation);
                allExeEqItemsRepresentation.Add(operation.GetStringRepresentation());
            }
            foreach (var function in _allowedFunctions)
            {
                allExeEqItems.Add((ExecutableEquationItem)function);
                allExeEqItemsRepresentation.Add(function.GetStringRepresentation());
            }

            ExecutableFunctions.AllExeEqItems.AddRange(allExeEqItems);
            ExecutableFunctions.AllExeEqItemsRepresentation.AddRange(allExeEqItemsRepresentation);


            string pathToExecutable = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string nameOfFile = "History.txt";
            _filePath = pathToExecutable + "\\" + nameOfFile;
        }
    }
}
