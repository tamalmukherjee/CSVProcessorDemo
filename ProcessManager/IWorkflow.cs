using DataLoader;
using FileChecker;
using FileReader;

namespace ProcessManager
{
    public interface IWorkflow
    {
        bool ProcessAndLoadFiles(string folderPath, string dbConnStr, IFileChecker fileChecker,
            IFileReader fileReader, string targetTable, IDataLoader dataLoader);
    }
}