using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questor.DAL.Models;
using Questor.DAL.Models.ViewModels;
using Questor.Services.Interfaces;

namespace Questor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IQuestService questService;
        public QuestController(IQuestService questService)
        {
            this.questService = questService;
        }

        [HttpGet]
        public async Task<Quest> GetQuest(int id)
        {
            return await questService.GetQuestById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuest([FromBody] QuestViewModel questViewModel)
        {   
            
            await questService.AddQuest(questViewModel.Name, questViewModel.Description, questViewModel.IsPublic, questViewModel.WriteOffControlMode, questViewModel.TimeLimit, questViewModel.UserId);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuest(int questId)
        {
            await questService.DeleteQuest(questId);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuest([FromBody] QuestViewModel questViewModel, int questId)
        {
            await questService.UpdateQuest(questId, questViewModel.Name,questViewModel.Description,questViewModel.IsPublic,questViewModel.WriteOffControlMode,questViewModel.TimeLimit);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("QuestByUserId")]
        public async Task<List<Quest>> GetQuestByUserId (string userId)
        {
            return await questService.GetQuestsByUserId(userId);
        }

        [HttpGet("PublicQuests")]
        public async Task<List<Quest>> GetAllPublicQuest()
        {
            return await questService.GetAllPublicQuest();
        }


    }
}
