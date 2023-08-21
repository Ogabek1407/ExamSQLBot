using System.ComponentModel.DataAnnotations.Schema;

namespace ExamBot.Domain.Entity;

public class ModelBase
{
    [Column("id")]
    public long Id { get; set; }
}