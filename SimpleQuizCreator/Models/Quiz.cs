using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class Quiz
    {
        public string Name { get; set; }
        public int ActiveQuestionNumber { get; set; } 

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
