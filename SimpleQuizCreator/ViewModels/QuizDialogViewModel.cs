﻿using Prism.Commands;
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
        private DelegateCommand _closeDialogCommand;
        public DelegateCommand CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand(ExecuteCloseDialogCommand));

        void ExecuteCloseDialogCommand()
        {
            var resParams = new DialogParameters();
            resParams.Add("score", 88.2);

            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, resParams));
        }

        public QuizDialogViewModel()
        {

        }

        public string Title => "Quiz Dialog";

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
            Quiz quiz = parameters.GetValue<Quiz>("quiz");
            var title = quiz.Name;
        }
    }
}