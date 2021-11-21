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

        private ScoreType type;
        public ScoreType Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        public ScoreTypeDialogViewModel()
        {
            Title = "ScoreTypeDialogTitle";
            Type = ScoreType.AllGoodWithMinus;
        }



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
