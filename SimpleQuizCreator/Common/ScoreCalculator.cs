using SimpleQuizCreator.Common.Calculator;
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
            ICalculationStrategy calculator = GetCalculationStrategy(quizGenerated.QuizSettings.ScoreType);
            ScoreResult score = calculator.Calculate(quizGenerated.Questions);

            return score;
        }

        private ICalculationStrategy GetCalculationStrategy(ScoreType scoreType)
        {
            switch( scoreType)
            {
                case ScoreType.OneGoodZeroBad:
                    return new OneGoodZeroBadCalcStrategy();
                case ScoreType.OneGoodOneBad:
                    return new OneGoodOneBadCalcStrategy();
                case ScoreType.OneGoodOneBadOneNo:
                    return new OneGoodOneBadOneNoCalcStrategy();
                case ScoreType.AllGoodWithoutMinus:
                    return new AllGoodWithoutMinusCalcStrategy();
                case ScoreType.AllGoodWithMinus:
                    throw new NotImplementedException($"There is no implementation of calculation strategy for 'NotImplementedException'");

                default:
                    throw new ArgumentException("There is no scoreType like this!", nameof( scoreType));                    
            }
        }
    }
}
