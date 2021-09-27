using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Common.Calculator
{
    /// <summary>
    /// 1pts for good answer, no minus points for bad answer, or lack answer
    /// (1,0,0) - G1B0N0
    /// </summary>
    public class OneGoodZeroBadCalcStrategy : ICalculationStrategy
    {
        public ScoreResult Calculate(List<Question> questions)
        {
            ScoreResult score = new ScoreResult();
            score.AllGoodAnswers = questions.SelectMany(x => x.Answers).Where(y => y.IsCorrect).Count();
            score.AllPosiblePoints = questions.Count;
            score.QuestionAmount = questions.Count;

            var res = 0;
            foreach (var question in questions)
            {
                var badSelected = question.Answers.Count(x => x.IsSelected && !x.IsCorrect);
                var goodSelected = question.Answers.Count(x => x.IsSelected && x.IsCorrect);

                res = (badSelected == 0 && goodSelected > 0) ? 1 : 0;
                score.PointScore += res;
            }

            score.PercentScore = Math.Round(
                ((double)score.PointScore >= 0 ? score.PointScore : 0 / (double)score.AllPosiblePoints)*100, 1);

            return score;
        }
    }
}
