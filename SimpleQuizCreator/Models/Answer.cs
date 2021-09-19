﻿namespace SimpleQuizCreator.Models
{
    public class Answer
    {
        public bool IsCorrect { get; set; }
        public bool IsSelected { get; set; } = false;

        public string AnswerText { get; set; }
    }
}