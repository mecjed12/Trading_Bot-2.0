using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using QuantConnect;

namespace DataBase.DataContext.Tables
{

    [Table("HystoricalCryptoDataList")]
    public class HystoriaclCryptoDataList
    {
        [Key]
        [Column("id")]
        public int ListId { get; set; }

        [Column("TimestampStart")]
        public DateTime TimeStampStart { get; set; }

        [Column("TimestampEnd")]
        public DateTime TimeStampEnd { get; set;}

        [Column("DataSize")]
        public long DataSize { get; set; }

        public virtual ICollection<HystoricalCryptoDataItems>? Datasets { get; set; }
    }

    [Table("HystoricalCryptoDataItems")]
    public class HystoricalCryptoDataItems
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Column("Volume")]
        public decimal Volume { get; set; }

        [Column("Open")]
        public decimal Open { get; set; }

        [Column("High")]
        public decimal High { get; set; }

        [Column("Low")]
        public decimal Low { get; set; }

        [Column("EndTime")]
        public DateTime Endtime { get; set; }

        [Column("Period")]
        public TimeSpan Period { get; set; }

        [Column("DataType")]
        public MarketDataType DataType { get; set; }

        [Column("IsFillForward")]
        public bool IsFillForward { get; set; }

        [Column("Time")]
        public DateTime Time { get; set; }

        [Column("Symbol")]
        public string? Symbolstring { get; set; }

        [NotMapped]
        public Symbol Symbol
        {
            get
            {
                if (Symbolstring == null)
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<Symbol>(Symbolstring);
            }

            set
            {
                if (value == null)
                {
                    Symbolstring = null;
                }
                else
                {
                    Symbolstring = JsonConvert.SerializeObject(value);
                }
            }
        }

        [Column("Value")]
        public decimal Value { get; set; }

        [Column("Pric")]
        public decimal Price { get; set; }

        [ForeignKey("listId")]
        public int ListId { get; set; }

        public virtual HystoriaclCryptoDataList? List { get; set; }
    }
}
