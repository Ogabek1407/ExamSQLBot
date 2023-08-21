using ExamBot.Domain.Entity;
using ExamBot.Domain.EntityView;

namespace Interfaces;

public interface IAUthServise
{
    Task RegisterUser(SignUp signUp);
    Task<Client?> Login(SignUp user);
    
    
}