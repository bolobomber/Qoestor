using Questor.DAL.Models;

namespace Questor.DAL.Interface.Repositories;

public interface IAnswerRepository
{
    public Task Add(Answer answer);
    public Task Delete(int id);
    public Task Update(Answer answer);
    public Task<Answer> GetAnswerById(int id);
    public Task<List<Answer>> GeAnswersByQuestionId(int id);
}