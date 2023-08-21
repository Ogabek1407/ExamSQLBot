using ExamBot.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamBot.Service.DataSource;

public class UserDataServise : DataServiceBase<User>
{
    public UserDataServise(DbContext dbContext) : base(dbContext)
    {
        
    }
}