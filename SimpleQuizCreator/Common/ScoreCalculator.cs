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
        QuizGenerated _quizGenerated;

        public ScoreCalculator()
        {                
        }

        public ScoreResult CalculateResult(QuizGenerated quizGenerated)
        {
            ScoreResult score = new ScoreResult();
            _quizGenerated = quizGenerated;

            score.AllGoodAnswers = quizGenerated.Questions.SelectMany(x => x.Answers).Where(y => y.IsCorrect).Count();

            return score;
        }

        private ICalculationStrategy GetCalculationStrategy()
        {
            ICalculationStrategy calculationStrategy = null;



            return calculationStrategy;
        }
    }
}
