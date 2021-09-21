using Prism.Mvvm;
using SimpleQuizCreator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class QuizSettings : BindableBase
    {
        public bool TimeRescriction { get; set; } = false;
        public bool AllowReturn { get; set; } = false;
        // Scoring
        public QuizType Type { get; set; } = QuizType.SingleChoice;
        public ScoreType ScoreType { get; set; } = ScoreType.OneGoodZeroBad;

        // Visibility
        public bool ShowTime { get; set; } = false;
        public bool ShowScore { get; set; } = false;

        // Questions
        private int _questionLimit = 30;
        public int QuestionLimit
        {
            get { return _questionLimit; }
            set { SetProperty(ref _questionLimit, value); }
        }

        public byte AutogenerateAnswers { get; set; } = 4;
    }
}
