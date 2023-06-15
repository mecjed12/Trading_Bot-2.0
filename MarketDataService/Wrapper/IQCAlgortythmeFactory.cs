using QuantConnect.Algorithm;

namespace MarketDataService.Wrapper
{
    public interface IQCAlgortythmeFactory
    {
        QCAlgorithm CreateAlgorithm();
    }
}
