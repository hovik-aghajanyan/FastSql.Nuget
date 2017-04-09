using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FastSql.Sdk.Interfaces;

namespace FastSql
{
    /// <summary>
    /// Query object which help to execute querys 
    /// </summary>
    public class Query
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
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        public Query(string query, params SqlParameter[] parameters)
        {
            Connection = Sql.Connection;
            Command = new SqlCommand(query, Connection);
            if (parameters.Length > 0)
                Command.Parameters.AddRange(parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        public Query(string query, ISqlParameter parameter)
        {
            Connection = Sql.Connection;
            Command = new SqlCommand(query, Connection);
            var parameters = parameter?.GetParameters();
            if (parameters != null)
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
        public List<T> Execute<T>() where T : class, ITable, new()
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
        public Dictionary<string, List<ITable>> Execute<T1, T2>() where T1 : class, ITable, new() where T2 : class, ITable, new()
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
        public Dictionary<string, List<ITable>> Execute<T1, T2, T3>() where T1 : class, ITable, new() where T2 : class, ITable, new() where T3 : class, ITable, new()
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
        public T ExecuteSingle<T>() where T : class, ITable, new()
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
