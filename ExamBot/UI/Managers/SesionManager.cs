using ExamBot.Domain.EntityView;
using ExamBot.Service.DataSource;

namespace ExamBot.UI.Managers;

public class SesionManager
{
    private readonly UserDataServise _userDataService;
    private List<Session> sessions = new List<Session>();

    public SesionManager(UserDataServise userDataService)
    {
        _userDataService = userDataService;
        
    }

    public async Task<Session> GetSessionByChatId(long chatId)
    {
        var lastSession = sessions.Find(x => x.TelegramChatId == chatId);
        if (lastSession is null)
        {
            var session = new Session()
            {
                Action = null,
                Controller = null,
                TelegramChatId = chatId
            };
            sessions.Add(session);
            return session;
        }

        return lastSession;
    }

    public async Task<Session> GetSessionByClientId(long clientId)
    {
        return  this.sessions.FirstOrDefault(x => x.ClientId == clientId);
    }

    public async Task TerminateSession(Session session)
    {
        this.sessions.Remove(session);
    }

}

