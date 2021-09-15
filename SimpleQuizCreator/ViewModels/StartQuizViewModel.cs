using Prism.Commands;
using Prism.Mvvm;
using SimpleQuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class StartQuizViewModel : BindableBase
    {
        IWindowView _windowView;

        private DelegateCommand _openQuizWindow;
        public DelegateCommand OpenQuizWindow =>
            _openQuizWindow ?? (_openQuizWindow = new DelegateCommand(ExecuteOpenQuizWindow, CanExecuteOpenQuizWindow));

        public StartQuizViewModel(IWindowView windowView)
        {
            _windowView = windowView;
        }

        void ExecuteOpenQuizWindow()
        {
            _windowView.Open();
        }

        bool CanExecuteOpenQuizWindow()
        {
            return true;
        }
    }
}
