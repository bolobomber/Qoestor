using Microsoft.EntityFrameworkCore;
using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;

namespace Questor.DAL.Repositories;

public class QuestResultRepository : IQuestResoultRepository
{
    private readonly QuestorContext context;
    public QuestResultRepository(QuestorContext context)
    {
        this.context = context;
    }
    public async Task Add(QuestResult questResult)
    {
        await context.AddAsync(questResult);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int questResultId)
    {
        context.Remove(await context.QuestResults.FirstOrDefaultAsync(x => x.Id == questResultId));
        await context.SaveChangesAsync();
    }

    public async Task Update(QuestResult questResult)
    {
        context.QuestResults.Update(questResult);
        await context.SaveChangesAsync();
    }

    public async Task<QuestResult> GetQuestResultById(int questResultId)
    {
        return await context.QuestResults.FirstOrDefaultAsync(x => x.Id == questResultId);

    }

    public async Task<List<QuestResult>> GetQuestResultsByQuestId(int questId)
    {
        return await context.QuestResults.Where(x => x.QuestId == questId).ToListAsync();
    }

    public async Task<List<QuestResult>> GetQuestResultByUserId(string userId)
    {
        return await context.QuestResults.Where(x => x.UserId == userId).ToListAsync();
    }
}