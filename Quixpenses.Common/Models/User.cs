using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models;

[Table("users")]
public record User : IDbModel
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("is_authorized")]
    public bool IsAuthorized { get; set; }

    [Column("is_admin")]
    public bool IsAdmin { get; set; }

    public virtual UserSettings? Settings { get; set; }
}