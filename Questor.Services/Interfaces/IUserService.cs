using Questor.DAL.Models;

namespace Questor.Services.Interfaces;

public interface IUserService
{
 //  public Task AddUser(string name, string email, string password);
   // public Task DeleteUser(string id);
    public Task<User> GetUserById(string id);
  //  public Task UpdateUser(string id, string name, string email, string password);
    public Task<List<User>> GetAllUsers();
 
}