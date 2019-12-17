using Tfl.Api.Presentation.Entities;

namespace RoadStatus
{
    public interface IConsole
    {
        void Write(RoadCorridor roadCorridor);
        void WriteNotValid(string roadId);
        void Pause();
    }
}
