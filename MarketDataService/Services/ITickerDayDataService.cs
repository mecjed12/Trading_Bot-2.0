namespace MarketDataService.Services
{
    public interface ITickerDayDataService
    {
        Task CollectingTickerDayDataAsync();
    }
}
