using System.Data.SqlClient;

namespace FastSql.Sdk.Interfaces
{
    public interface ISqlParameter
    {
        SqlParameter[] GetParameters();
    }
}