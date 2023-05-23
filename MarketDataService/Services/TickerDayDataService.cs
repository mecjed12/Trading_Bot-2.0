using DataBase.DataContext;
using DataBase.DataContext.Tables;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace MarketDataService.Services
{
    public class TickerDayDataService : ITickerDayDataService
    {
        private readonly IDataBaseContext _context;

        public TickerDayDataService(IDataBaseContext context)
        {
            _context = context;
        }

        public class TickerDayData
        {
            [JsonProperty("last")]
            public string? LastPrice { get; set; }

            [JsonProperty("high")]
            public string? HighestPrice { get; set; }

            [JsonProperty("low")]
            public string? LowestPrice { get; set; }

            [JsonProperty("vwap")]
            public string? VWap { get; set; }

            [JsonProperty("volume")]
            public string? Volume { get; set; }

            [JsonProperty("bid")]
            public string? Bid { get; set; }

            [JsonProperty("ask")]
            public string? Ask { get; set; }

            [JsonProperty("timestamp")]
            public long? Timestamp { get; set; }

            [JsonProperty("open")]
            public string? Open { get; set; }

            [JsonProperty("open_24")]
            public string? Open24 { get; set; }

            [JsonProperty("percent_change_24")]
            public string? PercentChange24 { get; set; }
        }

        public async Task CollectingTickerDayDataAsync()
        {
            string currencyPair = "btceur";
            string tickerDayUrl = $"https://www.bitstamp.net/api/v2/ticker/{currencyPair}/";

            List<TickerDayData> masterData = new();
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync(tickerDayUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failure to get the data: {response.StatusCode}");
                }

                var data = await response.Content.ReadAsStringAsync();
                var tickerDt = JsonConvert.DeserializeObject<TickerDayData>(data);

                masterData.Add(tickerDt);

                var tickerDayDataList = new TickerDayDataList
                {
                    Timestamp = DateTime.UtcNow,
                    DataSize = masterData.Count
                };

                var tickerDayDataItems = masterData.Select(o => new TickerDayDataItems
                {
                    LastPrice = decimal.Parse(o.LastPrice ?? "0", CultureInfo.InvariantCulture),
                    HighestPrice = decimal.Parse(o.HighestPrice ?? "0", CultureInfo.InvariantCulture),
                    LowestPrice = decimal.Parse(o.LowestPrice ?? "0", CultureInfo.InvariantCulture),
                    VWap = decimal.Parse(o.VWap ?? "0", CultureInfo.InvariantCulture),
                    Volume = decimal.Parse(o.Volume ?? "0", CultureInfo.InvariantCulture),
                    Bid = decimal.Parse(o.Bid ?? "0", CultureInfo.InvariantCulture),
                    Ask = decimal.Parse(o.Ask ?? "0", CultureInfo.InvariantCulture),
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(o.Timestamp ?? 0).UtcDateTime,
                    Open = decimal.Parse(o.Open ?? "0", CultureInfo.InvariantCulture),
                    Open24 = decimal.Parse(o.Open24 ?? "0", CultureInfo.InvariantCulture),
                    PercentChange24 = decimal.Parse(o.PercentChange24 ?? "0", CultureInfo.InvariantCulture),
                    Pair = currencyPair,
                    List = tickerDayDataList
                }) ;

                tickerDayDataList.TickerDayDataItems = tickerDayDataItems.ToList();
                _context.TickerDayData.Add(tickerDayDataList);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    throw;
                }
            }
        }
    }
}
