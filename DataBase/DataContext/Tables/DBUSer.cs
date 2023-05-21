using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataContext.Tables
{
    [Table("Users")]
    public class DBUser
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("username")]
        public string? UserName { get; set; }

        [Column("passwordhash")]
        public byte[]? PasswordHash { get; set; }

        [Column("passwordsalt")]
        public byte[]? PasswordSalt { get; set;}
    }
}
