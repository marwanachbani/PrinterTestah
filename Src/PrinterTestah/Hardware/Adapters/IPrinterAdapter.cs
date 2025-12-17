using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Adapters
{
    public interface IPrinterAdapter
    {
        string PrinterName { get; }

        bool RunTest();
        bool PrintTestPage();
    }
}
