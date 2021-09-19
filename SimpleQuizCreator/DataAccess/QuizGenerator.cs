using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    /// <summary>
    /// Generate new quiz using settings
    /// Draws questions from the pool, then mixes their order and the order of answers. 
    /// </summary>
    public class QuizGenerator : IQuizGenerator
    {
        QuizGenerated generated = new QuizGenerated();
        QuizSettings _quizSettings;

        public void GenerateNewQuiz(Quiz quiz, QuizSettings settings)
        {
            generated.Name = quiz.Name;
            _quizSettings = settings;

            generated.Questions = PrepareQuestions(quiz.Questions);
        }


        private static List<T> PrepareQuestions<T>(IList<T> originalList)
        {
            List<T> res = originalList.OrderBy(x => Guid.NewGuid()).ToList();
            return res;
        }

        public QuizGenerated GetQuiz()
        {
            return generated;
        }
    }
}
