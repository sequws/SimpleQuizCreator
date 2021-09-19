using SimpleQuizCreator.Helpers;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Common
{
    /// <summary>
    /// Generate new quiz using settings
    /// Draws questions from the pool, then mixes their order and the order of answers. 
    /// </summary>
    public class QuizGenerator : IQuizGenerator
    {
        QuizGenerated generated;

        public void GenerateNewQuiz(Quiz quiz, QuizSettings settings)
        {
            generated = new QuizGenerated();
            generated.Name = quiz.Name;
            generated.QuizSettings = settings;            

            var tmpQuestion = quiz.GetDeepCopy().Questions;
            tmpQuestion.ShuffleInPlaceList();
            foreach(var q in tmpQuestion)
            {
                q.Answers.ShuffleInPlaceList();
            }

            generated.Questions = tmpQuestion.Take(settings.QuestionLimit).ToList();
        }

        public QuizGenerated GetQuiz()
        {
            return generated;
        }
    }
}
