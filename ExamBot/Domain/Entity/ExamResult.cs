using System.ComponentModel.DataAnnotations.Schema;

namespace ExamBot.Domain.Entity;

public class ExamResult:ModelBase
{
    [Column("ball")] public int ball { get; set; }
    [Column("client_Id")] public long clientId { get; set; }
    [NotMapped] public virtual Client client { get; set; }
    [Column("exam_id")] public long ExamId { get; set; }
    [NotMapped] public Exam Exam { get; set; }
}