using Prism.Commands;
using Prism.Mvvm;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class StartQuizViewModel : BindableBase
    {
        IWindowView _windowView;
        IQuizService _quizService;
        public List<Quiz> ListOfQuizzes { get; set; }

        private Quiz _selectedQuiz = null;
        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set { SetProperty(ref _selectedQuiz, value); }
        }

        private DelegateCommand _openQuizWindow;
        public DelegateCommand OpenQuizWindow =>
            _openQuizWindow ?? (_openQuizWindow = new DelegateCommand(ExecuteOpenQuizWindow, CanExecuteOpenQuizWindow));

        public StartQuizViewModel(IWindowView windowView, IQuizService quizService)
        {
            _windowView = windowView;
            _quizService = quizService;
            ListOfQuizzes = new List<Quiz>(_quizService.GetAllQuizzes());
        }

        void ExecuteOpenQuizWindow()
        {
            _windowView.Open();
        }

        bool CanExecuteOpenQuizWindow()
        {
            return true;
        }
    }
}
