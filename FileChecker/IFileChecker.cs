using System.Collections.Generic;

namespace FileChecker
{
    public interface IFileChecker
    {
        List<KeyValuePair<string, string>> GetCSVFileNames(string directoryPath);
    }
}