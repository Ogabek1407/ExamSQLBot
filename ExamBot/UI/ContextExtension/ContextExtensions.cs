using ExamBot.UI.Controllers;
using ExamBot.UI.Managers;
using Telegram.Bot;
using Telegram.Bot.Types;
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
    
    
    public static ReplyKeyboardMarkup MakeDefaultReplyKeyboardMarkup(params KeyboardButton[] buttons)
    {
        return new ReplyKeyboardMarkup(buttons)
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };
    }
    
    public static ReplyKeyboardMarkup RequesPhoheNumberReplyKeyboardMarkup(this Context contexg)
        => MakeDefaultReplyKeyboardMarkup(new KeyboardButton("Send my phone number") { RequestContact = true });

   
    public static async Task<Message?> SendErrorMessage(this Context context, string text = null, int code = 404)
    {
        string codeText = code switch { 400 => "400", 401 => "401",500 => "500",_ => "404" };
        return null;
        // return await context.SendTextMessage( $"<b><code>{codeText} {text ?? "Not found!"}</code></b>");
    }

    public static async Task SendTextMessage(this Context context, string text, IReplyMarkup? replyMarkup = null,
        ParseMode? parseMode = null)
    {
        await TelegramBot._client.SendTextMessageAsync(context.Session.TelegramChatId, text, replyMarkup: replyMarkup,
            parseMode: parseMode);
    }
    
    
    
    public static long? GetChatIdFromUpdate(this Context context)
    {
        var update = context.Update;
        return update.Type switch
        {
            UpdateType.Message => update.Message?.Chat.Id,
            UpdateType.CallbackQuery => update.CallbackQuery?.From.Id,
            UpdateType.EditedMessage => update.EditedMessage?.Chat.Id,
            UpdateType.InlineQuery => update.InlineQuery?.From.Id,
            UpdateType.ChosenInlineResult => update.ChosenInlineResult?.From.Id,
            _ => null
        };
    }
}

