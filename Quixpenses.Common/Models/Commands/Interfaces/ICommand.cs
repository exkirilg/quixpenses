namespace Quixpenses.Common.Models.Commands.Interfaces;

public interface ICommand
{
    public string TypeName { get; }

    public string Name { get; }

    public string Description { get; }

    public int SettingsMessageId { get; set; }
}