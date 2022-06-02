using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questor.DAL.Interface;

namespace Questor.DAL.Models
{
    public class Answer : IEntity 
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set;}
        public bool IsCorrect { get; set; }
    }
}
