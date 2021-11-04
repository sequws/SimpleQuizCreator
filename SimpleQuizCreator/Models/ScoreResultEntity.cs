﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class ScoreResultEntity
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public int QuestionAmount { get; set; }
        public int AllPosiblePoints { get; set; }
        public int AllGoodAnswers { get; set; }
        public int PointScore { get; set; }
        public double PercentScore { get; set; }
        public int TimeInSeconds { get; set; }
        
    }
}
