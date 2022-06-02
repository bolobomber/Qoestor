using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Questor.DAL.Interface;

namespace Questor.DAL.Models
{
    public class Quest : IEntity
    {   
        public int Id { get; set; }
        //  public Creator Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public bool WriteOffControlMode { get; set; }
        public int TimeLimit { get; set; }
        public string? URL { get; set; }
        public string UserId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }
        public List<Question> Questions { get; set; }
        public List<QuestResult> QuestResults { get; set; }

    }
}
