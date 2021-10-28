using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SimpleQuizCreator.ViewModels
{
    public class StartQuizViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private readonly IQuizGenerator _quizGenerator;        
        private readonly IQuizService _quizService;
        private readonly IResultService _resultService;
        private readonly IGlobalSettingService _settingService;

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
            set
            {
                SetProperty(ref _selectedQuiz, value);
                if(QuizSettings.QuestionLimit > _selectedQuiz.QuestionAmount)
                {
                    QuizSettings.QuestionLimit = _selectedQuiz.QuestionAmount;
                }
                ScoreTypes = ScoreTypeList.GetPossibleScoreTypes(SelectedQuiz.SingleAnswer);
                SelectedScoreType = ScoreTypes[0];
            }
        }

        private List<ScoreTypeComboItem> scoreTypes;
        public List<ScoreTypeComboItem> ScoreTypes
        {
            get { return scoreTypes; }
            set { SetProperty(ref scoreTypes, value); }
        }

        private ScoreTypeComboItem selectedScoreType;
        public ScoreTypeComboItem SelectedScoreType
        {
            get { return selectedScoreType; }
            set { SetProperty(ref selectedScoreType, value); }
        }

        public ScoreTypeListViewModel ScoreTypeList { get; } = new ScoreTypeListViewModel();

        private DelegateCommand _openQuizWindow;
        public DelegateCommand OpenQuizWindow =>
            _openQuizWindow ?? (_openQuizWindow = new DelegateCommand(ExecuteOpenQuizWindow, CanExecuteOpenQuizWindow));

        public StartQuizViewModel(IQuizService quizService, 
            IDialogService dialogService, 
            IQuizGenerator quizGenerator, 
            IResultService resultService,
            IGlobalSettingService settingService)
        {
            _quizService = quizService;
            _dialogService = dialogService;
            _quizGenerator = quizGenerator;
            _resultService = resultService;
            _settingService = settingService;
            ListOfQuizzes = new List<Quiz>(_quizService.GetAllQuizzes().Where(x => x.CorrectlyLoaded));
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

            QuizSettings.ScoreType = SelectedScoreType.Type;

            _quizGenerator.GenerateNewQuiz(SelectedQuiz, QuizSettings);
            var generatedQuiz = _quizGenerator.GetQuiz();

            var dialogParams = new DialogParameters();
            dialogParams.Add("quiz", generatedQuiz);

            _dialogService.ShowDialog("QuizDialog", dialogParams , r =>
            {
                var scoreRes = r.Parameters.GetValue<ScoreResult>("score");

                if(scoreRes != null)
                {
                    var minQuestNum = (int)_settingService.Get("HistoryMinQuestion");
                    if(generatedQuiz.QuestionsNumber >= minQuestNum)
                    {
                        _resultService.SaveResult(scoreRes);
                    }
                }
            });
        }

        bool CanExecuteOpenQuizWindow()
        {
            return true;
        }
    }
}
