using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataContext.Tables
{
    [Table("TradingPairList")]
    public class TradingPairDataList
    {
        [Key]
        [Column("id")]
        public int ListId { get; set; }

        [Column("timestamp")]
        public DateTime DateTime => DateTime.Now;

        [Column("datasize")]
        public long Datasize { get; set; }

        public virtual ICollection<TradingPairDataItems>? Items { get; set; }
    }

    [Table("TradingPairItems")]
    public class TradingPairDataItems
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("url_symbol")]
        public string? UrlSymbol { get; set; }

        [Column("base_decimals")]
        public decimal BaseDecimals { get; set; }

        [Column("counter_decimals")]
        public decimal CounterDecimals { get; set; }

        [Column("instant_order_counter_decimals")]
        public decimal InstantorderCounterDecimals { get; set; }

        [Column("minimum_order")]
        public decimal MinimumOrder { get; set; }

        [Column("trading")]
        public string? TradingEngine { get; set; }

        [Column("instant_and_market_orders")]
        public string? InstantAndMarketOrders { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [ForeignKey("listId")]
        public int ListId { get; set; }

        public virtual TradingPairDataList? List { get; set; }
    }
}
