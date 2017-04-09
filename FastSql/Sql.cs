using System.Data.SqlClient;

namespace FastSql
{
    /// <summary>
    /// 
    /// </summary>
    public static class Sql
    {
        /// <summary>
        /// 
        /// </summary>
        public static SqlConnection Connection => new SqlConnection(_connectionString);

        private static string _connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initilize(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}