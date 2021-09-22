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
        #region OneGoodZeroBad
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

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(0, score.PointsScore);
        }

        [Fact]
        public void CalculateResult_OneGoodZeroBad_AllGoodSelected()
        {
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected();
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

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected_OneBad();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(2, score.PointsScore);
        }

        #endregion

        #region

        [Fact]
        public void CalculateResult_OneGoodOneBad_NoSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBad,
            };

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(0, score.PointsScore);
        }

        [Fact]
        public void CalculateResult_OneGoodOneBad_AllGoodSelected()
        {
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBad,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(3, score.PointsScore);
        }


        [Fact]
        public void CalculateResult_OneGoodOneBad_AllGoodAnswerWithOneBad()
        {
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBad,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected_OneBad();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(1, score.PointsScore);
        }


        [Fact]
        public void CalculateResult_OneGoodOneBad_TwoBadSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBad,
            };

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.Questions[0].Answers[1].IsSelected = true;
            quiz.Questions[1].Answers[0].IsSelected = true;
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(-2, score.PointsScore);
        }

        #endregion
    }
}
