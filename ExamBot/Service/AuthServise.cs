using ExamBot.Domain.Entity;
using ExamBot.Domain.EntityView;
using ExamBot.Service.DataSource;
using Interfaces;

namespace ExamBot.Service;

public class AuthServise : IAUthServise
{
    private ClientDataServise _clientDataServise;
    private UserDataServise _userDataServise;

    public AuthServise(ClientDataServise clientDataServise, UserDataServise userDataServise)
    {
        _clientDataServise = clientDataServise;
        _userDataServise = userDataServise;
    }

    public  Task RegisterUser(SignUp signUp)
    {
        throw new NotImplementedException();
    }

    public Task<Client?> Login(SignUp user)
    {
        throw new NotImplementedException();
    }
}