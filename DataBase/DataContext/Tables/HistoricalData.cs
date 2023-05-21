using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataContext.Tables
{
    [Table("Historicaldatalist")]
    public class HistoricalDataList
    {
        [Key]
        [Column("id")]
        public int ListId { get; set; }

        [Column("timestampstart")]
        public DateTime TimeStampStart { get; set; }

        [Column("timestampend")]
        public DateTime TimeStampEnd { get; set;}

        [Column("datasize")]
        public long Datasize { get; set; }

        public virtual ICollection<HistoricalDataItems>? DataSets { get; set; }
    }
    


    [Table("historiacalDataItems")]
    public class HistoricalDataItems
    {
        [Key]
        [Column("id")]
        public int ItemId { get; set; }

        [Column("timeStamp")]
        public int TimeStamp { get; set; }

        [Column("open")]
        public decimal Open { get; set; }

        [Column("high")]
        public decimal High { get; set; }

        [Column("low")]
        public decimal Low { get; set; }

        [Column("close")]
        public decimal Close { get; set; }

        [Column("volume")]
        public decimal Volume { get; set; }

        [ForeignKey("listId")]
        public int ListId { get; set; }

        public virtual HistoricalDataList? List { get; set; }
    }
}


