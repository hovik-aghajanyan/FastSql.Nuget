using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FastSql.Sdk.Bases;
using FastSql.Sdk.Interfaces;

namespace FastSql
{
    /// <summary>
    /// 
    /// </summary>
    public class StoredProcedure
    {
        /// <summary>
        /// 
        /// </summary>
        protected SqlCommand Command { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected SqlConnection Connection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        public StoredProcedure(string name, params SqlParameter[] parameters)
        {
            Connection = Sql.Connection;
            Command = new SqlCommand(name, Connection) {CommandType = CommandType.StoredProcedure};
            if(parameters.Length > 0)
                Command.Parameters.AddRange(parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameter"></param>
        public StoredProcedure(string name, ISqlParameter parameter)
        {
            Connection = Sql.Connection;
            Command = new SqlCommand(name, Connection) { CommandType = CommandType.StoredProcedure };
            var parameters = parameter?.GetParameters();
            if(parameters != null)
                Command.Parameters.AddRange(parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Execute<T>() where T: class, ITable, new()
        {
            List<T> result = new List<T>();
            try
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    T t = new T();
                    t.Parse(reader);
                    result.Add(t);
                }
            }
            finally
            {
                Connection.Close();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public Dictionary<string,List<ITable>> Execute<T1,T2>() where T1 : class, ITable, new() where T2 : class, ITable, new()
        {
            Dictionary<string, List<ITable>> result = new Dictionary<string, List<ITable>>();
            try
            {
                Connection.Open();
                var reader = Command.ExecuteReader();
                List<ITable> data = new List<ITable>();
                while (reader.Read())
                {
                    T1 t = new T1();
                    t.Parse(reader);
                    data.Add(t);
                }
                result.Add(typeof(T1).Name,data);
                if (reader.NextResult())
                {
                    List<ITable> data2 = new List<ITable>();
                    while (reader.Read())
                    {
                        T2 s = new T2();
                        s.Parse(reader);
                        data2.Add(s);
                    }
                    result.Add(typeof(T2).Name, data2);
                }
            }
            finally
            {
                Connection.Close();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public Dictionary<string, List<ITable>> Execute<T1, T2,T3>() where T1 : class, ITable, new() where T2 : class, ITable, new() where T3 : class, ITable, new()
        {
            Dictionary<string, List<ITable>> result = new Dictionary<string, List<ITable>>();
            try
            {
                Connection.Open();
                var reader = Command.ExecuteReader();
                List<ITable> data = new List<ITable>();
                while (reader.Read())
                {
                    T1 t = new T1();
                    t.Parse(reader);
                    data.Add(t);
                }
                result.Add(typeof(T1).Name, data);
                if (reader.NextResult())
                {
                    List<ITable> data2 = new List<ITable>();
                    while (reader.Read())
                    {
                        T2 s = new T2();
                        s.Parse(reader);
                        data2.Add(s);
                    }
                    result.Add(typeof(T2).Name, data2);
                }
                if (reader.NextResult())
                {
                    List<ITable> data3 = new List<ITable>();
                    while (reader.Read())
                    {
                        T3 k = new T3();
                        k.Parse(reader);
                        data3.Add(k);
                    }
                    result.Add(typeof(T3).Name, data3);
                }
            }
            finally
            {
                Connection.Close();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ExecuteSingle<T>() where T : class,ITable, new()
        {
            try
            {
                Connection.Open();
                var reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    T t = new T();
                    t.Parse(reader);
                    return t;
                }
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }
    }
}