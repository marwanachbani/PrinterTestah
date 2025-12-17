using Business.Services;

namespace Business.Tests
{
    [TestClass]
    public sealed class LoggingServiceTests
    {
        
        [TestMethod]
        public void Log_ShouldCreateCsvEntry()
        {
            var logger = new LoggingService();

            logger.Log("TestPrinter", "Test", true);

            Assert.IsTrue(File.Exists("PrinterLog.csv"));
        }
    }
}
