using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizWindowViewModel : BindableBase
    {
        private string _title = "Quiz :)";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public QuizWindowViewModel()
        {

        }
    }
}
