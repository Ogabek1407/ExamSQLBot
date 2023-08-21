using ExamBot.Domain.Enum;
using ExamBot.Service.DataSource;
using Interfaces;

namespace ExamBot.Service;

public class ExamService : IExamService
{
    private readonly ExamDataService _examDataService;

    public ExamService(ExamDataService examDataService)
    {
        _examDataService = examDataService;
    }


    public async Task ExamTime()
    {
        foreach (var exams in _examDataService.GetAll().Result)
        {
            if (exams.Time > DateTime.Now)
                exams.Status = ExamStatus.NoStarted;
            if (exams.Time <= DateTime.Now && exams.EndTime > DateTime.Now)
                exams.Status = ExamStatus.Started;
            else
                exams.Status = ExamStatus.Finished;

        }
        
    }
}