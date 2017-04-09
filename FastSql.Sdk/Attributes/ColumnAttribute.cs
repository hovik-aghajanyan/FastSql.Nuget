using System;

namespace FastSql.Sdk.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute:Attribute
    {
        public string Name { get; set; }

        public ColumnAttribute()
        {
            
        }

        public ColumnAttribute(string name) : this()
        {
            Name = name;
        }
    }
}