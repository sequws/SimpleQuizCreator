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

            ICalculationStrategy calculator = GetCalculationStrategy(quizGenerated.QuizSettings.ScoreType);

            calculator.Calculate(_quizGenerated.Questions);

            return score;
        }

        private ICalculationStrategy GetCalculationStrategy(ScoreType scoreType)
        {
            switch( scoreType)
            {
                case ScoreType.OneGoodZeroBad:
                    throw new NotImplementedException($"There is no implementation of calculation strategy for 'OneGoodZeroBad'");
                case ScoreType.OneGoodOneBad:
                    throw new NotImplementedException($"There is no implementation of calculation strategy for 'OneGoodOneBad'");
                case ScoreType.AllGoodWithoutMinus:
                    throw new NotImplementedException($"There is no implementation of calculation strategy for 'AllGoodWithoutMinus'");
                case ScoreType.AllGoodWithMinus:
                    throw new NotImplementedException($"There is no implementation of calculation strategy for 'NotImplementedException'");

                default:
                    throw new ArgumentException("There is no scoreType like this!", nameof( scoreType));                    
            }
        }
    }
}
