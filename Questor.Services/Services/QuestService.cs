using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;
using Questor.Services.Interfaces;

namespace Questor.Services.Services;

public class QuestService : IQuestService
{
    private readonly IQuestRepository questRepository;

    public QuestService(IQuestRepository questRepository)
    {
        this.questRepository = questRepository;
    }
    public async Task AddQuest(string questName, string questDescription, bool isPublic, bool writeOffControleMode, int timeLimit,
        int userId)
    {
        var quest = new Quest()
        {
            Name = questName,
            Description = questDescription,
            IsPublic = isPublic,
            WriteOffControlMode = writeOffControleMode,
            TimeLimit = timeLimit,
            UserId = userId
        };
        await questRepository.Add(quest);
    }

    public async Task DeleteQuest(int questId)
    {
        await questRepository.Delete(questId);
    }

    public async Task UpdateQuest(int questId, string questName, string questDescription, bool isPublic, bool writeOffControleMode,
        int timeLimit)
    {

        var quest = await questRepository.GetQuestById(questId);

        quest.Name = questName;
        quest.Description = questDescription;
        quest.IsPublic = isPublic;
        quest.WriteOffControlMode = writeOffControleMode;
        quest.TimeLimit = timeLimit;

        await questRepository.Update(quest);
    }

    public async Task<Quest> GetQuestById(int questId)
    {
        return await questRepository.GetQuestById(questId);
    }

    public async Task<List<Quest>> GetQuestsByUserId(int userId)
    {
        return await questRepository.GetQuestsByUserId(userId);

    }

    public async Task<List<Quest>> GetAllPublicQuest()
    {
        return await questRepository.GetAllPublicQuest();
    }
}