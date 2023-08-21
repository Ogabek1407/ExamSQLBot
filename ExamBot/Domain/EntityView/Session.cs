using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExamBot.Domain.EntityView;

public class Session
{
    public long TelegramChatId { get; set; }
    public SignUp SignUp { get; set; }
    public long ClientId { get; set; }
    public string Controller { get; set; }
    public string Action { get; set; }
}