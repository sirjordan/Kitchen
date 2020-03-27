using Microsoft.Extensions.Configuration;
using System.IO;

namespace Kitchen.Web
{
    public static class ConfigurationManager
    {
        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public static IConfiguration Configuration { get; }

        public class Settings
        {
            public const string DataBindDateTimeFormat = "{0:dd.M.yyyy г. H:mm}";

            public static bool Develop => bool.Parse(Configuration["Settings:Develop"]);
        }
    }
}
