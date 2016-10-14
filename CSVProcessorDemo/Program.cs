using DataLoader;
using FileChecker;
using FileReader;
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

            // configuration data
            var folderPath = @"C:\TestCSVLoader";
            var dbConnStr = @"Server=AZSAW0095;Database=WGD;User Id=frame_dev;Password=Kolkata@123;";
            var targetTable = "CSVDemo";

            workflow.ProcessAndLoadFiles(folderPath, dbConnStr, fileChecker, fileReader, targetTable, dataLoader);


            Console.ReadKey();
        }
    }
}