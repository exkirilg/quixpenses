using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models;

[Table("invites")]
public record Invite : IDbModel, IValidatableObject
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("available")]
    public ushort Available { get; set; }

    [Column("used")]
    public ushort Used { get; set; }

    [Column("expires_at")]
    public DateTime ExpiresAt { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Available < 1)
        {
            yield return new ValidationResult("Must be available for at least 1 use");
        }

        if (ExpiresAt <= DateTime.UtcNow)
        {
            yield return new ValidationResult("Already expired");
        }
    }
}