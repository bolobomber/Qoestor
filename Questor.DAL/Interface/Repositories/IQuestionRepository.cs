using Questor.DAL.Models;

namespace Questor.DAL.Interface.Repositories;

public interface IQuestionRepository
{
    public Task Add(Question question);
    public Task Delete(int id);
    public Task Update(Question question);
    public Task<Question> GetQuestionById(int id);
    public Task<List<Question>> GetQuestsByQuestId(int id);
   
}