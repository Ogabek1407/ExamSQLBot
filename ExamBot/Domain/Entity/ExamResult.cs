using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;

namespace ExamBot.Domain.Entity;

[Table("exam_result")]
public class ExamResult:ModelBase
{
    [Column("ball")] public int ball { get; set; }
    [Column("client_Id")] public long clientId { get; set; }
    [NotMapped] public virtual Client client { get; set; }
    [Column("exam_id")] public long ExamId { get; set; }
    [NotMapped] public Exam Exam { get; set; }
    [Column("exam_questions")]
    public Message ExamQuestions { get; set; }
}