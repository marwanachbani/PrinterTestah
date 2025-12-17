using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class PrinterInfo
    {
        public string Name { get; set; }
        public string Status { get; set; } // Online / Offline
        public bool IsDefault { get; set; }
        public int PagesPrinted { get; set; }
    }
}
