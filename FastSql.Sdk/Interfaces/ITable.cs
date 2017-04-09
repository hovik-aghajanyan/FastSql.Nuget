using System.Data.SqlClient;

namespace FastSql.Sdk.Interfaces
{
    public interface ITable
    {
        void Parse(SqlDataReader reader);
    }
}