using System.IO;
using Tfl.Api.Presentation.Entities;
using System.Text.Json;
using System;
using System.Diagnostics;

namespace RoadStatus.Tfl
{
    public partial class Api
    {
        public const string Url = "https://api.tfl.gov.uk/Road/{0}?app_id={1}&app_key={2}";
        
        public static object GetRoadCorridor(string roadId, string appId, string developerKey)
        {
            var url = string.Format(Url, roadId, appId, developerKey);

            var json = WebClient.GetRoadStatus(url, roadId, appId, developerKey);

            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            var jsonDocument = JsonDocument.Parse(json);

            try
            {
                jsonDocument = JsonDocument.Parse(json);
            }
            catch (Exception ex) 
            {
                Debugger.Break();
            }


            var payloadElement = Json.GetObjectElement(jsonDocument);
            var typeName = Json.GetTypeProperty(payloadElement);

            if (Entity.TypeNameIsRoadCorridor(typeName))
            {
                return GetRoadCorridor(payloadElement);
            }

            throw new InvalidDataException($"Unexpected type: {typeName} found in JSON response");
        }

        private static RoadCorridor GetRoadCorridor(JsonElement objectElement)
        {
            string json = objectElement.GetRawText();
            return new Serializer().ToRoadCorridor(json);
        }
    }
}
