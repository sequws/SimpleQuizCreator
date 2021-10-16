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
    public class ScoreTypeListViewModel : BindableBase
    {
        public ScoreTypeComboItem SelectedType { get; set; }

        private ObservableCollection<ScoreTypeComboItem> scoreTypes = new ObservableCollection<ScoreTypeComboItem>();
        public ObservableCollection<ScoreTypeComboItem> ScoreTypes
        {
            get { return scoreTypes; }
            set { SetProperty(ref scoreTypes, value); }
        }


        public ScoreTypeListViewModel()
        {
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodZeroBad,
                Desc = "+1 for any good answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBad,
                Desc = "+1 for any good answer, -1 for any bad answer, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBadOneNo,
                Desc = "+1 for any good answer, -1 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithoutMinus,
                Desc = "+1 for all good answers, 0 otherwise"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithMinus,
                Desc = "+1 for all good answers, -1 otherwise"
            });

            SelectedType = scoreTypes[0];
        }
    }
}
