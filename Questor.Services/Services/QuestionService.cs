using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;
using Questor.DAL.Models.Enums;
using Questor.Services.Interfaces;

namespace Questor.Services.Services;

public class QuestionService : IQuestionService
{
    public readonly IQuestionRepository questionRepository;

    public QuestionService(IQuestionRepository questionRepository)
    {
        this.questionRepository = questionRepository;
    }
    public async Task AddQuestion(string questionTitle, string linkToPhoto, int pointPerQuestion, QuestionType questionType, int questId)
    {
        var question = new Question()
        {
            Title = questionTitle,
            LinkTophoto = linkToPhoto,
            PointsPerQuestion = pointPerQuestion,
            QeustionType = questionType,
            QuestId = questId
        };
        await questionRepository.Add(question);
    }

    public async Task DeleteQuestion(int questionId)
    {
        await questionRepository.Delete(questionId);
    }

    public async Task UpdateQuestion(int questionId, string questionTitle, string linkToPhoto, int pointPerQuestion,
        QuestionType questionType)
    {
        var question = await questionRepository.GetQuestionById(questionId);

        question.Title = questionTitle;
        question.QeustionType = questionType;
        question.LinkTophoto = linkToPhoto;
        question.PointsPerQuestion =pointPerQuestion;


        await questionRepository.Update(question);

    }

    public async Task<Question> GetQuestionById(int questionId)
    {
        return await questionRepository.GetQuestionById(questionId);
    }

    public async Task<List<Question>> GetQuestionsByQuestId(int questId)
    {
        return await questionRepository.GetQuestionsByQuestId(questId);
    }
}