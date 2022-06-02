using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questor.DAL.Models;
using Questor.DAL.Models.Enums;
using Questor.Services.Interfaces;

namespace Questor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet]
        public async Task<Question> GetQuestion(int id)
        {
            return await questionService.GetQuestionById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(string questionTitle, string linkToPhoto, int pointPerQuestion, QuestionType questionType, int questId)
        {
            await questionService.AddQuestion(questionTitle, linkToPhoto, pointPerQuestion, questionType, questId);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            await questionService.DeleteQuestion(questionId);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(int questionId, string questionTitle, string linkToPhoto, int pointPerQuestion, QuestionType questionType, int questId)
        {
            await questionService.UpdateQuestion(questId, questionTitle, linkToPhoto, pointPerQuestion, questionType);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("QuestionsByQuestId")]
        public async Task<List<Question>> GetQuestionByQuestId(int questId)
        {
            return await questionService.GetQuestionsByQuestId(questId);
        }
    }
}
