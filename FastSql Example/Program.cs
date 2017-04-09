using System;
using System.Collections.Generic;
using FastSql;
using FastSql_Example.ProcedureParameterModel;
using FastSql_Example.TableModels;

namespace FastSql_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = "Data Source=INSTANCE_NAME;" +
                       "Initial Catalog=CATALOGNAME;" +
                       "User id=USER_NAME;" +
                       "Password=PASSWORD;";
            Sql.Initilize(conn);
            StoredProcedure sp = new StoredProcedure("spLogin",new LoginParameter(){Pass = "YOUR_PASS", UserName = "YOUR_USERNAME"});
            List<UserTable> result = sp.Execute<UserTable>();
        }
    }
}