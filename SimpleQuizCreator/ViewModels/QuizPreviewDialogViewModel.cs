﻿using Prism.Commands;
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

        private string _quizName;
        public string QuizName
        {
            get { return _quizName; }
            set { SetProperty(ref _quizName, value); }
        }

        private string _quizQuesionAmount;
        public string QuizQuestionAmount
        {
            get { return _quizQuesionAmount; }
            set { SetProperty(ref _quizQuesionAmount, value); }
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
            Quiz = parameters.GetValue<Quiz>("quiz");
            QuizName = Quiz.Name;

            if( Quiz.CorrectlyLoaded)
            {
                QuizQuestionAmount = $"[[Question amount: { Quiz.QuestionAmount}]]";                
            }
            else
            {
                QuizQuestionAmount = $"[[Error amount: { Quiz.Errors.Count}]]";
            }
            PreviewText = _quizPreviewGenerator.GeneratePreview(Quiz);
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
