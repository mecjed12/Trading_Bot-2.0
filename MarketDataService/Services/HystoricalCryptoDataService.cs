using DataBase.DataContext;
using DataBase.DataContext.Tables;
using MarketDataService.Wrapper;
using NodaTime;
using QuantConnect;
using QuantConnect.Algorithm;
using QuantConnect.Algorithm.CSharp;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Securities;

namespace MarketDataService.Services
{
    public class HystoricalCryptoDataService : IHystoricalCryptoDataService
    {
        private readonly IQCAlgortythmeFactory _algorithm;
        private readonly DataBaseContext _context;

        public HystoricalCryptoDataService(IQCAlgortythmeFactory algorithm, DataBaseContext context)
        {
            _algorithm = algorithm;
            _context = context;
        }

        public async Task FetchAndSaveHistoricalData(string symbol, Resolution resolution, DateTime startDate, DateTime endDate)
        {
            var algorithm = _algorithm.CreateAlgorithm();
            var symbolObjet = Symbol.Create(symbol, SecurityType.Crypto, Market.Binance);

            var historyRequest = new HistoryRequest(
                startDate,
                endDate,
                typeof(TradeBar),
                symbolObjet,
                resolution,
                SecurityExchangeHours.AlwaysOpen(TimeZones.Utc),
                DateTimeZone.Utc,
                resolution,
                false,
                false,
                DataNormalizationMode.Adjusted,
                TickType.Trade
                );

            IEnumerable<Slice> historicalData = null;
            if (algorithm.HistoryProvider != null)
            {
                historicalData = algorithm.HistoryProvider.GetHistory(new[] { historyRequest }, TimeZones.Utc);
            }

            if (historicalData != null)
            {
                var cryptoDataList = new HystoriaclCryptoDataList
                {
                    TimeStampStart = startDate,
                    TimeStampEnd = endDate,
                    DataSize = historicalData.Count()
                };

                _context.HystoricalCryptoData.Add(cryptoDataList);

                foreach (var data in historicalData)
                {
                    var tradeBar = data.Values as TradeBar;
                    if (tradeBar != null)
                    {
                        var cryptoDataItem = new HystoricalCryptoDataItems
                        {
                            Volume = tradeBar.Volume,
                            Open = tradeBar.Open,
                            High = tradeBar.High,
                            Low = tradeBar.Low,
                            Endtime = tradeBar.EndTime,
                            Period = tradeBar.Period,
                            DataType = tradeBar.DataType,
                            IsFillForward = tradeBar.IsFillForward,
                            Time = tradeBar.Time,
                            Symbol = tradeBar.Symbol,
                            Value = tradeBar.Value,
                            Price = tradeBar.Price,
                            ListId = cryptoDataList.ListId
                        };

                        _context.HystoricalCryptoDataItems.Add(cryptoDataItem);
                    }
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("exceptin");
            }
        }
    }
}
