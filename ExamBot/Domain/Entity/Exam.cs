using System.ComponentModel.DataAnnotations.Schema;
using ExamBot.Domain.Enum;
using Telegram.Bot.Types;

namespace ExamBot.Domain.Entity;

public class Exam:ModelBase
{
    [Column("status")] public ExamStatus Status { get; set; }
    [Column("users")] public virtual List<Client> Clients { get; set; }
    [Column("start_time")] public DateTime Time { get; set; }
    [Column("max_ball")] public int MaxBall { get; set; }
    
}