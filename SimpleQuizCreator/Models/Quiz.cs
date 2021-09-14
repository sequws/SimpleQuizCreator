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
        public List<Question> Questions { get; set; } = new List<Question>();
        public int QuestionAmount => Questions.Count();

        public List<string> Errors { get; set; } = new List<string>();
        public bool CorrectlyLoaded { get; internal set; }

        public Quiz() {}
    }
}
