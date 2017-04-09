using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using FastSql.Sdk.Attributes;
using FastSql.Sdk.Interfaces;

namespace FastSql.Sdk.Bases
{
    public class TableBase:ITable
    {
        public void Parse(SqlDataReader reader)
        {
            var props =
                this.GetType().GetRuntimeProperties().Where(p => p.GetCustomAttribute(typeof(ColumnAttribute)) != null);
            foreach (var propertyInfo in props)
            {
                var columnInfo = propertyInfo.GetCustomAttribute<ColumnAttribute>();
                var colName = string.IsNullOrEmpty(columnInfo?.Name) ? propertyInfo.Name : columnInfo.Name;
                try
                {
                    reader.GetOrdinal(colName);
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
                if (propertyInfo.PropertyType == typeof(decimal))
                {
                    propertyInfo.SetValue(this, decimal.Parse(reader[colName].ToString()));
                }
                else if (propertyInfo.PropertyType == typeof(long))
                {
                    propertyInfo.SetValue(this, long.Parse(reader[colName].ToString()));
                }
                else if (propertyInfo.PropertyType == typeof(int))
                {
                    propertyInfo.SetValue(this, int.Parse(reader[colName].ToString()));
                }
                else if (propertyInfo.PropertyType == typeof(Guid))
                {
                    propertyInfo.SetValue(this, Guid.Parse(reader[colName].ToString()));
                }
                else if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    propertyInfo.SetValue(this, DateTime.Parse(reader[colName].ToString()));
                }
                else if (propertyInfo.PropertyType == typeof(byte[]))
                {
                    propertyInfo.SetValue(this, reader[colName] as byte[]);
                }
                else if (propertyInfo.PropertyType == typeof(bool))
                {
                    propertyInfo.SetValue(this, bool.Parse(reader[colName].ToString()));
                }
                else
                {
                    propertyInfo.SetValue(this, reader[colName].ToString());
                }
            }
        }
    }
}