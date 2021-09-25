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
                Desc = "OneGoodZeroBad desc"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBad,
                Desc = "OneGoodOneBad desc"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.OneGoodOneBadOneNo,
                Desc = "OneGoodOneBadOneNo desc"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithoutMinus,
                Desc = "AllGoodWithoutMinus desc"
            });
            scoreTypes.Add(new ScoreTypeComboItem
            {
                Type = ScoreType.AllGoodWithMinus,
                Desc = "AllGoodWithMinus desc"
            });

            SelectedType = scoreTypes[0];
        }
    }
}
