    using FastSql.Sdk.Attributes;
    using FastSql.Sdk.Bases;

namespace FastSql_Example.TableModels
{
    [Table("tblUsers")]
    public class UserTable : TableBase
    {
        [Column("U_ID")]
        public long Id { get; set; }

        [Column("U_FirstName")]
        public string FirstName { get; set; }

        [Column("U_LastName")]
        public string LastName { get; set; }

        [Column("U_UserName")]
        public string UserName { get; set; }

        [Column("U_Password")]
        public string Password { get; set; }

        [Column("U_IsEnabled")]
        public bool IsEnabled { get; set; }

        [Column("U_Address")]
        public string Address { get; set; }

        [Column("U_Phone1")]
        public string Phone1 { get; set; }

        [Column("U_Phone2")]
        public string Phone2 { get; set; }

        [Column("U_Pin")]
        public string Pin { get; set; }

        [Column("U_Image")]
        public byte[] Image { get; set; }

        [Column("U_Rfid")]
        public string Rfid { get; set; }

        [Column("U_RoleId")]
        public long RoleId { get; set; }

        [Column("U_NeedChangePassword")]
        public bool IsNeedChangePassword { get; set; }
    }
}