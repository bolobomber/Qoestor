using Questor.DAL.Models;

namespace Questor.DAL.Interface.Repositories;

public interface IQuestResoultRepository
{  
    public Task<int> Add(QuestResult questResult);
    public Task Delete(int questResultId);
    public Task Update(QuestResult questResult);
    public Task<QuestResult> GetQuestResultById(int questResultId);
    public Task<List<QuestResult>> GetQuestResultsByQuestId(int questId);
    public Task<List<QuestResult>> GetQuestResultByUserId(string userId);
}