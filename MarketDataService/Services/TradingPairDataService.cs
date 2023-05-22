using DataBase.DataContext;
using DataBase.DataContext.Tables;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Globalization;

namespace MarketDataService.Services
{
    public class TradingPairDataService : ITradingPairDataServicecs
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

                masterData = JsonConvert.DeserializeObject<List<TradingPairData>>(data);

                Console.WriteLine($"{data}");

                var tradingPairDataList = new TradingPairDataList
                {
                    Datasize = masterData.Count
                };

                _context.TradingPairs.Add( tradingPairDataList );

                var tradingPairItems = masterData.Select(o => new TradingPairDataItems
                {
                    Name = o.Name,
                    UrlSymbol = o.UrlSymblo,
                    BaseDecimals = SafeDecimalParse(o.BaseDecimals),
                    CounterDecimals = SafeDecimalParse(o.CounterDecimals),
                    InstantorderCounterDecimals = SafeDecimalParse(o.InstantOrderCounterDecimals),
                    MinimumOrder = SafeDecimalParse(o.MinimumOrder),
                    TradingEngine = o.TradingEngine,
                    InstantAndMarketOrders = o.InstantAndMarketOrders,
                    Description = o.Description,
                    List = tradingPairDataList,
                }).ToList();

                tradingPairDataList.Items = tradingPairItems.ToList();

                await _context.SaveChangesAsync();
            }
        }

        public static decimal SafeDecimalParse(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            return 0;
        }
    }
}
