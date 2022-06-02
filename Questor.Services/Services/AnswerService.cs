using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;
using Questor.Services.Interfaces;

namespace Questor.Services.Services;

public class AnswerService : IAnswerService
{
    public readonly IAnswerRepository answerRepository;

    public AnswerService(IAnswerRepository answerRepository)
    {
        this.answerRepository = answerRepository;
    }
    public async Task AddAnswer(string value, int questionId, bool isCorrect)
    {
        var answer = new Answer()
        {
            Value = value,
            QuestionId = questionId,
            IsCorrect = isCorrect
        };

        await answerRepository.Add(answer);
    }

    public async Task DeleteAnswer(int answerId)
    {
        await answerRepository.Delete(answerId);
    }

    public async Task UpdateAnswer(int answerId, string value, bool isCorrect)
    {
        var answer = await answerRepository.GetAnswerById(answerId);
        answer.IsCorrect = isCorrect;
        answer.Value = value;
        await answerRepository.Update(answer);
    }

    public async Task<Answer> GetAnswerById(int answerId)
    {
        return await answerRepository.GetAnswerById(answerId);
    }

    public async Task<List<Answer>> GeAnswersByQuestionId(int Questionid)
    {
        return await answerRepository.GeAnswersByQuestionId(Questionid);
    }
}