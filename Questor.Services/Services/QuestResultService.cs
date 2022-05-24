using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;
using Questor.Services.Interfaces;

namespace Questor.Services.Services;

public class QuestResultService : IQuestResultService
{
    public readonly IQuestResoultRepository questResoultRepository;

    public QuestResultService(IQuestResoultRepository questResoultRepository)
    {
        this.questResoultRepository = questResoultRepository;
    }

    public async Task AddQuestResult(int userId, int questId, bool isCompleted, string TimeInQuest, int result, bool sentResultToEmail)
    {
        var questResult = new QuestResult()
        {
            UserId = userId,
            QuestId = questId,
            IsCompleted = isCompleted,
            TimeInQuest = TimeInQuest,
            Result = result,
            SentResultToEmail = sentResultToEmail
        };
        await questResoultRepository.Add(questResult);
    }

    public async Task DeleteQuestResult(int questResultId)
    {
        await questResoultRepository.Delete(questResultId);
    }

    public async Task UpdateQuestResult(int questResultId, bool isCompleted, string TimeInQuest, int result, bool sentResultToEmail)
    {
        var questResult = await questResoultRepository.GetQuestResultById(questResultId);

        questResult.Result = result;
        questResult.IsCompleted = isCompleted;
        questResult.TimeInQuest = TimeInQuest;
        questResult.SentResultToEmail = sentResultToEmail;

        await questResoultRepository.Update(questResult);
    }

    public async Task<QuestResult> GetQuestResultById(int questResultId)
    {
        return await questResoultRepository.GetQuestResultById(questResultId);
    }

    public async Task<List<QuestResult>> GetQuestResultsByQuestId(int questId)
    {
        return await questResoultRepository.GetQuestResultsByQuestId(questId);
    }

    public async Task<List<QuestResult>> GetQuestResultByUserId(int userId)
    {
        return await questResoultRepository.GetQuestResultByUserId(userId);
    }
}