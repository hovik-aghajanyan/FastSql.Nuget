using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using FastSql.Sdk.Attributes;
using FastSql.Sdk.Interfaces;

namespace FastSql.Sdk.Bases
{
    public class SqlParameterBase:ISqlParameter
    {
        public SqlParameter[] GetParameters()
        {
            var props =
                this.GetType()
                    .GetRuntimeProperties()
                    .Where(p => p.GetCustomAttribute(typeof(SqlParameterAttribute)) != null);
            List<SqlParameter> result = new List<SqlParameter>();
            foreach (var propertyInfo in props)
            {
                var paramInfo = propertyInfo.GetCustomAttribute<SqlParameterAttribute>();
                var paramName = string.IsNullOrEmpty(paramInfo.Name) ? propertyInfo.Name : paramInfo.Name.StartsWith("@") ? paramInfo.Name.Substring(1) : paramInfo.Name;
                result.Add(new SqlParameter("@"+paramName,propertyInfo.GetValue(this)));
            }
            if (result.Count == 0)
                return null;
            return result.ToArray();
        }
    }
}