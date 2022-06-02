using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Questor.DAL.Models;
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
        public async Task<IActionResult> AddUser(string name, string email, string password)
        {
            await userService.AddUser(name, email, password);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userService.DeleteUser(id);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<User> GetUser(string id)
        {   
            
            return await userService.GetUserById(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(string id, string name, string email, string password)
        {
            await userService.UpdateUser(id, name, email, password);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("Users")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }
    }
}
