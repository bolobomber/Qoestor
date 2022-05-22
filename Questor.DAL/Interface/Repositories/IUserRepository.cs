using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questor.DAL.Models;

namespace Questor.DAL.Interface.Repositories
{
    internal interface IUserRepository
    {
        public Task Add(User user);
        public Task Delete(int userId);
        public Task Update(User user);
        public Task<User> GetById(int userId);
    }
}
