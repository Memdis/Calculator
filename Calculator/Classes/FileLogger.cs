using System;
using System.IO;

namespace Calculator
{
    public class FileLogger : ILogger
    {
        private string _path;
        private string _dateTimeFormat = "dd.MM.yyyy, HH:mm:ss";
        public FileLogger(string Path)
        {
            _path = Path;
        }

        public FileLogger(string Path, string DateTimeFormat)
        {
            _path = Path;
            _dateTimeFormat = DateTimeFormat;
        }
        public void Log(string Equation, string Result)
        {
            //File.AppendAllText(_path, "\n" + DateTime.Now.ToString(_dateTimeFormat) + ", equation: " + Equation + ", result: " + Result);


            //TODO pozrieť sa na správne zaobchádzanie so subormi (subor môže byť otvorený, nemusíme mať práva doňho zapisovať atď...)
            using (StreamWriter streamWriter = new StreamWriter(_path, true)) 
            {
                streamWriter.WriteLine(DateTime.Now.ToString(_dateTimeFormat) + ", equation: " + Equation + ", result: " + Result);
                streamWriter.Close();
            }
        }
    }
}
