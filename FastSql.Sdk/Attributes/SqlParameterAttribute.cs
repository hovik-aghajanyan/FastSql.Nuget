using System;

namespace FastSql.Sdk.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SqlParameterAttribute:Attribute
    {
        public string Name { get; set; }

        public SqlParameterAttribute()
        {
            
        }

        public SqlParameterAttribute(string name):this()
        {
            Name = name;
        }
    }
}