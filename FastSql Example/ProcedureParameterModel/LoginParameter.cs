using FastSql.Sdk.Attributes;
using FastSql.Sdk.Bases;

namespace FastSql_Example.ProcedureParameterModel
{
    public class LoginParameter : SqlParameterBase
    {
        [SqlParameter]
        public string UserName { get; set; }

        [SqlParameter("@Password")]
        public string Pass { get; set; }
    }
}