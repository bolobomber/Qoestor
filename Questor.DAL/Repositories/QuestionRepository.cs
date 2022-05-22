using Microsoft.EntityFrameworkCore;
using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;

namespace Questor.DAL.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuestorContext context;
    public QuestionRepository(QuestorContext context)
    {
        this.context = context;
    }
    public async Task Add(Question question)
    {
        await context.AddAsync(question);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        context.Remove(await context.Questions.FirstOrDefaultAsync(x => x.Id == id));
        await context.SaveChangesAsync();
    }

    public async Task Update(Question question)
    {
        context.Questions.Update(question);
        await context.SaveChangesAsync();
    }

    public async Task<Question> GetQuestionById(int id)
    {
       return await context.Questions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Question>> GetQuestsByQuestId(int id)
    {
        return await context.Questions.Where(x => x.QuestId == id).ToListAsync();
    }
}