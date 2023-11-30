using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.Common.Models;

[Table("users_settings")]
public class UserSettings : IDbModel
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    public virtual Currency? Currency { get; set; }
}