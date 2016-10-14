using System.Collections.Generic;

namespace FileChecker
{
    public interface IFileChecker
    {
        List<KeyValuePair<string, string>> GetCSVFilesFromSource(string srcDirPath, string tempDirPath);
    }
}