using Prism.Mvvm;
using SimpleQuizCreator.Common;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Desc = "+1 for any good answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBad,
                IsSingleAnswer = true,
                Desc = "+1 for any good answer, -1 for any bad answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBadOneNo,
                IsSingleAnswer = true,
                Desc = "+1 for any good answer, -1 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithoutMinus,
                IsSingleAnswer = false,
                Desc = "+1 for all good answers, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithMinus,
                IsSingleAnswer = false,
                Desc = "+1 for all good answers, -1 otherwise"
            });
        }

        public List<ScoreTypeComboItem> GetPossibleScoreTypes(bool isSingleAnswer)
        {
            return new List<ScoreTypeComboItem>(scoreTypes.Where(x => x.IsSingleAnswer == isSingleAnswer));
        }
    }
}
