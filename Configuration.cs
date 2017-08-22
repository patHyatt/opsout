using System.Configuration;

namespace opsout
{
    public class Configuration
    {
        private static string CONFIG_URL = "bamboo.url";
        private static string CONFIG_USER = "bamboo.user";
        private static string CONFIG_PASSWORD = "bamboo.password";

        public Configuration()
        {
            this.Url = ConfigurationManager.AppSettings[CONFIG_URL];
            this.User = ConfigurationManager.AppSettings[CONFIG_USER];
            this.Password = ConfigurationManager.AppSettings[CONFIG_PASSWORD];
        }


        public bool IsValid()
        {
            return IsConfigured(Url) && IsConfigured(User) && IsConfigured(Password);

        }

        private bool IsConfigured(string value)
        {
            return !string.IsNullOrEmpty(value);
        }


        public string Url { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
