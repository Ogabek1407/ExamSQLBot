using Telegram.Bot.Types;

namespace ExamBot.UI;

public class ContextBase
{
    public Update Update { get; set; }
    public Message Message => Update?.Message;
}