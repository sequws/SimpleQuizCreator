using Prism.Mvvm;
using SimpleQuizCreator.Common;
using SimpleQuizCreator.Models;
using SimpleQuizCreator.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.ViewModels
{
    public class ScoreTypeListViewModel
    {
        private List<ScoreTypeComboItem> scoreTypes = new List<ScoreTypeComboItem>();
        ResourceManager rm = new ResourceManager(typeof(EnumResources));

        public ScoreTypeListViewModel()
        {
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodZeroBad,
                IsSingleAnswer = true,
                Desc = rm.GetString("OneGoodZeroBad")
                //Desc = "+1 for any good answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBad,
                IsSingleAnswer = true,
                Desc = rm.GetString("OneGoodOneBad")
                //Desc = "+1 for any good answer, -1 for any bad answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBadOneNo,
                IsSingleAnswer = true,
                Desc = rm.GetString("OneGoodOneBadOneNo")
                //Desc = "+1 for any good answer, -1 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithoutMinus,
                IsSingleAnswer = false,
                Desc = rm.GetString("AllGoodWithoutMinus")
                //Desc = "+1 for all good answers, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithMinus,
                IsSingleAnswer = false,
                Desc = rm.GetString("AllGoodWithMinus")
                //Desc = "+1 for all good answers, -1 otherwise"
            });
        }

        public List<ScoreTypeComboItem> GetPossibleScoreTypes(bool isSingleAnswer)
        {
            return new List<ScoreTypeComboItem>(scoreTypes.Where(x => x.IsSingleAnswer == isSingleAnswer));
        }
    }
}
