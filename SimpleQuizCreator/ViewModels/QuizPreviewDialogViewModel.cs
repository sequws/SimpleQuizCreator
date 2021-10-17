using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizPreviewDialogViewModel : BindableBase, IDialogAware
    {
        IQuizPreviewGenerator _quizPreviewGenerator;

        private Quiz _quiz;
        public Quiz Quiz
        {
            get { return _quiz; }
            set { SetProperty(ref _quiz, value); }
        }

        private QuizGenerated _quizGenerated;
        public QuizGenerated QuizGenerated
        {
            get { return _quizGenerated; }
            set { SetProperty(ref _quizGenerated, value); }
        }

        private string _previewTitle;
        public string PreviewTitle
        {
            get { return _previewTitle; }
            set { SetProperty(ref _previewTitle, value); }
        }

        private string _previewSubtitle;
        public string PreviewSubTitle
        {
            get { return _previewSubtitle; }
            set { SetProperty(ref _previewSubtitle, value); }
        }

        private string _previewText;
        public string PreviewText
        {
            get { return _previewText; }
            set { SetProperty(ref _previewText, value); }
        }

        public QuizPreviewDialogViewModel(IQuizPreviewGenerator quizPreviewGenerator)
        {
            _quizPreviewGenerator = quizPreviewGenerator;
        }

        #region IDialogAware
        public string Title => "Quiz preview";

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
            QuizGenerated = parameters.GetValue<QuizGenerated>("quizGenerated");
            if(QuizGenerated != null)
            {
                PreviewTitle = "Preview: " + QuizGenerated.Name; //"Preview!";
                PreviewText = _quizPreviewGenerator.GenerateResultPreview(QuizGenerated);
            }

            Quiz = parameters.GetValue<Quiz>("quiz");
            if (Quiz != null)
            {
                PreviewTitle = Quiz.Name;

                if (Quiz.CorrectlyLoaded)
                {
                    PreviewSubTitle = $"[[Question amount: { Quiz.QuestionAmount}]]";
                }
                else
                {
                    PreviewSubTitle = $"[[Error amount: { Quiz.Errors.Count}]]";
                }
                PreviewText = _quizPreviewGenerator.GeneratePreview(Quiz);
            }
        }
        #endregion

        #region commands
        private DelegateCommand _closeDialogCommand;
        public DelegateCommand CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand(ExecuteCloseDialogCommand));

        void ExecuteCloseDialogCommand()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }
        #endregion
    }
}
