using System.Data;

namespace DataLoader
{
    public interface IDataLoader
    {
        bool LoadDataIntoTable(DataTable data, string dbConnStr, string targetTable);
    }
}