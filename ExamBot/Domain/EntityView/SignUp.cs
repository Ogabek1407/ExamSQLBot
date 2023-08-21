namespace ExamBot.Domain.EntityView;

public class SignUp
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public long TelegramChatId { get; set; }
}