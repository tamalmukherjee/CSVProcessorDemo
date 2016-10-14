using DataLoader;
using FileChecker;
using FileReader;
using Logger;
using ProcessManager;
using System;

namespace CSVProcessorDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // instantiate interfaces
            IWorkflow workflow = new Workflow();
            IFileChecker fileChecker = new Folder();
            IFileReader fileReader = new CSVReader();
            IDataLoader dataLoader = new SQLDataLoader();
            ILogger logger = new DBLogger();

            // configuration data
            var srcDirPath = @"C:\TestCSVFilesSource";
            var tempDirPath = @"C:\CSVDemoTemp";
            var dbConnStr = @"Server=AZSAW0095;Database=WGD;User Id=frame_dev;Password=Kolkata@123;";
            var targetTable = "CSVDemo";

            logger.logInfo("Starting process.");
            workflow.ProcessAndLoadFiles(srcDirPath, tempDirPath, dbConnStr, fileChecker, fileReader, targetTable, dataLoader, logger);
            logger.logInfo("Process completed.");
        }
    }
}