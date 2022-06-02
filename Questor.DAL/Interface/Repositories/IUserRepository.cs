using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questor.DAL.Models;

namespace Questor.DAL.Interface.Repositories
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task Delete(string userId);
        public Task Update(User user);
        public Task<User> GetById(string userId);
        public Task<List<User>> GetAllUsers();
    }
}
