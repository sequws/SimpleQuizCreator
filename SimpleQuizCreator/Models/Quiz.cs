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
        public bool SingleAnswer => !Questions.Any(x => x.GoodAnswersCount > 1);

        public Quiz() {}

        public Quiz GetDeepCopy()
        {
            Quiz copyQuiz = new Quiz();
            copyQuiz.CorrectlyLoaded = CorrectlyLoaded;
            copyQuiz.Errors = new List<string>(Errors);
            copyQuiz.Name = Name;

            foreach (Question question in Questions)
            {
                Question copyQuestion = new Question();
                foreach (Answer answer in question.Answers)
                {
                    copyQuestion.Answers.Add(new Answer()
                    {
                        IsSelected = answer.IsSelected,
                        IsCorrect = answer.IsCorrect,
                        AnswerText = answer.AnswerText
                    });
                }

                copyQuestion.QuestionText = question.QuestionText;
                copyQuiz.Questions.Add(copyQuestion);
            }

            return copyQuiz;
        }

        public override string ToString()
        {
            return $"{Name} [{QuestionAmount}]";
        }
    }
}
