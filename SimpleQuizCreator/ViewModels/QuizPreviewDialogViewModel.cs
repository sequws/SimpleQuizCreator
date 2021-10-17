using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizPreviewDialogViewModel : BindableBase, IDialogAware
    {
        IQuizPreviewGenerator _quizPreviewGenerator;
        ResourceManager _resourceManager = new ResourceManager(typeof(Properties.Resources));

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
                PreviewTitle = string.Format(_resourceManager.GetString("QuizPreviewTitle"), QuizGenerated.Name);
                PreviewSubTitle = string.Format(_resourceManager.GetString("QuizPreviewSubTitle"), QuizGenerated.QuestionsNumber);
                PreviewText = _quizPreviewGenerator.GenerateResultPreview(QuizGenerated);
            }

            Quiz = parameters.GetValue<Quiz>("quiz");
            if (Quiz != null)
            {
                PreviewTitle = string.Format(_resourceManager.GetString("QuizPreviewTitle"), Quiz.Name);

                if (Quiz.CorrectlyLoaded)
                {
                    PreviewSubTitle = string.Format(_resourceManager.GetString("QuizPreviewSubTitle"), Quiz.QuestionAmount);
                }
                else
                {
                    PreviewSubTitle = string.Format(_resourceManager.GetString("QuizPreviewErrorSubTitle"), Quiz.Errors.Count);
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
