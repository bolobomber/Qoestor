using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questor.DAL.auth;
using Questor.DAL.Models;
using Questor.DAL.Models.ViewModels;
using Questor.Services.Interfaces;
using Questor.Services.Services;

namespace Questor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestResultController : ControllerBase
    {
        public readonly IQuestResultService questResultService;
        public readonly IEmailService _emailService;
        private readonly UserManager<IdentityUser> _userManager;
        public QuestResultController(IQuestResultService questResultService, IEmailService emailService, UserManager<IdentityUser> userManager)
        {
            this.questResultService = questResultService;
            _emailService = emailService;
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<QuestResult> GetQuestResult(int id)
        {
            return await questResultService.GetQuestResultById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestResult([FromBody] QuestResultViewModel questResultViewModel)
        {
           var a = await questResultService.AddQuestResult(questResultViewModel.UserId, questResultViewModel.QuestId, questResultViewModel.IsCompleted, questResultViewModel.TimeInQuest,questResultViewModel.Result,questResultViewModel.SentResultToEmail);
           if (questResultViewModel.IsCompleted && questResultViewModel.SentResultToEmail)
           {
               IdentityUser user = await _userManager.FindByIdAsync(questResultViewModel.UserId);
               _emailService.SendEmailAsync(user.Email, "Questor",$"твій результат проходження квесту {questResultViewModel.Result}");
            }
            return Ok(new Response { Status = "Success", Message = $"{a}" });
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
