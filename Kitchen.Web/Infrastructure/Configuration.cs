using System;
using System.Configuration;

namespace Kitchen.Web.Infrastructure
{
    public static class Configuration
    {
        // TODO: Extract this. Not place in web.config
        public static string EmailAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailAddress"];
            }
        }
        // TODO: Extract this. Not place in web.config
        public static string Phone
        {
            get
            {
                return ConfigurationManager.AppSettings["Phone"];
            }
        }
    }
}