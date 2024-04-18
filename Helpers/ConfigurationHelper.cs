using Microsoft.Extensions.Configuration;

namespace cat.itb.M6UF3EA1.Helpers
{
    public static class ConfigurationHelper
    {
        const string ConfPath = "appsettings.json";
        const string URLDataName = "MongoURL";
        const string DBDataName = "DB";
        const string CollectionDataName = "Collection";
        public static string GetDBUrl()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(ConfPath, optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString(URLDataName);
        }
        public static string GetDB()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(ConfPath, optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString(DBDataName);
        }
        public static string GetCollection()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(ConfPath, optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString(CollectionDataName);
        }
    }
}
