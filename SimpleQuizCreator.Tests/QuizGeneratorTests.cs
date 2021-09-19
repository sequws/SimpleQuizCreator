﻿using SimpleQuizCreator.DataAccess;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using SimpleQuizCreator.Tests.FakeData;
using System.Linq;
using Xunit;

namespace SimpleQuizCreator.Tests
{
    public class QuizGeneratorTests
    {
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
        }

        [Fact]
        public void GenerateNewQuiz_ConstAnswer()
        {
            // Arrange
            IQuizGenerator _quizGenerator = new QuizGenerator();
            Quiz quiz = FakeQuizFactory.NewQuiz3questions3asnwers();
            settings = new QuizSettings { QuestionLimit = 3, AutogenerateAnswers = 4 };

            // Act
            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            // Assert
            Assert.True(res.Questions.Count == 3);            
        }

        [Fact]
        public void GenerateNewQuiz_VariableAnswerNumber()
        {
            IQuizGenerator _quizGenerator = new QuizGenerator();
            Quiz quiz = FakeQuizFactory.NewQuiz5questionsRandomAsnwers();
            settings = new QuizSettings { QuestionLimit = 3, AutogenerateAnswers = 4 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            var quest5answers = res.Questions.Where(x => x.QuestionText == "Question 5").FirstOrDefault().GoodAnswersCount;

            Assert.True(res.Questions.Count == 5);
            Assert.Equal(4, quest5answers);
        }


        [Fact]
        public void GenerateNewQuiz_BigQuizTest()
        {
            IQuizGenerator _quizGenerator = new QuizGenerator();
            Quiz quiz = FakeQuizFactory.NewBigSimpleAutogeneratedQuiz(20,4);
            settings = new QuizSettings { QuestionLimit = 10, AutogenerateAnswers = 4 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            Assert.True(res.Questions.Count == 10);
        }
    }
}
