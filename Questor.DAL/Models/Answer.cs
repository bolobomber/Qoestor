using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questor.DAL.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Question Question { get; set;}
        public bool IsConformity { get; set; }
        public bool IsCorrect { get; set; }
    }
}
