using SimpleQuizCreator.Common;
using SimpleQuizCreator.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class ScoreTypeListViewModel
    {
        private List<ScoreTypeComboItem> scoreTypes = new List<ScoreTypeComboItem>();

        public ScoreTypeListViewModel()
        {
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodZeroBad,
                IsSingleAnswer = true,
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBad,
                IsSingleAnswer = true,
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBadOneNo,
                IsSingleAnswer = true,
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithoutMinus,
                IsSingleAnswer = false,
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithMinus,
                IsSingleAnswer = false,
            });
        }

        public List<ScoreTypeComboItem> GetPossibleScoreTypes(bool isSingleAnswer)
        {
            return new List<ScoreTypeComboItem>(scoreTypes.Where(x => x.IsSingleAnswer == isSingleAnswer));
        }
    }
}
