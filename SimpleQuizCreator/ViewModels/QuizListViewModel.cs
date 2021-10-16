using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizListViewModel : BindableBase
    {
        IQuizService _quizService;
        IDialogService _dialogService;

        private ObservableCollection<Quiz> listOfQuizzes;

        public ObservableCollection<Quiz> ListOfQuizzes
        {
            get { return listOfQuizzes; }
            set { SetProperty(ref listOfQuizzes, value); }
        }

        public QuizListViewModel(IQuizService quizService, IDialogService dialogService)
        {
            _quizService = quizService;
            _dialogService = dialogService;
            listOfQuizzes = new ObservableCollection<Quiz>(_quizService.GetAllQuizzes());
        }


        #region Commands
        private DelegateCommand _refreshCommand;
        public DelegateCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand, CanExecuteRefreshCommand));

        void ExecuteRefreshCommand()
        {
            ListOfQuizzes = new ObservableCollection<Quiz>(_quizService.GetAllQuizzes());
        }

        bool CanExecuteRefreshCommand()
        {
            return true;
        }

        private DelegateCommand<Quiz> _openDialogCommand;
        public DelegateCommand<Quiz> OpenDialogCommand =>
            _openDialogCommand ?? (_openDialogCommand = new DelegateCommand<Quiz>(ExecuteOpenDialogCmd, CanExecuteOpenDialogCmd));

        void ExecuteOpenDialogCmd(Quiz parameter)
        {
            if (parameter == null) return;

            var dialogParams = new DialogParameters();
            dialogParams.Add("quiz", parameter);

            _dialogService.ShowDialog("QuizPreviewDialog", dialogParams, res =>
            {

            });
        }

        bool CanExecuteOpenDialogCmd(Quiz parameter)
        {
            return true;
        }

        #endregion
    }
}
