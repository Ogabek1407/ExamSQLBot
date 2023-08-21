using System.ComponentModel.DataAnnotations.Schema;
using ExamBot.Domain.Enum;
using Telegram.Bot.Types;

namespace ExamBot.Domain.Entity;

[Table("exams")]
public class Exam:ModelBase
{
    [Column("status")] public ExamStatus Status { get; set; }
    [Column("start_time")] public DateTime Time { get; set; }
    [Column("end_time")] public DateTime EndTime { get; set; }
    [Column("max_ball")] public int MaxBall { get; set; }

    [Column("exam_content")]
    public Message ExamContent { get; set; }
    [NotMapped]
    public List<ExamResult> ExamResults { get; set; }
   
    
}