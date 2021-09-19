using SimpleQuizCreator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class ScoreResult
    {
        public ScoreType Type { get; set; }
        public int AllGoodAnswers { get; set; }
        public int QuestionAmount { get; set; }
        public int AllPosiblePoints { get; set; }
        public int PointsScore { get; set; }
        public double PercentScore { get; set; }
    }
}
