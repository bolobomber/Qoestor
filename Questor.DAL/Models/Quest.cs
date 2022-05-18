using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questor.DAL.Models
{
    public class Quest
    {   
        public int Id { get; set; }
        public Creator Creator { get; set; }
        public string NameOfQuest { get; set; }
        public List<Question> Questions { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public bool WriteOffControlMode { get; set; }
        public int TimeLimit { get; set; }
        public string QuestURL { get; set; }
        public List<QuestResult> QuestResults { get; set; }
    }
}
