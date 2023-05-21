using DataBase.DataContext.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DataContext
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : 
            base(options) 
        { }

        
        public DbSet<DBUser> users { get; set; }
        public DbSet<HistoricalDataList> HistoricalData { get; set; }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
