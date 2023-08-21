using System.ComponentModel.DataAnnotations.Schema;
using ExamBot.Domain.Enum;

namespace ExamBot.Domain.Entity;

public class Client:ModelBase
{
    [Column("role")] public Role role { get; set; }
    [Column("user_id")] public long UserId { get; set; }
    [NotMapped] public virtual User User { get; set; }
    [NotMapped] public virtual List<Exam> Exams { get; set; }
    
}