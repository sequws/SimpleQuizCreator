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
        //public int QuestionLimit { get; set; } = 30;
        private int _QuestionLimit = 30;
        public int QuestionLimit
        {
            get { return _QuestionLimit; }
            set { SetProperty(ref _QuestionLimit, value); }
        }

        public byte AutogenerateAnswers { get; set; } = 4;
    }
}
