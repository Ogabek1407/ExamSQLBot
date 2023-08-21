using ExamBot.UI.Controllers;
using ExamBot.UI.Managers;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamBot.UI.ContextExtension;

public static class ContextExtensions
{
    public static async Task Forward(this Context context,ControllerManager controllerManager)
    {
        ControllerBase baseController =  controllerManager.GetControllerBySessionData(context.Sesion);
        await baseController.Handle(context);
    }
    
    
    
   

    public static async Task SendTextMessage(this Context context, string text, IReplyMarkup? replyMarkup = null,
        ParseMode? parseMode = null)
    {
        await TelegramBot.BotClient.SendTextMessageAsync(context.Sesion.TelegramChatId, text, replyMarkup: replyMarkup,
            parseMode: parseMode);
    }
}

