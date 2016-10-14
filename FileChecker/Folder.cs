using System.Collections.Generic;
using System.IO;

namespace FileChecker
{
    public class Folder : IFileChecker
    {
        public List<KeyValuePair<string, string>> GetCSVFileNames(string directoryPath)
        {
            var filePaths = Directory.GetFiles(directoryPath, "*.csv");
            var retObj = new List<KeyValuePair<string, string>>();
            foreach (var filePath in filePaths)
            {
                retObj.Add(new KeyValuePair<string, string>(Path.GetFileName(filePath), filePath));
            }
            return retObj;
        }
    }
}