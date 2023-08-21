using ExamBot.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamBot.Service.DataSource;

public class ClientDataServise : DataServiceBase<Client>
{
    public ClientDataServise(DbContext dbContext) : base(dbContext)
    {
        
    }
    
}