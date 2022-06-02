using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Questor.DAL.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Quest> CreatedQuests { get; set; }
        public List<QuestResult> CompletedQuests { get; set; }
    }

}
