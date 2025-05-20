namespace FinanceManager.Domain.Configurations
{
    public class AppConfiguration
    {
        public bool BehindSSLProxy { get; set; }

        public string ProxyIP { get; set; }

        public string ApplicationUrl { get; set; }
    }
}