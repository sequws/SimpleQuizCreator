using SimpleQuizCreator.Common;
using SimpleQuizCreator.Helpers;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using SimpleQuizCreator.Tests.FakeData;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimpleQuizCreator.Tests
{
    public class QuizGeneratorTests
    {
        private QuizSettings settings;
        IQuizGenerator _quizGenerator;

        public QuizGeneratorTests()
        {
            _quizGenerator = new QuizGenerator();

            settings = new QuizSettings
            {
                IsReturnAllowed = false,
                AutogenerateAnswers = 4,
                QuestionLimit = 3,
                IsScoreShown = false
            };
        }

        [Fact]
        public void CollectionHelper_ShuffleInPlaceList()
        {
            // Arrange
            var listOfQuestion = new List<int>() { 0, 1, 2, 3, 4, 5 };
            
            var shuffleList = listOfQuestion.ShuffleList();
            var areListEqual = listOfQuestion.SequenceEqualsIgnoreOrder(shuffleList);

            // Assert
            Assert.True(areListEqual);
            Assert.Equal(listOfQuestion.Count, shuffleList.Count);
        }


        [Fact]
        public void GenerateNewQuiz_ConstAnswer()
        {
            // Arrange
            Quiz quiz = FakeQuizFactory.NewQuiz3questions3asnwers();
            settings = new QuizSettings { QuestionLimit = 3, AutogenerateAnswers = 4 };

            // Act
            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            // Assert
            Assert.True(res.Questions.Count == 3);
        }

        [Fact]
        public void GenerateNewQuiz_CheckDeepCopy()
        {
            Quiz quiz = FakeQuizFactory.NewQuiz3questions3asnwers();
            settings = new QuizSettings { QuestionLimit = 3, AutogenerateAnswers = 4 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            var quest1ans1 = quiz.Questions[0].Answers[0].AnswerText;
            var resQuest1 = res.Questions.Where(x => x.QuestionText == quiz.Questions[0].QuestionText).FirstOrDefault();
            var resQuest1ans1 = resQuest1.Answers.Where(x => x.AnswerText == quest1ans1).FirstOrDefault().AnswerText;                       
            
            string pattern = "XXXXX";
            quiz.Questions[0].Answers[0].AnswerText = pattern;
            var asnswerExists = res.Questions.SelectMany(x => x.Answers).Where(y => y.AnswerText.Equals(pattern)).Count();

            Assert.Equal(quest1ans1, resQuest1ans1);
            Assert.Equal(0, asnswerExists);
            Assert.True(res.Questions.Count == 3);
        }

        [Fact]
        public void GenerateNewQuiz_VariableAnswerNumber()
        {
            Quiz quiz = FakeQuizFactory.NewQuiz5questionsRandomAsnwers();
            settings = new QuizSettings { QuestionLimit = 5, AutogenerateAnswers = 4 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            var quest5answers = res.Questions.Where(x => x.QuestionText == "Question 5").FirstOrDefault().GoodAnswersCount;

            Assert.Equal(5, res.Questions.Count);
            Assert.Equal(4, quest5answers);
        }

        [Fact]
        public void GenerateNewQuiz_BigQuizTest()
        {
            Quiz quiz = FakeQuizFactory.NewBigSimpleAutogeneratedQuiz(20,4);
            settings = new QuizSettings { QuestionLimit = 10, AutogenerateAnswers = 4 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();

            Assert.True(res.Questions.Count == 10);
        }

        [Fact]
        public void GenerateNewQuiz_AutogenerateAnswers()
        {
            Quiz quiz = FakeQuizFactory.NewQuizWithOnlyOneAnswers();
            settings = new QuizSettings { QuestionLimit = 3, AutogenerateAnswers = 4 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();
            var allAnswer = res.Questions.Where(x => x.AnswersCount == 3).ToList();

            // All question must have same amount autogenerated answers, max - min(9,QuestionLimit)! 
            Assert.True(res.Questions.Count == 3);
            Assert.Equal(3, allAnswer.Count);
        }


        /// <summary>
        /// Should generate 5 question with 3answers each - only 3 different answers exists!
        /// </summary>
        [Fact]
        public void GenerateNewQuiz_AutogenerateSameSameAnswersIn3Questions()
        {
            Quiz quiz = FakeQuizFactory.NewQuizWithSameAnswersIn3Questions();
            settings = new QuizSettings { QuestionLimit = 5, AutogenerateAnswers = 5 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();
            var questionsWith3ans = res.Questions.Where(x => x.AnswersCount == 3).ToList();

            Assert.True(res.Questions.Count == 5);
            Assert.Equal(5, questionsWith3ans.Count);
        }

        /// <summary>
        /// Should generate 3 question with 1 answer each - all questions have the same answer
        /// </summary>
        [Fact]
        public void GenerateNewQuiz_AutogenerateSameAnswersForEachQuestion()
        {
            Quiz quiz = FakeQuizFactory.NewQuizWithSameAnswerInAllQuestions();
            settings = new QuizSettings { QuestionLimit = 5, AutogenerateAnswers = 5 };

            _quizGenerator.GenerateNewQuiz(quiz, settings);
            var res = _quizGenerator.GetQuiz();
            var questionsWith1ans = res.Questions.Where(x => x.AnswersCount == 1).ToList();

            Assert.True(res.Questions.Count == 3);
            Assert.Equal(3, questionsWith1ans.Count);
        }
    }
}
