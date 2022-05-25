using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.DeleteUser(id);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<User> GetUser(int id)
        {
            return await userService.GetUserById(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, string name, string email, string password)
        {
            await userService.UpdateUser(id, name, email, password);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
