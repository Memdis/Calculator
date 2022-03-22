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

            Settings.LoadSettings();

            HistoryFilePathSetUp();

            var fileLogger = new FileLogger(_filePath);
            var calculation = new Calculation();

            Application.Run(new MainForm(fileLogger, calculation));
        }

        private static void HistoryFilePathSetUp()
        {
            string pathToExecutable = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string nameOfFile = "History.txt";
            _filePath = pathToExecutable + "\\" + nameOfFile;
        }
    }
}
