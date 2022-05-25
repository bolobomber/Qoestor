using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questor.DAL.Models;
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
        public async Task<IActionResult> AddQuestResult(int userId, int questId, bool isCompleted, string TimeInQuest, int result, bool sentResultToEmail)
        {
            await questResultService.AddQuestResult(userId, questId, isCompleted, TimeInQuest, result, sentResultToEmail);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestResult(int id)
        {
            await questResultService.DeleteQuestResult(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestResult(int questResultId, bool isCompleted, string TimeInQuest, int result, bool sentResultToEmail)
        {
            await questResultService.UpdateQuestResult(questResultId, isCompleted, TimeInQuest, result, sentResultToEmail);
            //if sent to email == true sent user email with result зробити пізніше
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("QuestsResultsForUser")]
        public async Task<List<QuestResult>> GetQuestResultsByUserId(int userId)
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
