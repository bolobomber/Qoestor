using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questor.DAL.auth;
using Questor.DAL.Models;
using Questor.DAL.Models.Enums;
using Questor.DAL.Models.ViewModels;
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
        public async Task<IActionResult> AddQuestion([FromBody] QuestionViewModel questionViewModel)
        {
            var a = await questionService.AddQuestion(questionViewModel.Title, questionViewModel.LinkToPhoto,questionViewModel.PointPerQuestion, questionViewModel.QeustionType, questionViewModel.QuestId);
            return Ok(new Response { Status = "Success", Message = $"{a}" }); ;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            await questionService.DeleteQuestion(questionId);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestion([FromBody] QuestionViewModel questionViewModel, int questionId)
        {
            await questionService.UpdateQuestion(questionId, questionViewModel.Title,questionViewModel.LinkToPhoto, questionViewModel.PointPerQuestion, questionViewModel.QeustionType);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("QuestionsByQuestId")]
        public async Task<List<Question>> GetQuestionByQuestId(int questId)
        {
            return await questionService.GetQuestionsByQuestId(questId);
        }
    }
}
