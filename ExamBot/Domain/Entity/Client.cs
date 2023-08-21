using System.ComponentModel.DataAnnotations.Schema;
using ExamBot.Domain.Enum;

namespace ExamBot.Domain.Entity;

[Table("clients")]
public class Client:ModelBase
{
    [Column("role")] public Role role { get; set; }
    [Column("user_id")] public long UserId { get; set; }
    [Column("name")] public string Name { get; set; }
    [NotMapped] public virtual User User { get; set; }
    [NotMapped] public virtual List<ExamResult> ExamResults { get; set; }
    
}