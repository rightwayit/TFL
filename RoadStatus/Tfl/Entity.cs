namespace RoadStatus.Tfl
{
    public class Entity
    {
        public const string ApiErrorTypeName = "Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities";
        public const string RoadCorridorTypeName = "Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities";

        public static bool TypeNameIsRoadCorridor(string typeName)
        {
            return typeName == RoadCorridorTypeName;
        }

        public static bool TypeNameIsApiError(string typeName)
        {
            return typeName == ApiErrorTypeName;
        }
    }
}
