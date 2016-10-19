using System;
using System.Data.SqlClient;

namespace Logger
{
    public class DBLogger : ILogger
    {
        string dbConnStr, logTableName;
        public DBLogger()
        {
            dbConnStr = @"Server=AZSAW0095;Database=WGD;User Id=frame_dev;Password=Kolkata@123;";
            logTableName = "DemoLog";
        }

        public void LogError(string msg)
        {
            LogError("Error", msg);
        }

        public void logInfo(string msg)
        {
            LogError("Info", msg);
        }

        private void LogError(string type, string msg)
        {
            try
            {
                var query = "insert into " + logTableName + "(type, logdata, timestamp) values(@type, @logdata, CURRENT_TIMESTAMP)";
                using (var conn = new SqlConnection(dbConnStr))
                {
                    conn.Open();
                    using (var myCommand = new SqlCommand(query, conn))
                    {
                        myCommand.Parameters.AddWithValue("@type", type);
                        myCommand.Parameters.AddWithValue("@logdata", msg);
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
    }
}
