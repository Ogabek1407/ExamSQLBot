using ExamBot.UI.Managers;

namespace ExamBot.UI.Controllers;

public class HomeController:ControllerBase
{
    public HomeController(ControllerManager controllerManager) : base(controllerManager)
    {
    }

    public override async Task UpdateHandle(Context context)
    {
        throw new NotImplementedException();
    }

    public override async Task ActionHandle(Context context)
    {
        throw new NotImplementedException();
    }
}