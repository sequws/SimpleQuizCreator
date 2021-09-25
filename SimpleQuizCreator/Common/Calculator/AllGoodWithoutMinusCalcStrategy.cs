using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Common.Calculator
{
    public class AllGoodWithoutMinusCalcStrategy : ICalculationStrategy
    {
        public ScoreResult Calculate(List<Question> questions)
        {
            ScoreResult score = new ScoreResult();
            score.AllGoodAnswers = questions.SelectMany(x => x.Answers).Where(y => y.IsCorrect).Count();
            score.AllPosiblePoints = questions.Count;
            score.QuestionAmount = questions.Count;

            foreach (var question in questions)
            {
                var badSelected = question.Answers.Count(x => x.IsSelected && !x.IsCorrect);
                var goodSelected = question.Answers.Count(x => x.IsSelected && x.IsCorrect);
                var allGoods = question.Answers.Count(x => x.IsCorrect);
                var allGoodSelected = (allGoods == goodSelected && badSelected == 0) ? 1 : 0;

                score.PointsScore += allGoodSelected;
            }

            score.PercentScore = Math.Round(
                ((double)score.PointsScore >= 0 ? score.PointsScore : 0 / (double)score.AllPosiblePoints) * 100, 1);

            return score;
        }
    }
}
