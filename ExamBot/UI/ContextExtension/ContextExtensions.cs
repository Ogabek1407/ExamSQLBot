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
        ControllerBase baseController =  controllerManager.GetControllerBySessionData(context.Session);
        await baseController.Handle(context);
    }
    
    
    
   

    public static async Task SendTextMessage(this Context context, string text, IReplyMarkup? replyMarkup = null,
        ParseMode? parseMode = null)
    {
        //await Telegram..SendTextMessageAsync(context.Session.TelegramChatId, text, replyMarkup: replyMarkup,
          //  parseMode: parseMode);
    }
}

