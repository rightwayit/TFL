using System;
using System.Text;

namespace RoadStatus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!RoadIdWasPassed(args))
            {
                new DotNetConsole().WriteLine("Please supply a road id (for example: 'RoadStatus.exe a2')");
                return;
            }

            var roadId = args[0];
            
            var appId = string.Empty;
            var developerKey = string.Empty;

            if (ThreeArgumentsWerePassed(args))
            {
                appId = args[1];
                developerKey = args[2];
            }
            else
            {
                appId = AppConfigFile.AppSetting.AppId;
                developerKey = AppConfigFile.AppSetting.DeveloperKey;

                if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(developerKey))
                {
                    new DotNetConsole().WriteLine("Please add your app id and developer key to the command line (for example: 'RoadStatus.exe A2 169944f3 87472398b7d46b584812c602a452d97d') and developer key to appSettings in the App.config or ");
                }
            }

            new Application().Run(roadId, appId, developerKey);        
        }

        private static bool RoadIdWasPassed(string[] args)
        {
            return args != null && args.Length >= 1 && !string.IsNullOrWhiteSpace(args[0]);
        }

        private static bool ThreeArgumentsWerePassed(string[] args)
        {
            return args.Length == 3 && !string.IsNullOrWhiteSpace(args[2]);
        }
    }
}
