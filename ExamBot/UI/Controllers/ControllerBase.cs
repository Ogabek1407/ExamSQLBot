using ExamBot.UI.Managers;

namespace ExamBot.UI.Controllers;

public abstract class ControllerBase
{
    private readonly ControllerManager _controllerManager;

    public ControllerBase(ControllerManager controllerManager)
    {
        _controllerManager = controllerManager;
    }


    public async Task Handle(Context context)
    {
        await UpdateHandle(context);
        await ActionHandle(context);
    }


    public abstract Task UpdateHandle(Context context);

    public abstract Task ActionHandle(Context context);

}