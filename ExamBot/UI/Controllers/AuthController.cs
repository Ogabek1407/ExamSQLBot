using ExamBot.Service;
using ExamBot.UI.ContextExtension;
using ExamBot.UI.Managers;

namespace ExamBot.UI.Controllers;

public class AuthController:ControllerBase
{
    private readonly AuthServise _authServise;

    public AuthController(ControllerManager controllerManager , AuthServise authServise) 
        : base(controllerManager)
    {
        _authServise = authServise;
    }

    public override async Task UpdateHandle(Context context)
    {
        
    }

    public override async Task ActionHandle(Context context)
    {
        
    }

    public async Task RegistrationStart(Context context)
    {
        await context.SendTextMessage("Enter your phone number :", context.RequesPhoheNumberReplyKeyboardMarkup());
        context.Session.Action = nameof(RegistrationPhoneNumber);
    }

    public async Task RegistrationPhoneNumber(Context context)
    {
        var phoneNumber = context.Message?.Contact?.PhoneNumber;
        if (phoneNumber is null)
        {
            //await context.SendErrorMessage("Wrong phone number!", 400);
            return;
        }
        
        if (!phoneNumber.StartsWith("+"))
            phoneNumber = "+" + phoneNumber;
        
      //  context.Session.RegistrationModel.PhoneNumber = phoneNumber;
        await context.SendTextMessage("Please Enter your password: ");
        context.Session.Action = nameof(RegistrationPassword);
    }

    public async Task RegistrationPassword(Context context)
    {
        //context.Session.RegistrationModel.Password = context.Update.Message.Text;
        //context.Session.RegistrationModel.ChatId = context.Session.ChatId;

       // await _authService.RegisterUser(context.Session.RegistrationModel);

        //await context.SendBoldTextMessage("You Succesfully registired. Please re-sign in");

        context.Session.Controller = null;
        context.Session.Action = null;

        //await context.Forward(this._controllerManager);
    }
    
    
}