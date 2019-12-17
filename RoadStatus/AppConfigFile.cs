using System.Collections.Specialized;
using System.Configuration;

namespace RoadStatus
{
    public class AppConfigFile
    {
        public struct AppSetting
        {
            public static readonly NameValueCollection AppSettings = ConfigurationManager.AppSettings;
            
            public struct Key
            {
                public const string AppId = "your_app_id";
                public const string DeveloperKey = "your_developer_key";
            }

            public static string AppId => Get(Key.AppId);
            public static string DeveloperKey => Get(Key.DeveloperKey);

            public static string Get(string key)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new System.NullReferenceException("Null or whitespace key in AppConfigFile.Get()");
                }

                string @value = AppSettings.Get(key);

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.NullReferenceException($"AppConfigFile.Get({key}) retrieved null or whitespace value from app.config in ");
                }

                return value;
            }
        }
    }
}

