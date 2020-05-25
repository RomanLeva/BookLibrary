using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic.Mappings
{
    public static class SqlBulkDataTableWriter
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["Book_Library"].ConnectionString;

        public static void WriteDataTableToServer(DataTable table)
        {
            using (var sqlBulk = new SqlBulkCopy(_connectionString))
            {
                sqlBulk.DestinationTableName = table.TableName;
                foreach (var column in table.Columns)
                {
                    sqlBulk.ColumnMappings.Add(column.ToString(), column.ToString());
                }
                sqlBulk.WriteToServer(table);
            }
        }
    }
}
