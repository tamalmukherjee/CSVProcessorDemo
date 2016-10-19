using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLoader
{
    public class SQLDataLoader : IDataLoader
    {
        public bool LoadDataIntoTable(DataTable data, string dbConnStr, string targetTable)
        {
            using (var conn = new SqlConnection(dbConnStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                    {
                        foreach (DataColumn col in data.Columns)
                        {
                            bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        }

                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.DestinationTableName = targetTable;
                        bulkCopy.WriteToServer(data);
                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }                
            }
        }
    }
}
