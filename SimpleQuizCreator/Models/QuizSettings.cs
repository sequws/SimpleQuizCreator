using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public enum QuizType
    {
        SingleChoice,
        MultiChoice
    }

    public enum ScoreType
    {
        OneGoodZeroBad,         //  1pts for good answer, no minus points for bad answer
        OneGoodOneBad,          //  1pts for good answer, -1pts points for bad answer
        AllGoodWithoutMinus,    //  1pts for all good answers checked, zero otherwise
        AllGoodWithMinus,       //  1pts for all good answers checked, -1pts otherwise
        Custom                  //  
    }

    public class QuizSettings
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
        public byte QuestionLimit { get; set; } = 30;
        public byte AutogenerateAnswers { get; set; } = 4;
    }
}
