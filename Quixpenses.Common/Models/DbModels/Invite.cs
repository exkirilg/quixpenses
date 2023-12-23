using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models.DbModels;

[Table("invites")]
public record Invite : IDbModel
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
}