using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizPreviewDialogViewModel : BindableBase, IDialogAware
    {
        public QuizPreviewDialogViewModel()
        {

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
