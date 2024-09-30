using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenRegion62Ad.Serialization;

internal class JsonDateTimeConverter : JsonConverter<DateTime?>
{
    private const string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        return DateTime.ParseExact(value, DATETIME_FORMAT, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString(DATETIME_FORMAT, CultureInfo.InvariantCulture));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
