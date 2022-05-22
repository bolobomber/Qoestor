using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questor.DAL.Models.Enums;

namespace Questor.DAL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LinkTophoto { get; set; }
        public int PointsPerQuestion { get; set; }
        public QuestionType QeustionType { get; set; }
        public int QuestId { get; set; }
        public Quest Quest  { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
