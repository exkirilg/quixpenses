﻿using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Quixpenses.App.DatabaseAccess.DatabaseModels;

public record DbCurrency : IDbModel
{
    public string Id { get; set; } = default!;

    public ushort FractionDigits { get; set; }

    [UsedImplicitly]
    public DbCurrency()
    {
    }
}