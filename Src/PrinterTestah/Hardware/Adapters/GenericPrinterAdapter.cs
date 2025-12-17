using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Adapters
{
    public class GenericPrinterAdapter : IPrinterAdapter
    {
        public string PrinterName { get; }

        public GenericPrinterAdapter(string printerName)
        {
            PrinterName = printerName;
        }

        public bool RunTest()
        {
            try
            {
                // Simulate a printer test page
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = PrinterName;
                pd.PrintPage += (sender, e) =>
                {
                    e.Graphics.DrawString("Printer Test Page", new System.Drawing.Font("Arial", 20),
                        System.Drawing.Brushes.Black, 100, 100);
                };
                pd.Print();
                return true; // PASS
            }
            catch
            {
                return false; // FAIL
            }
        }

        public bool PrintTestPage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = PrinterName;
                pd.PrintPage += (sender, e) =>
                {
                    e.Graphics.DrawString("Sample Print Page", new System.Drawing.Font("Arial", 16),
                        System.Drawing.Brushes.Black, 50, 50);
                };
                pd.Print();
                return true; // PASS
            }
            catch
            {
                return false; // FAIL
            }
        }
    }
}
