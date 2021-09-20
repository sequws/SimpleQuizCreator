using SimpleQuizCreator.Common;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
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
        public void CalculateResult_AllGoodAnswer()
        {
            // Arrange
            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ScoreType = ScoreType.OneGoodZeroBad,
            };

            QuizGenerated quiz = new QuizGenerated
            {
                Name = "QuizGenerated",
                QuizSettings = settings,
                Questions = new List<Question>()
                {
                    new Question { QuestionText = "Question 1", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1 - good", IsCorrect = true, IsSelected = true },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                    new Question { QuestionText = "Question 2", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2 - good", IsCorrect = true, IsSelected = true },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                    new Question { QuestionText = "Question 3", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3 - good", IsCorrect = true, IsSelected = true },
                    }},
                }
            };

            // Act
            IScoreCalculator scoreCalculator = new ScoreCalculator();
            var score = scoreCalculator.CalculateResult(quiz);

            // Assert - green
            //Assert.Throws<NotImplementedException>(() => scoreCalculator.CalculateResult(quiz));
            Assert.Equal(3, score.AllGoodAnswers);
        }
    }
}
