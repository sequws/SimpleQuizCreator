using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class AboutDialogViewModel : BindableBase, IDialogAware
    {
        public AboutDialogViewModel()
        {

        }

        public string Title => "About SimpleQuizDialog";

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

        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(ExecuteCloseCommand, CanExecuteCloseCommand));

        void ExecuteCloseCommand()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        bool CanExecuteCloseCommand()
        {
            return true;
        }
    }
}
