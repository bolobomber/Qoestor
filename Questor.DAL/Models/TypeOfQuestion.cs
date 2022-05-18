using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questor.DAL.Models
{
    public class TypeOfQuestion
    {
        public int Id { get; set; }
        public string NameofType { get; set; }
        public List<Question> Questions {get; set;}

    }
}
