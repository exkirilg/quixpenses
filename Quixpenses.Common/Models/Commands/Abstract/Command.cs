using System.Text.Json.Serialization;
using Quixpenses.Common.Models.Commands.Interfaces;

namespace Quixpenses.Common.Models.Commands.Abstract;

public abstract record Command : ICommand
{
    [JsonIgnore]
    public virtual string TypeName => throw new NotImplementedException();

    [JsonIgnore]
    public virtual string Name => throw new NotImplementedException();

    [JsonIgnore]
    public virtual string Description => string.Empty;

    [JsonPropertyName("settingsMessageId")]
    public int SettingsMessageId { get; set; }

    [JsonIgnore]
    public virtual bool IsFilled => true;

    public void TrySetPropertyValue(string propertyName, string propertyValue)
    {
        var propertyInfo = GetType().GetProperty(propertyName);

        if (propertyInfo is null)
        {
            return;
        }

        try
        {
            var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            var newValue = Convert.ChangeType(propertyValue, type);
            propertyInfo.SetValue(this, newValue);
        }
        catch
        {
            // ignore
        }
    }
}