using QuantConnect;

namespace MarketDataService.Services
{
    public interface IHystoricalCryptoDataService
    {
        Task FetchAndSaveHistoricalData(string symbol, Resolution resolution, DateTime startDate, DateTime endDate);
    }
}
