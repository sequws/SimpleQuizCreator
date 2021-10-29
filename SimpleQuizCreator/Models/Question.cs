using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class Question : BindableBase
    {
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int GoodAnswersCount => Answers.Where(x => x.IsCorrect).Count();
        public int AnswersCount => Answers.Count();

        public override string ToString()
        {
            return $"{QuestionText}... [{AnswersCount}]";
        }
    }
}
