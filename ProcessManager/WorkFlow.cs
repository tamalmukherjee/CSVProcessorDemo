using DataLoader;
using FileChecker;
using FileReader;
using Logger;
using System;

namespace ProcessManager
{
    public class Workflow : IWorkflow
    {
        public bool ProcessAndLoadFiles(string srcDirPath, string tempDirPath, string dbConnStr, IFileChecker fileChecker,
            IFileReader fileReader, string targetTable, IDataLoader dataLoader, ILogger logger)
        {
            try
            {
                logger.logInfo("Getting CSV files from source to temp location.");
                var files = fileChecker.GetCSVFilesFromSource(srcDirPath, tempDirPath);
                logger.logInfo(files.Count + " file(s) found.");
                foreach (var file in files)
                {
                    try
                    {
                        logger.logInfo("Stating processing " + file.Key);
                        var data = fileReader.GetDataFromCSV(file.Value);
                        logger.logInfo("Data extracted from " + file.Key + ". Starting data load to " + targetTable);
                        dataLoader.LoadDataIntoTable(data, dbConnStr, targetTable);
                        logger.logInfo("Data load completed. Deleting temp file.");
                        fileReader.DeleteFile(file.Value);
                        logger.LogError("Temp file deleted.");
                    }
                    catch(Exception ex)
                    {
                        logger.LogError("Error occurred during processing of " + file.Key + ". Exception details: " + ex.StackTrace);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.logInfo(ex.StackTrace);
                return false;
            }
        }
    }
}