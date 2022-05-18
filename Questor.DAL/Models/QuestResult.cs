using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questor.DAL.Models
{
    public class QuestResult
    {
        public int id { get; set; }
        public Participant Participant { get; set; }
        public Quest Quest { get; set; }
        public bool IsCompleted { get; set; }
        public string TimeInQuest { get; set; }
        public int Result { get; set; }
        public bool SentResultToEmail { get; set; }
    }
}
