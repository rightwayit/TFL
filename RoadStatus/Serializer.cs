using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Tfl.Api.Presentation.Entities;


namespace RoadStatus
{
    public class Serializer
    {
        public static DataContractJsonSerializer Create<T>()
        {
            return new DataContractJsonSerializer(typeof(T));
        }

        public RoadCorridor ToRoadCorridor(string json)
        {
            DataContractJsonSerializer dataContractJsonSerializer = Serializer.Create<RoadCorridor>();
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var roadCorridor = (RoadCorridor)dataContractJsonSerializer.ReadObject(memoryStream);
            return roadCorridor;
        }
    }
}
