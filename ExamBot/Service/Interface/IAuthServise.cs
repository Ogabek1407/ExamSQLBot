using ExamBot.Domain;
using ExamBot.Domain.Entity;
using ExamBot.Domain.EntityView;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Interfaces;

public interface IAuthServise
{
    Task Registration(SignUp signUp);
    Task<Client> Login(SignUp signUp);

}