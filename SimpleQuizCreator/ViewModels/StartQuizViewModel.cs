using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Events;
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
        private readonly IScoreTypeService _scoreTypeService;
        private readonly IGlobalSettingService _settingService;
        private readonly IEventAggregator _ea;

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
                ScoreTypes = _scoreTypeService.GetPossibleScoreTypes(SelectedQuiz.IsSingleAnswer);
                SelectedScoreType = ScoreTypes[0];
                if(IsSetToMaxQuetionEnable)
                {
                    QuizSettings.QuestionLimit = SelectedQuiz.QuestionAmount;
                }
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

        private bool isSetToMaxQuestionEnable;
        public bool IsSetToMaxQuetionEnable
        {
            get { return isSetToMaxQuestionEnable; }
            set { 
                SetProperty(ref isSetToMaxQuestionEnable, value);
                if(value)
                {
                    QuizSettings.QuestionLimit = SelectedQuiz.QuestionAmount;
                }
            }
        }

        private DelegateCommand _openQuizWindow;
        public DelegateCommand OpenQuizWindow =>
            _openQuizWindow ?? (_openQuizWindow = new DelegateCommand(ExecuteOpenQuizWindow, CanExecuteOpenQuizWindow));

        public StartQuizViewModel(IQuizService quizService, 
            IDialogService dialogService, 
            IQuizGenerator quizGenerator, 
            IResultService resultService,
            IGlobalSettingService settingService,
            IScoreTypeService scoreTypeService,
            IEventAggregator ea)
        {
            _quizService = quizService;
            _dialogService = dialogService;
            _quizGenerator = quizGenerator;
            _resultService = resultService;
            _settingService = settingService;
            _scoreTypeService = scoreTypeService;
            _ea = ea;

            _ea.GetEvent<QuizFinishedEvent>().Subscribe(QuizFinishReceived);

            ListOfQuizzes = new List<Quiz>(_quizService.GetAllQuizzes().Where(x => x.IsCorrectlyLoaded));
            if(ListOfQuizzes.Count > 0)
            {
                SelectedQuiz = ListOfQuizzes.First();
            }
        }

        private void QuizFinishReceived(ScoreResult scoreRes)
        {
            if (scoreRes != null)
            {
                var minQuestNum = (int)_settingService.Get("HistoryMinQuestion");
                if (scoreRes.QuestionAmount >= minQuestNum)
                {
                    _resultService.SaveResult(scoreRes);
                }
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
            });
        }

        bool CanExecuteOpenQuizWindow()
        {
            return true;
        }
    }
}
