using Questor.DAL.Models;
using Questor.DAL.Models.Enums;

namespace Questor.Services.Interfaces;

public interface IQuestionService
{
    public Task AddQuestion(string questionTitle, string linkToPhoto, int pointPerQuestion, QuestionType questionType, int questId);
    public Task DeleteQuestion(int questionId);
    public Task UpdateQuestion(int questionId, string questionTitle, string linkToPhoto, int pointPerQuestion, QuestionType questionType);
    public Task<Question> GetQuestionById(int questionId);
    public Task<List<Question>> GetQuestionsByQuestId(int questId);
 
}