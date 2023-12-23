using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models;

[Table("categories")]
public record Category : IDbModel
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }

    public virtual User? User { get; set; }
}