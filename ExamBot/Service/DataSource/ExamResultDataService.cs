using ExamBot.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamBot.Service.DataSource;

public class ExamResultDataService : DataServiceBase<ExamResult>
{
    public ExamResultDataService(DbContext dbContext) : base(dbContext)
    {
    }
    
}