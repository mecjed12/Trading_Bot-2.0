using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataContext.Tables
{
    [Table("tradingPair")]
    public class TradingPair
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
