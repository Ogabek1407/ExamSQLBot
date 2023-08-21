using ExamBot.Domain.EntityView;
using ExamBot.UI.Controllers;

namespace ExamBot.UI.Managers;

public class ControllerManager
{
    private readonly AuthController _authController;
    private readonly HomeController _homeController;
    private readonly ClientController _clientController;
    private readonly ExamController _examController;
    private readonly ExaminerController _examinerController;

    public ControllerManager()
    {
        _authController = new AuthController(this);
        _homeController = new HomeController(this);
        _clientController = new ClientController(this);
        _examController = new ExamController(this);
        _examinerController = new ExaminerController(this);
    }
    
    public ControllerBase GetControllerBySessionData(Session session)
    {
        switch (session.Controller)
        {
            case nameof(_authController):
                return _authController;
            case nameof(_clientController) :
                return _clientController;
            case    nameof(_examController):
                return _examController;
            case nameof(_examinerController):
                return _examinerController;
        }
        return default;
    }

    public ControllerBase DefaultController => _homeController;

}