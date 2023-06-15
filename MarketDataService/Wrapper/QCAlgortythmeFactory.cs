using MarketDataService.Services;
using MathNet.Numerics.LinearAlgebra;
using QLNet;
using QuantConnect.Algorithm;

namespace MarketDataService.Wrapper
{
    public class QCAlgortythmeFactory : IQCAlgortythmeFactory
    {
        public QCAlgorithm CreateAlgorithm()
        {
            string dataDirectory = "\"C:\\Users\\aco podgorac\\source\\Data\\market-hours\\market-hours-database.json\"";
            QuantConnect.Configuration.Config.Set("data-directory", dataDirectory);
            var algorithm = new QCAlgorithm();

            return algorithm;

        }
    }
}