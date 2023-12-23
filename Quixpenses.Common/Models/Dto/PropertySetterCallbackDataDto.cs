using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Quixpenses.Common.Models.Dto;

public record PropertySetterCallbackDataDto(
    [property: JsonPropertyName("h")] int SessionHashCode,
    [property: JsonPropertyName("n")] string PropertyName,
    [property: JsonPropertyName("v")] string PropertyValue)
{
    public string ToBase64()
    {
        var json = JsonSerializer.Serialize(this);
        var bytes = Encoding.UTF8.GetBytes(json);
        return Convert.ToBase64String(bytes);
    }

    public static PropertySetterCallbackDataDto? TryParseFromBase64(string source)
    {
        var bytes = Convert.FromBase64String(source);
        var json = Encoding.UTF8.GetString(bytes);
        return JsonSerializer.Deserialize<PropertySetterCallbackDataDto>(json);
    }
}