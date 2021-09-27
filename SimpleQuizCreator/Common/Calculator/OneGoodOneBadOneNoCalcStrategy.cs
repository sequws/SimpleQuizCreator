using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.Common.Calculator
{
    internal class OneGoodOneBadOneNoCalcStrategy : ICalculationStrategy
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
                var anySelected = question.Answers.Any(x => x.IsSelected);

                res = (badSelected == 0 && goodSelected > 0) ? 1 : -1;
                if (!anySelected) res = -1;
                score.PointScore += res;
            }

            score.PercentScore = Math.Round(
                ((double)(score.PointScore >= 0 ? score.PointScore : 0) / (double)score.AllPosiblePoints) * 100, 1);

            return score;
        }
    }
}