using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using Hardware.Adapters;


namespace Business.Services
{
    public class TestManager
    {
        private readonly LoggingService _loggingService;

        public List<PrinterInfo> Printers { get; private set; } = new List<PrinterInfo>();

        public TestManager()
        {
            _loggingService = new LoggingService();
            RefreshPrinters();
        }

        // Detect all printers connected to the PC
        public void RefreshPrinters()
        {
            Printers.Clear();
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                var settings = new PrinterSettings { PrinterName = installedPrinter };
                Printers.Add(new PrinterInfo
                {
                    Name = installedPrinter,
                    Status = settings.IsValid ? "Online" : "Offline",
                    IsDefault = settings.IsDefaultPrinter,
                     // Approximate
                });
            }
        }

        // Run a test on a printer
        public bool RunTest(string printerName)
        {
            var adapter = new GenericPrinterAdapter(printerName);
            bool result = adapter.RunTest();
            _loggingService.Log(printerName, "Test", result);
            return result;
        }

        // Print a test page
        public bool PrintTestPage(string printerName)
        {
            var adapter = new GenericPrinterAdapter(printerName);
            bool result = adapter.PrintTestPage();
            _loggingService.Log(printerName, "Print", result);
            return result;
        }

        // Get log history
        public List<string> GetHistory()
        {
            return _loggingService.ReadLog();
        }
    }
}
