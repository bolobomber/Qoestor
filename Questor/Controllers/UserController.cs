using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Questor.DAL.Models;
using Questor.DAL.Models.ViewModels;
using Questor.Services.Interfaces;

namespace Questor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
            
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserViewModel userViewModel)
        {
            await userService.AddUser(userViewModel.Name,userViewModel.Email,userViewModel.Password);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userService.DeleteUser(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<User> GetUser(string id)
        {
            return await userService.GetUserById(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserViewModel userViewModel, string id)
        {
            await userService.UpdateUser(id, userViewModel.Name, userViewModel.Email, userViewModel.Password);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("Users")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }
    }
}
