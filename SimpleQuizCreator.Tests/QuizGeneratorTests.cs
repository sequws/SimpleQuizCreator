using SimpleQuizCreator.DataAccess;
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
    public class QuizGeneratorTests
    {
        private Quiz quiz;
        private QuizSettings settings;

        public QuizGeneratorTests()
        {
            settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                ShowScore = false
            };

            quiz = new Quiz
            {
                Errors = new List<string>(),
                Name = "QuizTest",
                Questions = new List<Question>()
                {
                    new Question { QuestionText = "Question 1", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1 - good", IsCorrect = true },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                                        new Question { QuestionText = "Question 2", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2 - good", IsCorrect = true },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                                                            new Question { QuestionText = "Question 3", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3 - good", IsCorrect = true },
                    }},
                }
            };
        }

        [Fact]
        public void GenerateNewQuiz_FakeData()
        {
            // Arrange
            IQuizGenerator _quizGenerator = new QuizGenerator();
            List<string> fakeFile = new List<string>();

            // Act
            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            // Assert
            Assert.True(res.Questions.Count == 3);
            //Assert.Equal(1, ((ErrorCollector)_quizParser).ErrorCounter);
        }
    }
}
