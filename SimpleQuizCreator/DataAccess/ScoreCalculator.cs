using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    public class ScoreCalculator : IScoreCalculator
    {
        public ScoreCalculator()
        {                
        }

        public ScoreResult CalculateResult(QuizGenerated quizGenerated)
        {
            throw new NotImplementedException();
        }
    }
}
