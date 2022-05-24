using Questor.DAL.Models;

namespace Questor.Services.Interfaces;

public interface IAnswerService
{
    public Task AddAnswer(string value, int questionId, bool isCorrect);
    public Task DeleteAnswer(int answerId);
    public Task UpdateAnswer(int answerId, string value, bool isCorrect);
    public Task<Answer> GetAnswerById(int answerId);
    public Task<List<Answer>> GeAnswersByQuestionId(int Questionid);
}