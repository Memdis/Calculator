using System;
using System.IO;

namespace Calculator
{
    public class FileLogger : ILogger
    {
        private string _path;
        private string _dateTimeFormat = "dd.MM.yyyy, HH:mm:ss";
        public FileLogger(string path)
        {
            _path = path;
        }

        public FileLogger(string path, string dateTimeFormat)
        {
            _path = path;
            _dateTimeFormat = dateTimeFormat;
        }
        public void Log(string Equation, string Result)
        {
            //File.AppendAllText(_path, "\n" + DateTime.Now.ToString(_dateTimeFormat) + ", equation: " + Equation + ", result: " + Result);
            
            using (StreamWriter streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString(_dateTimeFormat) + ", equation: " + Equation + ", result: " + Result);
                streamWriter.Close();
            }
        }
    }
}
