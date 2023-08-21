using ExamBot.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamBot.Service.DataSource;

public class ExamDataService : DataServiceBase<Exam>
{
    public ExamDataService(DbContext dbContext) : base(dbContext)
    {
    }
}