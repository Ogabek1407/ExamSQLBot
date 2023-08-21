using ExamBot.Domain.Entity;
using ExamBot.Domain.EntityView;
using ExamBot.Domain.Enum;
using ExamBot.Service.DataSource;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using User = ExamBot.Domain.Entity.User;

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

    public async Task RegisterUser(SignUp signUp)
    {
        
        var insertedUser = await this._userDataServise.Create(new User()
        {
            Password = signUp.Password,
            Login = signUp.PhoneNumber,
            ClientId = signUp.TelegramChatId
        });
        
        if (insertedUser is null)
            throw new Exception("Unable to insert user");
       
        var client = new Client()
        {
            UserId = insertedUser.Id,
            role = Role.Student,
            Name = string.Empty,
        };

        var insertedClient = await this._clientDataServise.Create(client);
        
        if (insertedClient is null)
            throw new Exception("Unable to add new client");
        
    }

    public async Task<Client?> Login(SignUp user)
    {
        var userInfo = _userDataServise.GetAll()
            .FirstOrDefault(item => 
                item.Password == user.Password
                && item.Login == user.Login);
        
        
        if (userInfo is User)
        {
            await this._userDataServise.Update(userInfo);
            
            return userInfo.Client;
        }

        return null;
    }

   public async Task<long> LoginUrl(SignUp signUp)
   {
       var user=_userDataServise.GetAll().FirstOrDefault(x => x.Login == signUp.Login && x.Password == signUp.Password);
       if (user is not null)
           throw new Exception("user not fount");
       var client =_clientDataServise.GetAll().FirstOrDefault(x => x.UserId == user.Id);
       if (client is null)
           throw new Exception("client not fount");
       return client.Id;
   }
    
}