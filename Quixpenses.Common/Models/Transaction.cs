using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models;

[Table("transactions")]
public record Transaction : IDbModel
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public virtual User? User { get; set; }

    public virtual Currency? Currency { get; set; }

    [Column("sum")]
    public int Sum { get; set; }
}