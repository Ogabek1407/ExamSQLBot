using System.ComponentModel.DataAnnotations.Schema;

namespace ExamBot.Domain.Entity;

public class User:ModelBase
{
    [Column("client_id")]
    public long? ClientId { get; set; }
    [NotMapped]
    public Client? Client { get; set; }
    
    public string Login { get; set; }
    public string Password { get; set; }
    public long  TelegramChatId { get; set; }
}