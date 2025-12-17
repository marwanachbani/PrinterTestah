using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LoggingService
    {
        private readonly string _csvFile = "PrinterLog.csv";

        public void Log(string printerName, string action, bool success)
        {
            string line = $"{DateTime.Now},{printerName},{action},{(success ? "PASS" : "FAIL")}";
            File.AppendAllLines(_csvFile, new[] { line });
        }

        public List<string> ReadLog()
        {
            if (!File.Exists(_csvFile))
                return new List<string>();

            return new List<string>(File.ReadAllLines(_csvFile));
        }
    }
}
