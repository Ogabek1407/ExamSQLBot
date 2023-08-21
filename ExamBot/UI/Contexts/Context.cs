using ExamBot.Domain.EntityView;
using Telegram.Bot.Types;

namespace ExamBot.UI;

public class Context:ContextBase
{

    public Func<Task> TerminateSession { get; set; }
    public Session Session { get; set; }
}