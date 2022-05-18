using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questor.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
    }

    public class Creator : User
    { 
        public List<Quest> CreatedQuests { get; set; }
    }
    public class Participant : User
    {
        public List<QuestResult> CompletedQuest { get; set; }
    }


}
