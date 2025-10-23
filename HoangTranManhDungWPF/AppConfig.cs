using Microsoft.Extensions.Configuration;
using System.IO;

namespace HoangTranManhDungWPF
{
    public static class AppConfig
    {
        private static IConfiguration _configuration;

        static AppConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static string GetAdminEmail()
        {
            return _configuration["AdminAccount:Email"];
        }

        public static string GetAdminPassword()
        {
            return _configuration["AdminAccount:Password"];
        }
    }
}