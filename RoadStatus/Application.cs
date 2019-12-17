using Tfl.Api.Presentation.Entities;

namespace RoadStatus
{
    public class Application
    {
        IConsole Console { get; set; }

        public Application(IConsole console = null)
        {
            Console = console ?? new DotNetConsole();
        }

        public void Run(string roadId, string appId, string developerKey)
        {
            var appRanOk = false;
            var result = GetRoadCorridor(roadId, appId, developerKey);

            var isRoadCorridor = result is RoadCorridor;
            if (result != null && result is RoadCorridor)
            {
                ShowRoadCorridor(result as RoadCorridor);
            }
            else
            {
                ShowApiError(roadId);
            }

            Pause();
            Environment.Exit(appRanOk);
        }

        private void Pause()
        {
            Console.Pause();
        }

        private static object GetRoadCorridor(string roadId, string appId, string developerKey)
        {
            var result = Tfl.Api.GetRoadCorridor(roadId, appId, developerKey);
            return result;
        }

        private void ShowRoadCorridor(RoadCorridor result)
        {
            Console.Write(result as RoadCorridor);
        }

        private void ShowApiError(string roadId)
        {
            Console.WriteNotValid(roadId);
        }
    }
}
