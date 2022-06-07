using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questor.DAL.Models;
using Questor.DAL.Models.ViewModels;
using Questor.Services.Interfaces;

namespace Questor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestResultController : ControllerBase
    {
        public readonly IQuestResultService questResultService;

        public QuestResultController(IQuestResultService questResultService)
        {
            this.questResultService = questResultService;
        }

        [HttpGet]
        public async Task<QuestResult> GetQuestResult(int id)
        {
            return await questResultService.GetQuestResultById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestResult([FromBody] QuestResultViewModel questResultViewModel)
        {
            await questResultService.AddQuestResult(questResultViewModel.UserId, questResultViewModel.QuestId, questResultViewModel.IsCompleted, questResultViewModel.TimeInQuest,questResultViewModel.Result,questResultViewModel.SentResultToEmail);
            //if sent to email == true sent user email with result зробити пізніше
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestResult(int id)
        {
            await questResultService.DeleteQuestResult(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestResult([FromBody] QuestResultViewModel questResultViewModel, int questResultId)
        {
            await questResultService.UpdateQuestResult(questResultId,questResultViewModel.IsCompleted,questResultViewModel.TimeInQuest,questResultViewModel.Result,questResultViewModel.SentResultToEmail);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("QuestsResultsForUser")]
        public async Task<List<QuestResult>> GetQuestResultsByUserId(string userId)
        {
            return await questResultService.GetQuestResultByUserId(userId);
        }

        [HttpGet("QuestsResultsForQuest")]
        public async Task<List<QuestResult>> GetQuestResultsByQuestId(int questId)
        {
            return await questResultService.GetQuestResultsByQuestId(questId);
        }
    }
}
