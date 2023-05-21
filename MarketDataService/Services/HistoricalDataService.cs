using DataBase.DataContext;
using DataBase.DataContext.Tables;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Globalization;


namespace MarketDataService.Services
{
    public class HistoricalDataService : IHistoricalDataService
    {
        private readonly IDataBaseContext _context;

        public HistoricalDataService(IDataBaseContext context)
        {
            _context = context;
        }

        public class OhlcData
        {
            public string? Pair { get; set; }
            public string? Timestamp { get; set; }
            public string? Open { get; set; }
            public string? High { get; set; }
            public string? Low { get; set; }
            public string? Close { get; set; }
            public string? Volume { get; set; }
        }

        public class OhlcResponse
        {
            public string? Namme { get; set; }
            public string? Period { get; set; }
            public string? Description { get; set; }
            public string? Pair { get; set; }
            public List<OhlcData>? Ohlc { get; set; }
        }

        public class DataResponse
        {
            public OhlcResponse? Data { get; set; }
        }

        public async Task ScrapTheHistoricalData()
        {
            string currencyPair = "btceur";
            string url = $"https://www.bitstamp.net/api/v2/ohlc/{currencyPair}";

            DateTime start = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime end = new DateTime(2021, 1, 1, 23, 59, 59, DateTimeKind.Utc);

            List<int> dates = new List<int>();

            for(var dt = start; dt <= end; dt = dt.AddHours(1))
            {
                var unixTime = (int)Math.Round((dt - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
                dates.Add(unixTime);
            }

            List<OhlcData> masterData = new List<OhlcData>();

            using (var client = new HttpClient())
            {
                for(int i = 0; i < dates.Count - 1; i++)
                {
                    var first = dates[i];
                    var last = dates[i + 1];

                    var parameters = new Dictionary<string, string>
                    {
                        {"step", "3600"},
                        {"limit", "10"},
                        {"start", first.ToString()},
                        {"end", last.ToString()}
                    };

                    var requestUrl = QueryHelpers.AddQueryString(url, parameters);
                    var response = await client.GetAsync(requestUrl);

                    if(!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Failed to get data for {first}-{last}: ");
                        continue;
                    }

                    var data = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"{data}");

                    var dataResponse = JsonConvert.DeserializeObject<DataResponse>(data);
                    var ohlcResponse = dataResponse?.Data;

                    if(ohlcResponse?.Ohlc == null)
                    {
                        Console.WriteLine($"No data for {first}-{last}");
                        continue;
                    }

                    foreach(var ohlcData in ohlcResponse.Ohlc)
                    {
                        ohlcData.Pair = ohlcResponse.Pair;
                    }
                    masterData.AddRange(ohlcResponse.Ohlc);
                }

                var historicalDataList = new HistoricalDataList
                {
                    TimeStampStart = start,
                    TimeStampEnd = end,
                    Datasize = masterData.Count
                };

                var historicalDataItems = masterData.Select(o => new HistoricalDataItems
                {
                    TimeStamp = int.Parse(o.Timestamp),
                    Open = decimal.Parse(o.Open, CultureInfo.InvariantCulture),
                    High = decimal.Parse(o.High, CultureInfo.InvariantCulture),
                    Low = decimal.Parse(o.Low, CultureInfo.InvariantCulture),
                    Close = decimal.Parse(o.Close, CultureInfo.InvariantCulture),
                    Volume = decimal.Parse(o.Volume, CultureInfo.InvariantCulture),
                    List = historicalDataList
                });

                historicalDataList.DataSets = historicalDataItems.ToList();

                _context.HistoricalData.Add(historicalDataList);

                await _context.SaveChangesAsync();
            }
        }
    }
}
