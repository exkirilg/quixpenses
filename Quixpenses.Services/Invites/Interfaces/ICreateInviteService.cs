﻿using Quixpenses.Common.Models;

namespace Quixpenses.Services.Invites.Interfaces;

public interface ICreateInviteService
{
    Task<Invite> CreateInviteAsync(ushort numberOfUses, DateTime expiresAt);
}