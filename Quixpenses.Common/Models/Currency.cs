using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models;

[Table("currencies")]
public record Currency : IDbModel
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = default!;

    [Column("fraction_digits")]
    public ushort FractionDigits { get; set; }
}