using ExamBot.Configuration;
using ExamBot.Service;
using ExamBot.Service.DataContext;
using ExamBot.Service.DataSource;
using ExamBot.UI;
using ExamBot.UI.ContextExtension;
using ExamBot.UI.Controllers;
using ExamBot.UI.Managers;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace ExamBot;

public class TelegramBot
{
    private readonly ClientDataServise _clientDataService;


    public static TelegramBotClient _client { get; set; }

    private DataAppContext DataContext { get; set; }
    private SesionManager SessionManager { get; set; }
    
    private ControllerManager ControllerManager { get; set; }
    private List<Func<Context, CancellationToken, Task>> updateHandlers { get; set; }


    private UserDataServise userDataServise;
    private ClientDataServise _clientDataServise;
    private ExamDataService _examDataService;
    private ExamResultDataService _examResultDataService;


    private AuthServise _authService;
    public TelegramBot()
    {
        DataContext = new DataAppContext();
        _client = new TelegramBotClient(Settings.botToken);


         this.userDataServise = new UserDataServise(DataContext);
        this._clientDataService = new ClientDataServise(DataContext);
        this._examDataService = new ExamDataService(DataContext);
        this._examResultDataService = new ExamResultDataService(DataContext);

        _authService = new AuthServise(_clientDataService,userDataServise);
        ExamService examService = new ExamService(_examDataService,_examResultDataService);
        
        
        
        SessionManager = new SesionManager(userDataServise);

        ControllerManager =
            new ControllerManager(_authService, examService);
            

        updateHandlers = new List<Func<Context, CancellationToken, Task>>();
    }

    public async Task Start()
    {
        //Session handler
        this.updateHandlers.Add(async (context, token) =>
        {
            long? chatId = context.GetChatIdFromUpdate();
            
            if (chatId is null)
                throw new Exception("Chat id not found to find session");

            var session = await SessionManager.GetSessionByChatId(chatId.Value);
            context.Session = session;
            context.TerminateSession = async () => await this.SessionManager.TerminateSession(context.Session);
        });
        //Log handler
        this.updateHandlers.Add(async (context, token) =>
        {
            Console.WriteLine("Log -> {0} | {1} | {2}", DateTime.Now, context.Session.TelegramChatId,
                context.Update.Message?.Text ?? context.Update.Message?.Caption);
        });

       
        
        
        
    }
    
}