using System.Data;
using System.Data.SqlClient;

namespace DataLoader
{
    public class SQLDataLoader : IDataLoader
    {
        public bool LoadDataIntoTable(DataTable data, string dbConnStr, string targetTable)
        {
            using (var bulkCopy = new SqlBulkCopy(dbConnStr))
            {
                foreach (DataColumn col in data.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = targetTable;
                bulkCopy.WriteToServer(data);
            }
            return true;
        }
    }
}
