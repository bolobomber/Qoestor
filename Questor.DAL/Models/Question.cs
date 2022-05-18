using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questor.DAL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string TitleOfQuestion { get; set; }
        public string LinkTophoto { get; set; }
        public int PointsPerQuestion { get; set; }
        public TypeOfQuestion TypeOfQuestion { get; set; }
        public Quest Quest  { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
