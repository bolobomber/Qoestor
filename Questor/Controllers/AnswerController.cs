using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questor.DAL.Models;
using Questor.DAL.Models.ViewModels;
using Questor.Services.Interfaces;

namespace Questor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        public readonly IAnswerService answerService;

        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }
        [HttpGet]
        public async Task<Answer> GetAnswer(int id)
        {
            return await answerService.GetAnswerById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer([FromBody] AnswerViewModel answerViewModel)
        {
            await answerService.AddAnswer(answerViewModel.Value, answerViewModel.QuestionId, answerViewModel.IsCorrect);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            await answerService.DeleteAnswer(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnswer([FromBody] AnswerViewModel answerViewMode, int answerId)
        {
            await answerService.UpdateAnswer(answerId, answerViewMode.Value, answerViewMode.IsCorrect);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("AnswersByQuestionId")]
        public async Task<List<Answer>> GetAnswerByQuestionId(int questionId)
        {
            return await answerService.GeAnswersByQuestionId(questionId);
        }
    }
}
