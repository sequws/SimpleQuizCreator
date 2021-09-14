using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();

        public int GoodAnswersCount => Answers.Where(x => x.IsCorrect).Count();

        public int AnswersCount => Answers.Count();
    }
}
