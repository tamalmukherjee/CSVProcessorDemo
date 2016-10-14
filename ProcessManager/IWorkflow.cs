using DataLoader;
using FileChecker;
using FileReader;
using Logger;

namespace ProcessManager
{
    public interface IWorkflow
    {
        bool ProcessAndLoadFiles(string srcDirPath, string tempDirPath, string dbConnStr, IFileChecker fileChecker,
            IFileReader fileReader, string targetTable, IDataLoader dataLoader, ILogger logger);
    }
}