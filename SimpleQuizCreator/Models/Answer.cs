using Prism.Mvvm;
using System.Linq;

namespace SimpleQuizCreator.Models
{
    public class Answer : BindableBase
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }

        public override string ToString()
        {
            return $"{(IsCorrect ? "[*]" : "")} - {AnswerText}...";
        }
    }
}