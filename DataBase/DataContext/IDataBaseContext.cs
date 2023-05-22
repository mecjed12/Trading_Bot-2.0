using DataBase.DataContext.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DataContext
{
    public interface IDataBaseContext
    {
        DbSet<DBUser> users { get; set; }
        DbSet<HistoricalDataList> HistoricalData { get; set; }
        DbSet<TradingPairDataList> TradingPairs { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
