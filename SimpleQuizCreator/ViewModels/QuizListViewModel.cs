using Prism.Commands;
using Prism.Mvvm;
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

        private ObservableCollection<Quiz> listOfQuizzes;

        public ObservableCollection<Quiz> ListOfQuizzes
        {
            get { return listOfQuizzes; }
            set { SetProperty(ref listOfQuizzes, value); }
        }

        public QuizListViewModel(IQuizService quizService)
        {
            _quizService = quizService;
            listOfQuizzes = new ObservableCollection<Quiz>(_quizService.GetAllQuizzes());
        }

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
    }
}
