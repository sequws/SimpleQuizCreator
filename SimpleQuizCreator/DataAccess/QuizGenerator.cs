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


        public void GenerateNewQuiz(Quiz quiz, QuizSettings settings)
        {
            
        }
    }
}
