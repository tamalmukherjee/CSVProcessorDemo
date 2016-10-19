using System.Collections.Generic;
using System.IO;

namespace FileChecker
{
    public class Folder : IFileChecker
    {
        public List<KeyValuePair<string, string>> GetCSVFilesFromSource(string srcDirPath, string tempDirPath)
        {
            var filePaths = Directory.GetFiles(srcDirPath, "*.csv");
            var retObj = new List<KeyValuePair<string, string>>();
            if (!Directory.Exists(tempDirPath))
            {
                Directory.CreateDirectory(tempDirPath);
            }
            foreach (var filePath in filePaths)
            {
                var fileExtension = Path.GetExtension(filePath);
                if (fileExtension == ".csv")
                {
                    var fileName = Path.GetFileName(filePath);
                    var tempFilePath = Path.Combine(tempDirPath, fileName);
                    File.Copy(filePath, tempFilePath, true);
                    retObj.Add(new KeyValuePair<string, string>(fileName, tempFilePath));
                }
            }
            return retObj;
        }
    }
}