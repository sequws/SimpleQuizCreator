using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
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
    public class HistoryViewModel : BindableBase
    {
        private readonly IResultService _resultService;
        private readonly IEventAggregator _ea;

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

        public HistoryViewModel(IResultService resultService, IEventAggregator ea)
        {
            _resultService = resultService;
            _ea = ea;

            _ea.GetEvent<QuizFinishedEvent>().Subscribe(QuizFinishReceived);

            HistoryResult = _resultService.GetAllResult().ToList();
            List<string> names = HistoryResult.Select(x => x.QuizName).Distinct().ToList();

            ResourceManager rm = new ResourceManager(typeof(Properties.Resources));
            QuizNames.Add(rm.GetString("AllText"));
            QuizNames.AddRange(names);
            SelectedQuizName = QuizNames[0];
        }

        private void QuizFinishReceived(ScoreResult obj)
        {
            // todo - hack? waiting for database save operation
            Task.Delay(1000).ContinueWith(t => RefreshData());
        }

        private DelegateCommand _refreshCommand;
        public DelegateCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand, CanExecuteRefreshCommand));

        void ExecuteRefreshCommand()
        {
            RefreshData();
        }

        bool CanExecuteRefreshCommand()
        {
            return true;
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
    }
}
