using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SimpleQuizCreator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace SimpleQuizCreator.ViewModels
{
    public class ScoreTypeDialogViewModel : BindableBase, IDialogAware
    {
        private readonly ResourceManager rm = new ResourceManager(typeof(Properties.Resources));

        public ScoreType SingleSimple { get; } = ScoreType.OneGoodZeroBad;
        public ScoreType SingleMedium { get; } = ScoreType.OneGoodOneBad;
        public ScoreType SingleHard { get; } = ScoreType.OneGoodOneBadOneNo;
        public ScoreType MultiSimple { get; } = ScoreType.AllGoodWithoutMinus;
        public ScoreType MultiHard { get; } = ScoreType.AllGoodWithMinus;

        public ScoreTypeDialogViewModel()
        {
            Title = rm.GetString("ScoreTypeDialogTitle");
       }

        #region commands
        private DelegateCommand _closeDialogCommand;
        public DelegateCommand CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand(ExecuteCloseDialogCommand));

        void ExecuteCloseDialogCommand()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }
        #endregion

        #region IDailogAware
        public string Title { get; }

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
    }
}
