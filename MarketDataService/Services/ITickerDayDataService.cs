namespace MarketDataService.Services
{
    public interface ITickerDayDataService
    {
        Task CollectingTickerDayDataAsync();
        Task DeleteTickerDayDataSetAsync(int id);
    }
}
