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
                SingleAnswer = true,
                Desc = "+1 for any good answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBad,
                SingleAnswer = true,
                Desc = "+1 for any good answer, -1 for any bad answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBadOneNo,
                SingleAnswer = true,
                Desc = "+1 for any good answer, -1 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithoutMinus,
                SingleAnswer = false,
                Desc = "+1 for all good answers, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithMinus,
                SingleAnswer = false,
                Desc = "+1 for all good answers, -1 otherwise"
            });
        }

        public List<ScoreTypeComboItem> GetPossibleScoreTypes(bool isSingleAnswer)
        {
            return new List<ScoreTypeComboItem>(scoreTypes.Where(x => x.SingleAnswer == isSingleAnswer));
        }
    }
}
