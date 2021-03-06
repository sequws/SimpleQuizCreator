using SimpleQuizCreator.Common;
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
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(0, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_OneGoodZeroBad_AllGoodSelected()
        {
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(3, score.PointScore);            
            Assert.Equal(100, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_OneGoodZeroBad_AllGoodAnswerWithOneBad()
        {
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected_OneBad();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(2, score.PointScore);
            Assert.Equal(66.67, score.PercentScore, 1);
        }

        #endregion

        #region OneGoodOneBad

        [Fact]
        public void CalculateResult_OneGoodOneBad_NoSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBad,
            };

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(0, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_OneGoodOneBad_AllGoodSelected()
        {
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBad,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(3, score.PointScore);
            Assert.Equal(100, score.PercentScore, 1);
        }


        [Fact]
        public void CalculateResult_OneGoodOneBad_AllGoodAnswerWithOneBad()
        {
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBad,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected_OneBad();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(1, score.PointScore);
            Assert.Equal(33.33, score.PercentScore, 1);
        }


        [Fact]
        public void CalculateResult_OneGoodOneBad_TwoBadSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
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
            Assert.Equal(-2, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }

        #endregion

        #region OneGoodOneBadOneNo

        [Fact]
        public void CalculateResult_OneGoodOneBadOneNo_NoSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBadOneNo,
            };

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(-3, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_OneGoodOneBadOneNo_AllGoodSelected()
        {
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBadOneNo,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(3, score.PointScore);
            Assert.Equal(100, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_OneGoodOneBadOneNo_AllGoodAnswerWithOneBad()
        {
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBadOneNo,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected_OneBad();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(1, score.PointScore);
            Assert.Equal(33.33, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_OneGoodOneBadOneNo_TwoBadSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodOneBadOneNo,
            };

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.Questions[0].Answers[1].IsSelected = true;
            quiz.Questions[1].Answers[0].IsSelected = true;
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(-3, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }

        #endregion

        #region AllGoodWithoutMinus

        [Fact]
        public void CalculateResult_AllGoodWithoutMinus_NoSelected()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.AllGoodWithoutMinus,
            };

            var quiz = FakeQuizGeneratedFactory.Clear_NoSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(0, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_AllGoodWithoutMinus_AllGoodSelected()
        {
            QuizSettings settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.AllGoodWithoutMinus,
            };

            var quiz = FakeQuizGeneratedFactory.AllGoodAnswersSelected();
            quiz.QuizSettings = settings;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(3, score.AllGoodAnswers);
            Assert.Equal(3, score.PointScore);
            Assert.Equal(100, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_MultiAnswer_AllGoodSelected()
        {
            var quiz = FakeQuizGeneratedFactory.GenerateClearQuiz(5,4,2,true);
            quiz.QuizSettings.ScoreType = ScoreType.AllGoodWithoutMinus;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(10, score.AllGoodAnswers);
            Assert.Equal(5, score.QuestionAmount);
            Assert.Equal(5, score.PointScore);
            Assert.Equal(100, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_MultiAnswer_NoneSelected()
        {
            var quiz = FakeQuizGeneratedFactory.GenerateClearQuiz(5, 4, 2);
            quiz.QuizSettings.ScoreType = ScoreType.AllGoodWithoutMinus;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(10, score.AllGoodAnswers);
            Assert.Equal(0, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }


        [Fact]
        public void CalculateResult_MultiAnswer_3correct2incomplete()
        {
            var quiz = FakeQuizGeneratedFactory.GenerateClearQuiz(5, 4, 2,true);
            quiz.QuizSettings.ScoreType = ScoreType.AllGoodWithoutMinus;

            quiz.Questions[3].Answers[1].IsSelected = false;
            quiz.Questions[4].Answers[1].IsSelected = false;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(10, score.AllGoodAnswers);
            Assert.Equal(5, score.QuestionAmount);
            Assert.Equal(3, score.PointScore);
            Assert.Equal(60, score.PercentScore, 1);
        }

        #endregion

        #region AllGoodWithMinus

        [Fact]
        public void CalculateResult_AllGoodWithMinus_NoneSelected()
        {
            var quiz = FakeQuizGeneratedFactory.GenerateClearQuiz(5, 4, 2);
            quiz.QuizSettings.ScoreType = ScoreType.AllGoodWithMinus;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(10, score.AllGoodAnswers);
            Assert.Equal(-5, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_AllGoodWithMinus_AllGoodSelected()
        {
            var quiz = FakeQuizGeneratedFactory.GenerateClearQuiz(5, 4, 2,true);
            quiz.QuizSettings.ScoreType = ScoreType.AllGoodWithMinus;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(10, score.AllGoodAnswers);
            Assert.Equal(5, score.PointScore);
            Assert.Equal(100, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_AllGoodWithMinus_3correct2incomplete()
        {
            var quiz = FakeQuizGeneratedFactory.GenerateClearQuiz(5, 4, 2, true);
            quiz.QuizSettings.ScoreType = ScoreType.AllGoodWithMinus;

            quiz.Questions[3].Answers[1].IsSelected = false;
            quiz.Questions[4].Answers[1].IsSelected = false;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(10, score.AllGoodAnswers);
            Assert.Equal(5, score.QuestionAmount);
            Assert.Equal(1, score.PointScore);
            Assert.Equal(20, score.PercentScore, 1);
        }

        [Fact]
        public void CalculateResult_AllGoodWithMinus_2correct2incomplete1mistake()
        {
            var quiz = FakeQuizGeneratedFactory.GenerateClearQuiz(5, 4, 2, true);
            quiz.QuizSettings.ScoreType = ScoreType.AllGoodWithMinus;

            quiz.Questions[2].Answers[1].IsSelected = false;
            quiz.Questions[3].Answers[1].IsSelected = false;
            quiz.Questions[4].Answers[0].IsSelected = false;
            quiz.Questions[4].Answers[1].IsSelected = false;            
            quiz.Questions[4].Answers[2].IsSelected = true;

            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            Assert.Equal(10, score.AllGoodAnswers);
            Assert.Equal(-1, score.PointScore);
            Assert.Equal(0, score.PercentScore, 1);
        }



        #endregion
    }
}
