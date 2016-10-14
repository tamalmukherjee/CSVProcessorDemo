using System;
using System.Data;
using System.IO;

namespace FileReader
{
    public class CSVReader : IFileReader
    {
        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public DataTable GetDataFromCSV(string filePath)
        {
            var Lines = File.ReadAllLines(filePath);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            var Cols = Fields.GetLength(0);
            var fileName = Path.GetFileName(filePath);
            var timestamp = DateTime.Now.ToLocalTime();
            using (var dt = new DataTable())
            {
                //1st row must be column names; force lower case to ensure matching later on.
                for (int i = 0; i < Cols; i++)
                {
                    dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                }
                dt.Columns.Add("filename", typeof(string));
                dt.Columns.Add("timestamp", typeof(DateTime));
                DataRow Row;
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    Fields = Lines[i].Split(new char[] { ',' });
                    Row = dt.NewRow();
                    for (int f = 0; f < Cols; f++)
                    {
                        Row[f] = Fields[f];
                    }
                    Row[Cols] = fileName;
                    Row[Cols + 1] = timestamp;
                    dt.Rows.Add(Row);
                }
                return dt;
            }
        }
    }
}
