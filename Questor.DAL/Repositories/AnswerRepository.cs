using Microsoft.EntityFrameworkCore;
using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;

namespace Questor.DAL.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly QuestorContext context;
    public AnswerRepository(QuestorContext context)
    {
        this.context = context;
    }
    public async Task<int> Add(Answer answer)
    {
        await context.AddAsync(answer);
        await context.SaveChangesAsync();
        return answer.Id;
    }

    public async Task Delete(int id)
    {
        context.Remove(await context.Answers.FirstOrDefaultAsync(x => x.Id == id));
        await context.SaveChangesAsync();
    }

    public async Task Update(Answer answer)
    {
        context.Update(answer);
        await context.SaveChangesAsync();
    }

    public async Task<Answer> GetAnswerById(int id)
    {
        return await context.Answers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Answer>> GeAnswersByQuestionId(int id)
    {
        return await context.Answers.Where(x => x.QuestionId == id).ToListAsync();
    }
}