using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models.DbModels;

[Table("expenses")]
public record Expense : IDbModel
{
    [Key]
    [Column("id")]
    public Guid Id { get; init; }

    [Column("created_at")]
    public DateTime CreatedAt { get; init; }

    [Column("sum")]
    public int Sum { get; init; }

    public virtual User? User { get; init; }

    public virtual Currency? Currency { get; init; }

    public virtual Category? Category { get; init; }
}