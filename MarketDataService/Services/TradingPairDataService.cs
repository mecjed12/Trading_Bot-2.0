using DataBase.DataContext;
using DataBase.DataContext.Tables;
using Microsoft.AspNetCore.WebUtilities;
using System.Globalization;

namespace MarketDataService.Services
{
    public class TradingPairDataService
    {
        private readonly IDataBaseContext _context;

        public TradingPairDataService(IDataBaseContext context)
        {
            _context = context;
        }

        public class TradingPairData
        {
            public string? Name { get; set; }
            public string? UrlSymblo { get; set; }
            public string? BaseDecimals { get; set; }
            public string? CounterDecimals { get; set; }
            public string? InstantOrderCounterDecimals { get; set; }
            public string? MinimumOrder { get; set; }
            public string? TradingEngine { get; set; }
            public string? InstantAndMarketOrders { get; set; }
            public string? Description { get; set; }
        }

        public async Task CollectTradingpairDataAsync()
        {
            string url = "https://www.bitstamp.net/api/v2/trading-pairs-info/";

            List<TradingPairData> masterData = new();

            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failer to get data: {response.StatusCode}");
                }

                var data = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"{data}");

                var tradingPairDataList = new TradingPairDataList
                {
                    Datasize = masterData.Count
                };

                var tradingPairItems = masterData.Select(o => new TradingPairDataItems
                {
                    Name = o.Name,
                    UrlSymbol = o.UrlSymblo,
                    BaseDecimals = decimal.Parse(o.BaseDecimals, CultureInfo.InvariantCulture),
                    CounterDecimals = decimal.Parse(o.CounterDecimals, CultureInfo.InvariantCulture),
                    InstantorderCounterDecimals = decimal.Parse(o.InstantOrderCounterDecimals, CultureInfo.InvariantCulture),
                    MinimumOrder = decimal.Parse(o.MinimumOrder, CultureInfo.InvariantCulture),
                    TradingEngine = o.TradingEngine,
                    InstantAndMarketOrders = o.InstantAndMarketOrders,
                    Description = o.Description,
                    List = tradingPairDataList,
                });
                
                tradingPairDataList.Items = tradingPairItems.ToList();

                await _context.SaveChangesAsync();
            }
        }

    }
}
