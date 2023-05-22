using static MarketDataService.Services.HistoricalDataService;

namespace MarketDataService.Services
{
    public interface IHistoricalDataService
    {
        Task<List<OhlcData>> ScrapTheHistoricalData(bool saveToDb);
        Task DeleteHistoricalDataSetAsync(int id);
        void OutputDataAsCsv(List<OhlcData> masterData);
        Task CreateAndSaveCsvData();
    }
}
