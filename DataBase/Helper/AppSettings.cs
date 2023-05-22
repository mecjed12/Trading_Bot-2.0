namespace AuthenticationService.Helper
{
    public class AppSettings : IAppSettings
    {
        public string Secret { get; set; }

        public string HistoricalDataFolderPath { get; set; }
    }
}
