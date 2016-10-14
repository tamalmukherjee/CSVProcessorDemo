using System.Data;

namespace FileReader
{
    public interface IFileReader
    {
        DataTable GetDataFromCSV(string filePath);
    }
}