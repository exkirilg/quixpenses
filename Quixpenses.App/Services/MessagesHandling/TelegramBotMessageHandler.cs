﻿using Telegram.Bot;
using Telegram.Bot.Types;
using Quixpenses.App.Exceptions;
using Quixpenses.App.Models;
using Quixpenses.App.Services.Users;

namespace Quixpenses.App.Services.MessagesHandling;

public class TelegramBotMessageHandler : ITelegramBotMessageHandler
{
    private readonly ILogger<TelegramBotMessageHandler> _logger;
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUsersServices _usersServices;

    public TelegramBotMessageHandler(
        ILogger<TelegramBotMessageHandler> logger,
        ITelegramBotClient telegramBotClient,
        IUsersServices usersServices)
    {
        _logger = logger;
        _telegramBotClient = telegramBotClient;
        _usersServices = usersServices;
    }

    public async Task HandleUpdateAsync(Update update)
    {
        _logger.LogInformation(
            "Handling update for chat {chatId}: {message}",
            update.Message?.Chat.Id,
            update.Message?.Text);

        if (!IncomingMessage.TryParse(update, out var incomingMessage))
        {
            throw new UnknownUpdateType();
        }

        if (incomingMessage.Text.StartsWith("/start"))
        {
            await HandleStartAsync(incomingMessage);
        }
    }

    private async Task HandleStartAsync(IncomingMessage message)
    {
        var isAuthorized = await _usersServices.IsAuthorizedAsync(message.ChatId);

        if (isAuthorized)
        {
            return;
        }

        isAuthorized = await _usersServices.TryAuthorizeUserAsync(message);

        if (isAuthorized)
        {
            await ReplyToMessageAsync(message, "Welcome to QuiXpenses!");
        }
        else
        {
            await ReplyToMessageAsync(message, "Sorry, there is problem with your invitation, please contact administration");
        }
    }

    private async Task ReplyToMessageAsync(IncomingMessage incomingMessage, string text)
    {
        await SendTextMessageAsync(incomingMessage.ChatId, text, incomingMessage.MessageId);
    }

    private async Task SendTextMessageAsync(long chatId, string text, int? replyToMessageId = null)
    {
        await _telegramBotClient.SendTextMessageAsync(chatId, text, replyToMessageId: replyToMessageId);
    }
}