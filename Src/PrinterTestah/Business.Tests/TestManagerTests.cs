using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestClass]
    public class TestManagerTests
    {
        private TestManager _manager;

        [TestInitialize]
        public void Setup()
        {
            _manager = new TestManager();
        }

        [TestMethod]
        public void RefreshPrinters_ShouldPopulatePrinterList()
        {
            // Act
            _manager.RefreshPrinters();

            // Assert
            Assert.IsNotNull(_manager.Printers);
            Assert.IsTrue(_manager.Printers.Count > 0,
                "No printers were detected on the system.");
        }

        [TestMethod]
        public void RefreshPrinters_ShouldMarkDefaultPrinter()
        {
            _manager.RefreshPrinters();

            bool hasDefault = _manager.Printers.Any(p => p.IsDefault);

            Assert.IsTrue(hasDefault,
                "No default printer detected. System should have one.");
        }

        [TestMethod]
        public void RunTest_ShouldReturnResult_AndLog()
        {
            _manager.RefreshPrinters();
            var printer = _manager.Printers.First();

            bool result = _manager.RunTest(printer.Name);

            Assert.IsTrue(result);

            var history = _manager.GetHistory();
            Assert.IsTrue(history.Any(l => l.Contains(printer.Name) && l.Contains("Test")));
        }

        [TestMethod]
        public void PrintTestPage_ShouldReturnResult_AndLog()
        {
            _manager.RefreshPrinters();
            var printer = _manager.Printers.First();

            bool result = _manager.PrintTestPage(printer.Name);

            Assert.IsTrue(result);

            var history = _manager.GetHistory();
            Assert.IsTrue(history.Any(l => l.Contains(printer.Name) && l.Contains("Print")));
        }

        [TestMethod]
        public void GetHistory_ShouldReturnCsvLines()
        {
            var history = _manager.GetHistory();

            Assert.IsNotNull(history);
        }
    }
}
