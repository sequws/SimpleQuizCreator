﻿using SimpleQuizCreator.Common;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using SimpleQuizCreator.Tests.FakeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleQuizCreator.Tests
{
    public class ScoreCalculatorTests
    {
        [Fact]
        public void CalculateResult_OneGoodZeroBad_NoSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            var quiz = FakeQuizGeneratedFactory.GenerateClearWithAllGoodNoSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(0, score.PointsScore);
        }

        [Fact]
        public void CalculateResult_OneGoodZeroBad_AllGoodAnswer()
        {
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            var quiz = FakeQuizGeneratedFactory.GenerateAllGoodAnswersSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(3, score.PointsScore);            
        }

        [Fact]
        public void CalculateResult_OneGoodZeroBad_AllGoodAnswerWithOneBad()
        {
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            var quiz = FakeQuizGeneratedFactory.GenerateAllGoodAnswersSelectedWithOneBad();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(2, score.PointsScore);
        }
    }
}
