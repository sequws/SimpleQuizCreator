using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SimpleQuizCreator.Events;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace SimpleQuizCreator.ViewModels
{
    public class HistoryViewModel : BindableBase, INavigationAware
    {
        private readonly IResultService _resultService;

        #region properties
        private string selectedQuizName;
        public string SelectedQuizName
        {
            get { return selectedQuizName; }
            set 
            {
                SetProperty(ref selectedQuizName, value);
                RefreshData();
            }
        }

        private List<ScoreResult> historyResult;
        public List<ScoreResult> HistoryResult
        {
            get { return historyResult; }
            set { SetProperty(ref historyResult, value); }
        }

        private ObservableCollection<string> quizNames = new ObservableCollection<string>();
        public ObservableCollection<string> QuizNames
        {
            get { return quizNames; }
            set { SetProperty(ref quizNames, value); }
        }
        #endregion

        public HistoryViewModel(IResultService resultService)
        {
            _resultService = resultService;

            HistoryResult = _resultService.GetAllResult().ToList();
            List<string> names = HistoryResult.Select(x => x.QuizName).Distinct().ToList();

            ResourceManager rm = new ResourceManager(typeof(Properties.Resources));
            QuizNames.Add(rm.GetString("AllText"));
            QuizNames.AddRange(names);
            SelectedQuizName = QuizNames[0];
        }

        private void RefreshData()
        {
            // todo - add pagination, search bar
            if (SelectedQuizName == null) return;

            if (SelectedQuizName.Equals(QuizNames[0]))
            {
                HistoryResult = _resultService.GetAllResult().ToList();
            }
            else
            {
                HistoryResult = _resultService.GetResultByQuizName(SelectedQuizName).ToList();
            }
        }

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            RefreshData();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        #endregion
    }
}
