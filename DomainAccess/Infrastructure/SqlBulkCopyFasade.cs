using System.Data;
using System.Data.SqlClient;
using DomainAccess.Infrastructure;

namespace DataAccess.Infrastructore
{
    public class SqlBulkCopyFasade
    {
        private readonly string _connectionString;

        public SqlBulkCopyFasade(ConnectionConfiguration connectionConfiguration)
        {
            _connectionString = connectionConfiguration.ConnectionString;
        }

        public void WriteDataTableToServer(DataTable table)
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
