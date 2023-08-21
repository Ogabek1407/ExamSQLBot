using ExamBot.Domain.Enum;
using ExamBot.Service.DataSource;
using Interfaces;

namespace ExamBot.Service;

public class ExamService : IExamService
{
    public readonly ExamDataService _examDataService;
    public readonly ExamResultDataService _examResultDataService;

    public ExamService(ExamDataService examDataService,ExamResultDataService examResultDataService)
    {
        _examDataService = examDataService;
        _examResultDataService = examResultDataService;
    }


    public async Task ExamTime()
    {
        foreach (var exams in _examDataService.GetAll())
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