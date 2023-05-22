namespace AuthenticationService.Helper
{
    public interface IAppSettings
    {
        string Secret { get; set; }
        string HistoricalDataFolderPath { get; set; }
    }
}
