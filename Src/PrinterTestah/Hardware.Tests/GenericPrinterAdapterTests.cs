using Hardware.Adapters;

namespace Hardware.Tests
{
    [TestClass]
    public class GenericPrinterAdapterTests
    {
        private const string SafePrinterName = "Microsoft Print to PDF";

        [TestMethod]
        public void Constructor_ShouldInitializePrinterName()
        {
            var adapter = new GenericPrinterAdapter(SafePrinterName);

            Assert.AreEqual(SafePrinterName, adapter.PrinterName);
        }

        [TestMethod]
        public void RunTest_WithValidPrinter_ShouldReturnTrue()
        {
            var adapter = new GenericPrinterAdapter(SafePrinterName);

            bool result = adapter.RunTest();

            Assert.IsTrue(result, "RunTest should return PASS for a valid printer.");
        }

        [TestMethod]
        public void PrintTestPage_WithValidPrinter_ShouldReturnTrue()
        {
            var adapter = new GenericPrinterAdapter(SafePrinterName);

            bool result = adapter.PrintTestPage();

            Assert.IsTrue(result, "PrintTestPage should return PASS for a valid printer.");
        }

        [TestMethod]
        public void RunTest_WithInvalidPrinter_ShouldReturnFalse()
        {
            var adapter = new GenericPrinterAdapter("Invalid_Printer_123");

            bool result = adapter.RunTest();

            Assert.IsFalse(result, "RunTest should FAIL for an invalid printer.");
        }

        [TestMethod]
        public void PrintTestPage_WithInvalidPrinter_ShouldReturnFalse()
        {
            var adapter = new GenericPrinterAdapter("Invalid_Printer_123");

            bool result = adapter.PrintTestPage();

            Assert.IsFalse(result, "PrintTestPage should FAIL for an invalid printer.");
        }
    }
}
