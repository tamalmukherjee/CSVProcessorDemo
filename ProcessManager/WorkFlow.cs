using DataLoader;
using FileChecker;
using FileReader;

namespace ProcessManager
{
    public class Workflow : IWorkflow
    {
        public bool ProcessAndLoadFiles(string folderPath, string dbConnStr, IFileChecker fileChecker,
            IFileReader fileReader, string targetTable, IDataLoader dataLoader)
        {
            var files = fileChecker.GetCSVFileNames(folderPath);
            foreach(var file in files)
            {
                var data = fileReader.GetDataFromCSV(file.Value);
                dataLoader.LoadDataIntoTable(data, dbConnStr, targetTable);
            }
            return true;
        }
    }
}