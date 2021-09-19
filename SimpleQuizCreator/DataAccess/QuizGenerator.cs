using SimpleQuizCreator.Helpers;
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


            var tmpQuestion = quiz.GetDeepCopy().Questions;
            tmpQuestion.ShuffleInPlaceList();
            foreach(var q in tmpQuestion)
            {
                q.Answers.ShuffleInPlaceList();
            }

            generated.Questions = tmpQuestion.Take(_quizSettings.QuestionLimit).ToList();
        }

        public QuizGenerated GetQuiz()
        {
            return generated;
        }
    }
}
