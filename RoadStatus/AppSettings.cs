namespace RoadStatus
{
    public class AppSettings
    {
        public string GetAppId()
        {
            string appId = AppConfigFile.AppSetting.Get("your_app_id");
            return appId;
        }

        public string GetDeveloperKey()
        {
            string developerKey = AppConfigFile.AppSetting.Get("your_developer_key");
            return developerKey;
        }
    }
}

