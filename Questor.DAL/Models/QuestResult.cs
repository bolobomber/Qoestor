using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questor.DAL.Interface;

namespace Questor.DAL.Models
{
    public class QuestResult : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public bool IsCompleted { get; set; }
        public string TimeInQuest { get; set; }
        public int Result { get; set; }
        public bool SentResultToEmail { get; set; }
    }
}
