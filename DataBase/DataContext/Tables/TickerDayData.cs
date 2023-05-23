using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataContext.Tables
{
    [Table("tickerDataList")]
    public class TickerDayDataList
    {
        [Key]
        [Column("Id")]
        public int ListId { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("datasize")]
        public long DataSize { get; set; }

        public virtual ICollection<TickerDayDataItems>? TickerDayDataItems { get; set; }
    }

    [Table("tickerDataItems")]
    public class TickerDayDataItems
    {
        [Key]
        [Column("id")]
        public int ItemId { get; set; }

        [Column("lastprice")]
        public decimal LastPrice { get; set; }

        [Column("highestPrice")]
        public decimal HighestPrice { get; set; }

        [Column("lowestPrice")]
        public decimal LowestPrice { get; set; }

        [Column("volume_weighted_average_price")]
        public decimal VWap { get; set;}

        [Column("volume")]
        public decimal Volume { get; set; }

        [Column("highest_buy_order")]
        public decimal Bid { get; set; }

        [Column("lowest_sell_order")]
        public decimal Ask { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("first_price_of_day")]
        public decimal Open { get; set; }

        [Column("open_24")]
        public decimal Open24 { get; set; }

        [Column("percent_change_24")]
        public decimal PercentChange24 { get; set; }

        [Column("pair")]
        public string? Pair { get; set; }

        [ForeignKey("listId")]
        public int ListId { get; set; }

        public virtual TickerDayDataList? List { get; set; }
    }
}
