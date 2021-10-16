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

        private DelegateCommand _openDialogCommand;
        public DelegateCommand OpenDialogCommand =>
            _openDialogCommand ?? (_openDialogCommand = new DelegateCommand(ExecuteOpenDialogCmd, CanExecuteOpenDialogCmd));

        void ExecuteOpenDialogCmd()
        {
            _dialogService.ShowDialog("QuizPreviewDialog", new DialogParameters(), res =>
            {

            });
        }

        bool CanExecuteOpenDialogCmd()
        {
            return true;
        }
        #endregion
    }
}
