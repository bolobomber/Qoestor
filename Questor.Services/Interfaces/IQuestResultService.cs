using Questor.DAL.Models;

namespace Questor.Services.Interfaces;

public interface IQuestResultService
{
    public Task AddQuestResult(int userId,int questId, bool isCompleted, string TimeInQuest, int result, bool sentResultToEmail);
    public Task DeleteQuestResult(int questResultId);
    public Task UpdateQuestResult(int questResultId, bool isCompleted, string TimeInQuest, int result, bool sentResultToEmail);
    public Task<QuestResult> GetQuestResultById(int questResultId);
    public Task<List<QuestResult>> GetQuestResultsByQuestId(int questId);
    public Task<List<QuestResult>> GetQuestResultByUserId(int userId);
}

