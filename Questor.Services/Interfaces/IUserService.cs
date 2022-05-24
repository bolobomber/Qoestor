using Questor.DAL.Models;

namespace Questor.Services.Interfaces;

public interface IUserService
{
    public Task AddUser(string name, string email, string password);
    public Task DeleteUser(int id);
    public Task<User> GetUserById(int id);
    public Task UpdateUser(int id, string name, string email, string password);
}