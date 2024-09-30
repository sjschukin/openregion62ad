using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace OpenRegion62Ad.Serialization;

internal class ApplicationJsonSerializerOptions
{
    public static JsonSerializerOptions Custom
    {
        get
        {
            var options = new JsonSerializerOptions(JsonSerializerOptions.Default)
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            options.Converters.Add(new JsonDateTimeConverter());

            return options;
        }
    }
}
