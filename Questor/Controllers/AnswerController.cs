using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questor.DAL.Models;
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
        public async Task<IActionResult> AddAnswer(string value, int questionId, bool isCorrect)
        {
            await answerService.AddAnswer(value, questionId, isCorrect);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            await answerService.DeleteAnswer(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnswer(int answerId, string value, bool isCorrect)
        {
            await answerService.UpdateAnswer(answerId, value, isCorrect);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("AnswersByQuestionId")]
        public async Task<List<Answer>> GetAnswerByQuestionId(int questionId)
        {
            return await answerService.GeAnswersByQuestionId(questionId);
        }
    }
}
