using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Common
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

        private ICalculationStrategy GetCalculationStrategy()
        {
            ICalculationStrategy calculationStrategy = null;

            return calculationStrategy;
        }
    }
}
