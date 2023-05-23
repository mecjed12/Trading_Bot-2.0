namespace MarketDataService.Services
{
    public interface ITickerHourDataService
    {
        Task CollectingTickerHourDataAsync();
        Task DeleteTickerHourDataSetAsync(int id);
    }
}
