using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using SimpleQuizCreator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizDialogViewModel : BindableBase, IDialogAware
    {
        private readonly IScoreCalculator _scoreCalculator;

        #region commands
        private DelegateCommand _closeDialogCommand;
        public DelegateCommand CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand(ExecuteCloseDialogCommand));

        void ExecuteCloseDialogCommand()
        {
            var resParams = new DialogParameters();
            resParams.Add("score", QuizResult);

            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, resParams));
        }

        private DelegateCommand _startQuizCommand;
        public DelegateCommand StartQuizCommand =>
            _startQuizCommand ?? (_startQuizCommand = new DelegateCommand(ExecuteStardQuizCommand));

        void ExecuteStardQuizCommand()
        {
            SelectedIndex++;
            ActiveQuestion = Quiz.ActiveQuestion;
        }

        private DelegateCommand _nextQuestionCommand;
        public DelegateCommand NextQuestionCommand =>
            _nextQuestionCommand ?? (_nextQuestionCommand = new DelegateCommand(ExecuteNextQuestionCommand));

        void ExecuteNextQuestionCommand()
        {
            Quiz.ActiveQuestionNumber++;
            ActiveQuestion = Quiz.ActiveQuestion;

            if (Quiz.ActiveQuestionNumber == Quiz.QuestionsNumber-1)
            {
                NextQuestionButtonCaption = rm.GetString("QuizDialogFinishText");
            } 
            else if (Quiz.ActiveQuestionNumber >= Quiz.QuestionsNumber)
            {
                SelectedIndex++;
                QuizResult = _scoreCalculator.CalculateResult( Quiz);
                ScoreText = string.Format(rm.GetString("QuizDialogScoreText"), QuizResult.PointScore, QuizResult.AllPosiblePoints);
            }
        }

        #endregion

        #region properties

        private string _scoreText;
        public string ScoreText
        {
            get { return _scoreText; }
            set { SetProperty(ref _scoreText, value); }
        }

        private string _nextQuestionButtonCaption = "_next_";
        public string NextQuestionButtonCaption
        {
            get { return _nextQuestionButtonCaption; }
            set { SetProperty(ref _nextQuestionButtonCaption, value); }
        }
                
        private string _quizInfoText;
        public string QuizInfoText
        {
            get { return _quizInfoText; }
            set { SetProperty(ref _quizInfoText, value); }
        }

        private int _selectedIndex = 0;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { SetProperty(ref _selectedIndex, value); }
        }

        private QuizGenerated _quiz;
        public QuizGenerated Quiz
        {
            get { return _quiz; }
            set { SetProperty(ref _quiz, value); }
        }

        private Question _activeQuestion;
        public Question ActiveQuestion
        {
            get { return _activeQuestion; }
            set { SetProperty(ref _activeQuestion, value); }
        }

        private ScoreResult _quizResult;
        public ScoreResult QuizResult
        {
            get { return _quizResult; }
            set { SetProperty(ref _quizResult, value); }
        }

        #endregion

        ResourceManager rm = new ResourceManager(typeof(SimpleQuizCreator.Properties.Resources));

        public QuizDialogViewModel(IScoreCalculator calculationStrategy)
        {
            _scoreCalculator = calculationStrategy;
            NextQuestionButtonCaption = rm.GetString("QuizDialogNexQuestionText");
        }

        #region IDialogAware

        public string Title => "Quiz Time!";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Quiz = parameters.GetValue<QuizGenerated>("quiz");

            QuizInfoText = string.Format(rm.GetString("QuizDialogQuizInfoText"), Quiz.QuizSettings.QuestionLimit);
        }

        #endregion
    }
}
