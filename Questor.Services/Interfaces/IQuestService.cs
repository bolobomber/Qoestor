using Questor.DAL.Models;

namespace Questor.Services.Interfaces;

public interface IQuestService
{
    public Task AddQuest(string questName, string questDescription, bool isPublic, bool writeOffControleMode, int timeLimit, string userId);
    public Task DeleteQuest(int questId);
    public Task UpdateQuest(int questId, string questName, string questDescription, bool isPublic, bool writeOffControleMode, int timeLimit);
    public Task<Quest> GetQuestById(int questId);
    public Task<List<Quest>> GetQuestsByUserId(string userId);
    public Task<List<Quest>> GetAllPublicQuest();

}