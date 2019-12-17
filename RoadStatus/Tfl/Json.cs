using System.IO;
using System.Text.Json;

namespace RoadStatus.Tfl
{
    public class Json
    {
        public const string TypePropertyElementName = "$type";

        public static string GetTypeProperty(JsonElement objectElement)
        {
            bool rootHasTypeProperty = objectElement.TryGetProperty(TypePropertyElementName, out var typeProperty);

            if (!rootHasTypeProperty)
            {
                throw new InvalidDataException($"No type property {TypePropertyElementName} was found in JSON response");
            }

            return typeProperty.GetString();
        }

        public static JsonElement GetObjectElement(JsonDocument jsonDocument)
        {
            JsonElement rootElement = jsonDocument.RootElement;

            JsonValueKind valueKind = rootElement.ValueKind;
            if (valueKind != JsonValueKind.Array)
            {
                return rootElement;
            }

            if (rootElement.GetArrayLength() != 0)
            {
                return rootElement[0];
            }

            throw new InvalidDataException("Empty JSON root element.");
        }
    }
}
