using System.ComponentModel.DataAnnotations.Schema;

namespace ExamBot.Domain.Entity;

[Table("user")]
public class User:ModelBase
{
    [Column("client_id")]
    public long? ClientId { get; set; }
    [NotMapped]
    public Client? Client { get; set; }
    [Column("login")]
    public string Login { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("telegram_chat_id")]
    public long  TelegramChatId { get; set; }
}