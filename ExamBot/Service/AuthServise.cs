using ExamBot.Domain.Entity;
using ExamBot.Domain.EntityView;
using ExamBot.Service.DataSource;

namespace ExamBot.Service;

public class AuthServise
{
    private UserDataServise _userDataServise;
    private ClientDataServise _clientDataServise;
    

    public AuthServise(UserDataServise userDataService, ClientDataServise clientDataService)
    {
        this._userDataServise = userDataService;
        this._clientDataServise = clientDataService;
    }
    // public async Task RegisterUser(SignUp signUp)
    // {
    //
    //     var oldUser  = await this._userDataServise.GetAll()
    //         .FirstOrDefaultAsync(x => x.PhoneNumber == userRegistration.PhoneNumber);
    //
    //     if (oldUser is User)
    //         throw new Exception("User already exists");
    //     
    //     var insertedUser = await this._userDataService.AddAsync(new User()
    //     {
    //         Password = userRegistration.Password,
    //         PhoneNumber = userRegistration.PhoneNumber,
    //         TelegramClientId = userRegistration.ChatId
    //     });
    //     
    //     if (insertedUser is null)
    //         throw new Exception("Unable to insert user");
    //     var client = new Client()
    //     {
    //         UserId = insertedUser.Id, // Updated line
    //         Status = ClientStatus.Enabled,
    //         IsPremium = false,
    //         UserName = string.Empty,
    //         Nickname = string.Empty
    //     };
    //
    //     var insertedClient = await this._clientDataService.AddAsync(client);
    //
    //     if (insertedClient is null)
    //         throw new Exception("Unable to add new client");
    // }
    //
    // public async Task<Client?> Login(UserLoginModel user)
    // {
    //     var userInfo = _userDataService.GetAll()
    //         .FirstOrDefault(item => 
    //             item.Password == user.Password
    //             && item.PhoneNumber == user.Login);
    //
    //     // if (userInfo is null)
    //     //     throw new Exception("User not found");
    //     
    //     if (userInfo is User)
    //     {
    //         userInfo.Signed = true;
    //         userInfo.LastLoginDate = DateTime.Now;
    //
    //         await _userDataService.UpdateAsync(userInfo);
    //         
    //         return userInfo.Client;
    //     }
    //
    //     return null;
    // }
    //
    // public async Task Logout(long userId)
    // {
    //     var user = await _userDataService.GetByIdAsync(userId);
    //     if (user is null)
    //         throw new Exception("User not found");
    //
    //     user.Signed = false;
    //     await _userDataService.UpdateAsync(user);
    // }
}