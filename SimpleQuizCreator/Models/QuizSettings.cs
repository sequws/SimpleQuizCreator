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
        public bool IsTimeRestricted { get; set; } = false;
        public bool IsReturnAllowed { get; set; } = false;
        // Visibility
        public bool IsTimeShown { get; set; } = false;
        public bool IsScoreShown { get; set; } = false;
        // Scoring
        public QuizType Type { get; set; } = QuizType.SingleChoice;
        public ScoreType ScoreType { get; set; } = ScoreType.OneGoodZeroBad;

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
