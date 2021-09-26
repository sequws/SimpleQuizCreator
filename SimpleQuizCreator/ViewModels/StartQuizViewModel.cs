using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SimpleQuizCreator.ViewModels
{
    public class StartQuizViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private readonly IQuizGenerator _quizGenerator;
        private readonly IWindowView _windowView;
        private readonly IQuizService _quizService;
        public List<Quiz> ListOfQuizzes { get; set; }

        private QuizSettings quizSettings = new QuizSettings();
        public QuizSettings QuizSettings
        {
            get { return quizSettings; }
            set { SetProperty(ref quizSettings, value); }
        }

        private Quiz _selectedQuiz = null;
        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set { SetProperty(ref _selectedQuiz, value); 
                if(QuizSettings.QuestionLimit > _selectedQuiz.QuestionAmount)
                {
                    QuizSettings.QuestionLimit = _selectedQuiz.QuestionAmount;
                }
            }
        }

        public ScoreTypeListViewModel ScoreTypeList { get; set; } = new ScoreTypeListViewModel();

        private DelegateCommand _openQuizWindow;
        public DelegateCommand OpenQuizWindow =>
            _openQuizWindow ?? (_openQuizWindow = new DelegateCommand(ExecuteOpenQuizWindow, CanExecuteOpenQuizWindow));

        public StartQuizViewModel(IWindowView windowView, IQuizService quizService, IDialogService dialogService, IQuizGenerator quizGenerator)
        {
            _windowView = windowView;
            _quizService = quizService;
            _dialogService = dialogService;
            _quizGenerator = quizGenerator;
            ListOfQuizzes = new List<Quiz>(_quizService.GetAllQuizzes());
            if(ListOfQuizzes.Count > 0)
            {
                SelectedQuiz = ListOfQuizzes.First();
            }
        }

        void ExecuteOpenQuizWindow()
        {
            if (SelectedQuiz == null)
                return;

            if( QuizSettings.QuestionLimit > SelectedQuiz.QuestionAmount)
            {
                MessageBox.Show("The selected number of questions is greater than the pool of questions in the quiz", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                QuizSettings.QuestionLimit = SelectedQuiz.QuestionAmount;
                return;
            }

            QuizSettings.ScoreType = ScoreTypeList.SelectedType.Type;

            _quizGenerator.GenerateNewQuiz(SelectedQuiz, QuizSettings);
            var generatedQuiz = _quizGenerator.GetQuiz();

            var dialogParams = new DialogParameters();
            dialogParams.Add("quiz", generatedQuiz);

            _dialogService.ShowDialog("QuizDialog", dialogParams , r =>
            {
                var scoreRes = r.Parameters.GetValue<ScoreResult>("score");

                // todo: Save results to database or file
            });
        }

        bool CanExecuteOpenQuizWindow()
        {
            return true;
        }
    }
}
