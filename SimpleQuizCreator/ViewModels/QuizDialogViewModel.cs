using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizDialogViewModel : BindableBase, IDialogAware
    {
        #region commands
        private DelegateCommand _closeDialogCommand;
        public DelegateCommand CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand(ExecuteCloseDialogCommand));

        void ExecuteCloseDialogCommand()
        {
            var resParams = new DialogParameters();
            resParams.Add("score", 88.2);

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
                NextQuestionButtonCaption = "Finish";
            } 
            else if (Quiz.ActiveQuestionNumber >= Quiz.QuestionsNumber)
            {
                SelectedIndex++;
            }
        }

        #endregion

        #region properties
        private string _nextQuestionButtonCaption = "Next";
        public string NextQuestionButtonCaption
        {
            get { return _nextQuestionButtonCaption; }
            set { SetProperty(ref _nextQuestionButtonCaption, value); }
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

        #endregion

        public QuizDialogViewModel()
        {

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
        }

        #endregion
    }
}
